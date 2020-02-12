using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace RandomPwRecommand
{
    class AboutSQL
    {
        
        
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dataReader;
        SqlParameter dbParameter=new SqlParameter();

        public static string tempstring;
        static StringBuilder tempstring2 = new StringBuilder();
        //  mssql 연결 방법 알기 전까지는 주석
        public AboutSQL()
        {
            connection = null;
            command = null;
            dataReader = null;
        }

        public void ConnectDB()
        {
            //string connstring = "server='127.0.0.1'; "+
               // "uid=id"+
               // "pwd=password"+
               // "database=database";//유저와 DB이용시

            //string winconn = "Server= localhost; Integrated Security = True;";
            //string winconn = "Data Source=.;Integrated Security = True;Initial Catalog=testdb;";
            //string winconn = "Data Source=.;Initial Catalog=testdb;Integrated Security=True;";//DB의 속성을 보면 연결 문자열을 사용하면 된다.
            string winconn = "Data Source=.;Integrated Security=True;";
            //윈도우 인증 계정 이용시
            connection = new SqlConnection(winconn);
            
            //dbConnection = new DbConnection(connstring);

            /*
            dbConnection.ConnectionString = "Data Source='127.0.0.1'; " +
                    "port='3306'; " +
                    //"Initial Catalog=TEST; " +//DB 생성 먼저 할 것
                    "user id='root'; password='1234'; " +
                    "protocol=tcp; Character Set=utf8; " +
                    "Connection timeout=15; " +
                    "Connection lifetime=0; " +
                    "Max Pool Size=100; " +
                    "Min Pool Size=10; " +
                    "allow user variables=true";
                    */
        }

        public void CreateDB()
        {
            connection.Open();
            //command.CommandText = "create database if not exists chattingip;";
            tempstring = @"if not exists (select * from sys.databases where name='testdb')
create database testdb;";
            //command = new SqlCommand("create database if not exists chattingip;",connection);
            command = new SqlCommand(tempstring, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void CreateTable()
        {
            connection.Open();
            connection.ChangeDatabase("testdb");
            //tempstring = "create table if not exists ChatIP (" +
            /*
            tempstring = "create table if not exists ChatIP (" +
                "ID INTEGER PRIMARY KEY," +
                "Name char(30) not null," +
                "IP char(20) null," +
                "Port int null" +
                ");";
            */

            tempstring = @"if not exists (select * from sysobjects where name='Rpwd')
create table Rpwd(Date varchar(32),
Password varchar(32)
);";
            
            //command.CommandText = tempstring;
            command = new SqlCommand(tempstring,connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertTable(string date,string password)
        {
            try
            {
                connection.Open();
                connection.ChangeDatabase("testdb");
                tempstring = "insert into Rpwd" +
                    "(Date,Password)" +
                    "values (@A,@B);";
                command.CommandText = tempstring;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@A",date);
                
                command.Parameters.AddWithValue("@B",password);
                /*
                dbParameter.ParameterName = "@A";
                dbParameter.Value = date;
                command.Parameters.Add(dbParameter);

                dbParameter.ParameterName = "@B";
                dbParameter.Value = password;
                command.Parameters.Add(dbParameter);
*/
                command.ExecuteNonQuery();
                connection.Close();
            }catch(Exception e)
            {
                connection.Close();
            }
        }

        public int SelectTable_count()
        {
            connection.Open();
            connection.ChangeDatabase("testdb");
            //connection.ChangeDatabase("chattingip");
            tempstring = "select count(*) FROM Rpwd;";
            int tempcount = 0;
            command = new SqlCommand(tempstring,connection);
            tempcount = Convert.ToInt32(command.ExecuteScalar());
            /*
            using (MySqlCommand mySqlCommand = new MySqlCommand(temp, Connection))
            {
                tempcount = Convert.ToInt32(mySqlCommand.ExecuteScalar());
            }
            */
            connection.Close();
            return tempcount;

        }
        public Dictionary<string,string> SelectTable_data()
        {
            connection.Open();
            connection.ChangeDatabase("testdb");
            tempstring = "select * From Rpwd;";
            command = new SqlCommand(tempstring, connection);
            dataReader = command.ExecuteReader();
            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            //List<string> datelist=new List<string>();
            
            while (dataReader.Read())
            {
                //datelist.Add(dataReader["Date"].ToString());
                dataDic.Add(dataReader["Date"].ToString(), dataReader["Password"].ToString());
            }
            connection.Close();
            return dataDic;
        }
        

        public string SelectTable_date()////
        {
            connection.Open();
            connection.ChangeDatabase("testdb");
            //tempstring = "select * FROM Rpwd Where ID=" + Id.ToString() + ";";
            tempstring = "select * FROM Rpwd;";
            command = new SqlCommand(tempstring,connection);
            dataReader = command.ExecuteReader();
            if (tempstring2.Length > 3)
                tempstring2.Clear();
            if (dataReader.Read())
                tempstring2.Append(dataReader["Date"]);///
            //Command.ExecuteNonQuery();
            dataReader.Close();
            connection.Close();

            return tempstring2.ToString();
        }

        public string SelectTable_pwd()////
        {
            connection.Open();
            connection.ChangeDatabase("testdb");
            //tempstring = "select * FROM Rpwd Where ID=" + Id.ToString() + ";";
            tempstring = "select * FROM Rpwd;";
            command = new SqlCommand(tempstring, connection);
            dataReader = command.ExecuteReader();
            if (tempstring2.Length > 3)
                tempstring2.Clear();
            if (dataReader.Read())
                tempstring2.Append(dataReader["Password"]);
            //Command.ExecuteNonQuery();
            dataReader.Close();
            connection.Close();

            return tempstring2.ToString();
        }
        public void DeleteTableData_all()
        {
            connection.Open();
            connection.ChangeDatabase("testdb");
            tempstring = " delete from Rpwd;";
            command.CommandText = tempstring;
            command.ExecuteNonQuery();
            connection.Close();
        }

        
    }
}
