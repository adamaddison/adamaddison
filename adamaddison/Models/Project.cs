using System;

namespace adamaddison.Models;

public class Project
{
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string FullDescription { get; set; } = string.Empty;
    public string GitHubLink { get; set; } = string.Empty;
    public string WebLink {get; set; } = string.Empty;
    public string[] ScreenshotUrls { get; set; } = [];
}
