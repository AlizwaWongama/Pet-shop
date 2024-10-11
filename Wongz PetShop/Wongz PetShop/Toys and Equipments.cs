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
    public partial class Toys_and_Equipments : Form
    {
        public Toys_and_Equipments()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmd;

        private void Toys_and_Equipments_Load(object sender, EventArgs e)
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
            cmd.CommandText = "SELECT * From Toys & Equipment ";
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
            cmd.CommandText = "INSERT INTO Toys & Equipment(Toys & Equipment_Name,Toys & Equipment_Size,Toys & Equipment_,Type,Toys & Equipment_Color,Toys & Equipment_Price)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text +'")"
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE ORDERS SET Toys & Equipment = '" + textBox1.Text + "'";
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
                cmd.CommandText = "DELETE FROM ORDERS WHERE Toys & EQUIPMENT  = " + textBox3.Text + "";
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
}
