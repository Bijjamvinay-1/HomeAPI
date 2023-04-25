using System.ComponentModel.DataAnnotations;

namespace bijjam_API.Model.DTO
{
    public class HomeNumberCreateDTO
    {
        [Required]
        public int HomeNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
