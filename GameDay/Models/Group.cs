using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameDay.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }  
        public string Description { get;set; }
        public virtual Game Game { get; set; }    
        public int MaxPlayers { get; set; }
        
    }
}
