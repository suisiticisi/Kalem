using Kalem.Api.Application.Interfaces.Repositories;
using Kalem.Api.Domain.Models;
using Kalem.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(KalemContext dbContext) : base(dbContext)
        {
        }
    }
}
