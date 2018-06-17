using CandidateTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTracker.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCandidate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCandidate(Candidate candidate)
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            repo.AddCandidate(candidate);
            return Redirect("/home/pending");
        }
        public ActionResult Pending()
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetPending());
        }
        public ActionResult Confirmed()
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetConfirmed());
        }
        public ActionResult Declined()
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetDeclined());
        }
        public ActionResult ViewDetails(int id)
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            return View(repo.ViewCandidateDetails(id));
        }
        [HttpPost]
        public void Confirm(int id)
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            repo.SetConfirmedStatus(id);
        }
        [HttpPost]
        public void Decline(int id)
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            repo.SetDeclinedStatus(id);
        }
        public ActionResult UpdateStatus()
        {
            var repo = new CandidateRepository(Properties.Settings.Default.ConStr);
            return Json(new { Pending = repo.GetPendingCount(), Confirmed = repo.GetConfirmedCount(), Declined = repo.GetDeclinedCount() }, JsonRequestBehavior.AllowGet);
        }
    }
}
