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
using System.Data.Entity.Migrations;

namespace EntityExample
{
    public partial class Form1 : Form
    {

        DbStudentEntities db = new DbStudentEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection connect = new SqlConnection(@"Data Source=ERENATES\SQLEXPRESS;Initial Catalog=DbStudent;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("Select * From ClassTable", connect);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable(); 
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

            DbStudentEntities db = new DbStudentEntities();
            dataGridView1.DataSource = db.ClassTables.ToList();

        }

        private void btnList_Click(object sender, EventArgs e)
        {

            //SqlConnection connect = new SqlConnection(@"Data Source=ERENATES\SQLEXPRESS;Initial Catalog=DbStudent;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("Select * From StudentTable", connect);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

            //DbStudentEntities db = new DbStudentEntities(); 
            //dataGridView1.DataSource = db.StudentTables.ToList(); 

            var query = from item in db.StudentTables
                        select new { item.ID, item.NAME, item.SURNAME };
            dataGridView1.DataSource = query.ToList();
        }

        private void btnGradeList_Click(object sender, EventArgs e)
        {
            //SqlConnection connect = new SqlConnection(@"Data Source=ERENATES\SQLEXPRESS;Initial Catalog=DbStudent;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("Select * From TableGrade", connect);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

            //dataGridView1.Columns[5].Visible=false;

            //DbStudentEntities db = new DbStudentEntities();
            //dataGridView1.DataSource= db.TableGrades.ToList();

            var query = from item in db.TableGrades
                        select new { item.GRADEID, item.STDNT, item.CLASS };

            dataGridView1.DataSource = query.ToList();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StudentTable newStudent = new StudentTable();
            newStudent.NAME = TxtName.Text;
            newStudent.SURNAME = TxtSurname.Text;
            newStudent.ID = Convert.ToInt32(TxtStudentID.Text);
            db.StudentTables.Add(newStudent);
            db.SaveChanges();
            MessageBox.Show("successfully registered!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtStudentID.Text);
            var x = db.StudentTables.Find(id);
            if (x == null)
            {
                MessageBox.Show("Please try again!");
                return;
            }
            db.StudentTables.Remove(x);
            db.SaveChanges();
            MessageBox.Show("the deletion process was successful!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(TxtStudentID.Text);
            var x = db.StudentTables.Find(id);

            x.NAME = TxtName.Text;
            x.SURNAME = TxtSurname.Text;
            x.PICTURE = TxtPıcture.Text;
            db.SaveChanges();
            MessageBox.Show("the updated process was successful!");

        }

        private void btnProcedures_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GRADELIST();
        }
    }
}
