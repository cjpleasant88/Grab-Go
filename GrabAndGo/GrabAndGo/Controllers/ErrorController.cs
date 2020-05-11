using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrabAndGo.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpsStatusCodeHandler(int statusCode)
        {
            //var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();


            //ViewBag.Path = statusCodeResult.OriginalPath;

            //ViewBag.QS = statusCodeResult.OriginalQueryString;

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    break;
                case 123:
                    ViewBag.ErrorMessage = "Sorry, that user does not exist";
                    break;
                default:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found!";
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");
        }
    }
}