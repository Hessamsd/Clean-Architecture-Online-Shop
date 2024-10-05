using _0_Framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _Webenvironment;

        public FileUploader(IWebHostEnvironment webenvironment)
        {
            _Webenvironment = webenvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_Webenvironment.WebRootPath}//ProductPictures//{path}";

            if(!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);


            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}
