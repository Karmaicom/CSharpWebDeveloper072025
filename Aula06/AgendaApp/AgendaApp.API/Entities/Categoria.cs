using System.Text.Json.Serialization;

namespace AgendaApp.API.Entities
{
    public class Categoria
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        // Para que não venha a lista de tarefas quando for serializado para JSON
        [JsonIgnore]
        public List<Tarefa> Tarefas { get; set; } = new();

    }
}
