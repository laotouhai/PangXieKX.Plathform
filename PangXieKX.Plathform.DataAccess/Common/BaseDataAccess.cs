using System;
using PangXieKX.Plathform.DB;
using System.Collections.Generic;
using PangXieKX.Plathform.DataAccess.DBUtils;

namespace PangXieKX.Plathform.DataAccess.Common
{
    public abstract class BaseDataAccess<T> : RepositoryBase<T>, IDisposable
            where T : class
    {
        protected BaseDataAccess()
            : base(SqlHelper.GetPerHttpRequestDBSession())
        {
        }
        public BaseDataAccess(IDBSession dbSession)
            : base(dbSession)
        {
        }

        public void Dispose()
        {

        }

        #region  成员方法
        public int Add(T memberMenu)
        {
            return Insert(memberMenu);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T memberMenu)
        {
            return Update(memberMenu);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {
            return Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T GetModel(int Id)
        {
            return GetById<T>(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="predList">查询条件对象</param>
        /// <returns></returns>
        public IEnumerable<T> GetList(object predList)
        {
            return GetList<T>(predList);
        }

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        public IEnumerable<T> GetList(int PageSize, int PageIndex)
        {
            long allRowsCount = 0;
            return GetPageList<T>(PageSize, PageIndex, out allRowsCount);
        }
        #endregion  成员方法
    }
}
