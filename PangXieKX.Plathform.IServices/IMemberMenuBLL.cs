using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PangXieKX.Plathform.Model.Entities;
using PangXieKX.Plathform.Model;
using PangXieKX.Plathform.Model.ViewModel;

namespace PangXieKX.Plathform.IBusiness
{
    public interface IMemberMenuBLL : IDependency
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="predList">查询条件对象</param>
        /// <returns></returns>
        List<MemberMenuVM> GetMenuList(object predList);
    }
}
