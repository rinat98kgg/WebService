using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi.Models
{
    [DataContract(IsReference = true)]
    public class BORROWER
    {
        [DataMember]
        public int FIZLICO_ID { get; set; }
        [DataMember]
        public string FULL_NAME { get; set; }
        [DataMember]
        public string PHONE_NUMBER { get; set; }
        [DataMember]
        public string IDCARD_ANN { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DATE_BIRTH { get; set; }
        [DataMember]
        public string GENDER_NAME { get; set; }
        [DataMember]
        public string MSTATUS_NAME { get; set; }
        [DataMember]
        public string NATIONALITY_NAME { get; set; }
        [DataMember]
        public int CREDIT_ID { get; set; }
        [DataMember]
        public string BANK_NAME { get; set; }
        [DataMember]
        public Nullable<int> CREDIT_SUM { get; set; }
        [DataMember]
        public Nullable<short> SROK_PERYEAR { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DATE_ISSUE { get; set; }
        [DataMember]
        public Nullable<short> PERCENT_PERYEAR { get; set; }
        [DataMember]
        public Nullable<short> FINE_PERYEAR { get; set; }
        [DataMember]
        public string CSTATUS_NAME { get; set; }
        [DataMember]
        public string STREET_ADDRESS { get; set; }
        [DataMember]
        public string POSTAL_CODE { get; set; }
        [DataMember]
        public string CITY_PROVINCE { get; set; }
    }
}