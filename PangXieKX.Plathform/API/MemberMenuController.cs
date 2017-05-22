using PangXieKX.Plathform.IBusiness;
using PangXieKX.Plathform.Model.Entities;
using PangXieKX.Plathform.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PangXieKX.Plathform.API
{
    public class MemberMenuController : ApiController
    {
        private readonly IMemberMenuBLL _memberMenuBll;

        public MemberMenuController(IMemberMenuBLL memberMenuBll)
        {
            _memberMenuBll = memberMenuBll;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MemberMenuVM> GetMenus()
        {
            var menuList = _memberMenuBll.GetMenuList(null);
            return menuList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}