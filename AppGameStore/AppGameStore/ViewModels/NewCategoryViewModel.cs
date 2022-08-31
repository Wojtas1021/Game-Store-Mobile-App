using AppGameStore.Models;
using System;


namespace AppGameStore.ViewModels
{
    public class NewCategoryViewModel : ANewItemViewModel<Category>
    {
        private string name;
        private string shortDescription;
        private string notes;
        private DateTime? modifiedDate;

        public NewCategoryViewModel()
            : base()
        {
        }
        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string ShortDescription
        {
            get => shortDescription;
            set => SetProperty(ref shortDescription, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }
        public DateTime? ModifiedDate
        {
            get => modifiedDate;
            set => SetProperty(ref modifiedDate, value);
        }
        public override Category SetItem()
        {
            Category newItem = new Category()
            {
                Name = Name,
                ShortDescription = ShortDescription,
                Notes = Notes,
                ModifiedDate = ModifiedDate
            };
            return newItem;
        }
    }
}