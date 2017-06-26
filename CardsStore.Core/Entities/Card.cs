using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsStore.Core.Entities
{
	[Table("Card")]
	public class Card: Entity
	{
		[Required]
		[MaxLength(400)]
		public string Name { get; set; }

		[MaxLength(2000)]
		public string Description { get; set; }

		[MaxLength(400)]
		public string WebSite { get; set; }

		private ICollection<CardCategory> _cardCategories;

		public virtual ICollection<CardCategory> Categories
		{
			get { return _cardCategories ?? (_cardCategories = new List<CardCategory>());}
			protected set { _cardCategories = value; }
		}
	}
}
