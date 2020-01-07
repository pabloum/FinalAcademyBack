namespace LandingAgency.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            PackageProduct = new HashSet<PackageProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int? ProductTypeId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }

        public int? Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageProduct> PackageProduct { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
