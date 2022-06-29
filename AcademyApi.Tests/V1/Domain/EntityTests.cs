// using System;
// using AcademyApi.V1.Domain;
// using FluentAssertions;
// using NUnit.Framework;
//
// namespace AcademyApi.Tests.V1.Domain
// {
//     [TestFixture]
//     public class EntityTests
//     {
//         [Test]
//         [Ignore("Not implemented")]
//         public void EntitiesHaveAnId()
//         {
//             var entity = new CouncilTaxSearchResult();
//             entity.Id.Should().BeGreaterOrEqualTo(0);
//         }
//
//         [Test]
//         public void EntitiesHaveACreatedAt()
//         {
//             var entity = new CouncilTaxSearchResult();
//             var date = new DateTime(2019, 02, 21);
//             entity.CreatedAt = date;
//
//             entity.CreatedAt.Should().BeSameDateAs(date);
//         }
//     }
// }
