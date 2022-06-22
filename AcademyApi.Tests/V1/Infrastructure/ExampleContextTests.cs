using System.Linq;
using AcademyApi.Tests.V1.Helper;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Infrastructure
{
    //TODO: Remove this file if Postgres is not being used
    [TestFixture]
    public class DatabaseContextTest : DatabaseTests
    {
        [Test]
        [Ignore("Ignore to test build")]
        public void CanGetADatabaseEntity()
        {
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntity();

            AcademyContext.Add(databaseEntity);
            AcademyContext.SaveChanges();

            var result = AcademyContext.CouncilTaxSearchResultDbEntities.ToList().FirstOrDefault();

            Assert.AreEqual(result, databaseEntity);
        }
    }
}
