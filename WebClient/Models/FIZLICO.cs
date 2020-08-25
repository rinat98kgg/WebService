using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebService.WebClient.Models
{
    public class FIZLICO
    {
        public int FIZLICO_ID { get; set; }
        public string FULL_NAME { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PHONE_NUMBER { get; set; }
        public string IDCARD_ANN { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DATE_BIRTH { get; set; }
        public Nullable<short> GENDER_ID { get; set; }
        public Nullable<short> MSTATUS_ID { get; set; }
        public Nullable<short> NATIONALITY_ID { get; set; }
        public Nullable<int> CREDIT_ID { get; set; }
        public Nullable<int> LOCATION_ID { get; set; }

        public virtual CREDITS CREDITS { get; set; }
        public virtual GENDER GENDER { get; set; }
        public virtual LOCATIONS LOCATIONS { get; set; }
        public virtual MARITAL_STATUS MARITAL_STATUS { get; set; }
        public virtual NATIONALITIES NATIONALITIES { get; set; }

        //public IEnumerable<SelectListItem> GENDERS { get; set; }
    }
}