// using FluentAssertions;
// using HerMajesty.Context;
// using NSubstitute;
//
// using HerMajesty.Model;
// using HerMajestyTests.Mock;
//
// namespace HerMajestyTests;
//
// [TestFixture]
// public class HallTests
// {
//     private IHall _hall;
//     private readonly PostgresDbContext _mockedDbContext = Substitute.For<PostgresDbContext>();
//     
//     [SetUp]
//     public void SetUp()
//     {
//         _mockedDbContext.GenerateContenderList().Returns(
//             MockContenderListGenerator.GenerateAscendingList()
//         );
//         
//         _hall = new Hall(_mockedDbContext);
//     }
//     
//     [Test]
//     public void GetNextContender_ContendersListFilled_ReturnsContender()
//     {
//         _hall.FillContendersList();
//         _hall.GetNextContender().Should().NotBeNull();
//     }
//     
//     [Test]
//     public void GetNextContender_ContendersListNotFilled_ReturnsNull()
//     {
//         _hall.GetNextContender().Should().BeNull();
//     }
// }