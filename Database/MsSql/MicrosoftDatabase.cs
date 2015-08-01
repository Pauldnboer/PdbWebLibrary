using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using PDBWebLibrary.Database.Install;
using PDBWebLibrary.Web;

namespace PDBWebLibrary.Database.MsSql
{
    public class MicrosoftDatabase
    {
        public void Test()
        {
            string query = @"CREATE TABLE k
                            (
                            PersonID int,
                            LastName varchar(255),
                            FirstName varchar(255),
                            Address varchar(255),
                            City varchar(255)
                            );";

            using (SqlCommand sqlCommand = new SqlCommand(query))
//                {
//                    sqlCommand.Parameters.AddRange(parameters);
//                    return new SqlDatabase(connectionString).ExecuteNonQuery(sqlCommand); ExecuteNonQuery

                        new SqlDatabase(PHttpApplication.DatabaseSettingsManager.ConnectionString).ExecuteNonQuery(sqlCommand);
//                }

            

           
        }
    }
}

//SqlConnection myConnection = new SqlConnection("user id=username;" + 
//                                       "password=password;server=serverurl;" + 
//                                       "Trusted_Connection=yes;" + 
//                                       "database=database; " + 
//                                       "connection timeout=30");

// public static int ExecuteNonQuery(string connectionString, string sql, params SqlParameter[] parameters)
//        {
//            try
//            {
//                ++LiveQueryCount;
//                using(SqlCommand sqlCommand = new SqlCommand(sql))
//                {
//                    sqlCommand.Parameters.AddRange(parameters);
//                    return new SqlDatabase(connectionString).ExecuteNonQuery(sqlCommand);
//                }
//            }
//            catch(Exception ex)
//            {
//                LogQueryError("ExecuteNonQuery", sql, parameters, ex);
//                throw;
//            }
//        }