// using FluentAssertions;
// using HerMajesty.Model;
//
// namespace HerMajestyTests;
//
// [TestFixture]
// public class PrincessTests
// {
//     /// Note: Princess's method `ChoosePrince()` does not have any tests since it completely matches
//     /// the `ChooseBestContender()` method in used IStrategy implementation
//
//     private const int ScoreGreaterThanHappinessBoundary = 100;   
//     private const int ScoreLessThanHappinessBoundary    = 10;
//
//     [Test]
//     public void CalculateHappinessPoints_ScoreGreaterThanHappinessBoundary_ReturnsPrinceScore()
//     {
//         Princess.CalculateHappinessPoints(ScoreGreaterThanHappinessBoundary)
//             .Should().Be(ScoreGreaterThanHappinessBoundary);
//     }
//     
//     [Test]
//     public void CalculateHappinessPoints_ScoreLessThanHappinessBoundary_ReturnsBadPrinceChosenScore()
//     {
//         Princess.CalculateHappinessPoints(ScoreLessThanHappinessBoundary)
//             .Should().Be(Princess.BadPrinceChosenScore);
//     }
//
//     [Test]
//     public void CalculateHappinessPoints_NoPrinceChosen_ReturnsNoPrinceChosenScore()
//     {
//         Princess.CalculateHappinessPoints(null)
//             .Should().Be(Princess.NoPrinceChosenScore);
//     }
// }