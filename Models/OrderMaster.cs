using System.ComponentModel.DataAnnotations;
using System;

public class OrderMaster
{
    [Key]
    public int OrderId { get; set; }

    public Guid CustomerID { get; set; }

    public DateTime OrderedDate { get; set; }

    public decimal OrderedAmount { get; set; }

}
