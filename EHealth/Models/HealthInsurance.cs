//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EHealth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HealthInsurance
    {
        public int healthInsuranceId { get; set; }
        public string companyOIB { get; set; }
        public string companyName { get; set; }
        public string MBO { get; set; }
        public int personId { get; set; }
    
        public virtual Person Person { get; set; }
    }
}