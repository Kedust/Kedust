using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kedust.Data.Dal;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Services.Implementation
{
    public class TableService : ITableService
    {
        private readonly IMapper _mapper;
        private readonly ITableRepo _tableRepo;
        
        public TableService(IMapper mapper, ITableRepo tableRepo)
        {
            _mapper = mapper;
            _tableRepo = tableRepo;
        }

        public async Task<IEnumerable<Menu.Table>> GetAll()
        {
            var data = _tableRepo.GetAll(tables => tables.Include(t => t.Menu)).ToList();
            return _mapper.Map<IEnumerable<Menu.Table>>(await _tableRepo.GetAll(tables => tables.Include(t => t.Menu)).ToListAsync());
        }

        public async Task<bool> Delete(int id)
        {
            var table = await _tableRepo.GetById(id);
            if (table == null) return false;
            var result = await _tableRepo.Delete(table);
            return result != null;
        }

        public async Task<Services.Menu.Table> GetById(int id)
        {
            var menu = await _tableRepo.GetById(id, tables => tables.Include(t => t.Menu));
            return _mapper.Map<Services.Menu.Table>(menu);
        }
    }
}