namespace ContactLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person_address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person_address()
        {
            People = new HashSet<Person>();
        }

        [Key]
        public long Aid { get; set; }

        [StringLength(20)]
        public string houseNum { get; set; }

        [StringLength(30)]
        public string street { get; set; }

        [StringLength(30)]
        public string address_city { get; set; }

        [StringLength(30)]
        public string address_state { get; set; }

        [StringLength(30)]
        public string address_country { get; set; }

        [StringLength(30)]
        public string zipcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
    }
}
