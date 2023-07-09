namespace AtFileshare.Application.Common.Interfaces.Services
{
    using AtFileshare.Domain.Entities;
    using Microsoft.AspNetCore.Http;

    public interface IFileSystemProvider
    {
        public string SaveToFileSystem(IFormFile file);
    }
}
