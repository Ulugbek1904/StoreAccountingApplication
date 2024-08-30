namespace StoreAccountingApplication.Services
{
    internal interface IFileService<T>
    {
        void WriteToFIle(T data);
        List<T> ReadFiles();
        void SaveAllToFile(List<T> data);
    }
}
