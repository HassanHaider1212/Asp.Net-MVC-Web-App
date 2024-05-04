using System.ComponentModel.DataAnnotations; 

public class Item
{
    [Key] 
    public int ItemsId { get; set; }

    [Required]
    public string ItemDesc { get; set; }

    public decimal ItemCost { get; set; }
}