using System;
using Microsoft.AspNetCore.Mvc;

namespace adamaddison.Interfaces;

public interface IHttpContentService<T>
{
    public Task<T> GetContentFromUrlAsync(string Url);
}
