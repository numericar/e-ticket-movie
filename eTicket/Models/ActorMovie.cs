namespace eTicket.Models
{
    public class ActorMovie
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        
        // Relationship
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}