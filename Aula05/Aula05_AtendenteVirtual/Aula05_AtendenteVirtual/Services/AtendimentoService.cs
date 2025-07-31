using OpenAI_API.Chat;

namespace Aula05_AtendenteVirtual.Services
{
    public class AtendimentoService
    {
        private readonly string _openAIApiKey;

        public AtendimentoService()
        {
            _openAIApiKey = new Settings.AppSettings().OpenAIApiKey;
        }

        /// <summary>
        /// Método para enviar uma pergunta para o ChatGPT
        /// </summary>
        /// <param name="nomeUsuario">Nome do usuário que está fazendo a pergunta</param>
        public string EnviarPagamento(string nomeUsuario, string pergunta)
        {
            // Criando o prompt para enviar ao OpenAI (treinamento do chat)
            var prompt = $"""
                    Você é um atendente de suporte de TI especializado em tirar dúvidas sobre hardware, 
                    software, configurações etc. Só responda perguntas que sejam sobre suporte técnico de TI,
                    qualquer pergunta fora desse contexto você não está qualificado para responder.                     
                    Faça um atendimento cordial e trate sempre o usuário pelo seu nome.

                    O nome do usuário que está fazendo a pergunta é {nomeUsuario}.

                    A pergunta é: {pergunta}.
                """;

            //Criando a requisição para o ChatGPT
            var chatRequest = new ChatRequest
            {
                Model = "gpt-4",    // modelo do ChatGPT
                MaxTokens = 500,    // número máximo de tokens(4 caracteres) na resposta
                Temperature = 0.8,  // de 0 a 1, onde 0 é menos criativo e 1 é mais criativo
            };

            //Configurando a chave de acesso
            var opanAI = new OpenAI_API.OpenAIAPI(new OpenAI_API.APIAuthentication(_openAIApiKey));

            //Configurando a mensagem que será enviada
            chatRequest.Messages = new List<ChatMessage>() { new ChatMessage(ChatMessageRole.User, prompt) };

            //Enviando a mensagem e obter a resposta
            var chat = opanAI.Chat.CreateChatCompletionAsync(chatRequest).Result;
            return chat.Choices.First().Message.TextContent;
        }

    }
}
