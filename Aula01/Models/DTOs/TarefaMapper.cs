using Aula01.Models.Entities;

namespace Aula01.Models.DTOs
{
    public static class TarefaMapper
    {
        public static TarefaResponse ToResponse(this Tarefa t) => new()
        {
            Id = t.Id,
            Titulo = t.Titulo,
            Descricao = t.Descricao,
            Concluida = t.Concluida,
            //UsuarioId = t.UsuarioId
            CriadaEm = t.CriadaEm,
            AtualizadaEm = t.AtualizadaEm
        };

        public static void ApplyUpdate(this Tarefa entity, TarefaResponse dto)
        {
            entity.Titulo = dto.Titulo.Trim();
            entity.Descricao = dto.Descricao?.Trim();
            entity.Concluida = dto.Concluida;
            entity.AtualizadaEm = DateTime.UtcNow;
        }

        public static Tarefa ToEntity(this TarefaCreateDto dto) => new()
        {
        
            Titulo = dto.Titulo.Trim(),
            Descricao = dto.Descricao?.Trim(),
            Concluida = false,
            CriadaEm = DateTime.UtcNow,
            
        };
    }
}
