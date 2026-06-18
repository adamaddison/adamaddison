using adamaddison.Controllers;
using adamaddison.Interfaces;
using adamaddison.Models;
using adamaddison.Models.Common;
using adamaddison.Services;
using adamaddison.View_Models;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace adamaddison.Tests.ControllerTests;

[TestClass]
public class PageControllerTests
{
    [TestMethod]
    public async Task Home_ReturnsView_OnSuccess()
    {
        // Arrange
        var expectedResponse = new HomeViewModel(){ BioText = "example" };
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetHomeContentAsync())
                       .ReturnsAsync(expectedResponse);

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.Home()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(expectedResponse, response.Model);
    }

    [TestMethod]
    public async Task Home_SetsError_WhenExceptionThrown()
    {
        // Arrange
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetHomeContentAsync())
                       .ThrowsAsync(new Exception("test exception"));

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.Home()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(SiteConstants.PageLoadErrorMessage, response.ViewData["TryCatchError"]);
    }

    [TestMethod]
    public async Task Portfolio_ReturnsView_OnSuccess()
    {
        // Arrange
        var expectedResponse = new PortfolioViewModel(){ Projects = [new Project(){ Title = "example" }] };
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetPortfolioContentAsync())
                       .ReturnsAsync(expectedResponse);

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.Portfolio()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(expectedResponse, response.Model);
    }

    [TestMethod]
    public async Task Portfolio_SetsError_WhenExceptionThrown()
    {
        // Arrange
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetPortfolioContentAsync())
                       .ThrowsAsync(new Exception("test exception"));

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.Portfolio()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(SiteConstants.PageLoadErrorMessage, response.ViewData["TryCatchError"]);
    }
    
    [TestMethod]
    public async Task WorkAndEducation_ReturnsView_OnSuccess()
    {
        // Arrange
        var expectedResponse = new WorkAndEducationViewModel(){ CompaniesAndSchools = [new CompanyOrSchool(){ Name = "example" }] };
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetWorkAndEducationContentAsync())
                       .ReturnsAsync(expectedResponse);

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.WorkAndEducation()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(expectedResponse, response.Model);
    }

    [TestMethod]
    public async Task WorkAndEducation_SetsError_WhenExceptionThrown()
    {
        // Arrange
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetWorkAndEducationContentAsync())
                       .ThrowsAsync(new Exception("test exception"));

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.WorkAndEducation()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(SiteConstants.PageLoadErrorMessage, response.ViewData["TryCatchError"]);
    }
    
    [TestMethod]
    public async Task Experience_ReturnsView_OnSuccess()
    {
        // Arrange
        var expectedResponse = new ExperienceViewModel(){ SkillsList = ["skill1", "skill2"] };
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetExperienceContentAsync())
                       .ReturnsAsync(expectedResponse);

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.Experience()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(expectedResponse, response.Model);
    }

    [TestMethod]
    public async Task Experience_SetsError_WhenExceptionThrown()
    {
        // Arrange
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetExperienceContentAsync())
                       .ThrowsAsync(new Exception("test exception"));

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.Experience()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(SiteConstants.PageLoadErrorMessage, response.ViewData["TryCatchError"]);
    }
    //
    [TestMethod]
    public async Task About_ReturnsView_OnSuccess()
    {
        // Arrange
        var expectedResponse = new AboutViewModel(){ Description = ["example"] };
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetAboutContentAsync())
                       .ReturnsAsync(expectedResponse);

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.About()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(expectedResponse, response.Model);
    }

    [TestMethod]
    public async Task About_SetsError_WhenExceptionThrown()
    {
        // Arrange
        var pageServiceMock = new Mock<IPageService>();
        pageServiceMock.Setup(x => x.GetAboutContentAsync())
                       .ThrowsAsync(new Exception("test exception"));

        var pageController = new PageController(pageServiceMock.Object);

        // Act
        var response = (await pageController.About()) as ViewResult;

        // Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType<ViewResult>(response);
        Assert.AreEqual(SiteConstants.PageLoadErrorMessage, response.ViewData["TryCatchError"]);
    }
}