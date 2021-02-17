using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedBuy.Domain.Entities.EntitesForAspIdentity.RoleViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name ="Role")]
        public string RoleName { get; set; }
    }
}
