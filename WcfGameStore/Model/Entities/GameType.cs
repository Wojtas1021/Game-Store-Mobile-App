//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfGameStore.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameType
    {
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Game Game { get; set; }
    }
}
