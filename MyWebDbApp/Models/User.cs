namespace ThesisDbApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public int ChairId { get; set; }
        public string? Chair { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Active { get; set; }
    }
}
