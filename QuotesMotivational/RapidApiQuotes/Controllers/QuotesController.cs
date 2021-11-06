using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidApiQuotes.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RapidApiQuotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {

        // POST: QuotesController/Generate
        [HttpPost]
        public async Task Generate(QuotesParams quotesParams)
        {
            
            var _httpclient = new HttpClient();
            //Serializado
            string quotesParamsJson = Newtonsoft.Json.JsonConvert.SerializeObject(quotesParams);
            //Request que contiene, Metodo, Uri, Headers y Contenido
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://motivational-quotes1.p.rapidapi.com/motivation"),
                Headers =
                {
                    { "x-rapidapi-host", "motivational-quotes1.p.rapidapi.com" },
                    { "x-rapidapi-key", "key" },
                },
                Content = new StringContent(quotesParamsJson, Encoding.UTF8)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            //Response contiene la solicitud del cliente.envio(solicitud)
            using (var response = await _httpclient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);//Body nos trae la frase y la imprimimos en consola, ya la podemos usar donde queramos en el front.
            }


        }
    }        
 }       