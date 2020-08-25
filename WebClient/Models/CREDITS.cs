using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class CREDITS
    {
        public CREDITS()
        {
            this.FIZLICO = new HashSet<FIZLICO>();
            this.URLICO = new HashSet<URLICO>();
        }

        public int CREDIT_ID { get; set; }
        public Nullable<int> BANK_ID { get; set; }
        public Nullable<int> CREDIT_SUM { get; set; }
        public Nullable<short> SROK_PERYEAR { get; set; }
        public Nullable<System.DateTime> DATE_ISSUE { get; set; }
        public Nullable<short> PERCENT_PERYEAR { get; set; }
        public Nullable<short> FINE_PERYEAR { get; set; }
        public Nullable<short> CSTATUS_ID { get; set; }

        public virtual BANKS BANKS { get; set; }
        public virtual CREDIT_STATUS CREDIT_STATUS { get; set; }
        public virtual ICollection<FIZLICO> FIZLICO { get; set; }
        public virtual ICollection<URLICO> URLICO { get; set; }
    }
}