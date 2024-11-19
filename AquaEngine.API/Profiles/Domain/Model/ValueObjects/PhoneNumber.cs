using System.Text.RegularExpressions;

namespace AquaEngine.API.Profiles.Domain.Model.ValueObjects;

public record PhoneNumber()
{
    /// <summary>
    /// Phone number.
    /// </summary>
    public string Number { get; }
    
    /// <summary>
    /// Creates a new instance of the <see cref="PhoneNumber"/> class.
    /// </summary>
    /// <param name="phoneNumber">
    /// Phone number.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when the phone number is not 9 digits.
    /// </exception>
    public PhoneNumber(string phoneNumber="000000000") : this()
    {
        if (string.IsNullOrEmpty(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\d{9}$"))
        {
            throw new ArgumentException("Phone number must be 9 digits.");
        }

        this.Number = phoneNumber;
    }
}