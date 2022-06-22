using Microsoft.EntityFrameworkCore;

namespace AcademyApi.V1.Infrastructure
{

    public class AcademyContext : DbContext
    {
        //TODO: rename DatabaseContext to reflect the data source it is representing. eg. MosaicContext.
        //Guidance on the context class can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/DatabaseContext
        public AcademyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CouncilTaxSearchResultDbEntity> CouncilTaxSearchResultDbEntities { get; set; }
    }
}
