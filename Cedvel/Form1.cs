using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cedvel
{
    public partial class Form1 : Form
    {
        public int id { get; set; }
        public int AutoIncrement { get; set; }
        public List<Person> people { get; set; } 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            people = new List<Person>();
            Person person = new Person()
            {
                Id = 1,
               Name = "Rufat",
               Surname = "Gasimov",
               Email = "rufatfq@code.edu.az"

            };
            people.Add(person);
            AutoIncrement = 1;
            FillList();
        }

        public void FillList()
        {
            dgv.DataSource = null;
            dgv.DataSource = people;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {

            Person person = new Person()
            {
                Id = ++AutoIncrement,
                Name = txbName.Text,
                Surname = txbSurname.Text,
                Email = txbEmail.Text
            };
            people.Add(person);
            FillList();
        }

        private void dgv_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
            var person = people.Where(p => p.Id == id).FirstOrDefault();
            txbEmail.Text = person.Email;
            txbName.Text = person.Name;
            txbSurname.Text = person.Surname;
            btnUpdate.Visible = true;
            btnRemove.Visible = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                var person = people.Where(p => p.Id == id).FirstOrDefault();
                people.Remove(person);
                FillList();
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("You have clicked Cancel Button");
                //Some task…  
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var person = people.Where(p => p.Id == id).FirstOrDefault();
            person.Name = txbName.Text;
            person.Surname = txbSurname.Text;
            person.Email = txbEmail.Text;
            FillList();
        }
    }
}
