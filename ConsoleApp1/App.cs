using Microsoft.Extensions.Configuration;
using NBL.BPA.Data;
using NBL.BPA.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class App
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IProcessor _processor;

        public App(IRepository customerService, IProcessor processor, IConfiguration configuration)
        {
            _repository = customerService;
            _configuration = configuration;
            _processor = processor;
        }

        public void Run(string[] args)
        {
            // version settings
            var version = _configuration["Version"];
            Console.WriteLine("version " + version);

            // ApiSettings sections
            var apiSettings = _configuration.GetRequiredSection("ConnectionStrings").Get<ApiSettings>();
            Console.WriteLine("Key " + apiSettings.ConnectionStrings);
            Console.WriteLine("Value " + apiSettings.ConValue);

            _processor.LoadData(@"C:\Users\adiaby\source\class\");
            _processor.Process(new byte[0]);
           

            //Console.WriteLine("Hello, World!");
            //Processor processor = new Processor();
            //processor.LoadData(@"C:\Users\adiaby\source\class\");
        }
    }
}
