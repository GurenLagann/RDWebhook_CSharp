using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Net;

using static System.Console;

using SugarApi.Models;
using SugarApi.Views;

namespace SugarApi.Controllers{
  [ApiController]
  [Route("/rdstation")]

  public class RDstation : Controller{
    [HttpPost]
    [Route("")]

    public AcceptedResult Webhook(
      [FromBody] Sugar model
    ) {
      Requisicao r1 = new Requisicao();
      Token token = r1.Autentica();
      SugarLeads leads = new SugarLeads(); 
      
      var AccessToken = token.access_token;
      var email = model.leads[0].email;
      var PLeads = "Leads?filter[0][email]=" + email;      
      leads = r1.isLead(PLeads, AccessToken);      
      
      
      if(leads.records != null && leads.records.Count >0){
        return Accepted(leads);    
      }
      else{
        SugarLeads client = new SugarLeads();
        var PClient = "Contacts?filter[0][email]=" + email;
        client = r1.isClient(PClient, AccessToken);

        if(client.records != null && client.records.Count >0){          
          return Accepted(leads);
        }
        else{
          var url ="https://lftm.sugarondemand.com/rest/v11/Leads";

          var sugarpost = new SendSugar{
              first_name = model.leads[0].name,
              email = new List<ExempleEmail>{
                new ExempleEmail{
                email_address = model.leads[0].email,
                primary_address = true,
                }
              },
              lftm_it_rd_station_c = model.leads[0].first_conversion.conversion_origin.channel + "|" + model.leads[0].first_conversion.conversion_origin.source,
              phone_mobile = model.leads[0].mobile_phone,
              lftm_lead_score_interesse_rd_c = model.leads[0].interest,
              lead_source = "rdstation",
              lead_source_description_new_c = model.leads[0].custom_fields.Interessado,
              lftm_ti_msg_fc_c = model.leads[0].custom_fields.mensagem,
              lftm_ti_url_rdstation_c = " " + model.leads[0].public_url,
              lftm_estimativa_pelo_assesso_c = model.leads[0].custom_fields.Faixa,
              primary_address_city = model.leads[0].city,
              primary_address_state = model.leads[0].state
            };

          // Transformando os parametros em JSON
          var jsonParams = JsonConvert.SerializeObject(sugarpost, Formatting.Indented);
          var httpContent = new StringContent(jsonParams, Encoding.UTF8, "application/json");


          // CONFIG DO REQUEST
          using (HttpClient cliente = new HttpClient())
          {
            cliente.BaseAddress = new Uri(url);
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            cliente.DefaultRequestHeaders.Add("oauth-token", AccessToken); 
            try{
                // Executando POST e pegando resposta
                HttpResponseMessage response = cliente.PostAsync(url, httpContent).Result;
                var responseAux = response.Content.ReadAsStringAsync();
                var jsonResult = responseAux.Result;
                return Accepted(sugarpost);                 
            }
            catch (HttpRequestException e){
                WriteLine("\nException Caught!");
                WriteLine("Message :{0} ", e.Message);
                return null;
            }
          }
        }            
      }        
    }  
  }    
}