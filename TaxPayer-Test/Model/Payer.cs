using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxPayer.Model
{
    [Table("Payer")]
    public class Payer
    {
        [Key]
        public string CPF { get; set; }
        public string Name { get; set; }
        public int NumberDependents { get; set; }
        public decimal NetSalary { get; set; } 
        public decimal GrossSalary { get; set; } 
    }
}
