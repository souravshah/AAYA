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
    public class SearchController : Controller
    {
        private IDataRepositoryFactory _repositoryFactory;
        //public SearchController(IDataRepositoryFactory repositoryFactory)
        //{
        //    _repositoryFactory = repositoryFactory;
        //}

        public ActionResult GetAllChildCareBySuburb(string suburb)
        {
            _repositoryFactory = new DataRepositoryFactory();
            var childCareRepository = _repositoryFactory.GetDataRepository<IChildCareRepository>();
            var result = childCareRepository.GetChildCareBySuburb(suburb);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}