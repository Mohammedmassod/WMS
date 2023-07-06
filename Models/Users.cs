using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using WMS.ViewModels;

namespace WMS.Models
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
        public bool IsClient { get; set; }
        public string? GovernorateName { get; set; }
        public string? DirectorateName { get; set; }
        public string? Pass { get; set; }
        public string? TypeUser { get; set; }
        [Column("OfficeId")]
/*        [BindProperty]
*/        public int OfficeId { get; set; }

        [ForeignKey(nameof(OfficeId))]
        [InverseProperty("Users")]
        public virtual Office? Office { get; set; } = null!;


        public Users(UserVM users)
        {

            UserName = users.UserName;
            Name = users.Name;
            PhoneNumber = users.PhoneNumber;
            IsClient = users.isClient;

        }

        public Users()
        {

        }
       
    }
}
