using System;
using adamaddison.View_Models;

namespace adamaddison.Interfaces;

public interface IPageService
{
    public HomeViewModel GetHomeContent();
    public PortfolioViewModel GetPortfolioContent();
    public WorkAndEducationViewModel GetWorkAndEducationContent();
    public ExperienceViewModel GetExperienceContent();
    public AboutViewModel GetAboutContent();
}