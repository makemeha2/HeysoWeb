using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HeysoHomeWeb.Controllers
{
    public class QnAController : Controller
    {
        private QnARepository _qnaRepository;

        // GET: QnA
        public ActionResult Index()
        {
            var currDate = DateTime.Now.ToString("yyyy-MM-dd");

            var yyyy = currDate.Substring(0, 4);
            var mm = currDate.Substring(5, 2);
            var dd = currDate.Substring(8, 2);
            var userId = string.Empty;

            var qnaData = GetQnAData(yyyy, mm, dd, userId);

            return View(); 
        }

        private QnAModel GetQnAData(string yyyy, string mm, string dd, string userId)
        {
            var paramQnA = new QnAModel();
            paramQnA.YYYY = yyyy;
            paramQnA.MM = mm;
            paramQnA.DD = dd;
            paramQnA.UserId = userId;

            GetContextObjects();

            return _qnaRepository.GetQnAData(paramQnA);

        }

        private void GetContextObjects()
        {
            var appContext = (XmlApplicationContext)HttpContext.Application["appContext"];
            _qnaRepository = appContext.GetObject<QnARepository>("qnARepository");
        }
    }
}