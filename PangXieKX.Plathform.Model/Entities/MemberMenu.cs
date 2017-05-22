using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangXieKX.Plathform.Model.Entities
{
    public class MemberMenu
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>		
        public string MenuName { get; set; }
        /// <summary>
        /// 父级菜单Id
        /// </summary>		
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单链接地址
        /// </summary>		
        public string MenuUrl { get; set; }
        /// <summary>
        /// 菜单图标样式
        /// </summary>		
        public string MenuIcon { get; set; }
    }
}
