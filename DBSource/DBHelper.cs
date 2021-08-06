using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSource
{
    public class DBHelper
    {
        #region 連接字串/ 找DataTable / 找DataRow
        /// <summary> 連接字串 </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }

        /// <summary> 抓取流水帳的DataTable </summary>
        /// <param name="connStr"></param>
        /// <param name="dbCommand"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ReadDataTable(string connStr, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }
        }

        /// <summary> 抓取流水帳的DataRow </summary>
        /// <param name="connStr"></param>
        /// <param name="dbCommand"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataRow ReadDataRow(string connStr, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count == 0)
                        return null;

                    DataRow dr = dt.Rows[0]; // 舊的搬過來
                    return dt.Rows[0];

                }
            }
        }
        #endregion

        #region 與DB相關部分
        /// <summary> CreateAccounting 的重構 </summary>
        /// <param name="connStr"></param>
        /// <param name="dbCommand"></param>
        /// <param name="paramList"></param>
        public static void CreatData(string connStr, string dbCommand, List<SqlParameter> paramList)
        {
            // connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(paramList.ToArray());

                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }
        }

        /// <summary> UpdateAccounting 與 DeleteAccounting 的重構 </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbCommandString"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static int ModifyData(string connectionString, string dbCommandString, List<SqlParameter> paramList)
        {
            // connect db & execute
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand(dbCommandString, conn))
                {
                    comm.Parameters.AddRange(paramList.ToArray());

                    conn.Open();
                    int effectRowsCount = comm.ExecuteNonQuery();
                    return effectRowsCount;
                }
            }
        }
        #endregion


        #region 計算
        public static void SaveData(int BaseNumber, int CoefficientNumber) {

            string connStr = GetConnectionString();
            string dbCommand =
                $@" INSERT INTO [MultDate]
                    (
                        [BaseNumber]
                       ,[CoefficientNumber]
                       ,[CreatDate]
                    )
                    VALUES
                    (
                        @BaseNumber
                       ,@CoefficientNumber
                       ,@CreatDate
                    )
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@BaseNumber", BaseNumber));
            paramList.Add(new SqlParameter("@CoefficientNumber", CoefficientNumber));
            paramList.Add(new SqlParameter("@CreatDate", DateTime.Now));


            try
            {
                CreatData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }


        public static DataTable GatData()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT
                        [BaseNumber]
                         ,[CoefficientNumber]
                           ,[CreatDate]
                    FROM [MultDate]
                    ORDER BY [CreatDate] DESC
                ";

            // 用List把Parameter裝起來，再裝到共用參數
            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@userID", userID));
            try // 讓錯誤可以被凸顯，因此 TryCatch 不應該重構進 DBHelper
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        #endregion
    }
}