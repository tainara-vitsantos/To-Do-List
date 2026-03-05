

using System.ComponentModel.DataAnnotations;

namespace Aula01.Models.DTOs
{
    public class UsuarioResponseDto
    {
        
         public Guid Id { get; set; }

      
        public string  Nome { get; set; }

       
        public string  Email { get; set; }

        //Lista de tarefas convertidas para o DTO de resposta(evita lopp infinito)
        public List<TarefaResponse> Tarefas { get; set; } = [];

   
    }
}