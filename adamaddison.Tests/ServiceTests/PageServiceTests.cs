using adamaddison.Interfaces;
using adamaddison.Models;
using adamaddison.Services;
using adamaddison.View_Models;
using Castle.Core.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace adamaddison.Tests.ServiceTests;

[TestClass]
public class PageServiceTests
{
    private Mock<ILogger<PageService>>? loggerMock;
    private Mock<IHttpContentService<HomeViewModel>>? getHomeViewModelMock;
    private Mock<IHttpContentService<PortfolioViewModel>>? getPortfolioViewModelMock;
    private Mock<IHttpContentService<WorkAndEducationViewModel>>? getWorkAndEducationViewModelMock;
    private Mock<IHttpContentService<ExperienceViewModel>>? getExperienceViewModelMock;
    private Mock<IHttpContentService<AboutViewModel>>? getAboutViewModelMock;
    private IConfiguration? config;
    private PageService? pageService;

    [TestInitialize]
    public void Setup()
    {
        loggerMock = new Mock<ILogger<PageService>>();
        getHomeViewModelMock = new Mock<IHttpContentService<HomeViewModel>>();
        getPortfolioViewModelMock = new Mock<IHttpContentService<PortfolioViewModel>>();
        getWorkAndEducationViewModelMock = new Mock<IHttpContentService<WorkAndEducationViewModel>>();
        getExperienceViewModelMock = new Mock<IHttpContentService<ExperienceViewModel>>();
        getAboutViewModelMock = new Mock<IHttpContentService<AboutViewModel>>();
        config = new ConfigurationBuilder().AddInMemoryCollection().Build();

        pageService = new PageService(
            loggerMock.Object,
            getHomeViewModelMock.Object,
            getPortfolioViewModelMock.Object,
            getWorkAndEducationViewModelMock.Object,
            getExperienceViewModelMock.Object,
            getAboutViewModelMock.Object,
            config
        );

    }

