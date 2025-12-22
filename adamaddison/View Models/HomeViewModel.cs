using System;

namespace adamaddison.View_Models;

public class HomeViewModel
{
    public string ProfileImageUrl { get; set; } = string.Empty;
    public KeyValuePair<string, string>[] ContactInfoList { get; set; } = [];
    public string BioText { get; set; } = string.Empty;
}
