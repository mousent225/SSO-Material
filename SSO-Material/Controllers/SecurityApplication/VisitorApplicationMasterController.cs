
using SSO_Material.Repositories.SecurityApplication;
using SSO_Material.Utilities;
using SSO_Material.ViewModels.SecurityApplication;
using System;
using System.Security.Claims;
using System.Web.Mvc;

namespace SSO_Material.Controllers.SecurityApplication
{
    [KSAuthorized]
    public class VisitorApplicationMasterController : Controller
    {
        VisitorApplicationMasterRepository _rep = new VisitorApplicationMasterRepository();
        // GET: VisitorApplicationMaster
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetAll(DateTime fromDate, DateTime toDate, string applicationType, string userId, string approvalStatus)
        {
            var list = _rep.GetAll(fromDate, toDate, applicationType, User.GetClaimValue(ClaimTypes.Sid), approvalStatus);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowApplicationDetail()
        {
            return PartialView("_ShortTerm");
        }
        #region Vendor
        public ActionResult GetListVendor(int? id, DateTime fromDate, DateTime toDate)
        {
            var list = _rep.GetListVendor(id, fromDate, toDate, User.GetClaimValue(ClaimTypes.Sid));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowVendorInformation()
        {
            return PartialView("_Vendor");
        }
        public ActionResult ShowVendorInformationView(int id)
        {
            var list = _rep.GetListVendor(id, DateTime.MinValue, DateTime.MaxValue, User.GetClaimValue(ClaimTypes.Sid));
            return PartialView("_VendorView", list[0]);
        }
        public ActionResult ShowVendorList()
        {
            return PartialView("_VendorList");
        }
        public JsonResult VendorInsert(VendorModel model)
        {
            var result = _rep.VendorInsert(model, User.GetClaimValue(ClaimTypes.Sid));
            return Json(result);
        }
        public JsonResult VendorUpdate(VendorModel model)
        {
            var result = _rep.VendorUpdate(model, User.GetClaimValue(ClaimTypes.Sid));
            return Json(result);
        }
        public JsonResult VendorDelete(int id)
        {
            var result = _rep.VendorDelete(id, User.GetClaimValue(ClaimTypes.Sid));
            return Json(result);
        }

        #endregion
    }
}