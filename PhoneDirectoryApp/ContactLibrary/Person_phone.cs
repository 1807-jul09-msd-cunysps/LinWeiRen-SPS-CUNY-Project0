namespace ContactLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person_phone
    {
        [Key]
        public long PHid { get; set; }

        public long Pid { get; set; }

        public int? countryCode { get; set; }

        [StringLength(20)]
        public string areaCode { get; set; }

        [StringLength(30)]
        public string number { get; set; }

        [StringLength(20)]
        public string ext { get; set; }

        public virtual Person Person { get; set; }
    }
}
