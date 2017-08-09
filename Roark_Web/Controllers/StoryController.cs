using Abstract;
using Entities;
using RepositoryContract;
using Roark_Web.Models;
using Roark_Web.Models.ModelFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roark_Web.Controllers
{
    public class StoryController : Controller
    {
        private IRoarkService _roarkService;
        private IRepository _repository;
        private IUserHelper _userHelper;

        public StoryController(IRoarkService roarkService, IRepository repository, IUserHelper userHelper)
        {
            _roarkService = roarkService;
            _repository = repository;
            _userHelper = userHelper;
        }
        
        public ActionResult Index()
        {
            User currUser = _userHelper.GetCurrentUser();
            var allUserStories = _roarkService.GetUserStories(currUser.UserId);

            var model = allUserStories.Select(s => ToVMFactory.ToStoryVM(s));

            return View(model);
        }
        
        //Use roarkService to generate the end story here
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
