using CrudSqlServerDapper.Entities;
using CrudSqlServerDapper.Repostiories;
using CrudSqlServerDapper.Validators;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSqlServerDapper.Controllers
{
    /// <summary>
    /// Classe de controler para realizar operações de gravação, edição,
    /// exclusão e consulta de cliente para o usuário do sistema
    /// </summary>
    public class ClienteController
    {

        public void Execute()
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE CLIENTES:\n");

            Console.WriteLine("(1) CADASTRAR CLIENTE");
            Console.WriteLine("(2) ATUALIZAR CLIENTE");
            Console.WriteLine("(3) EXCLUIR CLIENTE");
            Console.WriteLine("(4) PESQUISAR CLIENTES");

            Console.Write("\nINFORME A OPÇÃO DESEJADA...: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CreateClient();
                    break;

                case "2":
                    UpdateClient();
                    break;

                case "3":
                    DeleteClient();
                    break;

                case "4":
                    ReadClients();
                    break;

                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA!");
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR ? (S,N): ");
            var continuar = Console.ReadLine()?.ToUpper() ?? "N";

            if (continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear(); //limpa o console
                Execute(); //chama o método novamente para continuar o fluxo
            }
            else
            {
                Console.Clear(); //limpa o console
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }


        public void CreateClient()
        {
            try
            {
                Console.WriteLine("\nCadastro de Cliente:\n");

                var client = new Client();
                client.Id = Guid.NewGuid(); //gerando um novo id para o cliente

                Console.Write("Informe o nome..........................:");
                client.Name = Console.ReadLine() ?? string.Empty;

                Console.Write("Informe o e-mail........................:");
                client.Email = Console.ReadLine() ?? string.Empty;

                Console.Write("Informe a data de nascimento............:");
                if (Console.ReadLine().Equals(null) || Console.ReadLine().Equals(""))
                {
                    Console.Write("Data de nascimento inválida. Usando a data atual.");
                    client.BirthDate = DateTime.Now;
                }
                else
                {
                    client.BirthDate = DateTime.Parse(Console.ReadLine());
                }

                //Instanciando a classe de validação do cliente
                var validator = new ClientValidator();
                //Executar as validações no objeto e capturar o resultado
                var result = validator.Validate(client);

                //Verificar os dados do cliente passaram nas regras de validação
                if (result.IsValid)
                {
                    //Criando um objeto da classe de repositório
                    var clientRepository = new ClientRepository();
                    clientRepository.Insert(client); //gravando o cliente

                    Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nOCORRERAM ERROS DE VALIDAÇÃO!");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Erro: {error.ErrorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ReadClients()
        {
            try
            {
                var repo = new ClientRepository();
                var clients = repo.GetAll();

                Console.WriteLine("\nLISTA DE CLIENTES\n");
                foreach (var client in clients)
                {
                    Console.WriteLine($"Id............: {client.Id} " +
                                      $"\nName..........: {client.Name} " +
                                      $"\nEmail.........: {client.Email} " +
                                      $"\nBirthdate.....: {client.BirthDate.ToString("dd/MM/yyyy")} \n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateClient()
        {
            try
            {
                var client = new Client();

                Console.Write("Informe o Id..........................: ");                
                if (Console.ReadLine().Equals(null) || Console.ReadLine().Equals(""))
                {
                    throw new Exception();
                } else
                {
                    client.Id = Guid.Parse(Console.ReadLine() ?? string.Empty);
                }

                    Console.Write("Informe o nome..........................: ");
                client.Name = Console.ReadLine() ?? string.Empty;

                Console.Write("Informe o e-mail........................: ");
                client.Email = Console.ReadLine() ?? string.Empty;

                Console.Write("Informe a data de nascimento............: ");
                if (Console.ReadLine().Equals(null) || Console.ReadLine().Equals(""))
                {
                    Console.Write("Data de nascimento inválida. Usando a data atual.");
                    client.BirthDate = DateTime.Now;
                }
                else
                {
                    client.BirthDate = DateTime.Parse(Console.ReadLine());
                }

                var repo = new ClientRepository();
                repo.Update(client);

                Console.WriteLine("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteClient()
        {
            try
            {
                Console.Write("Informe o ID do cliente a ser excluído: ");
                var id = Console.ReadLine();

                if (string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var repo = new ClientRepository();
                repo.Delete(Guid.Parse(id));

                Console.WriteLine("Cliente excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
