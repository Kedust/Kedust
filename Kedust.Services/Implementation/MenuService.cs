using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;

namespace Kedust.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo _menuRepo;
        private readonly IChoiceRepo _choiceRepo;

        public MenuService(IChoiceRepo choiceRepo, IMenuRepo menuRepo)
        {
            _choiceRepo = choiceRepo;
            _menuRepo = menuRepo;
        }

        public async Task<int> Save(Menu menu, IEnumerable<Choice> choices)
        {
            bool isExistingMenu = menu.Id > 0;

            if (isExistingMenu)
            {
                await _menuRepo.Update(menu);

                var existingChoices = await _choiceRepo.GetByMenuId(menu.Id);
                var newChoices = choices.ToList();

                foreach (var removedChoice in
                    existingChoices.Where(ec => !newChoices.Select(x => x.Id).Contains(ec.Id)))
                {
                    await _choiceRepo.Delete(removedChoice);
                }

                foreach (var updateChoice in newChoices.Where(c => c.Id > 0))
                {
                    await _choiceRepo.Update(updateChoice);
                }

                foreach (var choice in newChoices.Where(c => c.Id == 0))
                {
                    choice.MenuId = menu.Id;
                    var data = await _choiceRepo.Insert(choice);
                    Console.Write(data);
                }

                return menu.Id;
            }
            else
            {
                var newMenu = await _menuRepo.Insert(menu);
                foreach (var choice in choices)
                {
                    choice.MenuId = newMenu.Id;
                    await _choiceRepo.Insert(choice);
                }

                return newMenu.Id;
            }
        }
    }
}