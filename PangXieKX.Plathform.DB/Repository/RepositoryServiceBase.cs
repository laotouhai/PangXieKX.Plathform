using System.Collections.Generic;
using System.Data;
using System.Linq;
using PangXieKX.Plathform.DB.Dapper;
using PangXieKX.Plathform.DB.DapperExtensions;
using PangXieKX.Plathform.DB;
using PangXieKX.Plathform.DB.Transactions;
using PangXieKX.Plathform.DB.DapperExtensions.Lambda;


namespace PangXieKX.Plathform.DB
{
    public class RepositoryServiceBase<T> : IDataRepository<T>
        where T : class
    {
        public IDBSession DBSession { get; private set; }

        protected DbConnObj GetConnObj(IDbTransaction transaction = null)
        {
            DbConnObj dbConnObj = new DbConnObj();
            dbConnObj.DbConnection = this.DBSession.Connection;
            if (null != transaction)
            {
                dbConnObj.DbConnection = transaction.Connection;
                dbConnObj.DbTransaction = transaction;
            }
            else if (null != Transaction.Current)
            {
                dbConnObj.DbConnection = Transaction.Current.DbTransactionWrapper.DbTransaction.Connection;
                dbConnObj.DbTransaction = Transaction.Current.DbTransactionWrapper.DbTransaction;
                if (this.DBSession.Connection.GetType() != dbConnObj.DbConnection.GetType())
                {
                    dbConnObj.DbConnection = this.DBSession.Connection;
                    dbConnObj.DbTransaction = null;
                }
                else
                {
                    if (this.DBSession.Connection.Database != dbConnObj.DbConnection.Database)
                    {
                        dbConnObj.DbConnection = this.DBSession.Connection;
                        dbConnObj.DbTransaction = null;
                    }
                }
            }
            return dbConnObj;
        }


        public RepositoryServiceBase(IDBSession dbSession)
        {
            if (null != dbSession)
            {
                this.DBSession = dbSession;
            }
        }

        public RepositoryServiceBase(IDataRepository<T> dataRepository)
        {
            if (null != dataRepository && null != dataRepository.DBSession)
            {
                this.DBSession = dataRepository.DBSession;
            }
        }

        #region 非传入Sql 方法


        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public T GetById(dynamic primaryId)
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.Get<T>(primaryId as object, dbType: this.DBSession.dbType);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="TReturn">返回的类型</typeparam>
        /// <param name="primaryId">主键</param>
        /// <returns></returns>
        public TReturn GetById<TReturn>(dynamic primaryId) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.Get<T, TReturn>(primaryId as object, dbType: this.DBSession.dbType);
        }


        /// <summary>
        /// 根据多个Id获取多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<T> GetByIds(IList<dynamic> ids)
        {
            var tblName = string.Format("dbo.{0}", typeof(T).Name);
            var idsin = string.Join(",", ids.ToArray<dynamic>());
            var sql = "SELECT * FROM @table WHERE Id in (@ids)";
            DbConnObj ConnObj = GetConnObj();
            IEnumerable<T> dataList = ConnObj.DbConnection.Query<T>(sql, new { table = tblName, ids = idsin });
            return dataList;
        }

        /// <summary>
        /// 根据多个Id获取多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> GetByIds<TReturn>(IList<dynamic> ids) where TReturn : class
        {
            var tblName = string.Format("dbo.{0}", typeof(T).Name);
            var idsin = string.Join(",", ids.ToArray<dynamic>());
            var sql = "SELECT * FROM @table WHERE Id in (@ids)";
            DbConnObj ConnObj = GetConnObj();
            IEnumerable<TReturn> dataList = ConnObj.DbConnection.Query<TReturn>(sql, new { table = tblName, ids = idsin });
            return dataList;
        }



