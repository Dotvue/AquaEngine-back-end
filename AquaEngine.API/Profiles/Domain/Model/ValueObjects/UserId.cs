namespace AquaEngine.API.Profiles.Domain.Model.ValueObjects;

public record UserId()
{
    public int Identifier { get; }

    public UserId(int identifier=1) : this()
    {
        if (identifier <= 0)
        {
            throw new ArgumentException("User identifier must be greater than 0.");
        }

        Identifier = identifier;
    }
}