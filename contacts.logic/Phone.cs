using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace contacts.logic
{
    public enum PhoneType : byte
    {
        None = 0,
        Mobile = 1,
        Home = 2,
        Work = 3
    }
    public class Phone
    {
        public string Number { get; set; } = null;
        public PhoneType Type { get; set; } = PhoneType.None;
        public int Contact_id { get; set; } = 0;         
         
    }
}
