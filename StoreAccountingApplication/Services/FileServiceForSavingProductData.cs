using StoreAccountingApplication.Models;
using System.Text.Json;

namespace StoreAccountingApplication.Services
{
    internal class FileServiceForSavingProductData : IFileService<Product>
    {
        public string path = "../../../ProductData.json";
        public FileServiceForSavingProductData()
        {
            EnsureFile();
        }
        public List<Product> ReadFiles()
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(json))
                    {
                        return new List<Product>();
                    }
                    return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
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

        public void SaveAllToFile(List<Product> data)
        {
            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true});
            using(StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(jsonData);
            }
        }

        public void WriteToFIle(Product type)
        {
            try
            {
                var products = ReadFiles();
                products.Add(type);
                var jsonMenegers = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true});
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.WriteLine(jsonMenegers);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error writing to the file", ex);
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
