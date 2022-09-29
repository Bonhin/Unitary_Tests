using Exercicio_1_Testes_Unitarios;
using FluentAssertions;

namespace Eleicoes.Tests
{
    public class UrnTests
    {
        [Fact]
        public void VerifyConstructor_IsRight_WhenInvoke()
        {
            //Arrange
            Urn urn = new Urn();

            //Act
            var result = urn;

            //Assert
            result.WinnerElection.Should().BeEmpty();
            result.WinnerVotes.Should().Be(0);
            result.Candidates.Should().BeEmpty();
            result.ActiveElection.Should().BeFalse();
        }

        [Fact]
        public void VerifyStartEndElection_IsRight_WhenInvoke()
        {
            //Arrange
            Urn urn = new Urn();

            //Act
            var result = urn.ActiveElection;
            urn.StartEndElection();

            //Assert
            urn.ActiveElection.Should().NotBe(result);
        }

        [Theory]
        [InlineData("José")]
        [InlineData("Maria")]
        public void VerifyRegisterCandidate_IsTheLast_WhenInvoke(string name)
        {
            //Arrange
            Urn urn = new Urn();

            //Act
            urn.RegisterCandidate(name);

            //Assert
            urn.Candidates.Last().Name.Should().BeEquivalentTo(name);
        }

        [Theory]
        [InlineData("José")]
        public void VerifyVote_InValidVote_WhenInvoKe(string name)
        {
            //Arrange
            Urn urn = new Urn();
            urn.RegisterCandidate(name);

            //Act
            var result = urn.Vote("Maria");

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("José")]
        public void VerifyVote_ValidVote_WhenInvoKe(string name)
        {
            //Arrange
            Urn urn = new Urn();
            urn.RegisterCandidate(name);

            //Act
            var result = urn.Vote("José");

            //Assert
            result.Should().BeTrue();
        }

        //public string ShowElectionResult()
        //{
        //    var winner = Candidates.OrderBy(c => c.Vote).ThenBy(c => c.Name).FirstOrDefault();

        //    return $"Nome vencedor: {winner.Name}. Votos: {winner.Vote}";
        //}

        [Theory]
        [InlineData("José","Maria")]
        public void VerifyShowElectionResult_IsRight_WhenInvoke(string candidate1, string candidate2)
        {
            //Arrange
            Urn urn = new Urn();
            urn.RegisterCandidate(candidate1);
            urn.RegisterCandidate(candidate2);
            urn.Vote(candidate1);
            urn.Vote(candidate2);
            urn.Vote(candidate2);

            //Act
            var result = urn.ShowElectionResult();

            //Assert
            result.Should().BeEquivalentTo($"Nome vencedor: {urn.Candidates.OrderByDescending(c =>c.Vote).FirstOrDefault().Name}. Votos: {urn.Candidates.OrderByDescending(c=>c.Vote).FirstOrDefault().Vote}");


        }
    }
}