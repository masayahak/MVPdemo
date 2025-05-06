using System.ComponentModel.DataAnnotations;

namespace MVPdemo.Models
{
    public class 利用者Model
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "利用者名は必須です。")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "利用者名は2文字以上+20文字以内で入力してください。")]
        public string 利用者名 { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "住所は200文字以内で入力してください。")]
        public string? 住所 { get; set; }

        [Required(ErrorMessage = "誕生日は必須です。")]
        [DataType(DataType.Date, ErrorMessage = "誕生日は日付を入力してください。")]
        public DateTime 誕生日 { get; set; }

        [Required]
        public int Version { get; set; }
    }
}
