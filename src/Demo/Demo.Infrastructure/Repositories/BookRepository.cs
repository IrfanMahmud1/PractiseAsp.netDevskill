using Demo.Domain.Entities;
using Demo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book,Guid>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Book> GetLatestBooks()
        {
            DateTime date = DateTime.Now.AddDays(-365);
            return _context.Books.Where(x => x.PublishDate < date).ToList();
        }
    }
}
