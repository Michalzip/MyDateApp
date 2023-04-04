using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public static class Constants
    {
        public static class ErrorCodes
        {
            public const string UserNotFound = "USER_NOT_FOUND";

            public const string UserVipExists = "USER_VIP_EXISTS";

            public const string UserAlreadyExists = "USER_ALREADY_EXISTS";

            public const string LackOfPermissions = "PERMISSION_INSUFFICIENCY";


        }
    }
}