﻿using Microsoft.EntityFrameworkCore;

namespace Netatmo.Dashboard.Data
{
    public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<NetatmoDbContext>
    {
        protected override NetatmoDbContext CreateNewInstance(DbContextOptions<NetatmoDbContext> options)
        {
            return new NetatmoDbContext(options);
        }
    }
}
