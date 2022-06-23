using AcademyApi.V1.Domain;
using AcademyApi.V1.Factories;
using AcademyApi.V1.Infrastructure;
using AutoFixture;

namespace AcademyApi.Tests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static CouncilTaxSearchResultDbEntity CreateDatabaseEntity()
        {
            var entity = new Fixture().Create<SearchResult>();

            return CreateDatabaseEntityFrom(entity);
        }

        public static CouncilTaxSearchResultDbEntity CreateDatabaseEntityFrom(SearchResult searchResult)
        {
            return searchResult.ToDatabase();
        }
    }
}
