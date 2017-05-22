using System.Collections.Generic;
using System.Data;
using System.Linq;
using PangXieKX.Plathform.DB.Dapper;
using PangXieKX.Plathform.DB.DapperExtensions;
using PangXieKX.Plathform.DB;
using PangXieKX.Plathform.DB.Transactions;
using System;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using PangXieKX.Plathform.DB.DapperExtensions.Lambda;

namespace PangXieKX.Plathform.DB
{
    /// <summary>
    /// Repository基类
    /// </summary>
    public class RepositoryBase<T> : RepositoryServiceBase<T>, IDataRepository<T>
                where T : class
    {



        public RepositoryBase(IDBSession dbSession)
            : base(dbSession)
        {
        }


        #region 传入Sql 语句执行
        /// <summary>
        /// 根据条件筛选出数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        protected IEnumerable<T> Get(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Query<T>(sql, param as object, transaction != null ? transaction : ConnObj.DbTransaction, true, commandTimeout, commandType);
        }

        /// <summary>
        /// 根据条件筛选出数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        protected IEnumerable<TReturn> Get<TReturn>(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Query<TReturn>(sql, param as object, transaction != null ? transaction : ConnObj.DbTransaction, true, commandTimeout, commandType);
        }



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="allRowsCountSql"></param>
        /// <param name="allRowsCountParam"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        protected IEnumerable<T> GetPage(int pageIndex, int pageSize, out long allRowsCount, string sql, dynamic param = null, string allRowsCountSql = null, dynamic allRowsCountParam = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnObj ConnObj = GetConnObj();
            IEnumerable<T> entityList = ConnObj.DbConnection.GetPage<T>(pageIndex, pageSize, out allRowsCount, sql, param as object, allRowsCountSql, ConnObj.DbTransaction, commandTimeout, true, base.DBSession.dbType);
            return entityList;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="allRowsCountSql"></param>
        /// <param name="allRowsCountParam"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        protected IEnumerable<TReturn> GetPage<TReturn>(int pageIndex, int pageSize, out long allRowsCount, string sql, dynamic param = null, string allRowsCountSql = null, dynamic allRowsCountParam = null, int? commandTimeout = null, CommandType? commandType = null) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj();
            IEnumerable<TReturn> entityList = ConnObj.DbConnection.GetPage<TReturn>(pageIndex, pageSize, out allRowsCount, sql, param as object, allRowsCountSql, ConnObj.DbTransaction, commandTimeout, true, base.DBSession.dbType);
            return entityList;
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        protected IEnumerable<T> Get<TFirst, TSecond>(string sql, Func<TFirst, TSecond, T> map,
            dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Query(sql, map, param as object, ConnObj.DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }


        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        protected IEnumerable<TReturn> Get<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Query(sql, map, param as object, ConnObj.DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }


        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        protected IEnumerable<T> Get<TFirst, TSecond, TThird>(string sql, Func<TFirst, TSecond, TThird, T> map,
            dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Query(sql, map, param as object, ConnObj.DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        protected IEnumerable<TReturn> Get<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map,
            dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null) where TReturn : class
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Query(sql, map, param as object, ConnObj.DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }



        /// <summary>
        /// 获取多实体集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        protected SqlMapper.GridReader GetMultiple(string sql, dynamic param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.QueryMultiple(sql, param as object, ConnObj.DbTransaction, commandTimeout, commandType);
        }

        /// <summary>
        /// 执行sql操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnObj ConnObj = GetConnObj(transaction);
            return ConnObj.DbConnection.Execute(sql, param as object, ConnObj.DbTransaction, commandTimeout, commandType);
        }

        #endregion






    }
}
