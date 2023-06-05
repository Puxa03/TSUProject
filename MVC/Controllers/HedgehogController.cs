using Hedgehogs.Services.Abstract;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Hedgehogs.MVC.Models;
using Hedgehogs.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hedgehogs.Services.Models;
using Hedgehogs.MVC.Infrastructure.Localizations;
using System.Globalization;

namespace Hedgehogs.MVC.Controllers
{
    
    public class HedgehogController : Controller
    {
        
        private readonly IHedgehogService _service;

        public HedgehogController(IHedgehogService service)
        {
           
            _service = service;
        }


        #region Index-Read

        public async Task <IActionResult> Index()
        {            
            var hedgehogsServiceModel = await _service.GetAllAsync();
            //this mapping is easy for mapster and it doesnt require configs
            var hedgehogList = new HedgehogListViewModel()
            {
                Hedgehogs = hedgehogsServiceModel.Adapt<List<Hedgehog>>()
            };
            ViewBag.Phrase = Phrases.Discover;
            return View(hedgehogList);
        }

        #endregion

        #region create
        public IActionResult Create()
        {
            ViewBag.Phrase = Phrases.Create;            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HedgehogPostRequest hedgehog)
        {
            
            await _service.Create(hedgehog.Adapt<HedgehogServiceModel>());
            return Redirect("../Hedgehog");
        }
        #endregion

        #region delete
        public IActionResult DeleteMenu()
        {
            ViewBag.Phrase = Phrases.Kill;
            return View();
        }      

        public IActionResult DeletePage(int id)
        {
            ViewBag.Id = id;
            ViewBag.Phrase = Phrases.Kill;
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result == System.Net.HttpStatusCode.OK)
            {
                return Redirect("../Hedgehog");
            }
            ViewBag.Id = id;
            return View("HedgehogNotFound");
        }
        #endregion

        #region update
        public IActionResult UpdateMenu()
        {
            ViewBag.Phrase = Phrases.Update;
            return View();
        }

        public IActionResult UpdatePage(int id)
        {
            ViewBag.Id = id;
            ViewBag.Phrase = Phrases.Update;
            return View();
        }

        public async Task<IActionResult> Update(Hedgehog hedgehog)
        {
            var result = await _service.Update(hedgehog.Adapt<HedgehogServiceModel>());
            if (result == System.Net.HttpStatusCode.OK)
            {
                return Redirect("../Hedgehog");
            }
            ViewBag.Id = hedgehog.Id;
            return View("HedgehogNotFound");
        }
        #endregion
    }
}
