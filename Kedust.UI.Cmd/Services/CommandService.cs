using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;

namespace Kedust.UI.Cmd.Services
{
    public class CommandService
    {
        private readonly IMenuItemRepo _menuItemRepo;
        private readonly ITableRepo _tableRepo;
        private readonly IMenuRepo _menuRepo;
        public CommandService(IMenuItemRepo menuItemRepo, ITableRepo tableRepo, IMenuRepo menuRepo)
        {
            _menuItemRepo = menuItemRepo;
            _tableRepo = tableRepo;
            _menuRepo = menuRepo;
        }
        
        
        public async void Start()
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "exit") break;
                string prefix = cmd.Contains(' ')? cmd.Substring(0, cmd.IndexOf(' ')): cmd;


                switch (prefix)
                {
                    case "Menu":
                        Console.WriteLine(string.Join("\n",(await _menuItemRepo.GetByTableCode("azerty")).Select(x => x.Name)));
                        break;
                    case "Create":

                        MenuItem item = await _menuItemRepo.Insert(new MenuItem
                        {
                            Category = "Drinks",
                            Description = null,
                            Name = "Spuitwater",
                            Price = 1.2m,
                            
                            
                        });

                        Menu menu = await _menuRepo.Insert(new Menu
                        {
                            MenuItems = new List<MenuItem> {item}
                        });

                        Table table = await _tableRepo.Insert(new Table
                        {
                            Code = "azerty",
                            Description = "23",
                            Menu = menu
                        });
                        
                        break;
                }
                
            }
        }
    }
}