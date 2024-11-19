using System.Text.RegularExpressions;

namespace AquaEngine.API.Profiles.Domain.Model.ValueObjects;

public record DniNumber()
{
    public string Number { get; }

    public DniNumber(string number = "00000000") : this()
    {
        if (string.IsNullOrEmpty(number) || !Regex.IsMatch(number, @"^\d{8}$"))
        {
            throw new ArgumentException("DNI number must be 8 digits.");
        }

        this.Number = number;
    }
}