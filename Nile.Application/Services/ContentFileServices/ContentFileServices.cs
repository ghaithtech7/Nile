
using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;

namespace Nile.Application.Services.ContentFileServices
{
    public class ContentFileServices : IContentFileServices
    {
        private readonly IApplicationDbContext _context;
        public ContentFileServices(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ContentFile> CreateFile(ContentFile file)
        {
            try
            {
                _context.ContentFiles.Add(file);
                await _context.SaveChangesAsync();
                return file;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteFile(ContentFile file)
        {
            try
            {
                _context.ContentFiles.Remove(file);
                return await _context.SaveChangesAsync();                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ContentFile>> GetAllFiles()
        {
            try
            {
                List<ContentFile> AllFiles = await _context.ContentFiles.ToListAsync();
                return AllFiles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ContentFile> GetFileById(int fileId)
        {
            ContentFile file = await _context.ContentFiles
                                .Where(x => x.FileId == fileId)
                                .FirstOrDefaultAsync();
            return file;
        }

        public async Task UpdateFile(ContentFile file)
        {
            try
            {
                _context.ContentFiles.Update(file);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
