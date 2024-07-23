using CountryLibrary;
using CountryLibrary.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace CountryWPF.Services
{
    public class ApiService
    {
        /// <summary>
        /// Retrieve data from Api
        /// </summary>
        /// <param name="urlBase">Url</param>
        /// <param name="controller">Controller</param>
        /// <returns>Response</returns>
        public async Task<Response> GetCountys(string urlBase, string controller)
        {
            try
            {
                var client = new HttpClient();

                //endereço onde tenho a api
                client.BaseAddress = new Uri(urlBase);

                //controlador - Assincrono - para ele ir buscar e a aplicação não deixar de correr
                var response = await client.GetAsync(controller);

                //agurada a resposta que vem de cima no formato de uma string
                var result = await response.Content.ReadAsStringAsync();




                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }



                var county = JsonConvert.DeserializeObject<List<Country>>(result);



                return new Response
                {
                    IsSuccess = true,
                    Result = county,
                };

            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
