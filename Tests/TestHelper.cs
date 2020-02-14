using BHHC.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tests
{
    class TestHelper
    {
        /// <summary>
        /// Creates a new in-memory only database context for testing purposes
        /// </summary>
        /// <returns></returns>
        public static AppDbContext CreateInMemoryDb()
        {
            DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(dbContextOptions);
        }
    }
}
