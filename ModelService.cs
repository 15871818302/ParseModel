using System.IO;
using System.Threading.Tasks;

namespace ParseModel
{
    public class ModelService: IService
    {
        // 支持的文件列表
        private readonly string[] _supportedFormats = { ".stl", ".obj", ".step", ".iges" };

        public bool SupportsFileFormat(string fileExtension)
        {
            // 检查文件扩展名是否在支持的列表中
            return _supportedFormats.Contains(fileExtension.ToLower());
        }

        public async Task<IndustialModel> ParseModelFileAsync(IFormFile file)
        {
            // 确保临时文件夹存在
            var tempPath = Path.Combine(Path.GetTempPath(), "ModelParser");
            Directory.CreateDirectory(tempPath);

            // 确保上传的文件能到临时位置
            var filePath = Path.Combine(tempPath, file.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            try
            {
                // 解析文件
                var model = await ParseModelFileAsync(filePath);

                // 处理完成后删除临时文件
                File.Delete(filePath);

                return model;
            }
            catch
            (Exception ex)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                // 处理文件解析错误
                throw new Exception($"解析文件出错: {ex.Message}", ex);
            }
        }

        public Task<IndustialModel> ParseModelFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
