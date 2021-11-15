using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kedust.Data.Dal;
using Kedust.Services.DTO;
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

        public async Task<IEnumerable<Table>> GetAll()
        {
            var data = _tableRepo.GetAll(tables => tables.Include(t => t.Menu)).ToList();
            return _mapper.Map<IEnumerable<Table>>(await _tableRepo.GetAll(tables => tables.Include(t => t.Menu))
                .ToListAsync());
        }

        public async Task<Table> GetById(int id)
        {
            var menu = await _tableRepo.GetById(id, tables => tables.Include(t => t.Menu));
            return _mapper.Map<Table>(menu);
        }
        
        public async Task<Table> GetByCode(string code)
        {
            var menu = await _tableRepo.GetByCode(code, tables => tables.Include(t => t.Menu));
            return _mapper.Map<Table>(menu);
        }

        public async Task<int> Save(Table request)
        {
            var table = _mapper.Map<Data.Domain.Table>(request);
            bool isExistingTable = table.Id != 0;
            if (isExistingTable)
            {
                await _tableRepo.Update(table);
                return table.Id;
            }
            else
            {
                var newTable = await _tableRepo.Insert(table);
                return newTable.Id;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var table = await _tableRepo.GetById(id);
            if (table == null) return false;
            var result = await _tableRepo.Delete(table);
            return result != null;
        }
    }
}