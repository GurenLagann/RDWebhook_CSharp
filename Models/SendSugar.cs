using System;
using System.Collections.Generic;


namespace SugarApi.Models {    

    public class SendSugar { 
      public string first_name {get; set;}
      public List<ExempleEmail> email {get; set;}
      public string lftm_it_rd_station_c {get; set;}
      public string phone_mobile {get; set;}
      public int lftm_lead_score_interesse_rd_c {get; set;}
      public string lead_source {get; set;}
      public string lead_source_description_new_c {get; set;}
      public string lftm_ti_msg_fc_c {get ; set;}
      public string lftm_ti_url_rdstation_c {get; set;}
      public string lftm_estimativa_pelo_assesso_c {get; set;}            
      public string primary_address_city {get; set;}
      public string primary_address_state {get; set;}
    }

    public class ExempleEmail {
      public string email_address {get; set;}
      public bool primary_address {get; set;}
    }
}       
