using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Common
{
    public class ResultJson
    {
        private string _code;
        private string _msg;
        private string _count;
        private Object _data;

        /// <summary>
        /// 状态
        /// </summary>
        public string code { get => _code; set => _code = value; }
        /// <summary>
        /// 提示
        /// </summary>
        public string msg { get => _msg; set => _msg = value; }
        /// <summary>
        /// layui.Table数据量
        /// </summary>
        public string count { get => _count; set => _count = value; }
        /// <summary>
        /// 数据
        /// </summary>
        public Object data { get => _data; set => _data = value; }
    }
}
