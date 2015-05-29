using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BankAppLayerArchetec.Model;
using System.Data;

namespace BankAppLayerArchetec.DAL
{
    class Gateway
    {

        public int Save(Account objAccount)
        {
            string connectionString = @"SERVER=FATEMA-PC\SQLEXPRESS; DATABASE=CustomerDB; INTEGRATED SECURITY=TRUE";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO CustomerInfo_Table VALUES ('"+objAccount.AccountNumber+"','"+objAccount.CustomerName+"','"+objAccount.OpeningDate+"','"+objAccount.balance+"','"+objAccount.Email+"')";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected=command.ExecuteNonQuery();
            connection.Close();
           return rowAffected;
        }
        public bool IsAccountNumberExist(Account objAccount)
        {
            string connectionString = @"SERVER=FATEMA-PC\SQLEXPRESS; DATABASE=CustomerDB; INTEGRATED SECURITY=TRUE";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from CustomerInfo_Table where Account_Number='" + objAccount.AccountNumber + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader=command.ExecuteReader();
            bool isExist = reader.Read();
            connection.Close();
            return isExist;

           
        }
           
            

        public int Update(Account objAccount)
        {
            string connectionString = @"SERVER=FATEMA-PC\SQLEXPRESS; DATABASE=CustomerDB; INTEGRATED SECURITY=TRUE";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE CustomerInfo_Table SET Balance='" + objAccount.balance + "'where Account_Number='" + objAccount.AccountNumber + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
       
       
        public double RetriveAmount(string accountNumber)
        {
            double amount = 0;

            string connectionString = @"SERVER=FATEMA-PC\SQLEXPRESS; DATABASE=CustomerDB; INTEGRATED SECURITY=TRUE";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select Balance from CustomerInfo_Table where Account_Number='" +accountNumber + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                amount = Convert.ToDouble(reader["Balance"]);
            }
            connection.Close();
            return amount;
        }
        public DataTable ShowDetail(Account objAccount)
        {
            string connectionString = @"SERVER=FATEMA-PC\SQLEXPRESS; DATABASE=CustomerDB; INTEGRATED SECURITY=TRUE";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from CustomerInfo_Table ";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adaptar = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adaptar.Fill(dataTable);

            connection.Close();
            return dataTable;
        }
        public DataTable Search(Account objAccount)
        {
            string connectionString = @"SERVER=FATEMA-PC\SQLEXPRESS; DATABASE=CustomerDB; INTEGRATED SECURITY=TRUE";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from CustomerInfo_Table where Account_Number='" + objAccount.AccountNumber + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adaptar = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adaptar.Fill(dataTable);

            connection.Close();
            return dataTable;
        }
    }
}
