using DesignPatterns.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DesignPatternDbContext _context;
        private readonly IRepository<Beer> _beers;
        private readonly IRepository<Brand> _brands;
        
        public IRepository<Beer> Beers 
        { 
            get
            {
                return _beers == null ?
                    new Repository<Beer>(_context) :
                    _beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return _brands == null ?
                    new Repository<Brand>(_context) :
                    _brands;
            }
        }

        public UnitOfWork(DesignPatternDbContext context)
        {
            _context = context; 
        }

        public void SaveChanges()
        {
            _context.SaveChanges();     
        }
    }
}
