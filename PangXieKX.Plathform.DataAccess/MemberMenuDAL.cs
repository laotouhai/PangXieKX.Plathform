using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PangXieKX.Plathform.DataAccess.Common;
using PangXieKX.Plathform.Model.Entities;
using PangXieKX.Plathform.IDataAccess;
using PangXieKX.Plathform.DB.Dapper;
using PangXieKX.Plathform.DB;

namespace PangXieKX.Plathform.DataAccess
{
    public class MemberMenuDAL : BaseDataAccess<MemberMenu>, IMemberMenuDAL
    {
        /// <summary>
        /// 获得菜单列表
        /// </summary>
        /// <param name="predList">查询条件对象</param>
        /// <returns></returns>
        public IEnumerable<MemberMenu> GetMenuList(object predList)
        {
            return GetList(predList);
        }
    }
}
