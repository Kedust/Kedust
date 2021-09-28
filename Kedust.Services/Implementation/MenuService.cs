using System.Collections.Generic;
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

        public async Task<IEnumerable<DTO.Menu>> GetAll()
        {
            return _mapper.Map<IEnumerable<DTO.Menu>>(await _menuRepo.GetAll().ToListAsync());
        }

        public async Task<DTO.Menu> GetById(int id)
        {
            var menu = await _menuRepo.GetById(id, menus => menus.Include(m => m.Choices));
            return _mapper.Map<DTO.Menu>(menu);
        }

        public async Task<int> Save(DTO.Menu request)
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