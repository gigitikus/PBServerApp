using Microsoft.Data.SqlClient;
using PBShared.DataTransferObject.Transaksi.TR_Partais.dto;
using static PBShared.Models.PagingParams;
using System.Data;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using PBShared.DBContexts;
using Microsoft.Extensions.Configuration;

namespace PBWebAPI.DataAccess
{
    public partial class da_Transactions
    {
        public int GetTotalCountPartais(DynamicCondition input)
        {
            int res = 0;
            DataTable dt = new DataTable("TRPartai");
            var conStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["PBManageServiceDbContext"];
            
            try
            {
                using(SqlConnection con = new SqlConnection(conStr))
                {
                    using(SqlCommand com = new SqlCommand("GetCountFetchPartais", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();

                        com.Parameters.Add("@condition", SqlDbType.NVarChar).Value = input.condition;
                        com.Parameters.Add("@pageNumber", SqlDbType.Int).Value = input.pageNumber;
                        com.Parameters.Add("@rowsOfPage", SqlDbType.Int).Value = input.rowsOfPage;

                        con.Open();
                        da.SelectCommand = com;
                        da.Fill(dt);
                        con.Close();

                        res = Convert.ToInt32(dt.Rows[0]["TotalCount"]);
                    }
                }
            }
            catch (Exception ex)
            {
                res = 0;
            }

            return res;
        }
        public List<TRPartai>? GetPartais(DynamicCondition input)
        {
            List<TRPartai>? res = new List<TRPartai>();
            DataTable dt = new DataTable("TRPartai");
            var conStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["PBManageServiceDbContext"];
            
            try
            {
                using(SqlConnection con = new SqlConnection(conStr))
                {
                    using(SqlCommand com = new SqlCommand("GetFetchPartai", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();

                        com.Parameters.Add("@condition", SqlDbType.NVarChar).Value = input.condition;
                        com.Parameters.Add("@pageNumber", SqlDbType.Int).Value = input.pageNumber;
                        com.Parameters.Add("@rowsOfPage", SqlDbType.Int).Value = input.rowsOfPage;

                        con.Open();

                        da.SelectCommand = com;
                        da.Fill(dt);

                        string json = JsonConvert.SerializeObject(dt);

                        res = JsonConvert.DeserializeObject<List<TRPartai>>(json);

                        con.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                res = null;
            }

            return res;
        }
    }
}
