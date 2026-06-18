using System.ComponentModel.DataAnnotations;
using System.Net;
using adamaddison.Interfaces;
using adamaddison.Services;
using adamaddison.View_Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace adamaddison.Tests.ServiceTests;

[TestClass]
public class HttpContentServiceTests
{
    [TestMethod]
    public async Task GetContentFromUrlAsync_ReturnsViewModel_OnSuccess()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HttpContentService<AboutViewModel>>>();
        var httpHandlerMock = new Mock<HttpMessageHandler>();
        httpHandlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>("SendAsync",
                                                        ItExpr.IsAny<HttpRequestMessage>(), 
                                                        ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent("{\"Description\":[\"This is a test\"],\"ImageUrls\":[\"element1\",\"element2\"]}")
                        });

        var httpClient = new HttpClient(httpHandlerMock.Object);
        var service = new HttpContentService<AboutViewModel>(httpClient, loggerMock.Object);

        // Act
        var vm = await service.GetContentFromUrlAsync("https://www.example.com/");

        // Assert
        Assert.IsNotNull(vm);
        Assert.IsInstanceOfType<AboutViewModel>(vm);
        Assert.AreEqual("This is a test", vm.Description[0]);
        Assert.AreEqual("element1", vm.ImageUrls[0]);
        Assert.AreEqual("element2", vm.ImageUrls[1]);
    }

    [TestMethod]
    public async Task GetContentFromUrlAsync_ThrowsException_WhenModelInvalid()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HttpContentService<AboutViewModel>>>();
        var httpHandlerMock = new Mock<HttpMessageHandler>();
        httpHandlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>("SendAsync",
                                                        ItExpr.IsAny<HttpRequestMessage>(), 
                                                        ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent("{not valid JSON")
                        });

        var httpClient = new HttpClient(httpHandlerMock.Object);
        var service = new HttpContentService<AboutViewModel>(httpClient, loggerMock.Object);

        // Act
        try
        {
            await service.GetContentFromUrlAsync("https://www.example.com/");

            Assert.Fail("Exception was not thrown in GetContentFromUrlAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("Failed to retrieve remote content."));
        }

        // Assert
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Failed to retrieve remote content.")),
                It.Is<System.Text.Json.JsonException>(ex => ex.Message.Length > 0),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestMethod]
    public async Task GetContentFromUrlAsync_ThrowsException_OnFail()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HttpContentService<AboutViewModel>>>();
        var httpHandlerMock = new Mock<HttpMessageHandler>();
        httpHandlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>("SendAsync",
                                                        ItExpr.IsAny<HttpRequestMessage>(), 
                                                        ItExpr.IsAny<CancellationToken>())
                        .ThrowsAsync(new Exception("test exception"));

        var httpClient = new HttpClient(httpHandlerMock.Object);
        var service = new HttpContentService<AboutViewModel>(httpClient, loggerMock.Object);

        // Act
        try
        {
            await service.GetContentFromUrlAsync("https://www.example.com/");

            Assert.Fail("Exception was not thrown in GetContentFromUrlAsync");
        }
        catch(Exception ex)
        {
            Assert.IsTrue(ex.Message.Equals("Failed to retrieve remote content."));
        }

        // Assert
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => 
                    v.ToString()!.Contains("Failed to retrieve remote content.")),
                It.Is<Exception>(ex => ex.Message == "test exception"),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
