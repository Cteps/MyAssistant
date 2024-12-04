namespace MAServer.Routes
{
    public static class SystemEndPoint
    {
        public static string basePath = "api/System";

    }

    public static class ObjEndPoints
    {
        private static string basePath = "api/Obj";

        public static string GetObjEsp =>
            $"{basePath}/GetObjEsp";
    }
}
