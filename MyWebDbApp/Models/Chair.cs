namespace ThesisDbApp.Models;
public class Chair
{

        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Thesis>? Thesis { get; set; }

}
