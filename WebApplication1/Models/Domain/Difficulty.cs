namespace WebApplication1.Models.Domain
{
    public class Difficulty
    {
        public Guid Id { get; set; } //if get set not return then compiler error will be produced and it becomes a field not property
        public string Name { get; set; }
    }
}
