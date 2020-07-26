using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RemDijital.EmlakTakip.EntityFrameworkCore
{
    public static class EmlakTakipDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EmlakTakipDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EmlakTakipDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
