using AppGameStore.Utils;
using ServiceReferenceGameStore;
using System;

namespace AppGameStore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Notes { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public Category() { }
        //konstruktor mapujący
        public Category(Category category)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, category);
        }
        public static implicit operator CategoryForView(Category category)
        {
            var res = new CategoryForView();
            res.AutomatedCopyingConstructor(category);
            return res;
        }
        public static implicit operator Category(CategoryForView category)
        {
            var res = new Category();
            res.AutomatedCopyingConstructor(category);
            return res;
        }
    }
}
