using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EnsekEntities
{
    public class MeterReadings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Accounts Account { get; set; }

        public DateTime MeterReadingDateTime { get; set; }
        //[Column(TypeName = "NUMERIC(5,0)")]
        public string MeterReadValue { get; set; }
    }
}
