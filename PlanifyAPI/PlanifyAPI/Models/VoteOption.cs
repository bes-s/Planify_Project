using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanifyAPI.Models
{
    public class VoteOption
    {
        [Key] 
        public int OptionId { get; set; }

        public int VoteId { get; set; }
        public string OptionText { get; set; } = string.Empty;

        public Vote Vote { get; set; }
        public ICollection<VoteResponse> Responses { get; set; }
    }
}
