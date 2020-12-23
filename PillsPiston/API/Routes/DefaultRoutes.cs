namespace PillsPiston.API.Routes
{
    public static class DefaultRoutes
    {
        public const string Root = "api";

        public const string Version = "v0";

        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Logout = Base + "/identity/logout";

            public const string RefreshToken = Base + "/identity/refreshToken";
        }

        public static class Admin
        {
            public const string Devices = Base + "/admin/devices";

            public const string Cells = Base + "/admin/cells";
        }

        public static class Device
        {
            public const string Cells = Base + "/device/cells";

            public const string Connection = Base + "/device/connection";
        }

        public static class Profile
        {
            public const string Relationships = Base + "/profile/relationship";

            public const string Cells = Base + "/profile/cell";

            public const string Adoption = Base + "/profile/adoption";
        }
    }
}
