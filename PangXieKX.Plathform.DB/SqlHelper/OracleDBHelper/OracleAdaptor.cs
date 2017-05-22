//using PangXieKX.Plathform.DB.DbUtils;
//using PangXieKX.Plathform.DB.Tool;
//using PangXieKX.Plathform.DB.Transactions;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.Common;
//using System.Data.OracleClient;
////using Oracle.DataAccess.Client;
//using System.Linq;
//using System.Text;

//namespace PangXieKX.Plathform.DB.OracleDBHelper
//{
//    /// <summary>
//    /// 数据库访问适配器 默认连接字符串使用【DefaultConnection】
//    /// </summary>
//    public class OracleAdaptor  : IDBHelper
//    {
//        private readonly string _ConnectionStringKey = "DefaultConnection";

//        public OracleAdaptor(string connKey = "")
//        {
//            if (!string.IsNullOrEmpty(connKey))
//            {
//                _ConnectionStringKey = connKey;
//            }
//        }


//        /// <summary>
//        /// 取得数据库连接
//        /// </summary>
//        /// <param name="DBKey">数据库连接主键</param>
//        /// <returns></returns>
//        public static OracleConnection GetConnByKey(string connectionStringKey)
//        {
//            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings[connectionStringKey];
//            string constr = css.ConnectionString;
//            OracleConnection con = new OracleConnection(constr);
//            return con;
//        }

//        #region 事务



//        /// <summary>
//        /// 开始一个事务
//        /// </summary>
//        public IDbTransaction BeginTractionand(IsolationLevel Iso = IsolationLevel.Unspecified)
//        {
//            OracleConnection con = GetConnByKey(_ConnectionStringKey);
//            IDbTransaction transaction = OracleHelper.BeginTransaction(con, Iso);
//            return transaction;
//        }

//        /// <summary>
//        /// 开始一个事务
//        /// </summary>
//        public IDbTransaction BeginTractionand(string connKey, IsolationLevel Iso = IsolationLevel.Unspecified)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            IDbTransaction transaction = OracleHelper.BeginTransaction(con, Iso);
//            return transaction;
//        }

//        /// <summary>
//        /// 回滚事务
//        /// </summary>
//        public void RollbackTractionand(IDbTransaction dbTransaction)
//        {
//            OracleHelper.endTransactionRollback(dbTransaction);
//        }

//        /// <summary>
//        /// 结束并确认事务
//        /// </summary>
//        public void CommitTractionand(IDbTransaction dbTransaction)
//        {
//            OracleHelper.endTransactionCommit(dbTransaction);
//        }
//        #endregion

//        #region DataSet


