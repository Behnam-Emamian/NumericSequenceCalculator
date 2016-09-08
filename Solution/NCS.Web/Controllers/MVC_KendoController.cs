﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PersianProcess.NCS.Model;

namespace PersianProcess.NCS.Web.Controllers
{
    public class MVC_KendoController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            
            var Model = db.SequenceNumbers;
            return View(Model);
        }

        public ActionResult SequenceNumbers_Read([DataSourceRequest]DataSourceRequest request)
        {
            //IQueryable<SequenceNumber> sequencenumbers = db.SequenceNumbers.OrderBy(Num => Num.Number);
            IQueryable<SequenceNumber> sequencenumbers = db.SequenceNumbers.OrderBy(Num => Num.Number);
            DataSourceResult result = sequencenumbers.ToDataSourceResult(request, sequenceNumber => new {
                SequenceNumberId = sequenceNumber.SequenceNumberId,
                Number = sequenceNumber.Number,
                IsOdd = sequenceNumber.IsOdd,
                IsEven = sequenceNumber.IsEven,
                IsMultipleBy3 = sequenceNumber.IsMultipleBy3,
                IsMultipleBy5 = sequenceNumber.IsMultipleBy5,
                IsFibonacci = sequenceNumber.IsFibonacci
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SequenceNumbers_Create([DataSourceRequest]DataSourceRequest request, SequenceNumber sequenceNumber)
        {
            if (ModelState.IsValid)
            {
                var entity = new SequenceNumber
                {
                    Number = sequenceNumber.Number
                };

                db.SequenceNumbers.Add(entity);
                db.SaveChanges();
                sequenceNumber.SequenceNumberId = entity.SequenceNumberId;
            }

            return Json(new[] { sequenceNumber }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SequenceNumbers_Destroy([DataSourceRequest]DataSourceRequest request, SequenceNumber sequenceNumber)
        {
            if (ModelState.IsValid)
            {
                var entity = new SequenceNumber
                {
                    SequenceNumberId = sequenceNumber.SequenceNumberId,
                    Number = sequenceNumber.Number,
                    IsOdd = sequenceNumber.IsOdd,
                    IsEven = sequenceNumber.IsEven,
                    IsMultipleBy3 = sequenceNumber.IsMultipleBy3,
                    IsMultipleBy5 = sequenceNumber.IsMultipleBy5,
                    IsFibonacci = sequenceNumber.IsFibonacci
                };

                //db.SequenceNumbers.Attach(entity);
                db.SequenceNumbers.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { sequenceNumber }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
