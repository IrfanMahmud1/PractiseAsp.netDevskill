using Demo.Application;
using Demo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork,IApplicationUnitOfWork
    {
        public IBookRepository BookRepository { get; private set; }
        public IAuthorRepository AuthorRepository { get; private set; }
        public ApplicationUnitOfWork(ApplicationDbContext applicationDbContext,IBookRepository bookRepository,IAuthorRepository authorRepository) : base(applicationDbContext)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
        }
    }
}
