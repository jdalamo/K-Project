//Author: Shaan Davis
//Date: October 22, 2019
//Assignment: Homework 4
//Description: Toy Store with Identity

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//TODO: Change this namespace to match your project
namespace fa19projectgroup16.Models
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }

        public AppUser AppUser { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }

        public AppUser AppUser { get; set; }
    }

}