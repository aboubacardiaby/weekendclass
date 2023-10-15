namespace NBL.BPA.DataLoader
{
    public interface IProcessor
    {
        public void LoadData(string path);
        public void Process();
    }
}
