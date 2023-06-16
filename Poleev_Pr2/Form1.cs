using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poleev_Pr2
{
    public partial class Form1 :Form
    {
        PhoneBook PhoneBook;
     
        public Form1 ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            PhoneBook = new PhoneBook();
            PhoneBookLoader.Load(PhoneBook, "PhoneBock.xlsx", dataGridView1);
        }

        private void Addbutton_Click (object sender, EventArgs e)
        {
            string name = AddNametextBox.Text;
            string phone = AddPhonetextBox.Text;
            if (CheckNumber(phone, name))
            {
                PhoneBook.AddUser(name, phone, dataGridView1);
            }
        }
        private bool CheckNumber (string number, string name)
        {
            try
            {
                if (number.Length != 14)
                {
                    throw new Exception("Вы ввели не все символы в номере");
                }
                if (number[0] != '(')
                {
                    throw new Exception("Неправильный формат номера");
                }
                if (number[4] != ')')
                {
                    throw new Exception("Неправильный формат номера");
                }
                if (number[8] != '-')
                {
                    throw new Exception("Неправильный формат номера");
                }
                if (number[11] != '-')
                {
                    throw new Exception("Неправильный формат номера");
                }
                if (name.Length == 0)
                    throw new Exception("Вы не ввели имя");
                return true;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void Deletebutton_Click (object sender, EventArgs e)
        {
            PhoneBook.RemoveUser(dataGridView1.SelectedRows[0].Index, dataGridView1);
        }

        private void dataGridView1_CellContentClick (object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Searchbutton_Click (object sender, EventArgs e)
        {
            PhoneBook.FindForName(DeletetextBox.Text, dataGridView1);
        }

        private void button1_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
