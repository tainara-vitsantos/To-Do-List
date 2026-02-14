using System.ComponentModel.DataAnnotations;

namespace Aula01.Models.DTOs
{
    public class TarefaCreateDto
    {
        [Required, MinLength(3), MaxLength(80)]
        public string Titulo { get; set; } = "";

        [MaxLength(100)]
        public string? Descricao { get; set; }
    }
}
