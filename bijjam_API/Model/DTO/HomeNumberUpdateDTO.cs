using System.ComponentModel.DataAnnotations;

namespace bijjam_API.Model.DTO
{
    public class HomeNumberUpdateDTO
    {
        [Required]
        public int HomeNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
