
using Aula01.Models.DTOs;

namespace Aula01.Models.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }

        public required string Titulo { get; set; }

        public string? Descricao { get; set; }

        public bool Concluida { get; set; }

        public DateTime CriadaEm { get; set; } = DateTime.UtcNow;

        public DateTime AtualizadaEm { get; set; }

        internal void ApplyUpdate(TarefaUpdate dto)
        {
            throw new NotImplementedException();
        }
    }
}
