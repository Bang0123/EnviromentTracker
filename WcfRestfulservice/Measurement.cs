using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WcfRestfulservice
{
    [Table("Measurement")]
    public partial class Measurement
    {
        public int LokaleId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime Tid { get; set; }

        public int Lyd { get; set; }

        public int Lys { get; set; }

        public int Temp { get; set; }
    }
}
