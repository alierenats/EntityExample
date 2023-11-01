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
using System.Collections;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.StudentTables.Where(x => x.NAME == TxtName.Text).ToList();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

            string search = TxtName.Text;
            var values = from item in db.StudentTables
                         where item.NAME.Contains(search)
                         select item;
            dataGridView1.DataSource = values.ToList();
        }

        private void TxtSurname_TextChanged(object sender, EventArgs e)
        {
            string searchSurname = TxtSurname.Text;
            var valueSurname = from item in db.StudentTables
                               where item.SURNAME.Contains(searchSurname)
                               select item;
            dataGridView1.DataSource = valueSurname.ToList();
        }

        private void TxtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnLinq_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                List<StudentTable> list1 = db.StudentTables.OrderBy(x => x.NAME).ToList();
                dataGridView1.DataSource = list1;
            }
            if (radioButton2.Checked == true)
            {
                List<StudentTable> list2 = db.StudentTables.OrderByDescending(x => x.NAME).ToList();
                dataGridView1.DataSource = list2;
            }
            if (radioButton3.Checked == true)
            {
                List<StudentTable> list3 = db.StudentTables.OrderByDescending(x => x.NAME).Take(5).ToList();
                dataGridView1.DataSource = list3;
            }

            if (radioButton4.Checked == true)
            {
                int sum = db.StudentTables.Count();
                MessageBox.Show(sum.ToString(), "Student");
            }

            if (radioButton5.Checked == true)
            {
                var avg1 = db.TableGrades.Average(x => x.EXAM1);
                MessageBox.Show("EXAM 1 AVERAGE :" + avg1.ToString());
            }

            if (radioButton6.Checked == true)
            {
                var avg2 = db.TableGrades.Average(x => x.EXAM2);
                MessageBox.Show("EXAM 2 AVERAGE :" + avg2.ToString());
            }
            if (radioButton7.Checked == true)
            {
                var avg3 = db.TableGrades.Average(x => x.EXAM3);
                MessageBox.Show("EXAM 3 AVERAGE :" + avg3.ToString());
            }

            if (radioButton8.Checked == true)
            {
                var avg1 = db.TableGrades.Average(x => x.EXAM3);
                dataGridView1.DataSource = db.TableGrades.Where(x => x.EXAM3 > avg1).ToList();

            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            var query1 = from d1 in db.TableGrades
                         join d2 in db.StudentTables
                         on d1.STDNT equals d2.ID
                         join d3 in db.TableGrades
                         on d1.CLASS equals d3.GRADEID

                         select new
                         {
                             student = d2.NAME + " " + d2.SURNAME,
                             CLASS = d3.CLASS,
                             EXAM1 = d1.EXAM1,
                             EXAM2 = d1.EXAM2,
                             EXAM3 = d1.EXAM3,

                         };
            dataGridView1.DataSource = query1.ToList();

        }

        private void PassForm2_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }

    }
}
//DB-FIRST