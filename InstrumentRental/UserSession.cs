using System;

namespace InstrumentRental
{
    public static class UserSession
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }
        public static bool IsAuthenticated { get; set; }

        public static void Clear()
        {
            UserID = 0;
            Username = null;
            FullName = null;
            Role = null;
            IsAuthenticated = false;
        }
    }
}