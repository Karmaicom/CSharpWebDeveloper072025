using Aula05_AtendenteVirtual.Entities;
using Aula05_AtendenteVirtual.Repositories;

namespace Aula05_AtendenteVirtual.Controllers
{
    public class AtendimentoController
    {

        public void RealizarAtendimento()
        {
            Console.WriteLine("\nNOVO ATENDIMENTO:\n");

            var atendimento = new Atendimento();

            Console.Write("Informe seu nome...........: ");
            atendimento.NomeUsuario = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite sua pergunta.......: ");
            atendimento.Pergunta = Console.ReadLine() ?? string.Empty;

            //Enviar a pergunta para a OpenAI (ChatGPT)
            var atendimentoService = new Services.AtendimentoService();
            atendimento.Resposta = atendimentoService.EnviarPagamento(atendimento.NomeUsuario, atendimento.Pergunta);

            //Gravar o atendimento no banco de dados
            var atendimentoRepository = new AtendimentoRepository();
            atendimentoRepository.Inserir(atendimento);

            //Imprimindo a resposta para o usuário
            Console.WriteLine("\nRESPOSTA:\n");
            Console.WriteLine(atendimento.Resposta);
        }

    }
}