    [TestMethod]
    public async Task GetAboutContentAsync_ReturnsModel_OnSuccess()
    {
        // Arrange
        var expectedResponse = new AboutViewModel(){ Description = ["This is a test"], ImageUrls = ["element1", "element2"]};
        Assert.IsNotNull(getAboutViewModelMock, "getAboutViewModelMock should not be null");
        getAboutViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                             .ReturnsAsync(expectedResponse);

        // Act
        Assert.IsNotNull(pageService, "pageService should not be null");
        var response = await pageService.GetAboutContentAsync();

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<AboutViewModel>(response);
        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public async Task GetAboutContentAsync_ThrowsException_OnFail()
    {
        // Arrange
        Assert.IsNotNull(getAboutViewModelMock, "getAboutViewModelMock should not be null");
        getAboutViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                             .ThrowsAsync(new Exception("test exception"));

        // Act
        try
        {
            Assert.IsNotNull(pageService, "pageService should not be null");
            await pageService.GetAboutContentAsync();

            Assert.Fail("Exception was not thrown in GetAboutContentAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("test exception"));
        }

        // Assert
        Assert.IsNotNull(loggerMock, "loggerMock should not be null");
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Exception thrown - PageService.GetAboutContentAsync")),
                It.Is<Exception>(ex => ex.Message == "test exception"),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
    
    [TestMethod]
    public async Task GetExperienceContentAsync_ReturnsModel_OnSuccess()
    {
        // Arrange
        var expectedResponse = new ExperienceViewModel(){ SkillsList = ["skill1", "skill2"] };
        Assert.IsNotNull(getExperienceViewModelMock, "getExperienceViewModelMock should not be null");
        getExperienceViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                                  .ReturnsAsync(expectedResponse);

        // Act
        Assert.IsNotNull(pageService, "pageService should not be null");
        var response = await pageService.GetExperienceContentAsync();

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ExperienceViewModel>(response);
        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public async Task GetExperienceContentAsync_ThrowsException_OnFail()
    {
        // Arrange
        Assert.IsNotNull(getExperienceViewModelMock, "getExperienceViewModelMock should not be null");
        getExperienceViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                                  .ThrowsAsync(new Exception("test exception"));

        // Act
        try
        {
            Assert.IsNotNull(pageService, "pageService should not be null");
            await pageService.GetExperienceContentAsync();

            Assert.Fail("Exception was not thrown in GetExperienceContentAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("test exception"));
        }

        // Assert
        Assert.IsNotNull(loggerMock, "loggerMock should not be null");
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Exception thrown - PageService.GetExperienceContentAsync")),
                It.Is<Exception>(ex => ex.Message == "test exception"),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
    
    [TestMethod]
    public async Task GetHomeContentAsync_ReturnsModel_OnSuccess()
    {
        // Arrange
        var expectedResponse = new HomeViewModel(){ BioText = "example" };
        Assert.IsNotNull(getHomeViewModelMock, "getHomeViewModelMock should not be null");
        getHomeViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                            .ReturnsAsync(expectedResponse);

        // Act
        Assert.IsNotNull(pageService, "pageService should not be null");
        var response = await pageService.GetHomeContentAsync();

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<HomeViewModel>(response);
        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public async Task GetHomeContentAsync_ThrowsException_OnFail()
    {
        // Arrange
        Assert.IsNotNull(getHomeViewModelMock, "getHomeViewModelMock should not be null");
        getHomeViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                            .ThrowsAsync(new Exception("test exception"));

        // Act
        try
        {
            Assert.IsNotNull(pageService, "pageService should not be null");
            await pageService.GetHomeContentAsync();

            Assert.Fail("Exception was not thrown in GetHomeContentAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("test exception"));
        }

        // Assert
        Assert.IsNotNull(loggerMock, "loggerMock should not be null");
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Exception thrown - PageService.GetHomeContentAsync")),
                It.Is<Exception>(ex => ex.Message == "test exception"),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
    
    [TestMethod]
    public async Task GetPortfolioContentAsync_ReturnsModel_OnSuccess()
    {
        // Arrange
        var expectedResponse = new PortfolioViewModel(){ Projects = [new Project(){ FullDescription = "example" }] };
        Assert.IsNotNull(getPortfolioViewModelMock, "getPortfolioViewModelMock should not be null");
        getPortfolioViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                                 .ReturnsAsync(expectedResponse);

        // Act
        Assert.IsNotNull(pageService, "pageService should not be null");
        var response = await pageService.GetPortfolioContentAsync();

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<PortfolioViewModel>(response);
        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public async Task GetPortfolioContentAsync_ThrowsException_OnFail()
    {
        // Arrange
        Assert.IsNotNull(getPortfolioViewModelMock, "getPortfolioViewModelMock should not be null");
        getPortfolioViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                                 .ThrowsAsync(new InvalidOperationException("test exception"));

        // Act
        try
        {
            Assert.IsNotNull(pageService, "pageService should not be null");
            await pageService.GetPortfolioContentAsync();

            Assert.Fail("Exception was not thrown in GetPortfolioContentAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("test exception"));
        }

        // Assert
        Assert.IsNotNull(loggerMock, "loggerMock should not be null");
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Exception thrown - PageService.GetPortfolioContentAsync")),
                It.Is<Exception>(ex => ex.Message == "test exception"),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
    
    [TestMethod]
    public async Task GetWorkAndEducationContentAsync_ReturnsModel_OnSuccess()
    {
        // Arrange
        var expectedResponse = new WorkAndEducationViewModel(){ CompaniesAndSchools = [new CompanyOrSchool(){ CompanySummary = "example" }] };
        Assert.IsNotNull(getWorkAndEducationViewModelMock, "getWorkAndEducationViewModelMock should not be null");
        getWorkAndEducationViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                                        .ReturnsAsync(expectedResponse);

        // Act
        Assert.IsNotNull(pageService, "pageService should not be null");
        var response = await pageService.GetWorkAndEducationContentAsync();

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<WorkAndEducationViewModel>(response);
        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public async Task GetWorkAndEducationContentAsync_ThrowsException_OnFail()
    {
        // Arrange
        Assert.IsNotNull(getWorkAndEducationViewModelMock, "getWorkAndEducationViewModelMock should not be null");
        getWorkAndEducationViewModelMock.Setup(x => x.GetContentFromUrlAsync(It.IsAny<string>()))
                                        .ThrowsAsync(new InvalidOperationException("test exception"));

        // Act
        try
        {
            Assert.IsNotNull(pageService, "pageService should not be null");
            await pageService.GetWorkAndEducationContentAsync();

            Assert.Fail("Exception was not thrown in GetWorkAndEducationContentAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("test exception"));
        }

        // Assert
        Assert.IsNotNull(loggerMock, "loggerMock should not be null");
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Exception thrown - PageService.GetWorkAndEducationContentAsync")),
                It.Is<Exception>(ex => ex.Message == "test exception"),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}