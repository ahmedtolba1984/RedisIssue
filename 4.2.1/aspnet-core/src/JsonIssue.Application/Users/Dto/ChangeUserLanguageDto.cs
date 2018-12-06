using System.ComponentModel.DataAnnotations;

namespace JsonIssue.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}