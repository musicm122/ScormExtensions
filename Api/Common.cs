using RusticiSoftware.HostedEngine.Client;

namespace HackerFerret.ScormHelper.Api
{
    public static class Common
    {
        public enum UpdateType
        {
            Additive,
            Replace
        }

        private static void Create(string origin = "", string appId = "", string secretKey = "")
        {
            InitScormConfig(origin = "", appId = "", secretKey = "");
        }

        public static bool KeysAreSet { get; set; }

        public static bool IsInitialized { get; set; }
        public static string AppliationId { get; set; }
        public static string SecretKey { get; set; }


        public static readonly string ScormServiceUrl = "https://cloud.scorm.com/EngineWebServices/";

        private static void SetKeys(string appId = "", string secretKey = "")
        {
            if (KeysAreSet || string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(secretKey)) return;
            AppliationId = appId;
            SecretKey = secretKey;
            KeysAreSet = true;

        }

        public static void InitScormConfig(string origin = "", string appId = "", string secretKey = "")
        {
            if (!IsInitialized || ScormCloud.Configuration == null)
            {
                ScormCloud.Configuration = new Configuration(ScormServiceUrl, appId, secretKey, origin);
                IsInitialized = true;
            }
            if (!KeysAreSet && !string.IsNullOrWhiteSpace(appId) && !string.IsNullOrWhiteSpace(secretKey))
            {
                SetKeys(appId, secretKey);
            }
        }

        public static void UpdateScormConfig(string origin = "", string appId = "", string secretKey = "")
        {
            SetKeys(appId, secretKey);
            ScormCloud.Configuration = new Configuration(ScormServiceUrl, appId, secretKey, origin);
            IsInitialized = true;
        }
    }
}
