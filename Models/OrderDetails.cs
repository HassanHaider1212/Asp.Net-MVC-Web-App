using System.ComponentModel.DataAnnotations;
public class OrderDetails
{
    [Key] 
    public int OrderedDetailsId { get; set; }

    public int OrderedIDMaster { get; set; }

    public int Item { get; set; }

    public int Quantity { get; set; }

    public decimal Cost { get; set; }
}
