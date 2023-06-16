using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poleev_Pr2
{
    internal class PhoneBook
    {
        List<Contact> contacts = new List<Contact>();
        public void FindForName (string name, DataGridView table)
        {
            for (int i = 0; i < table.Rows.Count - 1; i++)
            {
                if (table[0, i].Value.ToString().Contains(name))
                {
                    table[0, i].Selected = true;
                } else
                    table[0, i].Selected = false;

            }
        }
        internal void AddContact (Contact contact)
        {
            contacts.Add(contact);
        }
        public void AddUser (string name, string phonenumber, DataGridView table)
        {
            table.Rows.Add(name, phonenumber);
        }
        public void RemoveUser (int index, DataGridView table)
        {
            try
            {
                table.Rows.RemoveAt(index);
            } 
            catch
            {
                MessageBox.Show("Вы не выделили строчку, которую хотите удалить");
            }
        }

    }
}
