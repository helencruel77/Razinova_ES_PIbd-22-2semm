using System.ComponentModel;

namespace LawFirmBusinessLogics.ViewModels
{
    public class SkladBlankViewModel
    {
        public int Id { get; set; }
        public int SkladId { get; set; }
        public int BlankId { get; set; }
        [DisplayName("Название бланка")]
        public string BlankName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}