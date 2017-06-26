using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsStore.Core.Entities;

namespace CardsStore.Application.DTO
{
	public class CardDto
	{
		public int? ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebSite { get; set; }
		public string CategoriesString { get; set; }
	}
}
