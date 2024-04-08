
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Sql
{
    public static class NewRe
    {

        internal static MySqlConnection conWithString = new MySqlConnection
    ("Datasource=localhost; port=3306; username = root; password=;database=thisgym;"); // cneltyn[eq,jkmijq15SM

        public static void Grid(string re, DataGridView datagrid)
        {
            try
            {
                conWithString.Close();
                conWithString.Open();
                var command = new MySqlCommand(re, conWithString);
                command.ExecuteNonQuery();
                var datatable = new DataTable();
                var dataadapter = new MySqlDataAdapter(command);
                dataadapter.Fill(datatable);
                datagrid.DataSource = datatable.DefaultView;
                conWithString.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static DataTable Table(string re)
        {

            try
            {
                conWithString.Close();
                conWithString.Open();
                var command = new MySqlCommand(re, conWithString);
                command.ExecuteNonQuery();
                var datatable = new DataTable();
                var dataadapter = new MySqlDataAdapter(command);
                dataadapter.Fill(datatable);
                conWithString.Close();
                return datatable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;

        }


       

        public static string Str(string re)
        {
            string s = "-1";
            try
            {
                conWithString.Close();
                conWithString.Open();
                var command = new MySqlCommand(re, conWithString);
                if (command.ExecuteScalar() != null)
                    s = command.ExecuteScalar().ToString();
                conWithString.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return s;

        }


        public static int Command(string re)
        {
            try
            {
                conWithString.Close();
                conWithString.Open();
                var command = new MySqlCommand(re, conWithString);
                command.ExecuteNonQuery();
                conWithString.Close();
                return 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }


        }

        public static async void Asyn(ComboBox cb, string sel, string title)
        {

            {
                conWithString.Open();
                MySqlCommand cmd = new MySqlCommand(sel, conWithString);
                MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    cb.Items.Add(reader[title].ToString());
                }
                conWithString.Close();
            }
        }




    }
}