using Exercicio_1_Testes_Unitarios;
using FluentAssertions;

namespace Eleicoes.Tests
{
    public class CandidatoTest
    {
        [Theory]
        [InlineData("Jos�", 0)]
        [InlineData("Maria", 0)]
        public void QuantityOfVotes_ShouldBeZero_WhenRegisterCandidate(string name, int vote)
        {
            //Arrange
            Candidate candidate = new Candidate(name);

            //Act
            var result = candidate.Vote;

            //Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("Jos�")]
        public void QuantityOfVotes_IsRight_AfterAddVote(string name)
        {
            //Arrange
            Candidate candidate = new Candidate(name);

            //Act
            var result = candidate.AddVote(candidate);

            //Assert
            result.Should().Be(candidate.Vote);
        }

        [Theory]
        [InlineData("Jos�")]
        public void VerifyCandidateName_IsRight_AfterRegister(string name)
        {
            //Arrange
            Candidate candidate = new Candidate(name);

            //Act
            var result = candidate.Name;

            //Assert
            result.Should().MatchEquivalentOf(name);
        }
    }
}