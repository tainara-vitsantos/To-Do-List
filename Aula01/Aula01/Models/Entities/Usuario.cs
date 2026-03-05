
using System.ComponentModel.DataAnnotations;

namespace Aula01.Models.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O nome do usuario é obrigatorio")]
        public string  Nome { get; set; }

        [Required(ErrorMessage ="O Email do usuario é obrigatorio")]
        public string  Email { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

        

    }
}