using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardsStore.Core.Entities
{
	[Table("Category")]
	public class Category: Entity
	{
		[MaxLength(400)]
		public string Name { get; set; }
	}
}
