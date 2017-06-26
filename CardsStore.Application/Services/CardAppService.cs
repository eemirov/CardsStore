using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CardsStore.Application.DTO;
using CardsStore.Core.Data;
using CardsStore.Core.Entities;

namespace CardsStore.Application.Services
{
	public class CardAppService : ICardAppService
	{
		private readonly IRepository<Card> _cardRepository;
		private readonly IRepository<Category> _catRepository;
		private readonly IRepository<CardCategory> _cardCategoryRepository;

		public CardAppService(IRepository<Category> catRepository, IRepository<Card> cardRepository,
			IRepository<CardCategory> cardCategoryRepository)
		{
			_catRepository = catRepository;
			_cardRepository = cardRepository;
			_cardCategoryRepository = cardCategoryRepository;
		}

		#region Public Methods

		public CardListOutput GetList()
		{
			Mapper.Initialize(
				cfg => cfg.CreateMap<Card, CardDto>().ForMember("CategoriesString", o => o.MapFrom(c => GetCategories(c))));
			return new CardListOutput(Mapper.Map<IEnumerable<Card>, List<CardDto>>(_cardRepository.GetAll()));
		}

		public CardEditDto GetCard(int id)
		{
			Mapper.Initialize(cfg => cfg.CreateMap<Card, CardEditDto>());
			var card = _cardRepository.GetById(id);
			var cardEdit = Mapper.Map<Card, CardEditDto>(card);
			cardEdit.CategoryIds = string.Join(",", card.Categories.Select(c => c.CategoryId).ToList());
			cardEdit.AllCategories = _catRepository.GetAll().ToList();

			return cardEdit;
		}

		public CardEditDto CreateCard()
		{
			var cardEdit = new CardEditDto {AllCategories = _catRepository.GetAll().ToList(), CategoryIds = string.Empty};

			return cardEdit;
		}

		public void SaveCard(CardEditDto input)
		{
			Mapper.Initialize(cfg => cfg.CreateMap<CardEditDto, Card>().ForMember("Categories", o => o.Ignore()));
			var ids = input.CategoryIds.Split(',');
			Card editCard = null;

			if (input.ID.HasValue)
			{
				editCard = _cardRepository.GetById(input.ID.Value);
				editCard = Mapper.Map<CardEditDto, Card>(input, editCard);
				
				_cardRepository.Update(editCard);
			}
			else
			{
				editCard = Mapper.Map<CardEditDto, Card>(input);

				_cardRepository.Insert(editCard);
			}

			//save categories
			SaveCardCategories(editCard.ID, ids);
		}

		public void DeleteCard(int id)
		{
			var card =_cardRepository.GetById(id);
			if(card != null)
				_cardRepository.Delete(card);
		}

		#endregion

		#region Instance methods

		private void SaveCardCategories(int cardId, string[] cardIds)
		{
			var cardCategories = _cardCategoryRepository.GetAll().Where(c => c.CardId == cardId).ToList();

			//delete
			foreach (var category in cardCategories)
			{
				if(!cardIds.Contains(category.CategoryId.ToString()))
					_cardCategoryRepository.Delete(category);
			}

			//insert
			foreach (var id in cardIds)
			{
				if(!cardCategories.Exists(c => c.CategoryId.ToString() == id))
					_cardCategoryRepository.Insert(new CardCategory() { CardId = cardId, CategoryId = Int32.Parse(id) });
			}
		}

		private string GetCategories(Card c)
		{
			var list = c.Categories.ToList().Select(l => l.Category.Name);

			return string.Join(", ", list);
		}

		#endregion

	}
}
