using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_1_Testes_Unitarios
{
    public class Urn
    {
        public string? WinnerElection { get; set; }
        public int WinnerVotes { get; set; }
        public List<Candidate>? Candidates { get; set; }
        public bool ActiveElection { get; set; }

        public Urn()
        {
            WinnerElection = "";
            WinnerVotes = 0;
            Candidates = new List<Candidate>();
            ActiveElection = false;
        }

        public void StartEndElection()
        {
            ActiveElection = !ActiveElection;
        }

        public bool RegisterCandidate(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Candidate candidate = new Candidate(name);
                Candidates.Add(candidate);
                return true;
            }

            return false;
        }

        public bool Vote(string nome)
        {
            var ChosenCandidate = Candidates.Where(c => c.Name.ToUpper() == nome.ToUpper()).FirstOrDefault();

            if (ChosenCandidate is not null)
            {
                ChosenCandidate.AddVote(ChosenCandidate);
                return true;
            }

            return false;
        }

        public string ShowElectionResult()
        {
            var winner = Candidates.OrderByDescending(c => c.Vote).ThenBy(c => c.Name).FirstOrDefault();

            return $"Nome vencedor: {winner.Name}. Votos: {winner.Vote}";
        }
    }
}
