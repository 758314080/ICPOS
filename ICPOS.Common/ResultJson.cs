using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Common
{
    public class ResultJson
    {
        private string _data;
        private string _msg;
        private int _code;

        /// <summary>
        /// 状态
        /// </summary>
        public int Code { get => _code; set => _code = value; }
        /// <summary>
        /// 提示
        /// </summary>
        public string Msg { get => _msg; set => _msg = value; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get => _data; set => _data = value; }
    }
}
