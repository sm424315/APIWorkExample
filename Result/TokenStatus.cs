using System;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Result
{
    public class TokenStatus
    {
        public EnumValueAndName Status { get; set; }
        public DateTime? ExpiresDateTime { get; set; }
        public int? UserId { get; set; }
    }
}