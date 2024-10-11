using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Wongz_PetShop
{
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmd;

        private void Food_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\PetShop3.0.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * From Food ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Food(Food_Type,Food_Size)VALUES('" + textBox1.Text + "','" + textBox2.Text +'")"
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE FROM Food = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Food  = " + textBox2.Text + "";
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        catch (Exception ex)
            {
                MessageBox.Show("Error look at your code" + ex.Message);
            }
        }

        
        }
    
}
