using contacts.logic;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace contacts
{
    public partial class FormMain1 : Form
    {
        private LogicCore LogicCore = null;
        private BindingSource bindingSource1 = new BindingSource();
        public int idCell = 1;
        public bool flag = true;

        public FormMain1(LogicCore core)
        {
            InitializeComponent();

            LogicCore = core;

            core.LoadFirst();
            dataGridViewMain.DataSource = bindingSource1;
            bindingSource1.DataSource = core.Contacts;
            ColumnFIO.DataPropertyName = "FIO";
            dataGridViewMain.Columns["Name"].Visible = false;
            dataGridViewMain.Columns["LastName"].Visible = false;
            dataGridViewMain.Columns["ImageBytes"].Visible = false;
            dataGridViewMain.Columns["Bithday"].Visible = false;
            dataGridViewMain.Columns["SecondName"].Visible = false;
            dataGridViewMain.Columns["Email"].Visible = false;
            dataGridViewMain.Columns["Id"].Visible = false;
            dataGridViewMain.Columns["FIO"].Visible = false;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void butDel_Click(object sender, EventArgs e)
        {
            Console.WriteLine(idCell);
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LogicCore.DelContact(idCell);
                   
                    dataGridViewMain.Rows.RemoveAt(dataGridViewMain.CurrentRow.Index);
                    dataGridViewMain.Refresh();
               
            }
        }



        private void butAdd_Click(object sender, EventArgs e)
        {
            var f = new FormContact(new Contact(),flag,LogicCore);
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();            
        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridViewMain.Refresh();

            //Код для обновления
        }
        
        private void butEdit_Click(object sender, EventArgs e)
        {
            flag = false;
            var f = new FormContact(LogicCore.FindContact(idCell),flag,LogicCore);

            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.ShowDialog();
            
        }




        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idCell = Convert.ToInt32(this.dataGridViewMain.CurrentRow.Cells["Id"].Value);
        }
    }
}

