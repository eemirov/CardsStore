using System.Collections.Generic;
using CardsStore.Application.DTO;

namespace CardsStore.Application.Services
{
	public interface ICardAppService: IAppService
	{
		CardListOutput GetList();
		CardEditDto GetCard(int id);
		CardEditDto CreateCard();
		void SaveCard(CardEditDto input);
		void DeleteCard(int id);
	}
}