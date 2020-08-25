using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BORROWERController : ApiController
    {
        // GET: BORROWER
        public List<BORROWER> GetBORROWER(int id)
        {
            OracleConnection conn = new OracleConnection(WebConfigurationManager.ConnectionStrings["Entities2"].ConnectionString);
            List<BORROWER> lis = new List<BORROWER>();
            OracleCommand com = new OracleCommand("BORROWER_INFO", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.Add("BORROWER_ID", OracleDbType.Int32, id, System.Data.ParameterDirection.Input);
            com.Parameters.Add("CUR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);

            try
            {
                conn.Open();
                OracleDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    lis.Add(new BORROWER
                    {
                        FIZLICO_ID = Convert.ToInt32(dr[0]),
                        FULL_NAME = dr[1].ToString(),
                        PHONE_NUMBER = dr[2].ToString(),
                        IDCARD_ANN = dr[3].ToString(),
                        DATE_BIRTH = Convert.ToDateTime(dr[4]),
                        GENDER_NAME = dr[5].ToString(),
                        MSTATUS_NAME = dr[6].ToString(),
                        NATIONALITY_NAME = dr[7].ToString(),
                        CREDIT_ID = Convert.ToInt32(dr[8]),
                        BANK_NAME = dr[9].ToString(),
                        CREDIT_SUM = Convert.ToInt32(dr[10]),
                        SROK_PERYEAR = Convert.ToByte(dr[11]),
                        DATE_ISSUE = Convert.ToDateTime(dr[12]),
                        PERCENT_PERYEAR = Convert.ToByte(dr[13]),
                        FINE_PERYEAR = Convert.ToByte(dr[14]),
                        CSTATUS_NAME = dr[15].ToString(),
                        STREET_ADDRESS = dr[16].ToString(),
                        POSTAL_CODE = dr[17].ToString(),
                        CITY_PROVINCE = dr[18].ToString()
                    });
                    dr.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return lis;
        }
    }
}