        /// <summary>
        /// 获取全部数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.GetList<T>(dbType: this.DBSession.dbType);
        }


        /// <summary>
        /// 获取全部数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<TReturn> GetAll<TReturn>() where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.GetList<T, TReturn>(dbType: this.DBSession.dbType);
        }


        /// <summary>
        /// 统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public int Count(object predicate, bool buffered = false)
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.Count<T>(predicate, dbType: this.DBSession.dbType);
        }

        /// <summary>
        /// 查询列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(object predicate = null, IList<ISort> sort = null,
            bool buffered = false)
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.GetList<T>(predicate, sort, null, null, buffered, dbType: this.DBSession.dbType);
        }


        /// <summary>
        /// 查询列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> GetList<TReturn>(object predicate = null, IList<ISort> sort = null,
            bool buffered = false) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj();
            return ConnObj.DbConnection.GetList<T, TReturn>(predicate, sort, null, null, buffered, dbType: this.DBSession.dbType);
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPageList(int pageIndex, int pageSize, out long allRowsCount,
            object predicate = null, IList<ISort> sort = null, bool buffered = true)
        {
            DbConnObj ConnObj = GetConnObj();
            IEnumerable<T> entityList = ConnObj.DbConnection.GetPage<T>(predicate, sort, pageIndex, pageSize, null, null, buffered, dbType: this.DBSession.dbType);
            allRowsCount = ConnObj.DbConnection.Count<T>(predicate, dbType: this.DBSession.dbType);
            return entityList;
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> GetPageList<TReturn>(int pageIndex, int pageSize, out long allRowsCount,
            object predicate = null, IList<ISort> sort = null, bool buffered = true) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj();
            IEnumerable<TReturn> entityList = ConnObj.DbConnection.GetPage<T, TReturn>(predicate, sort, pageIndex, pageSize, null, null, buffered, dbType: this.DBSession.dbType);
            allRowsCount = ConnObj.DbConnection.Count<T>(predicate, dbType: this.DBSession.dbType);
            return entityList;
        }





        /// <summary>
        /// 插入单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public dynamic Insert(T entity, IDbTransaction transaction = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            dynamic result = ConnObj.DbConnection.Insert<T>(entity, ConnObj.DbTransaction, dbType: this.DBSession.dbType);
            return result;
        }

        /// <summary>
        /// 更新单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(T entity, IDbTransaction transaction = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            bool isOk = ConnObj.DbConnection.Update<T>(entity, ConnObj.DbTransaction, dbType: this.DBSession.dbType);
            return isOk;
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Delete(dynamic primaryId, IDbTransaction transaction = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            var entity = GetById(primaryId);
            var obj = entity as T;
            int isOk = ConnObj.DbConnection.Delete<T>(obj, dbType: this.DBSession.dbType);
            return isOk;
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns> 
        public int DeleteList(object predicate = null, IDbTransaction transaction = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Delete<T>(predicate, ConnObj.DbTransaction, dbType: this.DBSession.dbType);
        }

        /// <summary>
        /// 批量插入功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        public bool InsertBatch(IEnumerable<T> entityList, IDbTransaction transaction = null)
        {
            bool isOk = false;
            foreach (var item in entityList)
            {
                Insert(item, transaction);
            }
            isOk = true;
            return isOk;
        }

        /// <summary>
        /// 批量更新（）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateBatch(IEnumerable<T> entityList, IDbTransaction transaction = null)
        {
            bool isOk = false;
            foreach (var item in entityList)
            {
                Update(item, transaction);
            }
            isOk = true;
            return isOk;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DeleteBatch(IEnumerable<dynamic> ids, IDbTransaction transaction = null)
        {
            bool isOk = false;
            foreach (var id in ids)
            {
                this.Delete(id, transaction);
            }
            isOk = true;
            return isOk;
        }

        #endregion



        #region Lambda

        //public LambdaInsertHelper<T> LambdaInsert(IDbTransaction transaction = null, int? commandTimeout = null)
        //{
        //    DbConnObj ConnObj = GetConnObj(transaction);
        //    return ConnObj.DbConnection.LambdaInsert<T>(transaction, commandTimeout);
        //}

        //public LambdaInsertHelper<TEntity> LambdaInsert<TEntity>(IDbTransaction transaction = null, int? commandTimeout = null) where TEntity : class
        //{
        //    DbConnObj ConnObj = GetConnObj(transaction);
        //    return ConnObj.DbConnection.LambdaInsert<TEntity>(transaction, commandTimeout);
        //}


        public LambdaDeleteHelper<T> LambdaDelete(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.LambdaDelete<T>(transaction, commandTimeout);
        }
        public LambdaDeleteHelper<TEntity> LambdaDelete<TEntity>(IDbTransaction transaction = null, int? commandTimeout = null) where TEntity : class
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.LambdaDelete<TEntity>(transaction, commandTimeout);
        }

        public LambdaUpdateHelper<T> LambdaUpdate(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.LambdaUpdate<T>(transaction, commandTimeout);
        }
        public LambdaUpdateHelper<TEntity> LambdaUpdate<TEntity>(IDbTransaction transaction = null, int? commandTimeout = null) where TEntity : class
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.LambdaUpdate<TEntity>(transaction, commandTimeout);
        }

        public LambdaQueryHelper<T> LambdaQuery(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.LambdaQuery<T>(transaction, commandTimeout);
        }

        public LambdaQueryHelper<TEntity> LambdaQuery<TEntity>(IDbTransaction transaction = null, int? commandTimeout = null) where TEntity : class
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.LambdaQuery<TEntity>(transaction, commandTimeout);
        }
        #endregion


        protected class DbConnObj
        {
            public IDbTransaction DbTransaction { get; set; }

            public IDbConnection DbConnection { get; set; }
        }
    }
}
