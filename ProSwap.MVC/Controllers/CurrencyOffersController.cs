﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProSwap.Data;
using ProSwap.Data.OfferTypes;
using ProSwap.Services;

//namespace ProSwap.MVC.Controllers
//{
    //public class CurrencyOffersController : Controller
    //{
    //    private ApplicationDbContext db = new ApplicationDbContext();
    //    private Guid _userId;


    //    // GET: CurrencyOffers
    //    public ActionResult Index()
    //    {
    //        AccountOfferService _accountofferService = CreateAccountOfferService();
    //        var model = _accountofferService.GetAccountOffers();
    //        return View(model.ToList());
    //    }


    //    // GET: CurrencyOffers/Create
    //    public ActionResult Create()
    //    {
    //        var games = db.Games.ToList();
    //        var gameList = new SelectList(games.Select(e => new SelectListItem()
    //        {
    //            Value = e.ID.ToString(),
    //            Text = e.Name
    //        }).ToList(), "Value", "Text");

    //        var model = new CurrencyOfferCreate()
    //        {
    //            ListOfGames = gameList
    //        };

    //        return View(model);
    //    }

    //    // POST: Offers/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(AccountOfferCreate offer)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _userId = Guid.Parse(User.Identity.GetUserId());
    //            var _accountOfferService = new AccountOfferService(_userId);
    //            _accountOfferService.CreateAccountOffer(offer);
    //            return RedirectToAction("Index");
    //        }

    //        ViewBag.GameID = new SelectList(db.Games, "ID", "Name", offer.GameId);
    //        return View(offer);
    //    }

    //    // GET: Offers/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        var svc = CreateAccountOfferService();
    //        var model = svc.GetAccountOfferById(id);
    //        return View(model);
    //    }

    //    // GET: Offers/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        var service = CreateAccountOfferService();
    //        var detail = service.GetAccountOfferById(id);
    //        var model =
    //            new AccountOfferEdit
    //            {
    //                OfferId = detail.OfferId,
    //                Title = detail.Title,
    //                Body = detail.Body,
    //                IsActive = detail.IsActive
    //            };
    //        return View(model);
    //    }

    //    // POST: Offers/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(int id, AccountOfferEdit model)
    //    {
    //        if (!ModelState.IsValid) return View(model);

    //        if (model.OfferId != id)
    //        {
    //            ModelState.AddModelError("", "Id Mismatch");
    //            return View(model);
    //        }

    //        var service = CreateAccountOfferService();

    //        if (service.UpdateAccountOffer(model))
    //        {
    //            TempData["SaveResult"] = "Your account offer was modified.";
    //            return RedirectToAction("Index");
    //        }

    //        ModelState.AddModelError("", "Your account offer could not be updated.");
    //        return View(model);
    //    }

    //    // GET: Offers/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        var svc = CreateAccountOfferService();
    //        var model = svc.GetAccountOfferById(id);
    //        return View(model);
    //    }

    //    // POST: Offers/Delete/5
    //    [HttpPost]
    //    [ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeletePost(int id)
    //    {
    //        var service = CreateAccountOfferService();

    //        service.DeleteAccountOffer(id);

    //        TempData["SaveResult"] = "Your offer was deleted";

    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private AccountOfferService CreateCurrencyOfferService()
    //    {
    //        var userId = Guid.Parse(User.Identity.GetUserId());
    //        var _accountOfferService = new AccountOfferService(userId);
    //        return _accountOfferService;
    //    }
//    }
//}
