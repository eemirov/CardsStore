using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardsStore.Application.DTO;
using CardsStore.Application.Services;

namespace CardsStore.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICardAppService _cardAppService;

		public HomeController(ICardAppService cardAppService)
		{
			_cardAppService = cardAppService;
		}

		public ActionResult Index()
		{
			return View(_cardAppService.GetList());
		}


		public ActionResult ViewCard(int? id)
		{
			CardEditDto card = null;
			if (id.HasValue)
			{
				card = _cardAppService.GetCard(id.Value);
			}
			else
			{
				card = _cardAppService.CreateCard();
			}
			
			return PartialView("_CreateOrEdit", card);
		}

		[HttpPost]
		public RedirectResult EditCard(CardEditDto input)
		{
			_cardAppService.SaveCard(input);
			return Redirect("Index");
		}

		public void DeleteCard(int? id)
		{
			if(id.HasValue)
				_cardAppService.DeleteCard(id.Value);
		}
	}
}