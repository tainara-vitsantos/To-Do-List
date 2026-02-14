using System.ComponentModel.DataAnnotations;

namespace Aula01.Models.DTOs
{
    public class TarefaUpdate
    {
        [Required, MinLength(3), MaxLength(80)]
        public string Titulo { get; set; } = "";

        [MaxLength(200)]
        public string? Descricao { get; set; }

        public bool Concluida { get; set; }
    }
}
