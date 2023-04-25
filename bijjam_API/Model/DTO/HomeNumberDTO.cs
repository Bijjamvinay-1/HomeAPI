using System.ComponentModel.DataAnnotations;

namespace bijjam_API.Model.DTO
{
    public class HomeNumberDTO
    {
        [Required]
        public int HomeNo { get; set; }
        public String SpecialDetails { get; set; }      
        

    }
}
