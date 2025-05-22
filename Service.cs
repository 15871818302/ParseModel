namespace ParseModel
{
    public interface IService
    {
        Task<IndustialModel> ParseModelFileAsync(IFormFile file);
        Task<IndustialModel> ParseModelFileAsync(string filePath);
        bool SupportsFileFormat(string fileExtension);
    }
}
