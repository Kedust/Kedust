using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;

namespace Kedust.UI.Cmd.Services
{
    public class CmdTableService
    {
        private readonly ITableRepo _tableRepo;
        
        public CmdTableService(ITableRepo tableRepo)
        {
            _tableRepo = tableRepo;
        }

        public async Task Command(string command)
        {
            switch (command)
            {
                case var s when string.IsNullOrWhiteSpace(s):
                    Console.WriteLine("get all");
                    Console.Write(string.Join("\n", _tableRepo.GetAll()));
                    break;
                case "create":
                    await _tableRepo.Insert(new Table
                    {
                        Code = input("Code"),
                        Description = input("Description")
                    });
                    break;
            }
        }

        private string input(string question)
        {
            Console.Write(question+"\t:");
            return Console.ReadLine();
        }
    }
}