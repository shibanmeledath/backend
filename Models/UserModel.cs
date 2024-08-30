using System;
using System.ComponentModel.DataAnnotations;
namespace backend.Models;

public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string? PasswordHash { get; set; }   // Initialized to avoid warnings
    }
