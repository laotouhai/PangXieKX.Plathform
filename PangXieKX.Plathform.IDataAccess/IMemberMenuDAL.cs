using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PangXieKX.Plathform.Model.Entities;
using PangXieKX.Plathform.Model;

namespace PangXieKX.Plathform.IDataAccess
{
    public interface IMemberMenuDAL : IDependency
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(MemberMenu memberMenu);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(MemberMenu memberMenu);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MemberMenu GetModel(int Id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="predList">查询条件对象</param>
        /// <returns></returns>
        IEnumerable<MemberMenu> GetList(object predList);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        IEnumerable<MemberMenu> GetList(int PageSize, int PageIndex);

        #endregion  成员方法
    }
}
