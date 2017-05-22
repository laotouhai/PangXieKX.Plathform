using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PangXieKX.Plathform.Model.Entities;
using PangXieKX.Plathform.IBusiness;
using PangXieKX.Plathform.IDataAccess;
using PangXieKX.Plathform.Model.ViewModel;

namespace PangXieKX.Plathform.Business
{
    public class MemberMenuBLL : IMemberMenuBLL
    {
        private readonly IMemberMenuDAL _dal;

        public MemberMenuBLL(IMemberMenuDAL dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <param name="predList">查询条件对象</param>
        /// <returns></returns>
        public List<MemberMenuVM> GetMenuList(object predList)
        {
            var menuLists = _dal.GetList(predList).ToList();
            var menuTrees = ConvertToMenuTrees(new List<MemberMenuVM>(), menuLists);
            return menuTrees;
        }

        #region 私有方法
        /// <summary>
        /// 生成菜单树
        /// </summary>
        /// <param name="menuTrees"></param>
        /// <param name="menuLists"></param>
        /// <returns></returns>
        private List<MemberMenuVM> ConvertToMenuTrees(List<MemberMenuVM> menuTrees, List<MemberMenu> menuLists)
        {
            for (int i = 0; i < menuLists.Count; i++ )
            {
                if (menuLists[i].ParentId != 0)
                {
                    if (menuTrees.Where(x => x.Id == menuLists[i].ParentId) != null)
                    {
                        var treeObj = new MemberMenuVM
                        {
                            Id = menuLists[i].Id,
                            MenuName = menuLists[i].MenuName,
                            ParentId = menuLists[i].ParentId,
                            MenuUrl = menuLists[i].MenuUrl,
                            MenuIcon = menuLists[i].MenuIcon,
                            Children = new List<MemberMenuVM>()
                        };
                        menuTrees.ForEach(o =>
                        {
                            if (o.Id == menuLists[i].ParentId) o.Children.Add(treeObj);
                        });
                        menuLists.RemoveAll(x => x.Id == menuLists[i].Id);
                        ConvertToMenuTrees(menuTrees, menuLists);
                    }
                    else
                    {
                        ConvertToMenuTrees(menuTrees, menuLists);
                    }
                }
                else
                {
                    var treeObj = new MemberMenuVM
                    {
                        Id = menuLists[i].Id,
                        MenuName = menuLists[i].MenuName,
                        ParentId = menuLists[i].ParentId,
                        MenuUrl = menuLists[i].MenuUrl,
                        MenuIcon = menuLists[i].MenuIcon,
                        Children = new List<MemberMenuVM>()
                    };
                    menuTrees.Add(treeObj);
                    menuLists.RemoveAll(x => x.Id == menuLists[i].Id);
                    ConvertToMenuTrees(menuTrees, menuLists);
                }
            }
            return menuTrees;
        }
        #endregion
    }
}
