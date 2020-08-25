using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class URLICO
    {
        public int URLICO_ID { get; set; }
        public string URLICO_NAME { get; set; }
        public string URLICO_PHONE { get; set; }
        public Nullable<int> CREDIT_ID { get; set; }
        public Nullable<int> LOCATION_ID { get; set; }

        public virtual CREDITS CREDITS { get; set; }
        public virtual LOCATIONS LOCATIONS { get; set; }
    }
}