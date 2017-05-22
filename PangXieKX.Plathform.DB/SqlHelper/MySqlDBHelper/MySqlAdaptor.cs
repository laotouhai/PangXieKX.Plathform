using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using PangXieKX.Plathform.DB.Tool;
using PangXieKX.Plathform.DB.Transactions;
using PangXieKX.Plathform.DB.DbUtils;

namespace PangXieKX.Plathform.DB.MySqlDBHelper
{
    public class MySqlAdaptor : IDBHelper
    {
        private readonly string _ConnectionStringKey = "DefaultConnection";

        public MySqlAdaptor(string connKey = "")
        {
            if (!string.IsNullOrEmpty(connKey))
            {
                _ConnectionStringKey = connKey;
            }
        }


        /// <summary>
        /// 取得数据库连接
        /// </summary>
        /// <param name="DBKey">数据库连接主键</param>
        /// <returns></returns>
        public static MySqlConnection GetConnByKey(string connectionStringKey)
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings[connectionStringKey];
            string constr = css.ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            return con;
        }

        #region 事务



        /// <summary>
        /// 开始一个事务
        /// </summary>
        public IDbTransaction BeginTractionand(IsolationLevel Iso = IsolationLevel.Unspecified)
        {
            MySqlConnection con = GetConnByKey(_ConnectionStringKey);
            IDbTransaction transaction = MySqlHelper.BeginTransaction(con, Iso);
            return transaction;
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        public IDbTransaction BeginTractionand(string connKey, IsolationLevel Iso = IsolationLevel.Unspecified)
        {
            MySqlConnection con = GetConnByKey(connKey);
            IDbTransaction transaction = MySqlHelper.BeginTransaction(con, Iso);
            return transaction;
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTractionand(IDbTransaction dbTransaction)
        {
            MySqlHelper.endTransactionRollback(dbTransaction);
        }

        /// <summary>
        /// 结束并确认事务
        /// </summary>
        public void CommitTractionand(IDbTransaction dbTransaction)
        {
            MySqlHelper.endTransactionCommit(dbTransaction);
        }
        #endregion

        #region DataSet


        /// <summary>
        /// 执行sql语句,ExecuteDataSet 返回DataSet
        /// </summary>
        /// <param name="commandText">sql语句</param>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                DataSet ds = MySqlHelper.ExecuteDataset(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
                return ds;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                DataSet ds = MySqlHelper.ExecuteDataset(con, commandType, commandText);
                return ds;
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteDataSet 返回DataSet
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        public DataSet ExecuteDataSet(string connKey, string commandText, CommandType commandType)
        {
            MySqlConnection con = GetConnByKey(connKey);
            DataSet ds = MySqlHelper.ExecuteDataset(con, commandType, commandText);
            return ds;
        }

        /// <summary>
        /// 执行sql语句,ExecuteDataSet 返回DataSet
        /// </summary>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                DataSet ds = MySqlHelper.ExecuteDataset(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
                return ds;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                DataSet ds = MySqlHelper.ExecuteDataset(con, commandType, commandText, parameterValues);
                return ds;
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteDataSet 返回DataSet
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public DataSet ExecuteDataSet(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            MySqlConnection con = GetConnByKey(connKey);
            DataSet ds = MySqlHelper.ExecuteDataset(con, commandType, commandText, parameterValues);
            return ds;
        }


        public DataSet ExecuteDataSet(IDbTransaction trans, string commandText, CommandType commandType)
        {
            DataSet ds = MySqlHelper.ExecuteDataset(trans, commandType, commandText);
            return ds;
        }

        public DataSet ExecuteDataSet(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            DataSet ds = MySqlHelper.ExecuteDataset(trans, commandType, commandText, parameterValues);
            return ds;
        }

        public DataSet ExecuteDataSet(IDbConnection conn, string commandText, CommandType commandType)
        {
            DataSet ds = MySqlHelper.ExecuteDataset((MySqlConnection)conn, commandType, commandText);
            return ds;
        }

        public DataSet ExecuteDataSet(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            DataSet ds = MySqlHelper.ExecuteDataset((MySqlConnection)conn, commandType, commandText, parameterValues);
            return ds;
        }

        #endregion

        #region ExecuteNonQuery


        /// <summary>
        /// 执行sql语句,返回影响的行数
        /// </summary>
        /// <param name="commandText">sql语句</param>
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                int result = MySqlHelper.ExecuteNonQuery(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
                return result;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                int result = MySqlHelper.ExecuteNonQuery(con, commandType, commandText);
                return result;
            }
        }

        /// <summary>
        /// 执行sql语句,返回影响的行数
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        public int ExecuteNonQuery(string connKey, string commandText, CommandType commandType)
        {
            MySqlConnection con = GetConnByKey(connKey);
            int result = MySqlHelper.ExecuteNonQuery(con, commandType, commandText);
            return result;
        }




        /// <summary>
        /// 执行sql语句,返回影响的行数
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="commandText">sql语句</param>
        public int ExecuteNonQuery(IDbTransaction trans, string commandText, CommandType commandType)
        {
            int result = MySqlHelper.ExecuteNonQuery(trans, commandType, commandText);
            return result;
        }

        /// <summary>
        /// 执行sql语句,返回影响的行数
        /// </summary>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public int ExecuteNonQuery(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                int result = MySqlHelper.ExecuteNonQuery(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
                return result;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                int result = MySqlHelper.ExecuteNonQuery(con, commandType, commandText, parameterValues);
                return result;
            }
        }

        /// <summary>
        /// 执行sql语句,返回影响的行数
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public int ExecuteNonQuery(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            MySqlConnection con = GetConnByKey(connKey);
            int result = MySqlHelper.ExecuteNonQuery(con, commandType, commandText, parameterValues);
            return result;
        }

        /// <summary>
        /// 执行sql语句,返回影响的行数
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public int ExecuteNonQuery(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            int result = MySqlHelper.ExecuteNonQuery(trans, commandType, commandText, parameterValues);
            return result;
        }



        public int ExecuteNonQuery(IDbConnection conn, string commandText, CommandType commandType)
        {
            int result = MySqlHelper.ExecuteNonQuery((MySqlConnection)conn, commandType, commandText);
            return result;
        }

        public int ExecuteNonQuery(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            int result = MySqlHelper.ExecuteNonQuery((MySqlConnection)conn, commandType, commandText, parameterValues);
            return result;
        }


        #endregion

        #region IDataReader

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary>   
        /// <param name="commandText">sql语句</param>
        public IDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                IDataReader dr = MySqlHelper.ExecuteReader(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
                return dr;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText);
                return dr;
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary> 
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public IDataReader ExecuteReader(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                IDataReader dr = MySqlHelper.ExecuteReader(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
                return dr;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText, parameterValues);
                return dr;
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
        /// <param name="commandText">sql语句</param>
        public IDataReader ExecuteReader(string connKey, string commandText, CommandType commandType)
        {
            MySqlConnection con = GetConnByKey(connKey);
            IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText);
            return dr;
        }

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public IDataReader ExecuteReader(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            MySqlConnection con = GetConnByKey(connKey);
            IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText, parameterValues);
            return dr;
        }

        public IDataReader ExecuteReader(IDbTransaction trans, string commandText, CommandType commandType)
        {
            IDataReader dr = MySqlHelper.ExecuteReader(trans, commandType, commandText);
            return dr;
        }

        public IDataReader ExecuteReader(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            IDataReader dr = MySqlHelper.ExecuteReader(trans, commandType, commandText, parameterValues);
            return dr;
        }

        public IDataReader ExecuteReader(IDbConnection conn, string commandText, CommandType commandType)
        {
            IDataReader dr = MySqlHelper.ExecuteReader((MySqlConnection)conn, commandType, commandText);
            return dr;
        }

        public IDataReader ExecuteReader(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            IDataReader dr = MySqlHelper.ExecuteReader((MySqlConnection)conn, commandType, commandText, parameterValues);
            return dr;
        }

        #endregion

        #region IEnumerable<T>

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary>   
        /// <param name="commandText">sql语句</param>
        public IEnumerable<T> ExecuteIEnumerable<T>(string commandText, CommandType commandType) where T : class, new()
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                return ExecuteIEnumerable<T>(Transaction.Current.DbTransactionWrapper.DbTransaction, commandText, commandType);
            }
            else
            {
                using (MySqlConnection con = GetConnByKey(_ConnectionStringKey))
                {
                    using (IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText))
                    {
                        return DataReaderExtensions.DataReaderToList<T>(dr);
                    }
                }
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary> 
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public IEnumerable<T> ExecuteIEnumerable<T>(string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                return ExecuteIEnumerable<T>(Transaction.Current.DbTransactionWrapper.DbTransaction, commandText, commandType, parameterValues);
            }
            else
            {
                using (MySqlConnection con = GetConnByKey(_ConnectionStringKey))
                {
                    using (IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText, parameterValues))
                    {
                        return DataReaderExtensions.DataReaderToList<T>(dr);
                    }
                }
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
        /// <param name="commandText">sql语句</param>
        public IEnumerable<T> ExecuteIEnumerable<T>(string connKey, string commandText, CommandType commandType) where T : class, new()
        {
            using (MySqlConnection con = GetConnByKey(_ConnectionStringKey))
            {
                using (IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText))
                {
                    return DataReaderExtensions.DataReaderToList<T>(dr);
                }
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteReader 返回IDataReader
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public IEnumerable<T> ExecuteIEnumerable<T>(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
        {
            using (MySqlConnection con = GetConnByKey(_ConnectionStringKey))
            {
                using (IDataReader dr = MySqlHelper.ExecuteReader(con, commandType, commandText, parameterValues))
                {
                    return DataReaderExtensions.DataReaderToList<T>(dr);
                }
            }
        }

        public IEnumerable<T> ExecuteIEnumerable<T>(IDbTransaction trans, string commandText, CommandType commandType) where T : class, new()
        {
            using (IDataReader dr = MySqlHelper.ExecuteReader(trans, commandType, commandText))
            {
                return DataReaderExtensions.DataReaderToList<T>(dr);
            }

        }

        public IEnumerable<T> ExecuteIEnumerable<T>(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
        {
            using (IDataReader dr = MySqlHelper.ExecuteReader(trans, commandType, commandText, parameterValues))
            {
                return DataReaderExtensions.DataReaderToList<T>(dr);
            }
        }


        public IEnumerable<T> ExecuteIEnumerable<T>(IDbConnection conn, string commandText, CommandType commandType) where T : class, new()
        {
            using (IDataReader dr = MySqlHelper.ExecuteReader((MySqlConnection)conn, commandType, commandText))
            {
                return DataReaderExtensions.DataReaderToList<T>(dr);
            }
        }

        public IEnumerable<T> ExecuteIEnumerable<T>(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
        {
            using (IDataReader dr = MySqlHelper.ExecuteReader((MySqlConnection)conn, commandType, commandText, parameterValues))
            {
                return DataReaderExtensions.DataReaderToList<T>(dr); 
            }
        }


        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="commandText">sql语句</param>
        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                object result = MySqlHelper.ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
                return result;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                object result = MySqlHelper.ExecuteScalar(con, commandType, commandText);
                return result;
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="commandText">sql语句</param>
        public T ExecuteScalar<T>(string commandText, CommandType commandType)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                object result = MySqlHelper.ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
                return (T)result;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                object result = MySqlHelper.ExecuteScalar(con, commandType, commandText);
                return (T)result;
            }
        }


        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public object ExecuteScalar(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                object result = MySqlHelper.ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
                return result;
            }
            else
            {
                MySqlConnection con = GetConnByKey(_ConnectionStringKey);
                object result = MySqlHelper.ExecuteScalar(con, commandType, commandText, parameterValues);
                return result;
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public T ExecuteScalar<T>(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
            {
                return (T)ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandText, commandType, parameterValues);
            }
            else
            {
                return (T)ExecuteScalar(commandText, commandType, parameterValues);
            }
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandText">sql语句</param>
        public object ExecuteScalar(IDbTransaction trans, string commandText, CommandType commandType)
        {
            object result = MySqlHelper.ExecuteScalar(trans, commandType, commandText);
            return result;
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandText">sql语句</param>
        public T ExecuteScalar<T>(IDbTransaction trans, string commandText, CommandType commandType)
        {
            return (T)ExecuteScalar(trans, commandText, commandType);
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        public object ExecuteScalar(string connKey, string commandText, CommandType commandType)
        {
            MySqlConnection con = GetConnByKey(connKey);
            object result = MySqlHelper.ExecuteScalar(con, commandType, commandText);
            return result;
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        public T ExecuteScalar<T>(string connKey, string commandText, CommandType commandType)
        {
            return (T)ExecuteScalar(connKey, commandText, commandType);
        }


        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public object ExecuteScalar(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            MySqlConnection con = GetConnByKey(connKey);
            object result = MySqlHelper.ExecuteScalar(con, commandType, commandText, parameterValues);
            return result;
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public T ExecuteScalar<T>(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            return (T)ExecuteScalar(connKey, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="trans">事务param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public object ExecuteScalar(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            object result = MySqlHelper.ExecuteScalar(trans, commandType, commandText, parameterValues);
            return result;
        }

        /// <summary>
        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
        /// </summary>
        /// <param name="trans">事务param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameterValues">参数</param>
        public T ExecuteScalar<T>(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            return (T)ExecuteScalar(trans, commandText, commandType, parameterValues);
        }



        public object ExecuteScalar(IDbConnection conn, string commandText, CommandType commandType)
        {
            object result = MySqlHelper.ExecuteScalar((MySqlConnection)conn, commandType, commandText);
            return result;
        }
        public object ExecuteScalar(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            object result = MySqlHelper.ExecuteScalar((MySqlConnection)conn, commandType, commandText, parameterValues);
            return result;
        }



        public T ExecuteScalar<T>(IDbConnection conn, string commandText, CommandType commandType)
        {
            return (T)ExecuteScalar(conn, commandText, commandType);
        }



        public T ExecuteScalar<T>(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
        {
            return (T)ExecuteScalar(conn, commandText, commandType, parameterValues);
        }
        #endregion

        /// <summary>
        /// 生成分页SQL语句
        /// </summary>
        /// <param name="pageIndex">page索引</param>
        /// <param name="pageSize">page大小</param>
        /// <param name="selectSql">查询语句</param>
        /// <param name="SqlCount">查询总数的语句</param>
        /// <param name="orderBy">排序</param>
        /// <returns></returns>
        public string GetPagingSql(int pageIndex, int pageSize, string selectSql, string SqlCount, string orderBy)
        {
            return PageHelper.GetPagingSql(pageIndex, pageSize, selectSql, SqlCount, orderBy);
        }

        
    }

}

