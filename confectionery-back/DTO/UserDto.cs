﻿namespace confectionery_back.DTO
{
    public record UserDto
    {
        public string ?UserName { get; set; }
        public int OrderCounter { get; set; }
    }
}
