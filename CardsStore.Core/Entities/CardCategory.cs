using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsStore.Core.Entities
{
	[Table("CardCategories")]
	public class CardCategory: Entity
	{
		public int CardId { get; set; }
		public int CategoryId { get; set; }
		public virtual Card Card {get; set; }
		public virtual Category Category { get; set; }
	}
}
