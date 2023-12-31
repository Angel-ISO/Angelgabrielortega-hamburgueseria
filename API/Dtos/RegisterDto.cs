using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace API.Dtos;
public class RegisterDto
{
    [Required]
    public string  Email { get; set; }
    
    [Required]
    public string  Username { get; set; }

    [Required]
    public string  Password { get; set; }
        
}