using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Service.Dto.Menu
{
    public class MenuTreeDto
    {
        private int _id;
        private string _name;
        private string _checkbox;
        private string _spread;
        private List<MenuTreeDto> _children;

        public int id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string checkbox { get => _checkbox; set => _checkbox = value; }
        public string spread { get => _spread; set => _spread = value; }
        public List<MenuTreeDto> children { get => _children; set => _children = value; }

        //name：树显示的标题
        //id：主键对应的字段名
        //children：子类对应的字段名
        //checkbox：选中对应的字段名
        //spread：是否展开对应的字段名
    }
}
