using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class LOCATIONS
    {
        public LOCATIONS()
        {
            this.BANKS = new HashSet<BANKS>();
            this.FIZLICO = new HashSet<FIZLICO>();
            //this.URLICO = new HashSet<URLICO>();
        }

        public int LOCATION_ID { get; set; }
        public string STREET_ADDRESS { get; set; }
        public string POSTAL_CODE { get; set; }
        public string CITY_PROVINCE { get; set; }

        public virtual ICollection<BANKS> BANKS { get; set; }
        public virtual ICollection<FIZLICO> FIZLICO { get; set; }
        public virtual ICollection<URLICO> URLICO { get; set; }
    }
}