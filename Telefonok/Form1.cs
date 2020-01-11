using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Telefonok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewTelefonok.ColumnCount = 4;
            dataGridViewTelefonok.Columns[0].Name = "id";
            dataGridViewTelefonok.Columns[1].Name = "marka";
            dataGridViewTelefonok.Columns[1].HeaderText = "Márka";
            dataGridViewTelefonok.Columns[2].Name = "tipus";
            dataGridViewTelefonok.Columns[2].HeaderText = "Típus";
            dataGridViewTelefonok.Columns[3].Name = "ar";
            dataGridViewTelefonok.Columns[3].HeaderText = "Ár";
            DataGridView_Telefonok_Update();
        }
        private void DataGridView_Telefonok_Update()
        {
            dataGridViewTelefonok.Rows.Clear();
            Program.sql.CommandText = "SELECT id,marka,tipus,ar FROM telefon";
            try
            {
                using (MySqlDataReader dr=Program.sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int sor_index = dataGridViewTelefonok.Rows.Add();
                        dataGridViewTelefonok.Rows[sor_index].Cells["id"].Value=dr.GetInt32("id");
                        dataGridViewTelefonok.Rows[sor_index].Cells["marka"].Value=dr.GetString("marka");
                        dataGridViewTelefonok.Rows[sor_index].Cells["tipus"].Value=dr.GetString("tipus");
                        dataGridViewTelefonok.Rows[sor_index].Cells["ar"].Value=dr.GetInt32("ar");
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Program.sql.CommandText = "INSERT INTO telefon(id,marka,tipus,ar) VALUES (null,@marka,@tipus,@ar)";
            Program.sql.Parameters.Clear();
            Program.sql.Parameters.AddWithValue("@marka", textBox1.Text);
            Program.sql.Parameters.AddWithValue("@tipus", textBox2.Text);
            Program.sql.Parameters.AddWithValue("@ar", (int)numericUpDown1.Value);
            try
            {
                Program.sql.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DataGridView_Telefonok_Update();
        }

        private void dataGridViewTelefonok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int kivalasztott_sor_index = dataGridViewTelefonok.SelectedRows[0].Index;
            textBox1.Text = dataGridViewTelefonok.Rows[kivalasztott_sor_index].Cells["marka"].Value.ToString();
            textBox2.Text = dataGridViewTelefonok.Rows[kivalasztott_sor_index].Cells["tipus"].Value.ToString();
            numericUpDown1.Value = (int)dataGridViewTelefonok.Rows[kivalasztott_sor_index].Cells["ar"].Value;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Program.sql.CommandText = "UPDATE telefon SET marka=@marka, tipus=@tipus, ar=@ar WHERE id=@id";
            Program.sql.Parameters.Clear();
            int sor_index = dataGridViewTelefonok.SelectedRows[0].Index;
            Program.sql.Parameters.AddWithValue("@id", (int)dataGridViewTelefonok.Rows[sor_index].Cells["id"].Value);
            Program.sql.Parameters.AddWithValue("@marka",textBox1.Text);
            Program.sql.Parameters.AddWithValue("@tipus",textBox2.Text);
            Program.sql.Parameters.AddWithValue("@ar",numericUpDown1.Value);
            try
            {
                Program.sql.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DataGridView_Telefonok_Update();
        }
    }
}
