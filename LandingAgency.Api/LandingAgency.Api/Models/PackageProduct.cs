namespace LandingAgency.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PackageProduct")]
    public partial class PackageProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageProductId { get; set; }

        public int ProductId { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        public virtual Product Product { get; set; }
    }
}
