﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Contracts
{
    public static class ApiRoutes
    {
        public const string Base = "api";

        public static class UserAccount
        {
            public const string Register = Base + "/UserAccount/Register";

            public const string Authenticate = Base + "/UserAccount/Auth";

            public const string Refresh = Base + "/UserAccount/Refresh";
        }

        public static class User
        {
            public const string Get = Base + "/User";

            public const string GetById = Base + "/User";

            public const string Post = Base + "/User";

            public const string Put = Base + "/User";

            public const string Delete = Base + "/User";
        }
    }
}