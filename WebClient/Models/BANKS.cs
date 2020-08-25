using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class BANKS
    {
        public BANKS()
        {
            this.CREDITS = new HashSet<CREDITS>();
        }

        public int BANK_ID { get; set; }
        public string BANK_NAME { get; set; }
        public Nullable<int> LOCATION_ID { get; set; }

        public virtual LOCATIONS LOCATIONS { get; set; }
        public virtual ICollection<CREDITS> CREDITS { get; set; }
    }
}