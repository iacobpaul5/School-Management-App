﻿using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.API.Entities
{
    public class User
    {
        //public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }



}

