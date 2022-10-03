using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Proyecto_Sadas.Models
{
    [Table("archivo")]
    public class Archivo : IFormFile
    {
        [Key]
        public int archivo_id { get; set; }
        public string ruta { get; set; }
        [Column("nombre", TypeName = "nvarchar(1000)")]
        public string FileName { get; set; }
        [Column("tamanno", TypeName = "nvarchar(1000)")]
        public long Length { get; set; }
        public IList<SolicitudArchivo> solicitud_archivo { get; set; } = default!;


        public string ContentType => throw new NotImplementedException();

        public string ContentDisposition => throw new NotImplementedException();

        public IHeaderDictionary Headers => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            throw new NotImplementedException();
        }


    }
}
