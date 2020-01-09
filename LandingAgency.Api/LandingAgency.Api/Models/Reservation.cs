namespace LandingAgency.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReservationId { get; set; }

        public int? ClientId { get; set; }
        
        public int? ClientTypeId { get; set; }

        public int AmountTravelers { get; set; }

        public int DurationStay { get; set; }

        public int? PackageId { get; set; }

        public int[] TravelPackageIds { get; set; }

        public virtual Client Client { get; set; }

        public virtual Package Package { get; set; }
    }
}
