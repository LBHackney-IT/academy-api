using AcademyApi.V1.Domain;
using AcademyApi.V1.Infrastructure;
using AutoFixture;

namespace AcademyApi.Tests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static DatabaseEntity CreateDatabaseEntity()
        {
            var entity = new Fixture().Create<Entity>();

            return CreateDatabaseEntityFrom(entity);
        }

        public static DatabaseEntity CreateDatabaseEntityFrom(Entity entity)
        {
            return new DatabaseEntity
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
            };
        }
    }
}
