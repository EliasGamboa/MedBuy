using System.ComponentModel.DataAnnotations;

namespace MedBuy.Domain.Entities.EntitiesForAspIdentity.AccountViewModels
{
    public class UseRecoveryCodeViewModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}
