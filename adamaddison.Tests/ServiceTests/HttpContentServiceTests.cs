using System.ComponentModel.DataAnnotations;
using adamaddison.Interfaces;
using adamaddison.Services;
using adamaddison.View_Models;
using Microsoft.CodeCoverage.Core;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Company.TestProject1;

[TestClass]
public class HttpContentServiceTests
{
    IHttpContentService<AboutViewModel>? _httpContentService;

    [TestInitialize]
    public void Setup()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        var logger = loggerFactory.CreateLogger<HttpContentService<AboutViewModel>>();

        _httpContentService = new HttpContentService<AboutViewModel>(new HttpClient(), logger);
    }

    [TestMethod]
    public async Task GetContentFromUrlAsync_ReturnsViewModel()
    {
        AboutViewModel vm = await _httpContentService!.GetContentFromUrlAsync("https://adamaddisontest.blob.core.windows.net/testcontainer/AboutViewModel.txt?sp=r&st=2025-12-31T10:50:16Z&se=2026-12-31T19:05:16Z&spr=https&sv=2024-11-04&sr=b&sig=3FZ5X%2BBYp0wFXB5VHqvBm7Umvz17IRQmuirUTt0i%2Fik%3D");

        Assert.IsNotNull(vm);
        Assert.AreEqual("about content", vm.Description);
        Assert.AreEqual("a", vm.ImageUrls[0]);
        Assert.AreEqual("b", vm.ImageUrls[1]);
    }
}
