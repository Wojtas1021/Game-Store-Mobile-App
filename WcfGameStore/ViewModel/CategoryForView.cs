using System;
using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class CategoryForView
    {
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ShortDescription { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public CategoryForView() { }
        //konstruktor mapujący
        public CategoryForView(Category category)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, category);
        }
        public static implicit operator Category(CategoryForView category)
        {
            var res = new Category();
            res.AutomatedCopyingConstructor(category);
            return res;
        }

        public static implicit operator CategoryForView(Category category)
        {
            var res = new CategoryForView(category);
            return res;
        }
    }
}