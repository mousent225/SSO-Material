
using SSO_Material.Repositories.SecurityApplication;
using SSO_Material.Utilities;
using SSO_Material.ViewModels.SecurityApplication;
using System;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.UI;

namespace SSO_Material.Controllers.SecurityApplication
{
    [KSAuthorized]
    public class VisitorApplicationMasterController : Controller
    {
        #region Application Master
        VisitorApplicationMasterRepository _rep = new VisitorApplicationMasterRepository();
        // GET: VisitorApplicationMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDetail(string id)
        {
            ViewBag.ApplicationId = id;
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetAll(DateTime fromDate, DateTime toDate, int? applicationType, string userId, string approvalStatus)
        {
            var list = _rep.GetAll(null, fromDate, toDate, applicationType, User.GetClaimValue(ClaimTypes.Sid), approvalStatus == "" ? null : approvalStatus);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult ShowApplicationDetail()
        {
            return PartialView("_ShortTerm");
        }

        public ActionResult ShowApplicationDetailView(string id)
        {
            var item = _rep.GetMasterDetail(int.Parse(Util.Decrypt(id).Split('_')[0]), User.GetClaimValue(ClaimTypes.Sid));
            return PartialView("_ShortTermView", item);
        }

        public int ApplicationMasterInsert(VisitorApplicationMasterModel model)
        {
            if (model.Id == 0)
                return _rep.ApplicationMasterInsert(model, User.GetClaimValue(ClaimTypes.Sid));
            else
            {
                _rep.ApplicationMasterUpdate(model, User.GetClaimValue(ClaimTypes.Sid));
                return model.Id;
            }
        }
        
        public JsonResult ApplicationMasterUpdateAll(VisitorApplicationMasterModel model)
        {
            return Json(_rep.ApplicationMasterUpdateAll(model, User.GetClaimValue(ClaimTypes.Sid)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApplicationMasterDelete(int id)
        {
            return Json(_rep.ApplicationMasterDelete(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApplicationMasterDeleteUpdate(int id)
        {
            return Json(_rep.ApplicationMasterDeleteUpdate(id, User.GetClaimValue(ClaimTypes.Sid)), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Detail

        public ActionResult GetDetail(int applicationMasterId)
        {
            var list = _rep.GetDetail(applicationMasterId, null);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DetailInsert(VisitorApplicationDetailModel model)
        {
            return Json( _rep.DetailInsert(model, User.GetClaimValue(ClaimTypes.Sid)));
        }
        public JsonResult DetailUpdate(VisitorApplicationDetailModel model)
        {
            return Json(_rep.DetailUpdate(model, User.GetClaimValue(ClaimTypes.Sid)));
        }
        public JsonResult DetailDelete(int id)
        {
            return Json(_rep.DetailDelete(id, User.GetClaimValue(ClaimTypes.Sid)));
        }
        public ActionResult ShowVisitorDetail()
        {
            return PartialView("_VisitorInfor");
        }
        public ActionResult ShowVisitorDetailView(int id)
        {
            var model = _rep.GetDetail(null, id)[0];
            return PartialView("_VisitorInforView", model);
        }

        #endregion

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

        #region Approval Line
        public string DefaultApprovalLine(int applicationId)
        {
            return _rep.GetDefaultApproval(applicationId);
        }
        public ActionResult ApprvalLineHistory(int applicationId)
        {
            var result = _rep.ApprovalHistoryGetList(User.GetClaimValue(ClaimTypes.Sid), applicationId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetApproveHistory(int applicationId, int masterId)
        {
            var result = _rep.GetApprovalHistory(applicationId, masterId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApprovalLine(int applicationId, int masterId)
        {
            return Json(_rep.GetApproval(applicationId, masterId), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Confirm(int id, bool isConfirm, string linkApplication)
        {
            return Json( _rep.ApplicationConfirm(id, isConfirm, linkApplication));
        }
        public JsonResult Approve(ApprovalModel model)
        {
            return Json(_rep.ApproveApplication(model, User.GetClaimValue(ClaimTypes.Sid)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Recall(int masterId, int applicationId)
        {
            return Json(_rep.RecallApplication(masterId, applicationId, User.GetClaimValue(ClaimTypes.Sid)));
        }
        #endregion
    }
}