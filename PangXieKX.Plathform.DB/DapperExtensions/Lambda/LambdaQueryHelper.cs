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
    public class LambdaQueryHelper<T> : LambdaQueryHelper where T : class
    {

        public LambdaQueryHelper(IDbConnection connection, IDbTransaction transaction, IClassMapper classMap, int? commandTimeout = null)
            : base(connection, transaction, classMap, commandTimeout)
        {
        }

        #region Sql组装  Select  OrderBy  Group ……



        #region Select

        public LambdaQueryHelper<T> Select(ISelect select)
        {
            return (LambdaQueryHelper<T>)base.Select(select.Fields.ToArray());
        }

        public LambdaQueryHelper<T> Select(ISelect<T> select)
        {
            return (LambdaQueryHelper<T>)base.Select(select.Fields.ToArray());
        }


        public LambdaQueryHelper<T> Select(Expression<Func<T, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2>(Expression<Func<T, T2, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3>(Expression<Func<T, T2, T3, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3, T4>(Expression<Func<T, T2, T3, T4, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }


        public LambdaQueryHelper<T> Select(Expression<Func<T, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2>(Expression<Func<T, T2, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3>(Expression<Func<T, T2, T3, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> Select<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.Select(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }




        public LambdaQueryHelper<T> AddSelect(ISelect select)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(select.Fields.ToArray());
        }

        public LambdaQueryHelper<T> AddSelect(ISelect<T> select)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(select.Fields.ToArray());
        }

        public LambdaQueryHelper<T> AddSelect(Expression<Func<T, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2>(Expression<Func<T, T2, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3>(Expression<Func<T, T2, T3, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3, T4>(Expression<Func<T, T2, T3, T4, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, bool>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }


        public LambdaQueryHelper<T> AddSelect(Expression<Func<T, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2>(Expression<Func<T, T2, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3>(Expression<Func<T, T2, T3, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }
        public LambdaQueryHelper<T> AddSelect<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> lambdaSelect)
        {
            return (LambdaQueryHelper<T>)base.AddSelect(ExpressionToClip<T>.ToSelect(lambdaSelect));
        }



        #endregion

        public LambdaQueryHelper<T> Where(IWhere where)
        {
            return (LambdaQueryHelper<T>)base.Where(where.ToWhereClip());
        }

        public LambdaQueryHelper<T> Where(IWhere<T> where)
        {
            return (LambdaQueryHelper<T>)base.Where(where.ToWhereClip());
        }

        /// <summary>
        /// 
        /// </summary>
        public LambdaQueryHelper<T> Where(Expression<Func<T, bool>> lambdaWhere)
        {
            return (LambdaQueryHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }

        /// <summary>
        /// 
        /// </summary>
        public LambdaQueryHelper<T> Where<T2>(Expression<Func<T, T2, bool>> lambdaWhere)
        {
            return (LambdaQueryHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }

        /// <summary>
        /// 
        /// </summary>
        public LambdaQueryHelper<T> Where<T2, T3>(Expression<Func<T, T2, T3, bool>> lambdaWhere)
        {
            return (LambdaQueryHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }

        /// <summary>
        /// 
        /// </summary>
        public LambdaQueryHelper<T> Where<T2, T3, T4>(Expression<Func<T, T2, T3, T4, bool>> lambdaWhere)
        {
            return (LambdaQueryHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }
        /// <summary>
        /// 
        /// </summary>
        public LambdaQueryHelper<T> Where<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, bool>> lambdaWhere)
        {
            return (LambdaQueryHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }

        /// <summary>
        /// 
        /// </summary>
        public LambdaQueryHelper<T> Where<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, bool>> lambdaWhere)
        {
            return (LambdaQueryHelper<T>)Where(ExpressionToClip<T>.ToWhereClip(lambdaWhere));
        }

        public LambdaQueryHelper<T> Having(IWhere having)
        {
            return (LambdaQueryHelper<T>)base.Having(having.ToWhereClip());
        }

        public LambdaQueryHelper<T> Having(Expression<Func<T, bool>> lambdaHaving)
        {
            return (LambdaQueryHelper<T>)base.Having(ExpressionToClip<T>.ToWhereClip(lambdaHaving));
        }



        public new LambdaQueryHelper<T> Distinct()
        {
            return (LambdaQueryHelper<T>)base.Distinct();
        }

        public new LambdaQueryHelper<T> WithNoLock()
        {
            return (LambdaQueryHelper<T>)base.WithNoLock();
        }


        public new LambdaQueryHelper<T> Top(int topCount)
        {
            return (LambdaQueryHelper<T>)base.Top(topCount);
        }


        public new LambdaQueryHelper Page(int pageIndex, int pageSize)
        {
            return (LambdaQueryHelper<T>)base.Page(pageIndex, pageSize);
        }


        #region OrderBy


        public LambdaQueryHelper<T> OrderBy(IOrderBy orderby)
        {
            return (LambdaQueryHelper<T>)base.OrderBy(orderby.ToOrderByClip());
        }

        public LambdaQueryHelper<T> OrderBy(IOrderBy<T> orderby)
        {
            return (LambdaQueryHelper<T>)base.OrderBy(orderby.ToOrderByClip());
        }

        public LambdaQueryHelper<T> OrderBy(Expression<Func<T, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }

        public LambdaQueryHelper<T> OrderBy<T2>(Expression<Func<T, T2, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }
        public LambdaQueryHelper<T> OrderBy<T2, T3>(Expression<Func<T, T2, T3, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }
        public LambdaQueryHelper<T> OrderBy<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }

        public LambdaQueryHelper<T> OrderBy<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }

        public LambdaQueryHelper<T> OrderBy<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }


        public LambdaQueryHelper<T> OrderByDescending(Expression<Func<T, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }
        public LambdaQueryHelper<T> OrderByDescending<T2>(Expression<Func<T, T2, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> OrderByDescending<T2, T3>(Expression<Func<T, T2, T3, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> OrderByDescending<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> OrderByDescending<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> OrderByDescending<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)OrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }




        public LambdaQueryHelper<T> AddOrderBy(Expression<Func<T, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }

        public LambdaQueryHelper<T> AddOrderBy<T2>(Expression<Func<T, T2, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }
        public LambdaQueryHelper<T> AddOrderBy<T2, T3>(Expression<Func<T, T2, T3, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }
        public LambdaQueryHelper<T> AddOrderBy<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }

        public LambdaQueryHelper<T> AddOrderBy<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }

        public LambdaQueryHelper<T> AddOrderBy<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy));
        }


        public LambdaQueryHelper<T> AddOrderByDescending(Expression<Func<T, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }
        public LambdaQueryHelper<T> AddOrderByDescending<T2>(Expression<Func<T, T2, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> AddOrderByDescending<T2, T3>(Expression<Func<T, T2, T3, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> AddOrderByDescending<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> AddOrderByDescending<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }

        public LambdaQueryHelper<T> AddOrderByDescending<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> lambdaOrderBy)
        {
            return (LambdaQueryHelper<T>)base.AddOrderBy(ExpressionToClip<T>.ToOrderByClip(lambdaOrderBy, OrderByType.DESC));
        }


        #endregion


        public LambdaQueryHelper<T> GroupBy(Expression<Func<T, object>> lambdaGroupBy)
        {
            return (LambdaQueryHelper<T>)base.GroupBy(ExpressionToClip<T>.ToGroupByClip(lambdaGroupBy));
        }

        #endregion

        #region Join

        private new LambdaQueryHelper<T> Join(string tableName, WhereClip where, JoinType joinType)
        {
            return (LambdaQueryHelper<T>)base.Join(tableName, where, joinType);
        }


        public LambdaQueryHelper<T> InnerJoin<TEntity>(WhereClip where) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, where, JoinType.InnerJoin);
        }


        public LambdaQueryHelper<T> InnerJoin<TEntity>(Expression<Func<T, TEntity, bool>> lambdaWhere) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, ExpressionToClip<T>.ToJoinWhere(lambdaWhere), JoinType.InnerJoin);
        }


        public LambdaQueryHelper<T> LeftJoin<TEntity>(WhereClip where) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, where, JoinType.LeftJoin);
        }

        public LambdaQueryHelper<T> LeftJoin<TEntity>(Expression<Func<T, TEntity, bool>> lambdaWhere) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, ExpressionToClip<T>.ToJoinWhere(lambdaWhere), JoinType.LeftJoin);
        }




        public LambdaQueryHelper<T> RightJoin<TEntity>(WhereClip where) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, where, JoinType.RightJoin);
        }

        public LambdaQueryHelper<T> RightJoin<TEntity>(Expression<Func<T, TEntity, bool>> lambdaWhere) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, ExpressionToClip<T>.ToJoinWhere(lambdaWhere), JoinType.RightJoin);
        }



        public LambdaQueryHelper<T> CrossJoin<TEntity>(WhereClip where) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, where, JoinType.CrossJoin);
        }

        public LambdaQueryHelper<T> CrossJoin<TEntity>(Expression<Func<T, TEntity, bool>> lambdaWhere) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, ExpressionToClip<T>.ToJoinWhere(lambdaWhere), JoinType.CrossJoin);
        }





        public LambdaQueryHelper<T> FullJoin<TEntity>(WhereClip where) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, where, JoinType.FullJoin);
        }

        public LambdaQueryHelper<T> FullJoin<TEntity>(Expression<Func<T, TEntity, bool>> lambdaWhere) where TEntity : class
        {
            return Join(DapperExtension.DapperImplementor.SqlGenerator.Configuration.GetMap<TEntity>().TableName, ExpressionToClip<T>.ToJoinWhere(lambdaWhere), JoinType.FullJoin);
        }




        #endregion

        #region Execute
        public new IDataReader ToDataReader()
        {
            return base.ToDataReader();
        }

        public new DataSet ToDataSet()
        {
            return base.ToDataSet();
        }

        public new DataTable ToDataTable()
        {
            return base.ToDataTable();
        }



        public IEnumerable<T> ToList()
        {
            return base.ToList<T>();
        }

        #endregion
    }


    public class LambdaQueryHelper
    {
        #region 属性 变量
        public IClassMapper ClassMap { get; private set; }
        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }
        public DataBaseType DbType { get; private set; }

        [DefaultValue(30000)]
        public int CommandTimeout { get; private set; }
        public int? PageIndex { get; private set; }
        public int? PageSize { get; private set; }
        public string DistinctString { get; private set; }

        [DefaultValue(false)]
        public bool EnabledNoLock { get; private set; }

        private string _SqlString = string.Empty;
        private WhereClip _WhereClip = WhereClip.All;
        private WhereClip _HavingClip = WhereClip.All;
        private OrderByClip _OrderByClip = OrderByClip.None;
        private GroupByClip _GroupByClip = GroupByClip.None;
        private Dictionary<string, KeyValuePair<string, WhereClip>> _Joins = new Dictionary<string, KeyValuePair<string, WhereClip>>();
        private List<Field> _Fields = new List<Field>();
        private Dictionary<string, Parameter> _Parameters = new Dictionary<string, Parameter>();

        public WhereClip WhereClip
        {
            get { return _WhereClip; }
            private set { _WhereClip = value; }
        }

        public WhereClip HavingClip
        {
            get { return _HavingClip; }
            private set { _HavingClip = value; }
        }
        public OrderByClip OrderByClip
        {
            get { return _OrderByClip; }
            private set { _OrderByClip = value; }
        }
        public GroupByClip GroupByClip
        {
            get { return _GroupByClip; }
            private set { _GroupByClip = value; }
        }


        public Dictionary<string, KeyValuePair<string, WhereClip>> Joins
        {
            get { return _Joins; }
            private set { _Joins = value; }
        }


        public List<Field> Fields
        {
            get { return _Fields; }
            private set { _Fields = value; }
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
                    //  处理groupby的having
                    if (!GroupByClip.IsNullOrEmpty(_GroupByClip) && !WhereClip.IsNullOrEmpty(_HavingClip))
                    {
                        foreach (var item in _HavingClip.Parameters)
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
        public LambdaQueryHelper(IDbConnection connection, IDbTransaction transaction, IClassMapper classMap, int? commandTimeout = null)
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

        #region Sql组装  Select  OrderBy  Group ……


        /// <summary>
        /// 查询条件赋值
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public LambdaQueryHelper Select(params Field[] fields)
        {
            IsChangeSql();
            this._Fields.Clear();
            return AddSelect(fields);
        }

        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public LambdaQueryHelper AddSelect(params Field[] fields)
        {
            if (null != fields && fields.Length > 0)
            {
                IsChangeSql();
                foreach (Field field in fields)
                {
                    Field f = this._Fields.Find(fi => fi.Name.Equals(field.Name) && fi.TableName.Equals(field.TableName));
                    if (Field.IsNullOrEmpty(f))
                        this._Fields.Add(field);
                }
            }
            return this;
        }


        protected LambdaQueryHelper Where(WhereClip where)
        {
            IsChangeSql();
            this._WhereClip = where;
            return this;
        }


        protected LambdaQueryHelper OrderBy(OrderByClip orderBy)
        {
            IsChangeSql();
            this._OrderByClip = orderBy;
            return this;
        }

        protected LambdaQueryHelper AddOrderBy(OrderByClip orderBy)
        {
            IsChangeSql();
            this._OrderByClip = this._OrderByClip && orderBy; ;
            return this;
        }




        public LambdaQueryHelper GroupBy(GroupByClip groupBy)
        {
            IsChangeSql();
            this._GroupByClip = groupBy;
            return this;
        }


        public LambdaQueryHelper Having(WhereClip havingWhere)
        {
            IsChangeSql();
            this._HavingClip = havingWhere;
            return this;
        }

        public LambdaQueryHelper Distinct()
        {
            IsChangeSql();
            this.DistinctString = " DISTINCT ";
            return this;
        }


        public LambdaQueryHelper WithNoLock()
        {
            IsChangeSql();
            this.EnabledNoLock = true;
            return this;
        }

        public LambdaQueryHelper Top(int topCount)
        {
            if (topCount > 0)
            {
                IsChangeSql();
                this.PageIndex = 1;
                this.PageSize = topCount;
            }
            return this;
        }


        public LambdaQueryHelper Page(int pageIndex, int pageSize)
        {
            IsChangeSql();
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            return this;
        }

        #endregion

        #region  JOIN


        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <param name="joinType"></param>
        /// <returns></returns>
        protected LambdaQueryHelper Join(string tableName, WhereClip where, JoinType joinType)
        {
            IsChangeSql();
            if (string.IsNullOrEmpty(tableName) || WhereClip.IsNullOrEmpty(where))
                return this;
            if (!_Joins.ContainsKey(tableName))
            {
                _Joins.Add(tableName, new KeyValuePair<string, WhereClip>(DapperExtension.DapperImplementor.SqlGenerator.Configuration.Dialect.GetJoinString(joinType), where));
                if (where.Parameters.Count > 0)
                {
                    foreach (var item in where.Parameters)
                    {
                        _Parameters.Add(item.ParameterName, item);
                    }
                }

            }

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

                    _SqlString = DapperExtension.DapperImplementor.SqlGenerator.LambdaSelect(this, ref _Parameters);
                }
                return _SqlString;
            }
        }

        #region Execute

        public IDataReader ToDataReader()
        {
            if (Transaction != null)
            {
                return DBUtils.GetDBHelper(DbType).ExecuteReader(Transaction, this.SqlString, CommandType.Text, DBUtils.ConvertToDbParameter(Parameters, DbType).ToArray());
            }
            else
            {
                return DBUtils.GetDBHelper(DbType).ExecuteReader(Connection, this.SqlString, CommandType.Text, DBUtils.ConvertToDbParameter(Parameters, DbType).ToArray());
            }
        }

        public DataSet ToDataSet()
        {
            if (Transaction != null)
            {
                return DBUtils.GetDBHelper(DbType).ExecuteDataSet(Transaction, this.SqlString, CommandType.Text, DBUtils.ConvertToDbParameter(Parameters, DbType).ToArray());
            }
            else
            {
                return DBUtils.GetDBHelper(DbType).ExecuteDataSet(Connection, this.SqlString, CommandType.Text, DBUtils.ConvertToDbParameter(Parameters, DbType).ToArray());
            }
        }

        public DataTable ToDataTable()
        {
            return this.ToDataSet().Tables[0];
        }



        public IEnumerable<T> ToList<T>() where T : class
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var item in Parameters)
            {
                dynamicParameters.Add(item.Value.ParameterName, item.Value.ParameterValue);
            }
            return Connection.Query<T>(this.SqlString, dynamicParameters, Transaction, true, CommandTimeout, CommandType.Text);
        }



        IEnumerable<TReturn> ToList<TFirst, TSecond, TReturn>(Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var item in Parameters)
            {
                dynamicParameters.Add(item.Value.ParameterName, item.Value.ParameterValue);
            }
            return Connection.Query<TFirst, TSecond, TReturn>(this.SqlString, map, dynamicParameters, Transaction, true, splitOn, CommandTimeout, CommandType.Text);
        }

        IEnumerable<TReturn> ToList<TFirst, TSecond, TThird, TReturn>(Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id")
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var item in Parameters)
            {
                dynamicParameters.Add(item.Value.ParameterName, item.Value.ParameterValue);
            }
            return Connection.Query<TFirst, TSecond, TThird, TReturn>(this.SqlString, map, dynamicParameters, Transaction, true, splitOn, CommandTimeout, CommandType.Text);
        }
              


        /// <summary>
        /// 执行sql 返回总行数    请在 Page方法之前执行
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            string sql = DapperExtension.DapperImplementor.SqlGenerator.PageCount(this.SqlString);
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var item in Parameters)
            {
                dynamicParameters.Add(item.Value.ParameterName, item.Value.ParameterValue);
            }
            return (int)Connection.Query(sql, dynamicParameters, Transaction, false, CommandTimeout, CommandType.Text).Single().Total;
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
