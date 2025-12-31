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
    private readonly string HomeContentUrl;
    private readonly string PortfolioContentUrl;
    private readonly string WorkAndEducationContentUrl;
    private readonly string ExperienceContentUrl;
    private readonly string AboutContentUrl;

    public PageService(IHttpContentService<HomeViewModel> getHomeViewModel,
                       IHttpContentService<PortfolioViewModel> getPortfolioViewModel,
                       IHttpContentService<WorkAndEducationViewModel> getWorkAndEducationViewModel,
                       IHttpContentService<ExperienceViewModel> getExperienceViewModel,
                       IHttpContentService<AboutViewModel> getAboutViewModel,
                       IConfiguration config)
    {
        _getHomeViewModel = getHomeViewModel;
        _getPortfolioViewModel = getPortfolioViewModel;
        _getWorkAndEducationViewModel = getWorkAndEducationViewModel;
        _getExperienceViewModel = getExperienceViewModel;
        _getAboutViewModel = getAboutViewModel;

        HomeContentUrl = config["aaHomeUrl"] ?? string.Empty;
        PortfolioContentUrl = config["aaPortfolioUrl"] ?? string.Empty;
        WorkAndEducationContentUrl = config["aaWorkAndEducationUrl"] ?? string.Empty;
        ExperienceContentUrl = config["aaExperienceUrl"] ?? string.Empty;
        AboutContentUrl = config["adamaddisonTestBlobUrl"] ?? string.Empty;
    }

    public async Task<AboutViewModel> GetAboutContentAsync()
    {
        AboutViewModel vm = await _getAboutViewModel.GetContentFromUrlAsync(AboutContentUrl);

        return vm;
    }

    public async Task<ExperienceViewModel> GetExperienceContentAsync()
    {
        ExperienceViewModel vm = await _getExperienceViewModel.GetContentFromUrlAsync(ExperienceContentUrl);

        return vm;
    }

    public async Task<HomeViewModel> GetHomeContentAsync()
    {
        HomeViewModel vm = await _getHomeViewModel.GetContentFromUrlAsync(HomeContentUrl);

        return vm;
    }

    public async Task<PortfolioViewModel> GetPortfolioContentAsync()
    {
        PortfolioViewModel vm = await _getPortfolioViewModel.GetContentFromUrlAsync(PortfolioContentUrl);

        return vm;
    }

    public async Task<WorkAndEducationViewModel> GetWorkAndEducationContentAsync()
    {
        WorkAndEducationViewModel vm = await _getWorkAndEducationViewModel.GetContentFromUrlAsync(WorkAndEducationContentUrl);

        return vm;
    }
}
