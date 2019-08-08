using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_practise
{
    class DataBaseConnection
    {
        //define private class parameters
        private string sql_string;
        private string strCon;
        System.Data.SqlClient.SqlDataAdapter da_1;

        //define public class parameters
        public string Sql
        {
            set { sql_string = value; }
        }

        public string connection_string
        {
            set { strCon = value; }
        }

        public System.Data.DataSet GetConnection
        {
            get { return MyDataSet(); }
        }

        //Class constructors


        //Class Methods
        private System.Data.DataSet MyDataSet()
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strCon); //create connection to SQL database
            con.Open(); //open connection to database

            //create data adapter to open table in database; first variable defines records we want to take from table, second defines database where to find that table
            da_1 = new System.Data.SqlClient.SqlDataAdapter(sql_string, con);

            //define and create data set
            System.Data.DataSet data_set = new System.Data.DataSet();

            //fill data set
            da_1.Fill(data_set, "Table_Data_1"); // 1st parameter - object/DataSet to fill, 2nd parameter - name of a fill {optional}

            con.Close(); //close connection to database

            return data_set;
        }
    }
}
