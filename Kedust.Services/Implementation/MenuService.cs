using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kedust.Data.Dal;
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

        public async Task<IEnumerable<Menu.Menu>> GetAll()
        {
            return _mapper.Map<IEnumerable<Menu.Menu>>(await _menuRepo.GetAll().ToListAsync());
        }

        public async Task<IEnumerable<Menu.Choice>> GetByTableCode(string tableCode)
        {
            return _mapper.Map<IEnumerable<Menu.Choice>>(await _choiceRepo.GetByTableCode(tableCode));
        }

        public async Task<bool> Delete(int id)
        {
            var menu = await _menuRepo.GetById(id);
            if (menu == null) return false;
            var result = await _menuRepo.Delete(menu);
            return result != null;
        }

        public async Task<Services.Menu.Menu> GetById(int id)
        {
            var menu = await _menuRepo.GetById(id, menus => menus.Include(m => m.Choices));
            return _mapper.Map<Services.Menu.Menu>(menu);
        }

        public async Task<int> Save(Services.Menu.Menu request)
        {
            var menu = _mapper.Map<Data.Domain.Menu>(request);
            bool isExistingMenu = menu.Id > 0;
            if (isExistingMenu)
            {
                await _menuRepo.Update(menu);
                return menu.Id;
            }
            else
            {
                var newMenu = await _menuRepo.Insert(menu);
                return newMenu.Id;
            }
        }
    }
}