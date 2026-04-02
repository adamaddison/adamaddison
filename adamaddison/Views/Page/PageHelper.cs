using System;

namespace adamaddison.Views.Page;

public static class PageHelper
{
    public static string FromToDateString(DateTime from, DateTime to)
    {
        var toDateString = to.Year == 1 ? "Present" : to.ToString("MMMM") + " " + to.Year.ToString();
        return (from.ToString("MMMM") + " " + from.Year.ToString() + " - " + toDateString);
    }
}
