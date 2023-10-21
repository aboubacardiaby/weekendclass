using NBL.BPA.Data;
using System.Data;

namespace NBL.BPA.DataLoader
{
    public class Processor : IProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IRepository _repository;
        public DataSet ds = new DataSet();
        string[] files = new string[0];
        public Processor(IRepository repository)
        {
            _repository = repository;
        }
        public void LoadData(string sourceFileLocation)
        {

            DirectoryInfo selectedDirectory = new DirectoryInfo(sourceFileLocation);


            if (!selectedDirectory.Exists)
            {

                return;
            }


            if (!Path.IsPathRooted(sourceFileLocation))
            {

                return;
            }



            if (Directory.Exists(sourceFileLocation))
            {
                files = Directory.GetFiles(sourceFileLocation, @"*.csv", SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {

                    string filename = Path.GetFileName(file);
                    _repository.AddLogger(new Domain.Entities.Logger()
                    {

                        FileStatus = Domain.Entities.FileStatus.Received.ToString(),
                        LogFileName = filename,
                        LogFilePath = file,
                        CreateDate = DateTime.Now,
                        CreatedBy = "worker"

                    });


                    if (File.Exists(file))
                    {
                        ds = CsvDataManagementUtilities.GetDatasetFromCSVFile(file);
                    }
                }
            }

        }
        public async void Process()
        {
            string path = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                await _repository.AddCustomer(new Domain.Entities.Customer()
                {
                    CustId = ds.Tables[0].Rows[i]["CustId"].ToString(),
                    Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                    City = ds.Tables[0].Rows[i]["City"].ToString(),
                    Email = ds.Tables[0].Rows[i]["Email"].ToString(),
                    FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString(),
                    LastName = ds.Tables[0].Rows[i]["LastName"].ToString(),
                    PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString(),
                    State = ds.Tables[0].Rows[i]["State"].ToString()



                });
                await _repository.Addloan(new Domain.Entities.Loan()
                {
                    LoanAmount = ds.Tables[0].Rows[i]["LoanAmount"].ToString(),
                    LoanName = ds.Tables[0].Rows[i]["LoanName"].ToString(),
                    LoanNumber = ds.Tables[0].Rows[i]["LoandNumber"].ToString(),
                    LoanType = ds.Tables[0].Rows[i]["LoanType"].ToString(),



                }, ds.Tables[0].Rows[i]["CustId"].ToString());

                path = ds.Tables[0].Rows[i]["path"].ToString();


            }

            await _repository.AddLogger(new Domain.Entities.Logger()
            {

                FileStatus = Domain.Entities.FileStatus.Processed.ToString(),
                LogFileName = Path.GetFileName(path),
                LogFilePath = path,
                ProcessEndDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreatedBy = "worker"

            });
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string archive = @"C:\project\archive\" + datetime + Path.GetFileName(path);

            File.Move(path, archive);

        }

    }
}
