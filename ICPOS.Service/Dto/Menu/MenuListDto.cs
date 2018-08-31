using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Service.Dto.Menu
{
    public class MenuListDto
    {
        private string _Name;
        private string _Value;
        private bool _Checked;
        private object _List;

        public string name { get => _Name; set => _Name = value; }
        public string value { get => _Value; set => _Value = value; }
        public bool Checked { get => _Checked; set => _Checked = value; }
        public object list { get => _List; set => _List = value; }
    }

    #region Json格式
//    {
//	"code": 0,
//	"msg": "获取成功",
//	"data": {
//		"trees": [{
//				"name": "用户管理",
//				"value": "xsgl",
//				"checked": true,
//				"list": [{
//					"name": "用户组",
//					"value": "xsgl-basic",
//					"checked": true,
//					"list": [{
//							"name": "本站用户",
//							"value": "xsgl-basic-xsxm",
//							"checked": true,
//							"list": [{
//									"name": "用户列表",
//									"value": "xsgl-basic-xsxm-readonly",
//									"checked": true
//                                },
//								{
//									"name": "新增用户",
//									"value": "xsgl-basic-xsxm-editable",
//									"checked": false
//								}
//							]
//						},
//						{
//							"name": "第三方用户",
//							"value": "xsgl-basic-xsxm",
//							"checked": true,
//							"list": [{
//								"name": "用户列表",
//								"value": "xsgl-basic-xsxm-readonly",
//								"checked": true
//							}]
//						}
//					]
//				}]
//			},
//			{
//				"name": "用户组管理",
//				"value": "sbgl",
//				"checked": true,
//				"list": [{
//						"name": "角色管理",
//						"value": "sbgl-sbsjlb",
//						"checked": true,
//						"list": [{
//								"name": "添加角色",
//								"value": "sbgl-sbsjlb-dj",
//								"checked": true
//							},
//							{
//								"name": "角色列表",
//								"value": "sbgl-sbsjlb-yl",
//								"checked": false
//							}
//						]
//					},
//					{
//						"name": "管理员管理",
//						"value": "sbgl-sbsjlb",
//						"checked": true,
//						"list": [{
//								"name": "添加管理员",
//								"value": "sbgl-sbsjlb-dj",
//								"checked": true
//							},
//							{
//								"name": "管理员列表",
//								"value": "sbgl-sbsjlb-yl",
//								"checked": false
//							}
//						]
//					}
//				]
//			}
//		]
//	}
//}
    #endregion
}
