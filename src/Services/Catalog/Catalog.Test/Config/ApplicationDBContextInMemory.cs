using Catalog.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Test.Config
{
    public static class ApplicationDBContextInMemory
    {
        

        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                    .Options;

            return new ApplicationDbContext(options);        
        
        
            
        }


    }
}
