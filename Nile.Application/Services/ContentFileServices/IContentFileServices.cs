using Nile.Domain.EntityModel;

namespace Nile.Application.Services.ContentFileServices
{
    public interface IContentFileServices
    {
        Task<ContentFile> GetFileById(int fileId);
        Task<List<ContentFile>> GetAllFiles();
        Task<int> DeleteFile(ContentFile file);
        Task<ContentFile> CreateFile(ContentFile file);
        Task UpdateFile(ContentFile file);
    }
}