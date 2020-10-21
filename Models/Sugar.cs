using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SugarApi.Models{
 public class Sugar{
   [Key]   
   public int id {get; set;}

   [JsonProperty("leads")]
   public List<Leads> leads {get; set;} 

 }

 public class Leads{
   [Key]   
   
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

 }

 public class firstConversion {
   [Key] 
   public int fid {get; set;}
  
   [JsonProperty("conversion_origin")]
   public conversionOringin conversion_origin {get; set;}
 }

 public class conversionOringin {
   [Key]   
   [JsonProperty("source")]
   public string source {get; set;}

   [JsonProperty("channel")]
   public string channel {get; set;}   
 }

 public class lastConversion {
   [Key]   
  public int fid {get; set;}
   [JsonProperty("content")]
   public content content {get; set;}
 }

 public class content {
   [Key]  
   
   [JsonProperty("indentificador")]
   public string identificador {get; set;}

   [JsonProperty("cf_resultado_do_perfil")]
   public string cf_resultado_do_perfil {get; set;}
 }

 public class customFields{
      
   [JsonProperty ("Interessado em")]
   public string interessado {get; set;}
     
   [JsonProperty("Faixa de investimento OK")]
   public string investimento {get; set;}
  
   [Key]
   [JsonProperty("mensagem")]
   public string mensagem  {get; set;}

 }
 
    
}