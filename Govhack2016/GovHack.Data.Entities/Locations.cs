//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GovHack.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Locations
    {
        public double LOCATION_ID { get; set; }
        public string ID { get; set; }
        public string TYPE_OF_PROVIDER { get; set; }
        public string PROVIDER_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string SUBURB { get; set; }
        public string STATE { get; set; }
        public Nullable<double> POSTCODE { get; set; }
        public Nullable<double> LATITUDE { get; set; }
        public Nullable<double> LONGITUDE { get; set; }
        public string GEO_DATA { get; set; }
    }
}