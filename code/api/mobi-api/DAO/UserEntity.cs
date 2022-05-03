﻿using System.ComponentModel.DataAnnotations;

namespace mobi_api.DAO
{
    public class UserEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}