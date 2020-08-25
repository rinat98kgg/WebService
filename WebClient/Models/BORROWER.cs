using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.WebClient.Models
{
    public class BORROWER
    {
        public int FIZLICO_ID { get; set; }
        public string FULL_NAME { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string IDCARD_ANN { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DATE_BIRTH { get; set; }
        public string GENDER_NAME { get; set; }
        public string MSTATUS_NAME { get; set; }
        public string NATIONALITY_NAME { get; set; }
        public int CREDIT_ID { get; set; }
        public string BANK_NAME { get; set; }
        public Nullable<int> CREDIT_SUM { get; set; }
        public Nullable<short> SROK_PERYEAR { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DATE_ISSUE { get; set; }
        public Nullable<short> PERCENT_PERYEAR { get; set; }
        public Nullable<short> FINE_PERYEAR { get; set; }
        public string CSTATUS_NAME { get; set; }
        public string STREET_ADDRESS { get; set; }
        public string POSTAL_CODE { get; set; }
        public string CITY_PROVINCE { get; set; }
    }
}