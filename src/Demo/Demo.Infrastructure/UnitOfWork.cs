using Demo.Domain;
using Demo.Domain.Repositories;
using Demo.Domain.Utilities;
using Demo.Infrastructure.Repositories;
using Demo.Infrastructure.Utilities;
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
        protected ISqlUtility SqlUtility { get; private set; }
        public UnitOfWork(DbContext dbContext)
        {
            _dbcontext = dbContext;
            SqlUtility = new SqlUtility(_dbcontext.Database.GetDbConnection());
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
