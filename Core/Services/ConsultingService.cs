using Core.Entities;
using Core.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ConsultingService : IConsultingService
    {
        public async Task<Result> Consult(string cnpj)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://receitaws.com.br/v1/cnpj/{cnpj}");
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = new Result() { CNPJ = cnpj, Value = jsonString };

            return result;
        }
    }
}
