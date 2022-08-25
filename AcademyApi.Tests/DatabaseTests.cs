using AcademyApi.V1.Infrastructure;
using Hackney.Core.Testing.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;

namespace AcademyApi.Tests
{
    [TestFixture]
    public class DatabaseTests : LogCallAspectFixture
    {
        // private IDbContextTransaction _transaction;
        protected AcademyContext AcademyContext { get; private set; }

        [SetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(ConnectionString.TestDatabase());
            AcademyContext = new AcademyContext(builder.Options);

            // AcademyContext.Database.EnsureCreated();
            // _transaction = AcademyContext.Database.ExecuteNonQuery();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            // _transaction.Rollback();
            // _transaction.Dispose();
        }
    }
}
