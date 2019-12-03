using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// For Connection And Data Exchange To SQL, You Have To Add the Using Below
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// This Code Is An Easy Example About MSSQL Connection by C# And Present On A HTML Page,
/// Under Visual Studio 2017, A WebApplication Project, and Add New Web Form Under the Project
/// Authorize By Rojean Lin, @NTUT Dec.07, 2018
/// </summary>

namespace Teach_MSSQL_FrontStageShowing
{
    public partial class example : System.Web.UI.Page
    {
        public Double A;     /// To set the Variable Readable for Front Stage, It should be set as Public; In order to Calculate, a calculable Type is RECOMMANDED
        public Double B;        
        public Double C;
        protected void Page_Load(object sender, EventArgs e)
        {
            /// Optional (Main program)

        }

        /// Subroutine to be read
        protected string ss()
        {
            /// Declare a new DataTable and fill it for further utilize
            DataTable dt01 = new DataTable(); 
            /// Connect to SQL
            using (SqlConnection con01 = new SqlConnection("Data Source = 140.124.47.153; Initial Catalog = new_ASUS; Persist Security Info = True; User ID = remote test; Password = 654321"))
            {
                /// Open Connection
                con01.Open();
                /// Add a command and Execute under the connection
                SqlCommand cmd01 = new SqlCommand("SELECT *  FROM [0R].[dbo].[Table_1]", con01);
                /// The Fill method of the DataAdapter is used to populate a DataSet with the results of the SelectCommand of the DataAdapter. 
                /// Fill takes as its arguments a DataSet to be populated, and a DataTable object, or the name of the DataTable to be filled 
                /// with the rows returned from the SelectCommand.
                SqlDataAdapter da01 = new SqlDataAdapter(cmd01);
                da01.Fill(dt01);
                con01.Close();
            }

            /// dt.Rows[x][y] represent the xth Row and the yth Column of the DataTable dt
            A = Convert.ToDouble(dt01.Rows[0][0]);
            B = Convert.ToDouble(dt01.Rows[0][1]);
            C = Convert.ToDouble(dt01.Rows[0][2]);

            Double Product = A * B;
            /// Return Variable for further utilize
            return Convert.ToString(Product);
        }
    }
}