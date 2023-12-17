using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artem.Models
{
    public enum OperationType
    {
        Фрезерная,
        Токарная,
        ТокарноКарусельная
    }

    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string OperatorFullName { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public int Operation { get; set; }

        [Required]
        public OperationType OperationType { get; set; }

        [Required]
        public int LaborIntensityFact { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
