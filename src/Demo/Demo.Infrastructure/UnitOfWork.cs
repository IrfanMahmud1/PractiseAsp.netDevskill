using Demo.Domain;
using Demo.Domain.Repositories;
using Demo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbcontext;
        public UnitOfWork(DbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
