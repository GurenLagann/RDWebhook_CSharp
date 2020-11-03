using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Net;

namespace SugarApi.Models{
 public class Sugar{
   [JsonProperty("leads")]
   public List<Leads> leads {get; set;} 

 }

 public class Leads{
   [JsonProperty("email")]
   public string email{get; set;}

   [JsonProperty("name")]
   public string name {get; set;}
   
   [JsonProperty("public_url")]
   public string public_url {get; set;}

   [JsonProperty("interest")]
   public int interest {get; set;}

   [JsonProperty("state")]
   public string state {get; set;}
   
   [JsonProperty("city")]
   public string city {get; set;}

   [JsonProperty("first_conversion")]
   public firstConversion first_conversion {get; set;}
   
   [JsonProperty("last_conversion")]
   public lastConversion last_conversion {get; set;}

   [JsonProperty("custom_fields")]
   public customFields custom_fields {get; set;}

   [JsonProperty("mobile_phone")]
   public string mobile_phone {get; set;}

 }

 public class firstConversion {  
   [JsonProperty("conversion_origin")]
   public conversionOringin conversion_origin {get; set;}
 }

 public class conversionOringin {    
   [JsonProperty("source")]
   public string source {get; set;}

   [JsonProperty("channel")]
   public string channel {get; set;}   
 }

 public class lastConversion {
   [JsonProperty("content")]
   public content content {get; set;}
 }

 public class content {
   [JsonProperty("indentificador")]
   public string identificador {get; set;}

   [JsonProperty("cf_resultado_do_perfil")]
   public string cf_resultado_do_perfil {get; set;}
 }

 public class customFields{      
   [JsonProperty ("Interessado em")]
   public string Interessado {get; set;}
     
   [JsonProperty("Faixa de investimento OK")]
   public string Faixa {get; set;} 

   [JsonProperty("mensagem")]
   public string mensagem  {get; set;}

 }
 
    
}