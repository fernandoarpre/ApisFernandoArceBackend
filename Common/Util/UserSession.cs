using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Util
{
    public static class UserSession
    {
        public static int UserId;
        public static string  UserName;

        public static void setUserId(int userid)
        {
            UserId = userid;
        }

        public static int getUserId()
        {
            return UserId;
        } 
    }
}
