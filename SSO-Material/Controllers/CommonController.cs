using SSO_Material.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSO_Material.Controllers
{
    public class CommonController : Controller
    {
        readonly CommonRepository _res = new CommonRepository();
        // GET: Dept
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDeptTreeView()
        {
            var result = _res.GetDeptTreeView();
            return result.Any() ? Json(result, JsonRequestBehavior.AllowGet) : null;
        }
        #region employee 
        public ActionResult ShowModalEmployeeInfor(string id)
        {
            ViewBag.EmpId = id;
            return PartialView("_EmployeeInfor");
        }

        public JsonResult GetEmployeeInfor(int deptCode, string userId, string userName, string status, string nation, string sex, bool? hasEmail)
        {
            var result = Json(_res.GetUsers(1, userId, userName, status, deptCode, sex, nation, hasEmail), JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.Parse(ConfigurationManager.AppSettings["MaxJsonLength"]);
            return result;
        }
        #endregion
    }
        
}