using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
      var Lemails = leads.records[0].email[0].email_address; 
      
      if(Lemails == null){
        SugarLeads client = new SugarLeads();
        var PClient = "Contacts?filter[0][email]=" + email;
        client = r1.isClient(PClient, AccessToken);
        var Cemails = client.records[0].email[0].email_address;
        if(Cemails == null){          
          return Accepted(model);
        }
        else{
          return Accepted(leads);
        }      
      }
      else{
        return Accepted(model);        
      }

        
    }  
  }
    
}