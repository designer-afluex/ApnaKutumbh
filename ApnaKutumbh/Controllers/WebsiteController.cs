using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApnaKutumbh.Models;
using ApnaKutumbh.Filter;
using System.Data;
using System.Net.Mail;

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
            List<Master> lstImge = new List<Master>();
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
                    Master objs = new Master();
                    objs.SiteImage = r["SiteImage"].ToString();
                    objs.SiteImage1 = r["Image1"].ToString();
                    objs.SiteImage2 = r["Image2"].ToString();
                    objs.SiteImage3 = r["Image3"].ToString();
                    objs.SiteName = r["SiteName"].ToString();
                    lstSite.Add(objs);
                }
                model.lstSite = lstSite;
            }
            DataSet dss = model.PropertyTypeImage();

            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dss.Tables[0].Rows)
                {
                    Master obj1 = new Master();
                    obj1.SiteImage = r["SiteImage"].ToString();
                    //obj1.SiteImage1 = r["Image1"].ToString();
                    //obj1.SiteImage2 = r["Image2"].ToString();
                    //obj1.SiteImage3 = r["Image3"].ToString();
                    obj1.SiteName = r["SiteName"].ToString();
                    lstImge.Add(obj1);
                }
                model.lstImge = lstImge;
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Property()
        {
            List<Master> lst = new List<Master>();
            Master model = new Master();
            DataSet ds = model.GetSiteList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.SiteID = r["PK_SiteID"].ToString();
                    obj.EncryptKey = Crypto.Encrypt(r["PK_SiteID"].ToString());
                    obj.SiteName = r["SiteName"].ToString();
                    obj.Location = r["Location"].ToString();
                    obj.Rate = r["Rate"].ToString();
                    obj.UnitName = (r["UnitName"].ToString());
                    obj.DevelopmentCharge = (r["DevelopmentCharge"].ToString());
                    obj.SiteTypeName = (r["SiteTypeName"].ToString());
                    obj.SiteImage = (r["Image"].ToString());
                    obj.SiteImage1 = (r["Image1"].ToString());
                    obj.SiteImage2 = (r["Image2"].ToString());
                    obj.SiteImage3 = (r["Image3"].ToString());
                    obj.IsPopular = (r["IsPopular"].ToString());

                    lst.Add(obj);
                }
                model.lstSite = lst;
            }

            return View(model);
        }

        public ActionResult PropertyDetails( string SiteName)
        {
            if(SiteName==null)
            {
                return RedirectToAction("Property");
            }
            Master model = new Master();
            //model.AddedBy = Session["Pk_AdminId"].ToString();
            model.SiteName = SiteName;
            DataSet ds = model.GetPlotDetailsbySite();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    model.Location = r["Location"].ToString();
                    model.Rate = (r["Rate"].ToString());
                    model.SectorName =(r["SectorName"].ToString());
                    model.BlockName = (r["BlockName"].ToString());
                    model.Image = (r["Image"].ToString());
                    model.SiteName = (r["SiteName"].ToString());
                }
            }
            return View(model);           
        }
       
        [HttpPost]

        public ActionResult SendEmail(Master model)
        {
           
            if (model.Email != null)
            {                 
                try
                {
                    DataSet ds = model.SaveEnquiryDetails();

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

                }
            }
            return RedirectToAction("PropertyDetails");
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