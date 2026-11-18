using System.ComponentModel.DataAnnotations;

namespace KlijentiVjezba.DTOs;

public class KlijentDodajRequest
{
    [Required]
    public string Naziv { get; set; }
    [Required]
    public string Grad { get; set; }
    [Required]
    public string Email { get; set; }
}