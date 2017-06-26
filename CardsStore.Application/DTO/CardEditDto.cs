using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsStore.Core.Entities;

namespace CardsStore.Application.DTO
{
	public class CardEditDto
	{
		public int? ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebSite { get; set; }

		public string CategoryIds { get; set; }

		public ICollection<CardCategory> Categories { get; set; }

		public ICollection<Category> AllCategories { get; set; }

		public bool CheckCategory(int id)
		{
			return CategoryIds.Split(',').Contains(id.ToString());
		}
	}
}
