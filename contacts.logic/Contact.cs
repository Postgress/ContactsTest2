using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace contacts.logic
{
    public class Contact
    {
        public byte[] ImageBytes { get; set; } = null;
        public string Name { get; set; } = null;
        public string LastName { get; set; } = null;
        public string SecondName { get; set; } = null;
        public string FIO { get { return $"{Name} {LastName} {SecondName}"; } }
        public string Email { get; set; } = null;
        public string Bithday { get; set; } = null;
        public int Id { get; set; } = 0;

        public List<Phone> Numbers { get; set; } = new List<Phone>();  
         
        
    }
}
