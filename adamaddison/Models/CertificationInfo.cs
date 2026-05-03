using System;

namespace adamaddison.Models;

public class CertificationInfo
{
    public string Title { get; set; } = string.Empty;
    public DateTime DatePassed { get; set; }
    public string Description { get; set; } = string.Empty;
    public string[] ImageUrls { get; set; } = [];
}
