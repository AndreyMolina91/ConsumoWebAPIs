using Microsoft.AspNetCore.Mvc;
using RapidApiQuotes.Models.SendgridModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RapidApiQuotes.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class SendgridController : Controller
    {
        //POST: Controlador/Sendmail
        [HttpPost]
        public async Task SendMail(Example example)
        {
            var _httpclient = new HttpClient();
            //Serializar
            string exampleJson = Newtonsoft.Json.JsonConvert.SerializeObject(example);
            //Request (Metodo, Uri, Contenido y Headers)
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://rapidprod-sendgrid-v1.p.rapidapi.com/mail/send"),
                Headers =
                {
                    { "x-rapidapi-host", "rapidprod-sendgrid-v1.p.rapidapi.com" },
                    { "x-rapidapi-key", "key" },
                },
                Content = new StringContent(exampleJson, Encoding.UTF8)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            //using de ennvio de request y recibido de response
            using (var response = await _httpclient.SendAsync(request))
            {
                //Request y envio del email mediante la api
                response.EnsureSuccessStatusCode(); 
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
       }
    }
}
