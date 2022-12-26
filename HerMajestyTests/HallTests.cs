// using FluentAssertions;
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
//     private readonly IContenderListGenerator _mockedGenerator = Substitute.For<IContenderListGenerator>();
//     
//     [SetUp]
//     public void SetUp()
//     {
//         _mockedGenerator.GenerateContenderList().Returns(
//             MockContenderListGenerator.GenerateAscendingList()
//         );
//         
//         _hall = new Hall(_mockedGenerator);
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