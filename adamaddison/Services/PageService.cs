using System;
using adamaddison.Interfaces;
using adamaddison.View_Models;

namespace adamaddison.Services;

public class PageService : IPageService
{
    private readonly IHttpContentService<HomeViewModel> _getHomeViewModel;
    private readonly IHttpContentService<PortfolioViewModel> _getPortfolioViewModel;
    private readonly IHttpContentService<WorkAndEducationViewModel> _getWorkAndEducationViewModel;
    private readonly IHttpContentService<ExperienceViewModel> _getExperienceViewModel;
    private readonly IHttpContentService<AboutViewModel> _getAboutViewModel;

    public PageService(IHttpContentService<HomeViewModel> getHomeViewModel,
                       IHttpContentService<PortfolioViewModel> getPortfolioViewModel,
                       IHttpContentService<WorkAndEducationViewModel> getWorkAndEducationViewModel,
                       IHttpContentService<ExperienceViewModel> getExperienceViewModel,
                       IHttpContentService<AboutViewModel> getAboutViewModel)
    {
        _getHomeViewModel = getHomeViewModel;
        _getPortfolioViewModel = getPortfolioViewModel;
        _getWorkAndEducationViewModel = getWorkAndEducationViewModel;
        _getExperienceViewModel = getExperienceViewModel;
        _getAboutViewModel = getAboutViewModel;
    }

    public async AboutViewModel GetAboutContent()
    {
        throw new NotImplementedException();
    }

    public ExperienceViewModel GetExperienceContent()
    {
        throw new NotImplementedException();
    }

    public HomeViewModel GetHomeContent()
    {
        throw new NotImplementedException();
    }

    public PortfolioViewModel GetPortfolioContent()
    {
        throw new NotImplementedException();
    }

    public WorkAndEducationViewModel GetWorkAndEducationContent()
    {
        throw new NotImplementedException();
    }
}
