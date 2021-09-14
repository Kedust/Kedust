using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;
using Kedust.Services;

namespace Kedust.UI.Cmd.Services
{
    public class CommandService
    {
        private readonly CmdTableService _cmdTableService;
        private readonly IPrintService _printService; 

        public CommandService(CmdTableService cmdTableService, IPrintService printService)
        {
            _cmdTableService = cmdTableService;
            _printService = printService;
        }


        public async void Start()
        {
            bool loop = true;
            while (loop)
            {
                string cmd = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(cmd))
                    continue;
                switch (cmd)
                {
                    case "print":
                        await _printService.PrintOrderTicket(new Order
                        {
                            OrderItems = new List<OrderItem>
                            {
                                new OrderItem
                                {
                                    Amount = 2,
                                    Choice = new Choice
                                    {
                                        Category = "Drinks",
                                        Description = "Cola",
                                        Name = "Coca cola",
                                        Price = 1.8m
                                    }
                                }
                            },
                            Table = new Table
                            {
                                Description = "42",
                                Code = "azerty"
                            },
                            TimeOrderPlaced = DateTime.Now
                        });
                        break;
                    case "exit":
                        loop = false;
                        break;
                    case var s when s.StartsWith("table"):
                        await _cmdTableService.Command(cmd.Substring("table".Length).TrimStart());
                        break;
                    case var s when s.StartsWith("menu"):
                        await _cmdTableService.Command(cmd.Substring("menu".Length).TrimStart());
                        break;
                }
            }
        }

        private static string ReadLine(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}