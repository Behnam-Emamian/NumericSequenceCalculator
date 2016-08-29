using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using PersianProcess.NCS.Model;

namespace PersianProcess.NCS.WebAPI.Controllers
{
    public class SequenceNumbers2Controller : ApiController
    {
        private Entities db = new Entities();

        public DataSourceResult GetSequenceNumbers([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            return db.SequenceNumbers.ToDataSourceResult(request);
        }

        public SequenceNumber GetSequenceNumber(int id)
        {
            SequenceNumber sequenceNumber = db.SequenceNumbers.Find(id);
            if (sequenceNumber == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return sequenceNumber;
        }

        public HttpResponseMessage PutSequenceNumber(int id, SequenceNumber sequenceNumber)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != sequenceNumber.SequenceNumberId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry(sequenceNumber).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage PostSequenceNumber(SequenceNumber sequenceNumber)
        {
            if (ModelState.IsValid)
            {
                db.SequenceNumbers.Add(sequenceNumber);
                db.SaveChanges();

                DataSourceResult result = new DataSourceResult
                {
                    Data = new[] { sequenceNumber },
                    Total = 1
                };

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, result);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = sequenceNumber.SequenceNumberId }));

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage DeleteSequenceNumber(int id)
        {
            SequenceNumber sequenceNumber = db.SequenceNumbers.Find(id);

            if (sequenceNumber == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                db.SequenceNumbers.Remove(sequenceNumber);

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, sequenceNumber);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}