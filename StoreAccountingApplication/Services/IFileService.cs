namespace StoreAccountingApplication.Services
{
    internal interface IFileService<T>
    {
        void WriteToFIle(T type);
        List<T> ReadFiles();
    }
}
