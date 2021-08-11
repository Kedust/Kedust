﻿using System;
using System.Threading.Tasks;
using Kedust.Data.Dal;

namespace Kedust.UI.Cmd.Services
{
    public class CommandService
    {
        public Task StartAsync()
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "exit") break;
                string prefix = cmd.Contains(' ')? cmd.Substring(0, cmd.IndexOf(' ')): cmd;


                switch (prefix)
                {
                    case "init":
                        break;
                }
                
            }
            return Task.CompletedTask;
        }
    }
}