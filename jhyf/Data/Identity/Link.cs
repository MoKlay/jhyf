using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jhyf.Data.Identity
{
    [Table("Links", Schema = "data")]
    public class Link
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string NameFromLink { get; set; }

        [Display(Name = "Ссылка")]
        public string Linki { get; set; }
    }
}
