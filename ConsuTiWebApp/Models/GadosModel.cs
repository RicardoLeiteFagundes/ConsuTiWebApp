using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsuTiWebApp.Models
{
    public class GadosModel
    {
        Gados gados = new Gados();

        public String WebApi;
    public MediaTypeWithQualityHeaderValue mediaheader;
        public GadosModel()
        {
            
            this.WebApi = "http://homologacao.service.mergefusao.agrohub.com.br"; // Web API
            this.mediaheader = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<string> GetGados()
        {
            using (HttpClient client = new HttpClient())
            {
                String Gados = "/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2";
                client.BaseAddress = new Uri(this.WebApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage retorno = await client.GetAsync(Gados);
                if (retorno.IsSuccessStatusCode)
                {




                    dynamic output = JsonConvert.SerializeObject(retorno);

                    dynamic myObject = JsonConvert.DeserializeObject<dynamic>(output);



                    dynamic cList = (await myObject.Content.ReadAsStreamAsync<IList>()).dynamic();
                    return cList;


                }

                public Task<string> GetGadosByID(int id)
                {
                    using (HttpClient cli = new HttpClient())
                    {
                        String petition = "/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2" + id;
                        cli.BaseAddress = new Uri(this.WebApi);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(mediaheader);
                        HttpResponseMessage myObject = await client.GetAsync(petition);
                        if (retorno.IsSuccessStatusCode)
                        {
                            Gados c = await HttpContentExtensions.ReadAsAsync(myObject.Content);
                            return c;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            








            else { return null; }
            }
        }

        
        }

   

}
