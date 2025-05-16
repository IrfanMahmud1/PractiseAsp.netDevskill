using Demo.Domain;
using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author, Guid> , IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool IsNameDuplicate(string name, Guid? id = null)
        {
            if(id.HasValue)
                return GetCount(a => a.Id != id.Value && a.Name == name) > 0;
            else
                return GetCount(a => a.Name == name) > 0;
        }
        public (IList<Author> data, int total, int totalDisplay) GetPagedResult(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrEmpty(search.Value))
            {
                return GetDynamic(null, order,null, pageIndex, pageSize,true);
            }
            else
            {
                return GetDynamic(e =>e.Name.Contains(search.Value) || e.Biography.Contains(search.Value), order, null, pageIndex, pageSize, true);
            }
        }
    }
}
