using System.ComponentModel.DataAnnotations;

namespace KlijentiVjezba.Models;

public class Klijent
{
    public int Id { get; set; }
    public string Naziv { get; set; }
    
    public string Email { get; set; }
    
    public string Grad { get; set; }
    
    public DateOnly DatumKreiranja { get; set; }
}