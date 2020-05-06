using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace contacts.logic
{
    public class LogicCore
    {
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public LogicCore()
        {

        }


        public bool Save(Contact contacts)
        {
            //save list contact

            List<Phone> phones = new List<Phone>();
            phones = contacts.Numbers;
            int i = phones.Count;
            string connectString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PhoneContacts; Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                using (SqlCommand command = new SqlCommand("INSERT INTO Contacts VALUES(@Name,@LastName,@SecondName,@Email,@Bithday)", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", contacts.Name));
                    command.Parameters.Add(new SqlParameter("LastName", contacts.LastName));
                    command.Parameters.Add(new SqlParameter("SecondName", contacts.SecondName));
                    command.Parameters.Add(new SqlParameter("Email", contacts.Email));
                    command.Parameters.Add(new SqlParameter("Bithday", contacts.Bithday));
                    command.Parameters.Add(new SqlParameter("Image", contacts.ImageBytes));
                }
                using (SqlCommand command = new SqlCommand("INSERT INTO Numbers VALUES(@Phone,@Type_id,@Contact_id)", connection))
                {

                }
                connection.Close();
            }
            return false;
        }

        public void SaveContactToDB(Contact sContact)
        {
            Phones = sContact.Numbers;
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

                using (SqlCommand command = new SqlCommand("Update Numbers Set Phone=@Phone, Type_id=(Select id from NumberTypes Where Name=@Name) where Contact_id=@id", connection))
                {
                    foreach (var i in Phones)
                    {
                        command.Parameters.Add(new SqlParameter("id", sContact.Id));
                        command.Parameters.Add(new SqlParameter("Phone", i.Number));
                        command.Parameters.Add(new SqlParameter("Name", i.Type));

                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        public void LoadFirst()
        {
            Contacts.Clear();
            Phones.Clear();
            string connString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PhoneContacts; Integrated Security=True;";
            SqlConnection con = new SqlConnection(connString);
            string sqlQueryString = "SELECT* from Contacts ";
            SqlCommand cmd = new SqlCommand(sqlQueryString, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Contacts.Add(new Contact
                {
                    Id = (int)dataReader["id"],
                    Email = dataReader["Email"] as string,
                    Name = dataReader["Name"] as string,
                    LastName = dataReader["LastName"] as string,
                    SecondName = dataReader["SecondName"] as string,
                    ImageBytes = dataReader["Image"] as byte[],
                    Bithday = dataReader["Bithday"] as string
                });
            }
            con.Close();
        }

        public void LoadContacts(int idCon)
        {
            Contacts.Clear();
            Phones.Clear();

            string connString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PhoneContacts; Integrated Security=True;";
            SqlConnection con = new SqlConnection(connString);

            string sqlQueryString2 = "Select * From Numbers ";
            SqlCommand cmd2 = new SqlCommand(sqlQueryString2, con);
            con.Open();
            SqlDataReader datareader1 = cmd2.ExecuteReader();
            while (datareader1.Read())
            {
                Phones.Add(new Phone
                {
                    Contact_id = (int)datareader1["Contact_id"],
                    Number = datareader1["Phone"] as string,
                    Type = (PhoneType)datareader1["Type_id"]
                });
            }

            con.Close();
            string sqlQueryString = "SELECT* from  Contacts ";
            SqlCommand cmd = new SqlCommand(sqlQueryString, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Contacts.Add(new Contact
                {
                    Id = (int)dataReader["id"],
                    Email = dataReader["Email"] as string,
                    Name = dataReader["Name"] as string,
                    LastName = dataReader["LastName"] as string,
                    SecondName = dataReader["SecondName"] as string,
                    ImageBytes = dataReader["Image"] as byte[],
                    Bithday = dataReader["Bithday"] as string,
                    Numbers = Phones.FindAll(Phone => Phone.Contact_id == idCon)
                });
            }
            con.Close();
        }

        public Contact FindContact(int idCon)
        {
            LoadContacts(idCon);
            Contact resualt = Contacts.Find(cn => cn.Id == idCon);

            return resualt;
        }
        public void DelContact(int idCon)
        {
            string connString = @"Data Source=.\SQLEXPRESS; Initial Catalog=PhoneContacts; Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                string sqlQueryString2 = "delete from Contacts where id=@id" +  " delete from Numbers where Contact_id=@id";               
                using (SqlCommand command = new SqlCommand(sqlQueryString2, connection))
                {
                    command.Parameters.Add(new SqlParameter("id", idCon));

                    command.ExecuteNonQuery();
                }
             
            }
        }
    }
}