//        /// <summary>
//        /// 执行sql语句,ExecuteDataSet 返回DataSet
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                DataSet ds = OracleHelper.ExecuteDataset(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
//                return ds;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                DataSet ds = OracleHelper.ExecuteDataset(con, commandType, commandText);
//                return ds;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteDataSet 返回DataSet
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        public DataSet ExecuteDataSet(string connKey, string commandText, CommandType commandType)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            DataSet ds = OracleHelper.ExecuteDataset(con, commandType, commandText);
//            return ds;
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteDataSet 返回DataSet
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public DataSet ExecuteDataSet(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                DataSet ds = OracleHelper.ExecuteDataset(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
//                return ds;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                DataSet ds = OracleHelper.ExecuteDataset(con, commandType, commandText, parameterValues);
//                return ds;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteDataSet 返回DataSet
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public DataSet ExecuteDataSet(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            DataSet ds = OracleHelper.ExecuteDataset(con, commandType, commandText, parameterValues);
//            return ds;
//        }


//        public DataSet ExecuteDataSet(IDbTransaction trans, string commandText, CommandType commandType)
//        {
//            DataSet ds = OracleHelper.ExecuteDataset(trans, commandType, commandText);
//            return ds;
//        }

//        public DataSet ExecuteDataSet(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            DataSet ds = OracleHelper.ExecuteDataset(trans, commandType, commandText, parameterValues);
//            return ds;
//        }

//        public DataSet ExecuteDataSet(IDbConnection conn, string commandText, CommandType commandType)
//        {
//            DataSet ds = OracleHelper.ExecuteDataset((OracleConnection)conn, commandType, commandText);
//            return ds;
//        }

//        public DataSet ExecuteDataSet(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            DataSet ds = OracleHelper.ExecuteDataset((OracleConnection)conn, commandType, commandText, parameterValues);
//            return ds;
//        }

//        #endregion

//        #region ExecuteNonQuery


//        /// <summary>
//        /// 执行sql语句,返回影响的行数
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        public int ExecuteNonQuery(string commandText, CommandType commandType)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                int result = OracleHelper.ExecuteNonQuery(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
//                return result;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                int result = OracleHelper.ExecuteNonQuery(con, commandType, commandText);
//                return result;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,返回影响的行数
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        public int ExecuteNonQuery(string connKey, string commandText, CommandType commandType)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            int result = OracleHelper.ExecuteNonQuery(con, commandType, commandText);
//            return result;
//        }




//        /// <summary>
//        /// 执行sql语句,返回影响的行数
//        /// </summary>
//        /// <param name="trans">事务对象</param>
//        /// <param name="commandText">sql语句</param>
//        public int ExecuteNonQuery(IDbTransaction trans, string commandText, CommandType commandType)
//        {
//            int result = OracleHelper.ExecuteNonQuery(trans, commandType, commandText);
//            return result;
//        }

//        /// <summary>
//        /// 执行sql语句,返回影响的行数
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public int ExecuteNonQuery(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                int result = OracleHelper.ExecuteNonQuery(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
//                return result;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                int result = OracleHelper.ExecuteNonQuery(con, commandType, commandText, parameterValues);
//                return result;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,返回影响的行数
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public int ExecuteNonQuery(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            int result = OracleHelper.ExecuteNonQuery(con, commandType, commandText, parameterValues);
//            return result;
//        }

//        /// <summary>
//        /// 执行sql语句,返回影响的行数
//        /// </summary>
//        /// <param name="trans">事务对象</param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public int ExecuteNonQuery(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            int result = OracleHelper.ExecuteNonQuery(trans, commandType, commandText, parameterValues);
//            return result;
//        }



//        public int ExecuteNonQuery(IDbConnection conn, string commandText, CommandType commandType)
//        {
//            int result = OracleHelper.ExecuteNonQuery((OracleConnection)conn, commandType, commandText);
//            return result;
//        }

//        public int ExecuteNonQuery(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            int result = OracleHelper.ExecuteNonQuery((OracleConnection)conn, commandType, commandText, parameterValues);
//            return result;
//        }


//        #endregion

//        #region IDataReader

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary>   
//        /// <param name="commandText">sql语句</param>
//        public IDataReader ExecuteReader(string commandText, CommandType commandType)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                IDataReader dr = OracleHelper.ExecuteReader(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
//                return dr;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText);
//                return dr;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary> 
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public IDataReader ExecuteReader(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                IDataReader dr = OracleHelper.ExecuteReader(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
//                return dr;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText, parameterValues);
//                return dr;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
//        /// <param name="commandText">sql语句</param>
//        public IDataReader ExecuteReader(string connKey, string commandText, CommandType commandType)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText);
//            return dr;
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public IDataReader ExecuteReader(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText, parameterValues);
//            return dr;
//        }

//        public IDataReader ExecuteReader(IDbTransaction trans, string commandText, CommandType commandType)
//        {
//            IDataReader dr = OracleHelper.ExecuteReader(trans, commandType, commandText);
//            return dr;
//        }

//        public IDataReader ExecuteReader(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            IDataReader dr = OracleHelper.ExecuteReader(trans, commandType, commandText, parameterValues);
//            return dr;
//        }

//        public IDataReader ExecuteReader(IDbConnection conn, string commandText, CommandType commandType)
//        {
//            IDataReader dr = OracleHelper.ExecuteReader((OracleConnection)conn, commandType, commandText);
//            return dr;
//        }

//        public IDataReader ExecuteReader(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            IDataReader dr = OracleHelper.ExecuteReader((OracleConnection)conn, commandType, commandText, parameterValues);
//            return dr;
//        }

//        #endregion

//        #region IEnumerable<T>

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary>   
//        /// <param name="commandText">sql语句</param>
//        public IEnumerable<T> ExecuteIEnumerable<T>(string commandText, CommandType commandType) where T : class, new()
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                return ExecuteIEnumerable<T>(Transaction.Current.DbTransactionWrapper.DbTransaction, commandText, commandType);
//            }
//            else
//            {
//                using (OracleConnection con = GetConnByKey(_ConnectionStringKey))
//                {
//                    using (IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText))
//                    {
//                        return DataReaderExtensions.DataReaderToList<T>(dr);
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary> 
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public IEnumerable<T> ExecuteIEnumerable<T>(string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                return ExecuteIEnumerable<T>(Transaction.Current.DbTransactionWrapper.DbTransaction, commandText, commandType, parameterValues);
//            }
//            else
//            {
//                using (OracleConnection con = GetConnByKey(_ConnectionStringKey))
//                {
//                    using (IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText, parameterValues))
//                    {
//                        return DataReaderExtensions.DataReaderToList<T>(dr);
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
//        /// <param name="commandText">sql语句</param>
//        public IEnumerable<T> ExecuteIEnumerable<T>(string connKey, string commandText, CommandType commandType) where T : class, new()
//        {
//            using (OracleConnection con = GetConnByKey(_ConnectionStringKey))
//            {
//                using (IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText))
//                {
//                    return DataReaderExtensions.DataReaderToList<T>(dr);
//                }
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteReader 返回IDataReader
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>        
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public IEnumerable<T> ExecuteIEnumerable<T>(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
//        {
//            using (OracleConnection con = GetConnByKey(_ConnectionStringKey))
//            {
//                using (IDataReader dr = OracleHelper.ExecuteReader(con, commandType, commandText, parameterValues))
//                {
//                    return DataReaderExtensions.DataReaderToList<T>(dr);
//                }
//            }
//        }

//        public IEnumerable<T> ExecuteIEnumerable<T>(IDbTransaction trans, string commandText, CommandType commandType) where T : class, new()
//        {
//            using (IDataReader dr = OracleHelper.ExecuteReader(trans, commandType, commandText))
//            {
//                return DataReaderExtensions.DataReaderToList<T>(dr);
//            }

//        }

//        public IEnumerable<T> ExecuteIEnumerable<T>(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
//        {
//            using (IDataReader dr = OracleHelper.ExecuteReader(trans, commandType, commandText, parameterValues))
//            {
//                return DataReaderExtensions.DataReaderToList<T>(dr);
//            }
//        }


//        public IEnumerable<T> ExecuteIEnumerable<T>(IDbConnection conn, string commandText, CommandType commandType) where T : class, new()
//        {
//            using (IDataReader dr = OracleHelper.ExecuteReader((OracleConnection)conn, commandType, commandText))
//            {
//                return DataReaderExtensions.DataReaderToList<T>(dr);
//            }
//        }

//        public IEnumerable<T> ExecuteIEnumerable<T>(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues) where T : class, new()
//        {
//            using (IDataReader dr = OracleHelper.ExecuteReader((OracleConnection)conn, commandType, commandText, parameterValues))
//            {
//                return DataReaderExtensions.DataReaderToList<T>(dr); 
//            }
//        }


//        #endregion

//        #region ExecuteScalar
//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        public object ExecuteScalar(string commandText, CommandType commandType)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                object result = OracleHelper.ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
//                return result;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                object result = OracleHelper.ExecuteScalar(con, commandType, commandText);
//                return result;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        public T ExecuteScalar<T>(string commandText, CommandType commandType)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                object result = OracleHelper.ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText);
//                return (T)result;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                object result = OracleHelper.ExecuteScalar(con, commandType, commandText);
//                return (T)result;
//            }
//        }


//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public object ExecuteScalar(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                object result = OracleHelper.ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandType, commandText, parameterValues);
//                return result;
//            }
//            else
//            {
//                OracleConnection con = GetConnByKey(_ConnectionStringKey);
//                object result = OracleHelper.ExecuteScalar(con, commandType, commandText, parameterValues);
//                return result;
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public T ExecuteScalar<T>(string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            if (null != PangXieKX.Plathform.DB.Transactions.Transaction.Current)
//            {
//                return (T)ExecuteScalar(Transaction.Current.DbTransactionWrapper.DbTransaction, commandText, commandType, parameterValues);
//            }
//            else
//            {
//                return (T)ExecuteScalar(commandText, commandType, parameterValues);
//            }
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="trans">事务</param>
//        /// <param name="commandText">sql语句</param>
//        public object ExecuteScalar(IDbTransaction trans, string commandText, CommandType commandType)
//        {
//            object result = OracleHelper.ExecuteScalar(trans, commandType, commandText);
//            return result;
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="trans">事务</param>
//        /// <param name="commandText">sql语句</param>
//        public T ExecuteScalar<T>(IDbTransaction trans, string commandText, CommandType commandType)
//        {
//            return (T)ExecuteScalar(trans, commandText, commandType);
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        public object ExecuteScalar(string connKey, string commandText, CommandType commandType)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            object result = OracleHelper.ExecuteScalar(con, commandType, commandText);
//            return result;
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        public T ExecuteScalar<T>(string connKey, string commandText, CommandType commandType)
//        {
//            return (T)ExecuteScalar(connKey, commandText, commandType);
//        }


//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public object ExecuteScalar(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            OracleConnection con = GetConnByKey(connKey);
//            object result = OracleHelper.ExecuteScalar(con, commandType, commandText, parameterValues);
//            return result;
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="connectionStringKey">数据库连接字符串的Key</param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public T ExecuteScalar<T>(string connKey, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            return (T)ExecuteScalar(connKey, commandText, commandType, parameterValues);
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="trans">事务param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public object ExecuteScalar(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            object result = OracleHelper.ExecuteScalar(trans, commandType, commandText, parameterValues);
//            return result;
//        }

//        /// <summary>
//        /// 执行sql语句,ExecuteScalar 返回第一行第一列的值
//        /// </summary>
//        /// <param name="trans">事务param>
//        /// <param name="commandText">sql语句</param>
//        /// <param name="parameterValues">参数</param>
//        public T ExecuteScalar<T>(IDbTransaction trans, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            return (T)ExecuteScalar(trans, commandText, commandType, parameterValues);
//        }



//        public object ExecuteScalar(IDbConnection conn, string commandText, CommandType commandType)
//        {
//            object result = OracleHelper.ExecuteScalar((OracleConnection)conn, commandType, commandText);
//            return result;
//        }
//        public object ExecuteScalar(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            object result = OracleHelper.ExecuteScalar((OracleConnection)conn, commandType, commandText, parameterValues);
//            return result;
//        }



//        public T ExecuteScalar<T>(IDbConnection conn, string commandText, CommandType commandType)
//        {
//            return (T)ExecuteScalar(conn, commandText, commandType);
//        }



//        public T ExecuteScalar<T>(IDbConnection conn, string commandText, CommandType commandType, params IDataParameter[] parameterValues)
//        {
//            return (T)ExecuteScalar(conn, commandText, commandType, parameterValues);
//        }
//        #endregion

//        /// <summary>
//        /// 生成分页SQL语句
//        /// </summary>
//        /// <param name="pageIndex">page索引</param>
//        /// <param name="pageSize">page大小</param>
//        /// <param name="selectSql">查询语句</param>
//        /// <param name="SqlCount">查询总数的语句</param>
//        /// <param name="orderBy">排序</param>
//        /// <returns></returns>
//        public string GetPagingSql(int pageIndex, int pageSize, string selectSql, string SqlCount, string orderBy)
//        {
//            return PageHelper.GetPagingSql(pageIndex, pageSize, selectSql, SqlCount, orderBy);
//        }

        
//    }

//}

