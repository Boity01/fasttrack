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
    
    public partial class OrderType
    {
        public OrderType()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public System.DateTime DateTimeCreated { get; set; }
        public string Description { get; set; }
        public int iOrder { get; set; }
        public System.Guid Guid { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
