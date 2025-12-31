using System;
using adamaddison.View_Models;

namespace adamaddison.Interfaces;

public interface IPageService
{
    public Task<HomeViewModel> GetHomeContentAsync();
    public Task<PortfolioViewModel> GetPortfolioContentAsync();
    public Task<WorkAndEducationViewModel> GetWorkAndEducationContentAsync();
    public Task<ExperienceViewModel> GetExperienceContentAsync();
    public Task<AboutViewModel> GetAboutContentAsync();
}