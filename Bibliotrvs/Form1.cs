using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 


namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            datacartisql();
            panels();
        }
        private void panels()
        {
            panel3.Visible = false;
            panel4.Visible = false; 
            panel5.Visible = false;
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UBC4JA8\\SQLEXPRESS;Initial Catalog=CEITI;Integrated Security=True");
        private void datacartisql()
        {
            SqlCommand cmd = new SqlCommand("Select id ,denum as Denumire , autor as Autor , stock as Stock from carti ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font ("Verdana",10,FontStyle.Bold);

        }
        private void dataelevisql()
        {
            SqlCommand cmd = new SqlCommand("Select Id , Numele , Prenumele , Grupa  from Elevi ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);

        }

        private void datedatoriisql()
        {
            SqlCommand cmd = new SqlCommand("Select Id,   Numele_elev as Nume , Prenumele_elev as Prenume , Denumirea_carte as Cartea , Autor_carte as Autor  from Datorii ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();
            textBox2.Text = selectedrow.Cells[1].Value.ToString();
            textBox3.Text = selectedrow.Cells[2].Value.ToString();
            textBox4.Text = selectedrow.Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into carti(id,denum,autor,stock)values (@id,@denumirea,@autor,@stock)" , conn);
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            cmd.Parameters.AddWithValue("denumirea", textBox2.Text);
            cmd.Parameters.AddWithValue("autor", textBox3.Text);
            cmd.Parameters.AddWithValue("stock", textBox4.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datacartisql();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update carti set denum=@denumirea , autor=@autor , stock=@stock where id=@id", conn);
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            cmd.Parameters.AddWithValue("denumirea", textBox2.Text);
            cmd.Parameters.AddWithValue("autor", textBox3.Text);
            cmd.Parameters.AddWithValue("stock", textBox4.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datacartisql();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from carti where id=@id",conn);
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datacartisql();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select id ,denum as Denumire , autor as Autor , stock as Stock from carti where denum Like @denumirea+'%' ", conn);
            cmd.Parameters.AddWithValue("denumirea", textBox2.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button18.Visible = true;
            button5.Visible = true;
            button15.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button18.Visible = false;
            dataelevisql();
            button5.Visible = false;
            button15.Visible = false;
            panel4.Visible = true;
            panel3.Visible = true;
           panel5.Visible = false;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView2.Rows[index];
            textBox10.Text = selectedrow.Cells[0].Value.ToString();
            textBox9.Text = selectedrow.Cells[1].Value.ToString();
            textBox8.Text = selectedrow.Cells[2].Value.ToString();
            textBox7.Text = selectedrow.Cells[3].Value.ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select id ,denum as Denumire , autor as Autor , stock as Stock from carti where denum Like @denumirea ", conn);
            cmd.Parameters.AddWithValue("denumirea", textBox1.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select id ,denum as Denumire , autor as Autor , stock as Stock from carti where autor Like @autor+'%' ", conn);
            cmd.Parameters.AddWithValue("autor", textBox3.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into Elevi(Id,Numele,Prenumele,Grupa)values (@id,@numele,@prenumele,@grupa)", conn);
            cmd.Parameters.AddWithValue("id", textBox10.Text);
            cmd.Parameters.AddWithValue("numele", textBox9.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox8.Text);
            cmd.Parameters.AddWithValue("grupa", textBox7.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            dataelevisql();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            textBox10.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Elevi set Numele=@numele ,Prenumele=@prenumele,Grupa=@grupa where id=@id", conn);
            cmd.Parameters.AddWithValue("id", textBox10.Text);
            cmd.Parameters.AddWithValue("numele", textBox9.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox8.Text);
            cmd.Parameters.AddWithValue("grupa", textBox7.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            dataelevisql();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Elevi where id=@id", conn);
            cmd.Parameters.AddWithValue("id", textBox10.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            dataelevisql();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Id , Numele , Prenumele , Grupa  from Elevi where Numele=@nume ", conn);
            cmd.Parameters.AddWithValue("nume", textBox9.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Id , Numele , Prenumele , Grupa  from Elevi where Prenumele=@prenume ", conn);
            cmd.Parameters.AddWithValue("prenume", textBox8.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Id , Numele , Prenumele , Grupa  from Elevi where Grupa=@grupa ", conn);
            cmd.Parameters.AddWithValue("grupa", textBox7.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select id ,denum as Denumire , autor as Autor , stock as Stock from carti ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Id , Numele , Prenumele , Grupa  from Elevi ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button18.Visible = false;
            datedatoriisql();
            button5.Visible = false;
            button15.Visible = false;
            panel4.Visible = true;
            panel3.Visible = true;
            panel5.Visible = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView3.Rows[index];
            textBox13.Text = selectedrow.Cells[0].Value.ToString();
            textBox5.Text = selectedrow.Cells[1].Value.ToString();
            textBox6.Text = selectedrow.Cells[2].Value.ToString();
            textBox11.Text = selectedrow.Cells[3].Value.ToString();
            textBox12.Text = selectedrow.Cells[4].Value.ToString();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into Datorii(Id,Numele_elev,Prenumele_elev,Denumirea_carte,Autor_carte) values (@id,@nume,@prenume,@denumire,@autor)",conn);
            SqlCommand cmd1 = new SqlCommand("Update Carti set stock=stock-1 where denum=@denumire and autor=@autor ",conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("nume", textBox5.Text);
            cmd.Parameters.AddWithValue("prenume", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            cmd1.Parameters.AddWithValue("id", textBox13.Text);
            cmd1.Parameters.AddWithValue("nume", textBox5.Text);
            cmd1.Parameters.AddWithValue("prenume", textBox6.Text);
            cmd1.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd1.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Datorii where Id=@id", conn);
            SqlCommand cmd1 = new SqlCommand("Update Carti set stock=stock+1 where denum=@denumire and autor=@autor ", conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("nume", textBox5.Text);
            cmd.Parameters.AddWithValue("prenume", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            cmd1.Parameters.AddWithValue("id", textBox13.Text);
            cmd1.Parameters.AddWithValue("nume", textBox5.Text);
            cmd1.Parameters.AddWithValue("prenume", textBox6.Text);
            cmd1.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd1.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Datorii set Numele_elev=@numele,Prenumele_elev=@prenumele,Denumirea_carte=@denumire,Autor_carte=@autor where Id=@id", conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("numele", textBox5.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }

        private void button28_Click(object sender, EventArgs e)

        {

            SqlCommand cmd = new SqlCommand("Select Id,   Numele_elev as Nume , Prenumele_elev as Prenume , Denumirea_carte as Cartea , Autor_carte as Autor  from Datorii ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Numele_elev=@numele,Prenumele_elev=@prenumele,Denumirea_carte=@denumire,Autor_carte=@autor from Datorii where Numele_elev=@numele", conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("numele", textBox5.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Numele_elev=@numele,Prenumele_elev=@prenumele,Denumirea_carte=@denumire,Autor_carte=@autor from Datorii where Prenumele_elev=@prenumele", conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("numele", textBox5.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Numele_elev=@numele,Prenumele_elev=@prenumele,Denumirea_carte=@denumire,Autor_carte=@autor from Datorii where Denumirea_carte=@denumire", conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("numele", textBox5.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Numele_elev=@numele,Prenumele_elev=@prenumele,Denumirea_carte=@denumire,Autor_carte=@autor from Datorii where Autor_carte=@autor", conn);
            cmd.Parameters.AddWithValue("id", textBox13.Text);
            cmd.Parameters.AddWithValue("numele", textBox5.Text);
            cmd.Parameters.AddWithValue("prenumele", textBox6.Text);
            cmd.Parameters.AddWithValue("denumire", textBox11.Text);
            cmd.Parameters.AddWithValue("autor", textBox12.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            datedatoriisql();
        }
    }
}
