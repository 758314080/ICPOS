using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Service.Dto
{
    public class UserListDto
    {
        private int _Users_ID;
        private string _Role_Name;
        private string _Name;
        private string _Phone;
        private string _Email;
        private DateTime _CreateDate;
        private int _Status;
        private string _Note;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int Users_ID { get => _Users_ID; set => _Users_ID = value; }
        /// <summary>
        /// 用户角色名称
        /// </summary>
        public string Role_Name { get => _Role_Name; set => _Role_Name = value; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get => _Name; set => _Name = value; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get => _Phone; set => _Phone = value; }
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get => _Email; set => _Email = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get => _CreateDate; set => _CreateDate = value; }
        /// <summary>
        /// 启用/禁用
        /// </summary>
        public int Status { get => _Status; set => _Status = value; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get => _Note; set => _Note = value; }
    }
}
