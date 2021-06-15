using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilDrawing.Class
{
    class UIHelper
    {
        public static void DataGridView(DataGridView dataGridView, List<Item> itemList)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();

            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.RowHeadersVisible = false;

            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].Name = "Name";
            dataGridView.Columns[1].Name = "Number";
            dataGridView.Columns[2].Name = "Unit";
            dataGridView.Columns[3].Name = "Note";

            foreach (Item item in itemList)
            {
                if (item.note == "TITLE")
                {
                    dataGridView.Rows.Add(item.name, "", "", "");
                }
                else if (item.note == "IGNORE")
                {
                    dataGridView.Rows.Add("", "", "", "");
                }
                else
                {
                    dataGridView.Rows.Add(item.name, MathHelper.RoundDec(item.number, 4), item.unit, item.note);
                }

            }
            dataGridView.AutoResizeColumns();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        public static void ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }
    }
}
