﻿namespace BiuBiuServer.Services
{
    public class CustomJwtAuthenticationPayload
    {
        public long UserId { get; set; }
        public string DisplayName { get; set; }
        public bool IsAdmin { get; set; }
    }
}