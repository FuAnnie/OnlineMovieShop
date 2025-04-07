using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validators;

public class ValidPurchaseDateAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime)
        {
            return new ValidationResult("Invalid date format.");
        }
        
        var purchaseDate = (DateTime)value;
        return purchaseDate.Date < DateTime.Today ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
    }
}