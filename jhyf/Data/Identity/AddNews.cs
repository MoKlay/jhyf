using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace jhyf.Data.Identity
{
    public class AddNews
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string? Title { get; set; }

        [Display(Name = "Название фотографии")]
        public string? NameFile { get; set; }

        [Display(Name = "Фото")]
        public byte[]? ImageNews { get; set; }

        [Display(Name = "Ссылка на новость")]
        public string? LinkImage { get; set; }

        [Display(Name = "Текст новости")]
        public string? Description { get; set; }

        [Display(Name = "Название файла")]
        public string? NameDoc { get; set; }

        [Display(Name = "Ссылка на файл из google диска")]
        public string? LinkFile { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "Дата последнего обновления")]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}