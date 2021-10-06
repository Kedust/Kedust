using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using Kedust.Data.Dal;
using Kedust.Services.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepo _menuRepo;
        private readonly IChoiceRepo _choiceRepo;

        public MenuService(IChoiceRepo choiceRepo, IMenuRepo menuRepo, IMapper mapper)
        {
            _choiceRepo = choiceRepo;
            _menuRepo = menuRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return _mapper.Map<IEnumerable<Menu>>(await _menuRepo.GetAll().ToListAsync());
        }

        public async Task<Menu> GetById(int id)
        {
            var menu = await _menuRepo.GetById(id, menus => menus.Include(m => m.Choices));
            return _mapper.Map<Menu>(menu);
        }

        public async Task<int> Save(Menu request)
        {
            var menu = _mapper.Map<Data.Domain.Menu>(request);
            bool isExistingMenu = menu.Id > 0;
            if (isExistingMenu)
            {
                //Delete record
                // var existingMenu = await _menuRepo.GetById(menu.Id, menus => menus.Include(m => m.Choices));
                // var deleted =
                //     existingMenu.Choices.Except(existingMenu.Choices.Where(c =>
                //         menu.Choices.Select(x => x.Id).Contains(c.Id)));
                // foreach (var choice in deleted) await _choiceRepo.Delete(choice);
                await _menuRepo.Update(menu);
                return menu.Id;
            }
            else
            {
                var newMenu = await _menuRepo.Insert(menu);
                return newMenu.Id;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var menu = await _menuRepo.GetById(id);
            if (menu == null) return false;
            var result = await _menuRepo.Delete(menu);
            return result != null;
        }

        public async Task<IEnumerable<DTO.Choice>> GetByTableCode(string tableCode)
        {
            tableCode = tableCode?.ToLower();
            return _mapper.Map<IEnumerable<DTO.Choice>>(await _choiceRepo.GetByTableCode(tableCode));
        }
    }
}