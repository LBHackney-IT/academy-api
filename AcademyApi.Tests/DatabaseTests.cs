using AcademyApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;

namespace AcademyApi.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        // private IDbContextTransaction _transaction;
        protected AcademyContext AcademyContext { get; private set; }

        [SetUp]
        public void RunBeforeAnyTests()
        {
            // var builder = new DbContextOptionsBuilder();
            // builder.UseNpgsql(ConnectionString.TestDatabase());
            // AcademyContext = new AcademyContext(builder.Options);
            //
            // AcademyContext.Database.EnsureCreated();
            // _transaction = AcademyContext.Database.BeginTransaction();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            // _transaction.Rollback();
            // _transaction.Dispose();
        }
    }
}
