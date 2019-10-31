using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ChatClient
{
    class AboutSqlite
    {
        MySqlConnection Connection;
        MySqlCommand Command;
        MySqlDataReader DataReader;
        
        public AboutSqlite()
        {
            Connection = null;
            Command = null;
            DataReader = null;
        }

        public void ConnectDB()
        {
            string connectionString =
                    "Data Source='127.0.0.1'; " +
                    "port='3306'; " +
                    //"Initial Catalog=TEST; " +//DB 생성 먼저 할 것
                    "user id='root'; password='1234'; " +
                    "protocol=tcp; Character Set=utf8; " +
                    "Connection timeout=15; " +
                    "Connection lifetime=0; " +
                    "Max Pool Size=100; " +
                    "Min Pool Size=10; " +
                    "allow user variables=true";
            Connection = new MySqlConnection(connectionString);
        }

        public void CreateDB()
        {
            Connection.Open();
            string checkDB = "create database if not exists chattingip;";
            Command = new MySqlCommand(checkDB, Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void CreateTable()
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "create table if not exists ChatIP (" +
                "ID INTEGER PRIMARY KEY," +
                "Name char(30) not null," +
                "IP char(20) null," +
                "Port int null" +
                ");";

            Command = new MySqlCommand(temp, Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void InsertTable(int id,string name,string ipaddress, int port)/////
        {
            try
            {
                Connection.Open();
                Connection.ChangeDatabase("chattingip");
                string temp = "insert into ChatIP " +
                    "(ID,Name,IP,Port) " +
                    "values (@A,@B,@C,@D);";

                Command = new MySqlCommand(temp, Connection);
                Command.Parameters.AddWithValue("@A", id);
                Command.Parameters.AddWithValue("@B", name);
                Command.Parameters.AddWithValue("@C", ipaddress);
                Command.Parameters.AddWithValue("@D", port);
                Command.ExecuteNonQuery();///////////////////
                Connection.Close();
            }
            catch(Exception e)
            {
                Connection.Close();
            }
        }
        
        public int SelectTable_count()
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "select count(*) FROM ChatIP;";
            int tempcount = 0;
            using (MySqlCommand mySqlCommand = new MySqlCommand(temp, Connection))
            {
                tempcount= Convert.ToInt32(mySqlCommand.ExecuteScalar());
            }
            Connection.Close();
            return tempcount;
            /*
            Command = new MySqlCommand(temp, Connection);

            var result = Command.ExecuteScalar();
            //count = (int)result;///////

            //Command.ExecuteNonQuery();
            //DataReader.Close();
            Connection.Close();

            return (int)result;//////
            */
        }
        
        public string SelectTable_name(int Id)////
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "select * FROM ChatIP Where ID="+Id.ToString()+";";
            Command = new MySqlCommand(temp, Connection);
            DataReader = Command.ExecuteReader();
            string name = string.Empty;
            if (DataReader.Read())
                name = DataReader["Name"].ToString();///
            //Command.ExecuteNonQuery();
            DataReader.Close();
            Connection.Close();

            return name;
        }

        public string SelectTable_ip(string name)
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "select * FROM ChatIP Where Name='"+name+"';";
            Command = new MySqlCommand(temp, Connection);
            DataReader = Command.ExecuteReader();
            string ip=string.Empty;
            if(DataReader.Read())
                ip = DataReader["IP"].ToString();///
            //Command.ExecuteNonQuery();
            DataReader.Close();
            Connection.Close();

            return ip;
        }

        public int SelectTable_port(string name)
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "select * FROM ChatIP Where Name='" + name + "';";
            Command = new MySqlCommand(temp, Connection);
            DataReader = Command.ExecuteReader();
            int port = 0;
            if (DataReader.Read())
                port = int.Parse(DataReader["Port"].ToString());///
            //Command.ExecuteNonQuery();
            DataReader.Close();
            Connection.Close();
            
            return port;
        }

        public void UpdataTable(int id,int count)////
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "update ChatIP set " +
                "ID=ID-1 Where ID= @A;";

            for (int id2=id+1;id2<=count;id2++)
            {
                Command = new MySqlCommand(temp, Connection);
                Command.Parameters.AddWithValue("@A", id2);
                Command.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public void DeleteTable(int id)/////
        {
            Connection.Open();
            Connection.ChangeDatabase("chattingip");
            string temp = "delete from ChatIP Where ID=@A;";

            Command = new MySqlCommand(temp, Connection);
            Command.Parameters.AddWithValue("@A", id);
            Command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
