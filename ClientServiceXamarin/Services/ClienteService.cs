using ClientServiceXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiceXamarin.Services
{
    internal class ClienteService
    {
        HttpClient client = new HttpClient();

        public ClienteService()
        {
            client.BaseAddress = new Uri("https://1374-2806-108e-26-cfa9-299a-1671-8530-8fda.ngrok.io/Encuesta/");
        }
        public async Task<Preguntas> GetPreguntas()
        {

            HttpResponseMessage responseMessage = await client.GetAsync("pregunta");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responder = await responseMessage.Content.ReadAsStringAsync();
                Preguntas preguntas = JsonConvert.DeserializeObject<Preguntas>(responder); 
                return preguntas;   


            }
            else
            {
                return null;    
            }

        }
        public async Task Votacion(int votacion)
        {
            var responder= await client.GetAsync("Contestar?votacion=" + votacion);   
            responder.EnsureSuccessStatusCode();    

        }
        public async Task ContestarPOST(VotacionClientes votacion)
        {
            var json= JsonConvert.SerializeObject(votacion);    
            var content= new StringContent(json,Encoding.UTF8,"application/json");
            var responder= await client.PostAsync("Contestar",content);
            responder.EnsureSuccessStatusCode();
        }







    }
}
