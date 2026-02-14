using System;

namespace Aula01.Models.DTOs
{
    public class TarefaResponse
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = "";

        public bool Concluida { get; set; }

        public string? Descricao { get; set; }

        public DateTime CriadaEm { get; set; }

        public DateTime AtualizadaEm { get; set; }
    }
}
