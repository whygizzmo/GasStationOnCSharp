namespace Bwp
{
    public class AppSettings
    {
        /// The maximum interval in seconds for payment-related operations.
        public int MaxIntervalSec { get; set; }

        /// The delay factor for payment-related operations.
        public double DelayFactor { get; set; }

        /// <summary>Pay2Play auth token</summary>
        public string RefreshToken { get; set; }

        /// <summary>Pay2Play payment system url</summary>
        public string Pay2PlayUrl { get; set; }

        /// <summary>Url of this app, needed for making callback urls</summary>
        public string ApplicationUrl { get; set; }

        /// <summary>Path to callback action</summary>
        public string P2PCallbackRelativeUrl { get; set; }

        /// The relative URL to the callback action for AiPay.
        public string AiPayCallbackRelativeUrl { get; set; }

        /// The URL of the AiPay service.
        public string AiPayUrl { get; set; }

        /// The authentication token for accessing the AiPay service.
        public string AiPayToken { get; set; }
    }
}
