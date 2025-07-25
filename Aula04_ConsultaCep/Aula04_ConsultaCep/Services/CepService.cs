using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04_ConsultaCep.Services
{
    public class CepService
    {
        /// <summary>
        /// Método para consultar o CEP e retornar o endereço.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public string ObterEndereco(string cep)
        {
            using (var http = new HttpClient())
            {
                var result = http.GetAsync($"https://viacep.com.br/ws/{cep}/json").Result;
                return result.Content.ReadAsStringAsync().Result;
            }


        }

    }
}
