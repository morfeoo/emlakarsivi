using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RemDijital.EmlakTakip.Configuration;
using RemDijital.EmlakTakip.Web;

namespace RemDijital.EmlakTakip.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class EmlakTakipDbContextFactory : IDesignTimeDbContextFactory<EmlakTakipDbContext>
    {
        public EmlakTakipDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EmlakTakipDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            EmlakTakipDbContextConfigurer.Configure(builder, configuration.GetConnectionString(EmlakTakipConsts.ConnectionStringName));

            return new EmlakTakipDbContext(builder.Options);
        }
    }
}
