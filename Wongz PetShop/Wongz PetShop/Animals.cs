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
    public partial class Animals : Form
    {
        public Animals()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmd;

        private void Animals_Load(object sender, EventArgs e)
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
            cmd.CommandText = "INSERT INTO Animal(Animal_Name,Animal_Type)VALUES('" + textBox1.Text + "','" + textBox2.Text +'")"
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        
        


       

        

       
    }
}
