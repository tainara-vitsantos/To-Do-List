

namespace Aula01.Models.DTOs
{
    public class UsuarioCreateDto
    {
         [Required, MinLength(3), MaxLength(100)]
        public string Nome { get; set; } ="";

        [Required, EmailAddress]
        public string Email { get; set; } = "";
    }
}