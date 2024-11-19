namespace AquaEngine.API.Profiles.Domain.Model.ValueObjects;

/// <summary>
/// Person Name record: represents the name of a person.
/// </summary>
/// <param name="Name">
/// The first name of the person.
/// </param>
/// <param name="LastName">
/// The last name of the person.
/// </param>
public record PersonName(string Name, string LastName)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonName"/> class.
    /// </summary>
    public PersonName() : this(string.Empty, string.Empty)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonName"/> class.
    /// </summary>
    /// <param name="firstName">
    /// The first name of the person.
    /// </param>
    public PersonName(string firstName) : this(firstName, string.Empty)
    {
    }
    
    /// <summary>
    /// Gets the full name of the person.
    /// </summary>
    public string FullName => $"{Name} {LastName}";
} 