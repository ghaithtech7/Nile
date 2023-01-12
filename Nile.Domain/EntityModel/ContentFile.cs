using System.ComponentModel.DataAnnotations;

namespace Nile.Domain.EntityModel
{
    public class ContentFile
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }

        public virtual Product Product { get; set; }

    }
}
