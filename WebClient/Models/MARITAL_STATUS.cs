using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class MARITAL_STATUS
    {
        public MARITAL_STATUS()
        {
            this.FIZLICO = new HashSet<FIZLICO>();
        }

        public short MSTATUS_ID { get; set; }
        public string MSTATUS_NAME { get; set; }

        public virtual ICollection<FIZLICO> FIZLICO { get; set; }
    }
}