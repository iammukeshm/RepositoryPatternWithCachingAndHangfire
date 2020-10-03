using Core.Entity;
using Core.Enums;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DbSet<Customer> _customer;

        public CustomerRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {
            _customer = dbContext.Set<Customer>();
        }
    }
}
