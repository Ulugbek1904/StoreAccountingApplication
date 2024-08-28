
using StoreAccountingApplication.Models;
using System.Text.Json;

namespace StoreAccountingApplication.Services
{
    public class FileServiceForMeneger : IFileService<Meneger>
    {
        public string path = "../../../MenegerFayl.json";
        public FileServiceForMeneger()
        {
            EnsureFile();
        }
        public List<Meneger> ReadFiles()
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(json))
                    {
                        return new List<Meneger>();
                    }
                    return JsonSerializer.Deserialize<List<Meneger>>(json) ?? new List<Meneger>();
                }
            }
            catch (JsonException jsonEx)
            {
                throw new ApplicationException("Error deserializing the JSON data", jsonEx);
            }
            catch (FileNotFoundException fileEx)
            {
                throw new ApplicationException("File not found", fileEx);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading the file.", ex);
            }
        }

        public void WriteToFIle(Meneger meneger)
        {
            try
            {
                var menegers = ReadFiles();
                menegers.Add(meneger);
                var jsonMenegers = JsonSerializer.Serialize(menegers);
                using (StreamWriter writer = new StreamWriter(path,false))
                {
                    writer.WriteLine(jsonMenegers);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error writing to the file",ex);
            }
        }
        private void EnsureFile()
        {
            
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
    }
}
