using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SugarApi.Models {
    

    public class SugarLeads {        
        public List<Records> records {get; set;}
    }

    public class Records {
        public string id {get; set;}
        public string name {get; set;}
        public List<Email> email {get; set;}
    }

    public class Email {
        public string email_address { get; set; }
        public bool primary_address { get; set; }
    }    
}