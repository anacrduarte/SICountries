using CountryLibrary.Models;
using System.Net;

namespace CountryWPF.Services
{
    public class NetworkService
    {
        /// <summary>
        /// Check internet connection
        /// </summary>
        /// <returns>Response</returns>
        public Response CheckConnection()
        {
            //testar se tenho ligação a net
            var client = new WebClient();

            try
            {
                //fazer ping ao servidor da google
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    //retorna a resposta de sucesso == true
                    return new Response
                    {
                        IsSuccess = true,
                    };
                }
            }
            catch
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = "Configure a sua ligação à internet",
                };
            }

        }
    }
}
