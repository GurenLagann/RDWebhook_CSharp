using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using SugarApi.Models;
using SugarApi.Views;
using SugarApi.Data;

namespace SugarApi.Controllers{
  [ApiController]
  [Route("/rdstation")]

  public class RDstation : Controller{
    [HttpPost]
    [Route("")]

    public async Task<ActionResult<Sugar>> Post(
      [FromServices]DataContext context,
      [FromBody] Sugar model
    )
    {
      if(ModelState.IsValid) {
        context.Sugar.Add(model);
        await context.SaveChangesAsync();
        return model;
      }
      else {
        return BadRequest(ModelState);
      }
    }

    public AcceptedResult Webhook() {
      var rd = new Sugar();
      var list = rd.leads;
      Console.WriteLine(list);

      return Accepted(202);
      
    }
    
  }
    
}