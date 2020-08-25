using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class GENDER
    {
        public GENDER()
        {
            this.FIZLICO = new HashSet<FIZLICO>();
        }

        public short GENDER_ID { get; set; }
        [Required]
        public string GENDER_NAME { get; set; }

        public virtual ICollection<FIZLICO> FIZLICO { get; set; }
    }
}