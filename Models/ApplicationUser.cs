using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace Adfontes.Models
{

    // Add profile data for application users by adding properties to the ApplicationUser class
    [DataContract]  //opt-in approach for Serialization
    public class ApplicationUser : IdentityUser
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public List<Note> Notes { get; set; }
        [DataMember]
        public List<Notebook> Notebooks { get; set; }

        [DataMember]
        public override string UserName {
            get {
                return base.UserName;
            }
            set {
                base.UserName = value;
            }
        }
        [DataMember]
        public override string Email {
            get {
                return base.Email;
            }
            set {
                base.Email = value;
            }
        }
        [DataMember]
        public override string PhoneNumber {
            get {
                return base.PhoneNumber;
            }
            set {
                base.PhoneNumber = value;
            }
        }
    }
}
