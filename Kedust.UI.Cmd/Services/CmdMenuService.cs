using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;

namespace Kedust.UI.Cmd.Services
{
    public class CmdMenuService
    {
        public CmdMenuService()
        {
        }

        public async Task Command(string command)
        {
            switch (command)
            {
                case var s when s.StartsWith(""):
                    break;
            }
        } 
    }
}