using Microsoft.Extensions.Configuration;
using NBL.BPA.Data;
using NBL.BPA.DataLoader;

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

            _processor.LoadData(args[0]);
            _processor.Process();



        }
    }
}
