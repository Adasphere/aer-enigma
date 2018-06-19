// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalSettings.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public const string AzureTag = "Azure";

        /// <summary>
        /// 
        /// </summary>
        public const string MockTag = "Mock";

        /// <summary>
        /// 
        /// i.e.: "http://YOUR_IP" or "http://YOUR_DNS_NAME"
        /// </summary>
        public const string DefaultEndpoint = "http://YOUR_IP_OR_DNS_NAME";

        /// <summary>
        /// hello world
        /// </summary>
        private static readonly GlobalSettings instance = new GlobalSettings();

        /// <summary>
        /// 
        /// </summary>
        private string baseEndpoint;

        /// <summary>
        /// 
        /// </summary>
        public GlobalSettings()
        {
            AuthToken = "INSERT AUTHENTICATION TOKEN";
            BaseEndpoint = DefaultEndpoint;
        }

        /// <summary>
        /// 
        /// </summary>
        public static GlobalSettings Instance => instance;

        /// <summary>
        /// 
        /// </summary>
        public string BaseEndpoint
        {
            get => this.baseEndpoint;

            set
            {
                this.baseEndpoint = value;
                this.UpdateEndpoint(this.baseEndpoint);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId => "xamarin";

        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret => "secret";

        /// <summary>
        /// 
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RegisterWebsite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IdentityEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserInfoEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogoutEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IdentityCallback { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogoutCallback { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseEndpoint">
        /// 
        /// </param>
        private void UpdateEndpoint(string baseEndpoint)
        {
            var identityBaseEndpoint = $"{baseEndpoint}/identity";
            this.RegisterWebsite = $"{identityBaseEndpoint}/Account/Register";
            this.LogoutCallback = $"{identityBaseEndpoint}/Account/Redirecting";

            var connectBaseEndpoint = $"{identityBaseEndpoint}/connect";
            this.IdentityEndpoint = $"{connectBaseEndpoint}/authorize";
            this.UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
            this.TokenEndpoint = $"{connectBaseEndpoint}/token";
            this.LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            this.IdentityCallback = $"{baseEndpoint}/xamarincallback";
        }
    }
}
