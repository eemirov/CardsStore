using System.Collections.Generic;
using System.Data.Entity;
using CardsStore.Core.Entities;

namespace CardsStore.Core.Data
{
	public class DbInitializer : DropCreateDatabaseIfModelChanges<EntityDbContext>
	{
		protected override void Seed(EntityDbContext db)
		{
			var categories = db.Set<Category>();
			var category1 = new Category() { Name = "Category1" };
			var category2 = new Category() { Name = "Category2" };
			var category3 = new Category() { Name = "Category3" };
			var category4 = new Category() { Name = "Category4" };
			var category5 = new Category() { Name = "Category5" };
			var category6 = new Category() { Name = "Category6" };

			categories.Add(category1);
			categories.Add(category2);
			categories.Add(category3);
			categories.Add(category4);
			categories.Add(category5);
			categories.Add(category6);
			db.SaveChanges();

			var cards = db.Set<Card>();

			var card1 = (new Card() { Name = "Card1", Description = "Description1", WebSite = "http://card1.com"});
			var card2 = (new Card() { Name = "Card2", Description = "Description2", WebSite = "http://card2.com"});
			var card3 = (new Card() { Name = "Card3", Description = "Description3", WebSite = "http://card3.com"});
			var card4 = (new Card() { Name = "Card4", Description = "Description4", WebSite = "http://card4.com"});

			cards.Add(card1);
			cards.Add(card2);
			cards.Add(card3);
			cards.Add(card4);

			db.SaveChanges();

			var cardCategories = db.Set<CardCategory>();
			cardCategories.Add(new CardCategory() {CardId = card1.ID, CategoryId = category1.ID});
			cardCategories.Add(new CardCategory() { CardId = card1.ID, CategoryId = category6.ID});
			cardCategories.Add(new CardCategory() { CardId = card2.ID, CategoryId = category2.ID });
			cardCategories.Add(new CardCategory() { CardId = card2.ID, CategoryId = category4.ID });
			cardCategories.Add(new CardCategory() { CardId = card4.ID, CategoryId = category1.ID });

			db.SaveChanges();

			base.Seed(db);
		}
	}

}
