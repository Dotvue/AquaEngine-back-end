using System.Text.RegularExpressions;

namespace AquaEngine.API.Profiles.Domain.Model.ValueObjects;

public record DniNumber()
{
    public string Dni { get; }

    public DniNumber(string dni = "00000000") : this()
    {
        if (string.IsNullOrEmpty(dni) || !Regex.IsMatch(dni, @"^\d{8}$"))
        {
            throw new ArgumentException("DNI number must be 8 digits.");
        }

        this.Dni = dni;
    }
}