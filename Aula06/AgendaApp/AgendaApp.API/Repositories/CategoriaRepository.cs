using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;

namespace AgendaApp.API.Repositories
{
    public class CategoriaRepository
    {

        /// <summary>
        /// Método para consultar todas as categorias no banco de dados.
        /// </summary>
        public List<Categoria> ObterTodos()
        {
            using (var context = new DataContext())
            {
                /*
                 * SELECT * FROM CATEGORIA 
                 * ORDER BY NOME ASC
                 */
                return context
                        .Set<Categoria>()
                        .OrderBy(c => c.Nome)
                        .ToList();
            }
        }

        /// <summary>
        /// Verifica se uma categoria existe no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CategoriaExiste(Guid id)
        {
            using (var context = new DataContext())
            {
                /*
                 * SELECT * FROM CATEGORIA 
                 * WHERE ID = @id
                 */
                return context
                        .Set<Categoria>()
                        .Any(c => c.Id == id);
            }
        }
    }
}
