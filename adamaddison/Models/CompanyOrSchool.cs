using System;

namespace adamaddison.Models;

public class CompanyOrSchool
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartedDate { get; set; }
    public DateTime LeftDate { get; set; }
    public string CompanySummary { get; set; } = string.Empty;
    public string SchoolGradeTable { get; set; } = string.Empty;
    public string LocationText { get; set; } = string.Empty;
    public string LocationImageUrl { get; set; } = string.Empty;
    public string[] ImageUrls { get; set; } = [];
}
