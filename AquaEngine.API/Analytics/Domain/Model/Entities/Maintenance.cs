namespace AquaEngine.API.Analytics.Domain.Model.Entities;

public class Maintenance
{
    public int Id { get; private set; }
    public string Date { get; private set; }
    public string Technician { get; private set; }
    public string IssueType { get; private set; }
    public string Description { get; private set; }
    public string AdditionalInfo { get; private set; }

    public Maintenance()
    {
        Date = string.Empty;
        Technician = string.Empty;
        IssueType = string.Empty;
        Description = string.Empty;
        AdditionalInfo = string.Empty;
    }
    public Maintenance(string date, string technician, string issueType, string description, string additionalInfo)
    {
        Date = date;
        Technician = technician;
        IssueType = issueType;
        Description = description;
        AdditionalInfo = additionalInfo;
    }

}
