using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsStore.Core.Entities
{
	public abstract class Entity: IEntity
	{
		[Required]
		public int ID { get; set; }
	}
}
