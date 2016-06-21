using DepositCalculator.Containers;
using DepositCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DepositCalculator.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        CalculatorsContainer cc = new CalculatorsContainer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculators()
        {
            List<Calculator> calculators = cc.GetAllCalculators().Result;
            return View(calculators);
        }

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(new Calculator());
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Calculator calculator)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = cc.CreateNewCalculator(calculator);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Calculators");
                }
            }
            return View(new Calculator());
        }


        public ActionResult Details(int? calculatorId)
        {
            if (calculatorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calculator calculator = cc.GetSingleCalculator((int)calculatorId).Result;
            if (calculator == null)
            {
                return HttpNotFound();
            }

            return View(calculator);
        }

        public ActionResult Edit(int? calculatorId)
        {
            if (calculatorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calculator calculator = cc.GetSingleCalculator((int)calculatorId).Result;
            if (calculator == null)
            {
                return HttpNotFound();
            }
            return View(calculator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Calculator calculator)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = cc.UpdateCalculator(calculator);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Calculators");
                }
            }
            return View(calculator);
        }

        public ActionResult Delete(int? calculatorId)
        {
            if (calculatorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calculator calculator = cc.GetSingleCalculator((int)calculatorId).Result;
            if (calculator == null)
            {
                return HttpNotFound();
            }

            return View(calculator);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int calculatorId)
        {
            Calculator calculator = cc.GetSingleCalculator((int)calculatorId).Result;
            if (calculator == null)
            {
                return HttpNotFound();
            }

            HttpResponseMessage response = cc.DeleteCalculator(calculator);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Calculators");
            }

            return RedirectToAction("Delete", calculatorId);
        }

    }
}