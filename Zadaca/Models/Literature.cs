namespace Zadaca.Models;

public class Literature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ISBN { get; set; }

    public List<Author> Authors { get; set; } = new ();


}