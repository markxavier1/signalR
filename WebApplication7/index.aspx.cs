using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static IEnumerable<Cases_tbl> GetData()
        {


            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                red_multimediaEntities red = new red_multimediaEntities();
                var q = red.Cases_tbl as DbQuery<Cases_tbl>;
                //SqlCommand c = new SqlCommand();

                //c.CommandText = q.ToString();
                connection.Open();
                using (SqlCommand command = new SqlCommand(q.ToString(), connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                  using (var reader = command.ExecuteReader())
                        //return reader.Cast<IDataRecord>()
                        //    .Select(x => new Products()
                        //    {
                        //        CaseId = x.GetInt32(0),
                        //        CaseName = x.GetString(1),
                        //        CaseTime = x.GetString(2),
                        //        CaseDate = x.GetString(3),
                        //        CaseDescription = x.GetString(4),
                        //    }).ToList();

                        return  red.Cases_tbl.ToList();


                }
            }
        }
        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MyHub.Show();
        }


    }
}