using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICPOS.Web.Models
{
    public class Users
    {
        private int _Users_ID;
        private string _GUID;
        private int _Role_ID;
        private int _ParentID;
        private string _LoginName;
        private string _Password;
        private string _Name;
        private string _Phone;
        private string _Email;
        private DateTime _CreateDate;
        private int _Status;
        private string _Note;

        [Key]
        public int Users_ID { get => _Users_ID; set => _Users_ID = value; }
        public string GUID { get => _GUID; set => _GUID = value; }
        public int Role_ID { get => _Role_ID; set => _Role_ID = value; }
        public int ParentID { get => _ParentID; set => _ParentID = value; }
        public string LoginName { get => _LoginName; set => _LoginName = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public DateTime CreateDate { get => _CreateDate; set => _CreateDate = value; }
        public int Status { get => _Status; set => _Status = value; }
        public string Note { get => _Note; set => _Note = value; }
    }
}
