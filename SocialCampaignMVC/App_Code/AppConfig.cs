using System.Configuration;

namespace SocialCampaignMVC.App_Code
{
    public static class AppConfig
    {

        private readonly static string dbFBConnectionString;
        private readonly static string dbXDConnectionString;


        static AppConfig()
        {

            dbFBConnectionString = ConfigurationManager.ConnectionStrings["FaceConnection"].ConnectionString;
            dbXDConnectionString = ConfigurationManager.ConnectionStrings["XceedConnectionString"].ConnectionString;

        }

        public static string FBConnectionString
        {
            get
            {
                return dbFBConnectionString;
            }
        }

        public static string AppConnectionString
        {
            get
            {
                return dbXDConnectionString;
            }
        }
    }
}

