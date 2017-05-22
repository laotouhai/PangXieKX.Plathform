using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

using PangXieKX.Plathform.DB.Dapper;
using PangXieKX.Plathform.DB.DapperExtensions;
using PangXieKX.Plathform.DB.DapperExtensions.Mapper;
using PangXieKX.Plathform.DB.DapperExtensions.Sql;
using PangXieKX.Plathform.DB.DapperExtensions.ValueObject;
using PangXieKX.Plathform.DB;

namespace PangXieKX.Plathform.DB.DapperExtensions.Lambda
{
    public class LambdaDeleteHelper<T> : LambdaDeleteHelper where T : class
    {
        public LambdaDeleteHelper(IDbConnection connection, IDbTransaction transaction, IClassMapper classMap, int? commandTimeout = null)
            : base(connection, transaction, classMap, commandTimeout)
        {
        }

        #region Sql组装  Where



        public LambdaDeleteHelper<T> Where(IWhere where)
        {
            return (LambdaDeleteHelper<T>)base.Where(where.ToWhereClip());
        }

        public LambdaDeleteHelper<T> Where(IWhere<T> where)
        {
            return (LambdaDeleteHelper<T>)base.Where(where.ToWhereClip());
        }

        /// <summary>
        /// 
        /// </summary>
        public LambdaDeleteHelper<T> Where(Expression<Func<T, bool>> lambdaWhere)
        {
            return (LambdaDeleteHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }



        #endregion

    }


    public class LambdaDeleteHelper
    {
        #region 属性 变量
        public IClassMapper ClassMap { get; private set; }
        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }
        public DataBaseType DbType { get; private set; }

        [DefaultValue(30000)]
        public int CommandTimeout { get; private set; }


        private string _SqlString = string.Empty;
        private WhereClip _WhereClip = WhereClip.All;

        private Dictionary<string, Parameter> _Parameters = new Dictionary<string, Parameter>();

        public WhereClip WhereClip
        {
            get { return _WhereClip; }
            private set { _WhereClip = value; }
        }


        public Dictionary<string, Parameter> Parameters
        {
            get
            {
                if (null == _Parameters || _Parameters.Count == 0)
                {
                    if (!WhereClip.IsNullOrEmpty(_WhereClip))
                    {
                        foreach (var item in _WhereClip.Parameters)
                        {
                            _Parameters.Add(item.ParameterName, item);
                        }
                    }
                }
                return _Parameters;
            }
            internal set
            {
                this._Parameters = value;
            }


        }


        #endregion

        #region 构造函数
        public LambdaDeleteHelper(IDbConnection connection, IDbTransaction transaction, IClassMapper classMap, int? commandTimeout = null)
        {
            this.Connection = connection;
            this.DbType = DapperExtension.DapperImplementor.DbType;
            this.Transaction = transaction;
            this.ClassMap = classMap;
            if (null != commandTimeout)
            {
                this.CommandTimeout = CommandTimeout;
            }
        }
        #endregion

        #region Sql组装  Where






        protected LambdaDeleteHelper Where(WhereClip where)
        {
            IsChangeSql();
            this._WhereClip = where;
            return this;
        }

        #endregion



        /// <summary>
        /// 执行的sql语句
        /// </summary>
        public string SqlString
        {
            get
            {
                if (string.IsNullOrEmpty(_SqlString))
                {

                    _SqlString = DapperExtension.DapperImplementor.SqlGenerator.LambdaDelete(this, ref _Parameters);
                }
                return _SqlString;
            }
        }

        #region Execute

        public int Execute()
        {
            if (Transaction != null)
            {
                return DBUtils.GetDBHelper(DbType).ExecuteNonQuery(Transaction, this.SqlString, CommandType.Text, DBUtils.ConvertToDbParameter(Parameters, DbType).ToArray());
            }
            else
            {
                return DBUtils.GetDBHelper(DbType).ExecuteNonQuery(Connection, this.SqlString, CommandType.Text, DBUtils.ConvertToDbParameter(Parameters, DbType).ToArray());
            }
        }

        #endregion


        #region Private方法

        private void IsChangeSql()
        {
            _Parameters.Clear();
            _SqlString = string.Empty;
        }

        #endregion
    }

}
