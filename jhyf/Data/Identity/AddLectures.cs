using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jhyf.Data.Identity
{
    [Table("Lectures")]
    public class AddLectures
    {
        public int Id { get; set; }

        [Display(Name = "Тема лекции")]
        public string? Name { get; set; }
        
        [Display(Name = "Ссылка на лекцию")]
        public string? LecturesLink { get; set; }
    }
}
