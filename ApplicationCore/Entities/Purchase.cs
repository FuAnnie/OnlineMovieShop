using ApplicationCore.Validators;

namespace ApplicationCore.Entities;

public class Purchase
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    [ValidPurchaseDate(ErrorMessage = "Purchase date cannot be in the past.")]
    public DateTime PurchaseDateTime { get; set; }
    public Guid PurchaseNumber { get; set; }
    public decimal TotalPrice { get; set; }
    
    public Movie Movie { get; set; }
    public User User { get; set; }
}