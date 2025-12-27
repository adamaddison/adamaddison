using System;

namespace adamaddison.Models;

public class CertificationInfo
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] ImageUrls { get; set; } = [];
}
