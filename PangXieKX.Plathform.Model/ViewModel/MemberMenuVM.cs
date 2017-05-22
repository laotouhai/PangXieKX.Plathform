using PangXieKX.Plathform.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangXieKX.Plathform.Model.ViewModel
{
    public class MemberMenuVM : MemberMenu
    {
        /// <summary>
        /// 菜单子节点实体集合
        /// </summary>
        public List<MemberMenuVM> Children;

    }
}
