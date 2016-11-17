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

        public static bool KeysAreSet { get; set; }
        public static bool IsInitialized { get; set; }
        public static string AppliationId { get; set; }
        public static string SecretKey { get; set; }

        /// <summary>
        /// Default Scorm Cloud Service Url
        /// </summary>
        public static readonly string ScormServiceUrl = "https://cloud.scorm.com/EngineWebServices/";

        /// <summary>
        /// Sets Api and Secret Keys required for connection to scorm cloud.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secretKey"></param>
        private static void SetKeys(string appId = "", string secretKey = "")
        {
            if (KeysAreSet || string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(secretKey)) return;
            AppliationId = appId;
            SecretKey = secretKey;
            KeysAreSet = true;

        }

        /// <summary>
        /// Initializes static instance of Scorm Cloud
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="appId"></param>
        /// <param name="secretKey"></param>
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

        /// <summary>
        /// Used to update the static instance
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="appId"></param>
        /// <param name="secretKey"></param>
        public static void UpdateScormConfig(string origin = "", string appId = "", string secretKey = "")
        {
            SetKeys(appId, secretKey);
            ScormCloud.Configuration = new Configuration(ScormServiceUrl, appId, secretKey, origin);
            IsInitialized = true;
        }
    }
}
