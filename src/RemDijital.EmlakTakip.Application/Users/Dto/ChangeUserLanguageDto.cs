using System.ComponentModel.DataAnnotations;

namespace RemDijital.EmlakTakip.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}