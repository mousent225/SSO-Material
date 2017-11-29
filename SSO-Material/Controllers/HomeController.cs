using SSO_Material.Repositories;
using SSO_Material.Utilities;
using SSO_Material.ViewModels;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace SSO_Material.Controllers
{
    [KSAuthorized]
    public class HomeController : Controller
    {
        ForgetCardRepository _rep = new ForgetCardRepository();
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Print(string empId, DateTime workDate)
        {
            return View(_rep.GetInfor(empId, workDate));
        }
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public ActionResult GetAll(int deptId, string empId, string empName, string position, string jobTitle, DateTime fromDate, DateTime toDate)
        {
            return Json(_rep.GetAll(deptId, empId == "" ? null : empId, empName == "" ? null : empName, position == "" ? null : position
                    , jobTitle == "" ? null : jobTitle, fromDate, toDate), JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public JsonResult GetForGetCardInfor(string empId, DateTime? workDate)
        {
            var result = Json(_rep.GetInfor(empId, workDate));
            result.MaxJsonLength = int.Parse(ConfigurationManager.AppSettings["MaxJsonLength"]);
            return result;
        }
        [AllowAnonymous]
        public JsonResult UpdateForgetCardInfor(ForgetCardModel model)
        {
            return Json(_rep.UpdateForgetCard(model));
        }
        [AllowAnonymous]
        public JsonResult DeleteForgetCardInfor(string empId, DateTime? workDate)
        {
            return Json(_rep.DeleteForgetCard(empId, workDate));
        }
        [AllowAnonymous]
        public ActionResult ShowPersionalInformation()
        {
            return PartialView("_PersonalInformation");
        }
    }
}