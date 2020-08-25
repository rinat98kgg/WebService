using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class CREDIT_STATUS
    {
        public CREDIT_STATUS()
        {
            this.CREDITS = new HashSet<CREDITS>();
        }

        public short CSTATUS_ID { get; set; }
        public string CSTATUS_NAME { get; set; }

        public virtual ICollection<CREDITS> CREDITS { get; set; }
    }
}