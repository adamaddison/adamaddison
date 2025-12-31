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

    public async Task<AboutViewModel> GetAboutContentAsync()
    {
        AboutViewModel vm = await _getAboutViewModel.GetContentFromUrlAsync("");

        return vm;
    }

    public async Task<ExperienceViewModel> GetExperienceContentAsync()
    {
        ExperienceViewModel vm = await _getExperienceViewModel.GetContentFromUrlAsync("");

        return vm;
    }

    public async Task<HomeViewModel> GetHomeContentAsync()
    {
        HomeViewModel vm = await _getHomeViewModel.GetContentFromUrlAsync("");

        return vm;
    }

    public async Task<PortfolioViewModel> GetPortfolioContentAsync()
    {
        PortfolioViewModel vm = await _getPortfolioViewModel.GetContentFromUrlAsync("");

        return vm;
    }

    public async Task<WorkAndEducationViewModel> GetWorkAndEducationContentAsync()
    {
        WorkAndEducationViewModel vm = await _getWorkAndEducationViewModel.GetContentFromUrlAsync("");

        return vm;
    }
}
