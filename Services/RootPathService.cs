using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class RootPathService
{
    private readonly IWebHostEnvironment _env;

    public RootPathService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string GetRootPath()
    {
        return _env.ContentRootPath;  // ✅ Correct way to get the root path
    }
    public string GetEnvironmentName()
    {
        return _env.EnvironmentName;  // ✅ Correct way to get the root path
    }
}
