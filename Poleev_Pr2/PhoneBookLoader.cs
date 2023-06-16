using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;

namespace Poleev_Pr2
{
    static class PhoneBookLoader
    {
        public static void Load (PhoneBook phoneBock, string filename, DataGridView table)
        {
            try
            {
                table.RowCount = 1;
                FileStream stream = File.Open($@"{filename}", FileMode.Open, FileAccess.Read);
                var reader = ExcelReaderFactory.CreateReader(stream);
                do
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string phone = reader.GetString(1);
                        Contact contact = new Contact(name, phone);
                        phoneBock.AddContact(contact);
                        table.Rows.Add(reader.GetString(0), reader.GetString(1));
                    }
                } while (reader.NextResult());
                stream.Close();
            } catch
            {
                MessageBox.Show("Такого файла нет");
            }


        }
        public static void Save (PhoneBook phoneBook, string fileName, DataGridView table)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook book = exApp.Workbooks.Add(Type.Missing);
            book.SaveAs($"{fileName}.xlsx");

            for (int i = 0; i < table.RowCount - 1; i++)
            {
                for (int j = 0; j < table.ColumnCount; j++)
                {
                    exApp.Cells[i + 1, j + 1] = table[j, i].Value.ToString();
                }
            }
            exApp.Visible = true;
        }
    }
}
