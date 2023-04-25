using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bijjam_API.Model
{
    public class HomeNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]  //here the data base key is unique
        public int HomeNo { get; set; } 
        public string SpecialDetails { get; set;}
        public DateTime CreatedDate { get; set;} 
        public DateTime UpdateDate { get; set;}


    }
}
