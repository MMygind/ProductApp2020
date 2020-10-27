using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Infrastructure.SQLLite.Data
{
    public interface IDBInitializer
    {
        void SeedDB(ProductAppLiteContext ctx);
    }
}
