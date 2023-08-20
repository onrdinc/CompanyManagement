using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Model.Entities
{
    [Table("Users")]
    public class User:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set;}
        public string? Surname { get; set;}
        public string? Nickname { get; set;}
        public string? Email { get; set;}
        public string? Password { get; set;}
        public string? Country { get; set;}
        public string? City { get; set;}
        public string? PicturePath { get; set;}
        public byte[]? Picture { get; set; }
        public bool? IsDeleted { get; set; } =false;


        [NotMapped] // bu propertynin veritabanındaki ilgili tabloyla bir alakası yok bunula ilgili birşey yapma çalışma
        public string Base64Picture
        {
            get
            {
                if (Picture != null)
                {
                    var base64Str = string.Empty;
                    using (var ms = new MemoryStream())
                    {

                        int offset = 0 ;
                        ms.Write(Picture, offset, Picture.Length - offset);
                        var bmp = new System.Drawing.Bitmap(ms);
                        using (var jpegms = new MemoryStream())
                        {
                            bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            base64Str = Convert.ToBase64String(jpegms.ToArray());
                        }


                    }
                    return base64Str;

                }


                return string.Empty;
            }
        }

    }
}
