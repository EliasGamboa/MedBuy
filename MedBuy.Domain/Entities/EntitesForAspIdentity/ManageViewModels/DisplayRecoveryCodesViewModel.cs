using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedBuy.Domain.Entities.EntitiesForAspIdentity.ManageViewModels
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
