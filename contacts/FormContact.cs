using contacts.logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;


namespace contacts
{
    public partial class FormContact : Form
    {
        private Contact Contact = null;
        private Phone Phone = null;
        bool flag = false;
        private BindingSource bindingSource = new BindingSource();
        public List<Phone> newPhones = new List<Phone>();
        //List<EnumModel> enums = ((PhoneType[])Enum.GetValues(typeof(PhoneType))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();

        public FormContact(Contact contact)
        {
            InitializeComponent();
            Contact = contact;
            Load += FormContact_Load;
            newPhones = Contact.Numbers;

            dataGridView1.DataSource = bindingSource;
            //bindingSource.DataSource = Contact.Numbers;
            Numbers.DataPropertyName = "Number";
            Types.DataSource = Enum.GetValues(typeof(PhoneType)).Cast<PhoneType>().Select(p => new { Name = Enum.GetName(typeof(PhoneType), p), Value = (int)p }).ToList();     //Enum.GetValues(typeof(PhoneType));  
            Types.DisplayMember = "Name";
            Types.ValueMember = "Value";
            Types.DataPropertyName = "Type";
            bindingSource.DataSource = Contact.Numbers;

            // dataGridView1.Columns["Number"].Visible = true;
            //dataGridView1.Columns["Type"].Visible = true;
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
            if (txbName.Text.Length > 0) { bCreate.Text = "Сохранить"; flag = true; }
            else { enterName.Visible = true; flag = false; }

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
            var i = dataGridView1.Rows.Count-1;
            var count = 0;
            while (count < i)
            {
                newPhone.Add(new Phone
                {
                    Type = (PhoneType)(dataGridView1[1, count].Value),
                    Contact_id = sContact.Id,
                    Number = (string)(dataGridView1[0, count].Value.ToString()),

                }) ;
                Console.WriteLine((PhoneType)(dataGridView1[1, count].Value));
                Console.WriteLine(dataGridView1[0, count].Value.ToString());
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
        public void SaveContactToDB(Contact sContact)
        {
            newPhones = sContact.Numbers;
            string connectString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PhoneContacts; Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                using (SqlCommand command = new SqlCommand("Update Contacts Set Name=@Name , LastName=@LastName, SecondName= @SecondName , Email=@Email , Bithday=@Bithday , Image = @Image Where Id=@id )", connection))
                {

                    command.Parameters.Add(new SqlParameter("id", sContact.Id));
                    command.Parameters.Add(new SqlParameter("Name", sContact.Name));
                    if (String.IsNullOrEmpty(sContact.LastName)) { command.Parameters.AddWithValue("@LastName", DBNull.Value); }
                    else command.Parameters.Add(new SqlParameter("LastName", sContact.LastName));
                    if (String.IsNullOrEmpty(sContact.SecondName)) { command.Parameters.AddWithValue("@SecondName", DBNull.Value); }
                    else command.Parameters.Add(new SqlParameter("SecondName", sContact.SecondName));
                    if (String.IsNullOrEmpty(sContact.Email)) { command.Parameters.AddWithValue("@Email", DBNull.Value); }
                    else command.Parameters.Add(new SqlParameter("Email", sContact.Email));
                    if (String.IsNullOrEmpty(sContact.Bithday)) { command.Parameters.AddWithValue("@Bithday", DBNull.Value); }
                    command.Parameters.Add(new SqlParameter("Bithday", sContact.Bithday));
                    if (sContact.ImageBytes == null) { command.Parameters.Add("@Image", System.Data.SqlDbType.VarBinary, -1).Value = DBNull.Value; }
                    command.Parameters.Add(new SqlParameter("Image", sContact.ImageBytes));
                }


                using (SqlCommand command = new SqlCommand("Update Numbers Set Phone=@Phone, Type_id=(Select id from NumberTypes Where Name='@Name') where Contact_id=@id", connection)) 
                {
                   foreach (var i in newPhones)
                   {              
                        command.Parameters.Add(new SqlParameter("id", sContact.Id));
                        command.Parameters.Add(new SqlParameter("Phone", i.Number));
                        command.Parameters.Add(new SqlParameter("Name", i.Type));
                        command.ExecuteNonQuery();
                   }
                }
            }
        }
        private void loadNewContactToDataBase(Contact sContact)
        {

            Int32 newProdID = 0;
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
                Console.WriteLine(i);
                while (count < i)
                {
                    var number = dataGridView1[0, count].FormattedValue;
                    var name = dataGridView1[1, count].FormattedValue;
                    Console.WriteLine(number);
                    Console.WriteLine(name);
                    using (SqlCommand command = new SqlCommand("INSERT INTO Numbers Values Phone=@Phone Contact_id=@Contact_id Type_id=2)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("Phone", dataGridView1[0, count].FormattedValue.ToString()));
                        command.Parameters.Add(new SqlParameter("Contact_id", newProdID));
                        command.Parameters.Add(new SqlParameter("Name", dataGridView1[1, count].FormattedValue.ToString()));
                    }
                    count++;
                }
                connection.Close();

            }

        }

        private void bCreate_Click(object sender, EventArgs e)
        {

            //  if (flag == true && txbName.Text.Length > 0)
            //  {
            // loadNewContactToDataBase(Contact);
            //   }
            //  else if (txbName.Text.Length > 0)
            //   {
            SaveChangesContact(Contact);
            SaveContactToDB(Contact);
            ///    }

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {

            if (enterName.Visible == true)
            {
                enterName.Visible = false;
            }
            Console.WriteLine(flag.ToString());
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
            if (txbName.Text.Length > 0) { flag = true; }
            else { flag = false; enterName.Visible = true; }

        }

        // private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        //  {
        //     switch (e.ColumnIndex)
        //    {
        //        case 0: e.Value = newPhones[e.RowIndex].Number; break;
        //        case 1: e.Value = newPhones[e.RowIndex].Type; break;
        //    }
        // }

        //  private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        //  {
        //    switch (e.ColumnIndex)
        //    {
        //       case 0: newPhones[e.RowIndex].Number = e.Value.ToString(); break;
        //       case 1: Type.DataPropertyName = ((PhoneType)(e.Value)).ToString(); // newPhones[e.RowIndex].Type = (PhoneType)(e.Value);
        //                break;
        //   }
        //  }
    }
}
