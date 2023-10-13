using NBL.BPA.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NBL.BPA.DataLoader
{
    public class Processor : IProcessor
    {
        public readonly IRepository _repository;
        public DataSet ds = new DataSet();

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

            string[] files;

            if (Directory.Exists(sourceFileLocation))
            {
                files = Directory.GetFiles(sourceFileLocation, @"*.csv", SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    if (File.Exists(file))
                    {
                       ds =   CsvDataManagementUtilities.GetDatasetFromCSVFile(file);
                    }
                }
            }
            
        }
        public async void Process(byte[] data)
        {
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                await _repository.AddCustomer(new Domain.Entities.Customer()
                {
                    CustId = ds.Tables[0].Rows[i]["CustId"].ToString(),
                    Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                    City = ds.Tables[0].Rows[i]["City"].ToString(),
                   Email = ds.Tables[0].Rows[i]["Email"].ToString(),
                   FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString()   ,
                   LastName = ds.Tables[0].Rows[i]["LastName"].ToString(),
                   PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString(),
                   State = ds.Tables[0].Rows[i]["State"].ToString()
                   
                   

                });
                await _repository.Addloan(new Domain.Entities.Loan() {
                LoanAmount = ds.Tables[0].Rows[i]["LoanAmount"].ToString(),
                LoanName = ds.Tables[0].Rows[i]["LoanName"].ToString(),
                LoandNumber = ds.Tables[0].Rows[i]["LoandNumber"].ToString(),
                LoanType= ds.Tables[0].Rows[i]["LoanType"].ToString(),



                }, ds.Tables[0].Rows[i]["CustId"].ToString());
            }

        }
        public void Execute(string _sourceFileLocation)
        {
            DateTime start = DateTime.Now;

            DirectoryInfo selectedDirectory = new DirectoryInfo(_sourceFileLocation);

            if (!selectedDirectory.Exists)
            {

                return;
            }

            if (!Path.IsPathRooted(_sourceFileLocation))
            {

                return;
            }
        }
    }
}
