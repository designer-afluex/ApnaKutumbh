using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApnaKutumbh.Models;
using ApnaKutumbh.Filter;
using System.Data;

namespace ApnaKutumbh.Controllers
{
    public class WebsiteController : Controller
    {
        //GET: Website
        public ActionResult Index()
        {



            return Redirect("/AgencyBazaarLandingPage/index.html");
            //return View();
        }

        public ActionResult Home()
        {
            
           
            Master model = new Master();
            List<Master> lstSite = new List<Master>();
            List<Master> SiteType = new List<Master>();


            DataSet ds2 = model.GetSiteTypeList();
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds2.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.SiteTypeName = r["SiteTypeName"].ToString();
                    SiteType.Add(obj);
                    
                }

            }

            model.SiteType = SiteType;


            DataSet ds = model.GetSiteImage();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.SiteImage = r["SiteImage"].ToString();
                    obj.SiteName = r["SiteName"].ToString();
                    lstSite.Add(obj);
                }
                model.lstSite = lstSite;
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Property()
        {
            return View();
        }

        public ActionResult PropertyDetails()
        {
            return View();
        }


        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ActionName("ContactUs")]
        [OnAction(ButtonName = "btnsave")]
        public ActionResult ContactUs(Website model)
        {
            try
            {
                DataSet ds = model.SaveContact();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        TempData["Contactmsg"] = "Details saved successfully !";
                    }
                    else if (ds.Tables[0].Rows[0]["MSG"].ToString() == "0")
                    {
                        TempData["Contactmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                    else
                    {
                        TempData["Contactmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["Contactmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["Contactmsg"] = ex.Message;
            }
            return RedirectToAction("ContactUs", "Website");
        }

        public ActionResult Signin()
        {
            return View();
        }
    }
}