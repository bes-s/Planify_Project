using System.ComponentModel.DataAnnotations;

namespace PlanifyAPI.Models { 
public class VoteResponse
{
        [Key]
    public int ResponseId { get; set; }
    public int OptionId { get; set; }
    public int UserId { get; set; }

    public VoteOption Option { get; set; }
    public User User { get; set; }
}
}