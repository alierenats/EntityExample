using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityExample
{
    public partial class Form2 : Form
    {

        DbStudentEntities db = new DbStudentEntities();

        public Form2()
        {
            InitializeComponent();
        }

        private void LinqEntityForm2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dataGridView2.DataSource = db.TableGrades.Where(x => x.EXAM1 < 50).ToList();

            }

            if (radioButton2.Checked == true)
            {
                dataGridView2.DataSource = db.StudentTables.Where(x => x.NAME == "Ali").ToList();
            }

            if (radioButton3.Checked == true)
            {
                dataGridView2.DataSource = db.StudentTables.Where(x => x.NAME == textBox1.Text || x.SURNAME == textBox1.Text).ToList();
            }

            if (radioButton4.Checked == true)
            {
                //var sname = db.StudentTables.Select(x => new { sur=x.SURNAME });
                //dataGridView2.DataSource = sname.ToList();

                dataGridView2.DataSource = db.StudentTables.Select(x => new { Soyad = x.SURNAME }).ToList();
            }

            if (radioButton5.Checked == true)
            {

                var values = db.TableGrades.SelectMany(x => db.StudentTables.Where(y => y.ID == x.STDNT), (x, y) => new
                {
                    x.STDNT,
                    y.NAME,
                    y.SURNAME,
                    x.EXAM1

                });
                dataGridView2.DataSource = values.ToList();

            }

            if (radioButton6.Checked == true)
            {
                var values = db.StudentTables.OrderBy(x => x.ID).Take(3).ToList();
                dataGridView2.DataSource = values.ToList();
            }
            if (radioButton7.Checked == true)
            {
                var values = db.StudentTables.OrderByDescending(x => x.ID).Take(3).ToList();
                dataGridView2.DataSource = values.ToList();
            }

            if (radioButton8.Checked == true)
            {
                var values = db.StudentTables.OrderBy(x => x.ID).Skip(5).ToList();
                dataGridView2.DataSource = values.ToList();
            }

            if (radioButton9.Checked == true)
            {
                List<StudentTable> list1 = db.StudentTables.OrderBy(x => x.NAME).ThenByDescending(x => x.SURNAME).ToList();
                dataGridView2.DataSource = list1;


            }

        }

        private void PassForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
