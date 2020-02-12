﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class AboutSQL
    {
        MySqlConnection conn;
        MySqlCommand command;

        public AboutSQL()
        {
            conn = null;
            command = null;
        }

        public void Connect()
        {
            string connectionString =
                    "Data Source='127.0.0.1'; " +
                    "port='3306'; " +
                    "user id='root'; password='1234'; " +
                    "Character Set=utf8; allow user variables=true";
            conn = new MySqlConnection(connectionString);
        }
        public void CreateDB()
        {
            conn.Open();
            string checkDB = "create database if not exists examdata;";
            command = new MySqlCommand(checkDB, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void CreateTable()
        {
            conn.Open();
            conn.ChangeDatabase("examdata");
            string temp = "create table if not exists datamember (" +
                "grade integer PRIMARY KEY not null," +
                "cclass integer not null," +
                "no integer not null," +
                "name char(30) not null," +
                "score char(2) not null" +
                ");";

            command = new MySqlCommand(temp, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertTable(int grade, int cclass, int no, string name,string score)//create
        {
            try
            {
                conn.Open();
                conn.ChangeDatabase("examdata");
                string temp = "insert into datamember " +
                    "(grade,cclass,no,name,score) " +
                    "values (@A,@B,@C,@D,@E);";

                command = new MySqlCommand(temp, conn);
                command.Parameters.AddWithValue("@A", grade);
                command.Parameters.AddWithValue("@B", cclass);
                command.Parameters.AddWithValue("@C", no);
                command.Parameters.AddWithValue("@D", name);
                command.Parameters.AddWithValue("@E", score);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
            }
        }
        public DataTable SelectTable()//Read
        {
            conn.Open();
            conn.ChangeDatabase("examdata");
            string query = "select * from datamember;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dataTable=new DataTable();
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }
        public void UpdataTable(DataTable dataTable)//Update
        {
            conn.Open();
            conn.ChangeDatabase("examdata");
            string tempstring = "Select * from datamember";
            MySqlDataAdapter adapter=new MySqlDataAdapter(tempstring,conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            DataTable temptable = new DataTable();
            adapter.Fill(temptable);

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                for(int j = 0; j < dataTable.Columns.Count; j++)
                {
                    temptable.Rows[i][j] = dataTable.Rows[i][j];
                }
            }

            adapter.Update(temptable);
            conn.Close();
        }

        public void DeleteTable(string grade)//Remove
        {
            conn.Open();
            conn.ChangeDatabase("examdata");
            command = new MySqlCommand("Delete from datamember where grade=@A",conn);
            command.Parameters.AddWithValue("@A", grade);
            command.ExecuteNonQuery();
            conn.Close();
        }

    }
}