using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EnsekEntities
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<MeterReadings> MeterReadings { get; set; }

    }
}
