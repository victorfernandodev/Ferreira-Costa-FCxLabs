﻿namespace UsersAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CPF { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? MotherName { get; set; }
        public string? Status { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateTime ChangeDate { get; set; }

    }
}
