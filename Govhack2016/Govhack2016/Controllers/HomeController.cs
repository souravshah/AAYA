using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GovHack.Data.Contracts;
using GovHack.Data.Contracts.Repository_Interfaces;
using GovHack.Data.Repositories;

namespace Govhack2016.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepositoryFactory _repositoryFactory;
        public ActionResult GetAllSuburbs()
        {
            _repositoryFactory = new DataRepositoryFactory();
            var childCareRepository = _repositoryFactory.GetDataRepository<IChildCareRepository>();
            var result = childCareRepository.GetAllSuburbs();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
