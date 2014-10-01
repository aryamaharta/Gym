using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Gym
{
    class DatabaseModel
    {
        MySqlConnection con;
        String konf = "Server=localhost;port=3306;UID=root;PWD=;Database=db_gym";
        DataTable dt;

        public void insertPaket(String deskripsi, String waktu, String harga)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "insert into master_paket (deskripsi_paket, lama_waktu, harga_paket) values('"+deskripsi+"','"+waktu+"','"+harga+"')";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void addMember(String queryInsert)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = queryInsert;
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void deletePaket(String id)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "delete from master_paket where id_paket='"+id+"'";
                query.ExecuteNonQuery();
                query.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable getData(String tabel)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                //query.CommandText = "select * from '" + tabel + "'";
                query.CommandText = "select * from " + tabel + "";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }

        public DataTable getDataWhere(String tabel, String col, String value)
        {
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            dt = new DataTable();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "select * from " + tabel + " WHERE " + col + "='" + value + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }

        public String login(String user, String pass)
        {
            dt = new DataTable();
            String result = "0";
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {

                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "select count(*) from master_staf where username='" + user + "' AND pass='"+ pass +"'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                result = dt.Rows[0][0].ToString();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return result;
            }
        }

        public DataTable loginMember(String tanggal, String id)
        {
            dt = new DataTable();
            con = new MySqlConnection(konf);
            MySqlCommand query;
            con.Open();
            try
            {
                query = new MySqlCommand();
                query.Connection = con;
                query.CommandText = "SELECT *, IF(('" + tanggal + "' >= tanggal_mulai AND '" + tanggal + "' <= tanggal_selesai), 'masuk', 'tidak') AS STATUS FROM master_member WHERE id_member='"+id+"'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                adapter.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }
    }
}
