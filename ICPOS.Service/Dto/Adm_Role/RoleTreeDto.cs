using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Service.Dto.Adm_Role
{
    public class RoleTreeDto
    {
        private List<statuscode> _status;
        private List<SonTree> _data;

        public List<statuscode> status { get => _status; set => _status = value; }
        public List<SonTree> data { get => _data; set => _data = value; }
    }

    public class statuscode
    {
        private string _code;
        private string _message;

        public string code { get => _code; set => _code = "200"; }
        public string message { get => _message; set => _message = "操作成功"; }
    }

    public class SonTree
    {
        private string _id; //节点ID
        private string _parentId; //父节点ID
        private string _title; //节点名称
        private string _iconClass; //自定义图标class
        private string _children; //子节点名称
        private string _level; //层级
        private List<SoncheckArr> _checkArr; //复选框列表
        private string _isChecked; //是否选中
        private string _type; //复选框标记
        private string _basicData; //表示用户自定义需要存储在树节点中的数据

        public string id { get => _id; set => _id = value; }
        public string parentId { get => _parentId; set => _parentId = value; }
        public string title { get => _title; set => _title = value; }
        public string iconClass { get => _iconClass; set => _iconClass = value; }
        public string children { get => _children; set => _children = value; }
        public string level { get => _level; set => _level = value; }
        public List<SoncheckArr> checkArr { get => _checkArr; set => _checkArr = value; }
        public string isChecked { get => _isChecked; set => _isChecked = value; }
        public string type { get => _type; set => _type = value; }
        public string basicData { get => _basicData; set => _basicData = value; }
    }

    public class SoncheckArr
    {
        private string _type;
        private string _isChecked;

        public string type { get => _type; set => _type = value; }
        public string isChecked { get => _isChecked; set => _isChecked = value; }
    }
}
