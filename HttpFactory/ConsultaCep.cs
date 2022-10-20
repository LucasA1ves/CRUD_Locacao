using CrudLocacao.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrudLocacao.HttpFactory
{
    public class ConsultaCep
    {
        private static readonly HttpClient client = new HttpClient();
        private static string BaseUri = "http://viacep.com.br/ws";

        public async Task<ResponseConsultaCep> ConsultarCep(string cep)
        {
            string result = String.Empty;
            string url = string.Format("{0}/{1}", BaseUri, $"{cep}/json");

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();

                var responseApi = JsonConvert.DeserializeObject<ResponseConsultaCep>(result);
                return responseApi;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar a consulta na URL {url} - #Exception: {ex.Message}");
            }
        }
    }
}
