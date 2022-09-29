namespace Exercicio_1_Testes_Unitarios
{
    public class Candidate
    {
        public int Vote { get; set; }
        public string Name;

        public Candidate(string name)
        {
            Name = name;
            Vote = 0;
        }

        public int AddVote(Candidate candidate)
        {
            candidate.Vote++;
            return Vote;    
        }

        public object ReturnVotes(Candidate candidate)
        {
            return candidate.Vote;
        }
    }
}