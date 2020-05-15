using contacts.logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace contacts
{
    public partial class FormContact : Form
    {
        private Contact Contact = null;
        private LogicCore LogicCore = null;
        private BindingSource bindingSource = new BindingSource();
        public List<Phone> newPhones = new List<Phone>();
        public bool flag1;
        public FormContact(Contact contact, bool flag, LogicCore core)
        {
            InitializeComponent();
            LogicCore = core;
            Contact = contact;
            flag1 = flag;
            Load += FormContact_Load;
            newPhones = Contact.Numbers;

            dataGridView1.DataSource = bindingSource;
            Numbers.DataPropertyName = "Number";
            Types.DataSource = Enum.GetValues(typeof(PhoneType)).Cast<PhoneType>().Select(p => new { Name = Enum.GetName(typeof(PhoneType), p), Value = (int)p }).ToList();
            Types.DisplayMember = "Name";
            Types.ValueMember = "Name";
            Types.DataPropertyName = "Type";
            bindingSource.DataSource = Contact.Numbers;

            dataGridView1.Columns["Contact_id"].Visible = false;
        }

        private void FormContact_Load(object sender, EventArgs e)
        {
            txbLName.Text = Contact.LastName;
            txbMail.Text = Contact.Email;
            txbName.Text = Contact.Name;
            txbSecName.Text = Contact.SecondName;
            dtBithday.Text = Contact.Bithday;
            if (Contact.ImageBytes != null)
            {
                MemoryStream ms = new MemoryStream(Contact.ImageBytes);
                Image returnImage = Image.FromStream(ms);
                picB1.Image = returnImage;
            }
            if (flag1 == true) { enterName.Visible = true; }
            else { bCreate.Text = "Сохранить"; }

        }


        private void picB1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OPF = new OpenFileDialog())
            {
                OPF.InitialDirectory = "c:\\";
                OPF.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                OPF.RestoreDirectory = true;

                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    picB1.Image = Image.FromFile(OPF.FileName);
                    Contact.ImageBytes = File.ReadAllBytes(OPF.FileName);
                }
            }

        }
        public Contact SaveChangesContact(Contact sContact)
        {
            List<Phone> newPhone = new List<Phone>();
            var i = dataGridView1.Rows.Count - 1;
            var count = 0;
            while (count < i)
            {
                newPhone.Add(new Phone
                {
                    Type = (PhoneType)(dataGridView1[1, count].Value),
                    Contact_id = sContact.Id,
                    Number = (string)(dataGridView1[0, count].Value.ToString()),

                });
                count++;
            }
            sContact.Name = txbName.Text;
            sContact.LastName = txbLName.Text;
            sContact.SecondName = txbSecName.Text;
            sContact.Bithday = dtBithday.Text;
            sContact.Email = txbMail.Text;
            sContact.Numbers.Clear();
            sContact.Numbers = newPhone;


            return sContact;
        }
        
       
        private void loadNewContactToDataBase(Contact sContact)
        {

            Int32 newProdID = 0;
            Int32 idNum = 0;
            string connectString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PhoneContacts; Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                using (SqlCommand command = new SqlCommand("INSERT INTO Contacts(Name,LastName,SecondName,Email,Bithday,Image) VALUES(@Name,@LastName,@SecondName,@Email,@Bithday,@Image)" + "SELECT CAST(scope_identity() AS int)", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", txbName.Text));
                    if (String.IsNullOrEmpty(txbLName.Text)) { command.Parameters.Add(new SqlParameter("@LastName", DBNull.Value)); }
                    else command.Parameters.Add(new SqlParameter("LastName", txbLName.Text));
                    if (String.IsNullOrEmpty(txbSecName.Text)) { command.Parameters.Add(new SqlParameter("@SecondName", DBNull.Value)); }
                    else command.Parameters.Add(new SqlParameter("SecondName", txbSecName.Text));
                    if (String.IsNullOrEmpty(txbMail.Text)) { command.Parameters.Add(new SqlParameter("@Email", DBNull.Value)); }
                    else command.Parameters.Add(new SqlParameter("Email", txbMail.Text));
                    if (String.IsNullOrEmpty(dtBithday.Text)) { command.Parameters.Add(new SqlParameter("@Bithday", DBNull.Value)); }
                    else command.Parameters.Add(new SqlParameter("Bithday", dtBithday.Text));
                    if (sContact.ImageBytes == null) { command.Parameters.Add("@Image", System.Data.SqlDbType.VarBinary, -1).Value = DBNull.Value; }
                    else command.Parameters.Add(new SqlParameter("Image", sContact.ImageBytes));
                    try
                    {
                        newProdID = (Int32)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                var i = dataGridView1.Rows.Count - 1;
                var count = 0;
                while (count < i)
                {
                    var number = dataGridView1[0, count].FormattedValue.ToString();
                    var name = dataGridView1[1, count].FormattedValue.ToString();
                    using (SqlCommand command = new SqlCommand("Select id from NumberTypes Where Name=@Name", connection))
                    {
                        command.Parameters.Add(new SqlParameter("Name", name));
                        using (SqlDataReader sqlReader = command.ExecuteReader())
                        {
                            if (sqlReader.Read())
                            {
                                idNum = Convert.ToInt32(sqlReader[0]);
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand("INSERT INTO Numbers (Phone,Contact_id,Type_id) Values (@Phone , @Contact_id , @Type_id)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("Phone", number));
                        command.Parameters.Add(new SqlParameter("Contact_id", newProdID));
                        command.Parameters.Add(new SqlParameter("Type_id", idNum));
                        command.ExecuteNonQuery();

                    }
                    count++;
                }
                connection.Close();
            }
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            if (flag1 == true)
            {
                loadNewContactToDataBase(Contact);
            }
            else
            {
                SaveChangesContact(Contact);
                LogicCore.SaveContactToDB(Contact);
            }

            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
            if (column.Name == "num" || column.Name == "typen")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Это значение не может быть пустым";
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = null;
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text.Length > 0) { enterName.Visible = false; }
            else { enterName.Visible = true; }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //if (!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
            //{
            //  e.ThrowException = false;
            // }
        }

    }
}
