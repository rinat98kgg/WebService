using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class NATIONALITIES
    {
        public NATIONALITIES()
        {
            this.FIZLICO = new HashSet<FIZLICO>();
        }

        public short NATIONALITY_ID { get; set; }
        public string NATIONALITY_NAME { get; set; }

        public virtual ICollection<FIZLICO> FIZLICO { get; set; }
    }
}