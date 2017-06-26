using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsStore.Application.DTO
{
	public class CardListOutput: List<CardDto>
	{
		public CardListOutput(IEnumerable<CardDto> items):base(items)
		{
			
		}
	}
}
