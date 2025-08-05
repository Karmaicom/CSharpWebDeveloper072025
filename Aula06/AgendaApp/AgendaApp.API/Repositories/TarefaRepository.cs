using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Repositories
{
    public class TarefaRepository
    {
        /// <summary>
        /// Método para inserir uma nova tarefa no banco de dados.
        /// </summary>
        /// <param name="tarefa"></param>
        public void Inserir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Add(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar uma tarefa no banco de dados.
        /// </summary>
        /// <param name="tarefa"></param>
        public void Atualizar(Tarefa tarefa)
        {
            using(var context = new DataContext())
            {
                context.Update(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir uma tarefa no banco de dados.
        /// </summary>
        /// <param name="tarefa"></param>
        public void Excluir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Remove(tarefa);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Consulta tarefas por intervalo de datas.
        /// </summary>
        /// <param name="dataHotaInicio"></param>
        /// <param name="dataHoraFim"></param>
        /// <returns></returns>
        public List<Tarefa> ObterPorDatas(DateTime dataHotaInicio, DateTime dataHoraFim)
        {
            using (var context = new DataContext())
            {
                return context
                    .Set<Tarefa>()
                    .Include(x => x.Categoria)
                    .Where(x => x.DataHora >= dataHotaInicio && x.DataHora <= dataHoraFim)
                    .OrderByDescending(x => x.DataHora)
                    .ToList();
            }
        }

        /// <summary>
        /// Método para consultar 1 tarefa no banco de dados através do ID.
        /// </summary>
        public Tarefa? ObterPorId(Guid id)
        {
            using (var context = new DataContext())
            {
                return context
                        .Set<Tarefa>()
                        .Include(x => x.Categoria)
                        .SingleOrDefault(t => t.Id == id);
            }
        }
    }
}
