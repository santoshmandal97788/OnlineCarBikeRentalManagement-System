//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineCarBikeRentalSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPayment
    {
        public int PaymentId { get; set; }
        public Nullable<int> CustomerRecordId { get; set; }
        public Nullable<int> BookingId { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public string ReceivedBy { get; set; }
    
        public virtual tblBooking tblBooking { get; set; }
        public virtual tblCustomerRecord tblCustomerRecord { get; set; }
    }
}
