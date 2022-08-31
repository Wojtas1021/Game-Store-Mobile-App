using AppGameStore.Models;
using ServiceReferenceGameStore;
using System.Collections.Generic;
using System.Linq;

namespace AppGameStore.Services
{
    public class CategoryDataStore : AbstractDataStore<Category>
    {
        public CategoryDataStore()
            : base()
        {
            GameStoreServices.GetCategories(new GetCategoriesRequest()).GetCategoriesResult
             .Select(k => new Category(k))
             .ToList();
        }
        public override void Add(Category item)
        {
            GameStoreServices.AddOrUpdateCategory(new AddOrUpdateCategoryRequest(new CategoryForView
            {
                Name = item.Name,
                ShortDescription = item.ShortDescription,
                Notes= item.Notes
            }));
        }
        public override Category Find(Category category)
        {
            return items.Where((Category arg) => arg.CategoryID == category.CategoryID).FirstOrDefault();
        }
        public override Category Find(int id)
        {
            return items.Where((Category arg) => arg.CategoryID == id).FirstOrDefault();
        }
        public override void Refresh()
        {
            List<CategoryForView> listaCFV =
                GameStoreServices.GetCategories(new GetCategoriesRequest())
                .GetCategoriesResult
                .ToList();
            items = new List<Category>();
            foreach (var c in listaCFV)
            {
                items.Add(new Category(c));
            }
        }
    }
}