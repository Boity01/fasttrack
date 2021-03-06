//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastTrackFront.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int OrderTypeId { get; set; }
        public System.DateTime DateTimeCreated { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> CollectionDate { get; set; }
        public string Estimation { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual User User { get; set; }
    }
}
