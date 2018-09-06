using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Service.Dto.Menu
{
    public class MenuAuthDto
    {
        private int _id;
        private int _pId;
        private string _name;

        public int id { get => _id; set => _id = value; }
        public int pId { get => _pId; set => _pId = value; }
        public string name { get => _name; set => _name = value; }
    }
}
