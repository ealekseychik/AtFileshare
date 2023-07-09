namespace AtFileshare.Infrastructure.Services
{
    using AtFileshare.Application.Common.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;

    public class FileSystemProvider : IFileSystemProvider
    {

        private readonly FileSystemConfiguration _fileSystemConfiguration;
        private readonly IDateTimeProvider _dateTimeProvider;

        public FileSystemProvider(IDateTimeProvider dateTimeProvider,
            IOptions<FileSystemConfiguration> fsOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _fileSystemConfiguration = fsOptions.Value;
        }

        public string SaveToFileSystem(IFormFile file)
        {
            var savePath = Path.Combine(_fileSystemConfiguration.Directory,
                _dateTimeProvider.UtcNow.ToString("yyyy-mm-dd"));

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            var filePath = Path.Combine(savePath,
                file.Name + "__" + Directory.EnumerateFiles(savePath).Count());

            using (var fs = File.OpenWrite(filePath))
            {
                file.CopyTo(fs);
            }

            return filePath;
        }
    }
}
