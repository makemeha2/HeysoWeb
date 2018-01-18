using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using HeysoHomeWeb.WebCommon;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HeysoHomeWeb.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController()
        {
            
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult Login(FormCollection collection, string ReturnUrl)
        {
            try
            {
                GetContextObjects();

                var userInfo = new UserModel();
                var userId = collection["Email"];
                var password = collection["Password"];
                var remember = (collection["Remember"] == "on" ? true : false);

                var loginUser = _userRepository.GetLoginUser(userId, password);

                if (loginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(loginUser.NickName, remember);

                    var redirectUrl = !string.IsNullOrWhiteSpace(ReturnUrl) ? ReturnUrl : string.Empty;
                    return Json(new ResultModel("1", redirectUrl));
                }
                else
                {
                    return Json(new ResultModel("-1", "등록되지 않은 사용자 입니다."));
                }
            }
            catch(Exception ex)
            {
                return Json(new ResultModel("-1", ex.Message));
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult IsNotExist(string email)
        {
            GetContextObjects();

            var userInfo = _userRepository.GetUser(email);

            if (userInfo == null)
            {
                return Json("true");
            }
            else
            {
                return Json("이미 존재하는 email 주소입니다.");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Create(FormCollection collection)
        {
            try
            {
                GetContextObjects();

                var userInfo = new UserModel();
                userInfo.UserId = collection["Email"];
                userInfo.Password = collection["Password"];
                userInfo.NickName = collection["NickName"];

                var existData = _userRepository.GetUser(userInfo.UserId);

                if (existData == null)
                {
                    _userRepository.InsertUser(userInfo);

                    return Json(new ResultModel("1", ""));
                }
                else
                {
                    return Json(new ResultModel("-1", "이미 존재하는 email 주소입니다."));
                }
            }
            catch(Exception ex)
            {
                return Json(new ResultModel("-1", ex.Message));
            }
        }
        
        private void GetContextObjects()
        {
            var appContext = (XmlApplicationContext)HttpContext.Application["appContext"];
            _userRepository = appContext.GetObject<UserRepository>("userRepository");
        }
    }
}
