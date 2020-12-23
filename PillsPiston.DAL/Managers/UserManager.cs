using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PillsPiston.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillsPiston.DAL.Managers
{
    public class UserManager : UserManager<User>
    {
        private AppDbContext dbContext;

        public UserManager(AppDbContext dbContext, IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> FindAsync(Func<User, bool> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null)
        {
            IQueryable<User> query = this.dbContext.Set<User>();
            if (include != null)
            {
                query = include(query);
            }

            List<User> tList = await query.ToListAsync();
            return tList.FirstOrDefault(e => predicate(e));
        }
    }
}
