using System.Collections.Generic;
using MadPixel;
using MAXHelper;
using UnityEngine;
using UnityEngine.Purchasing;

namespace MadPixelAnalytics {
    [RequireComponent(typeof(AppMetrica))]
    public class AppMetricaComp : MonoBehaviour {
        [SerializeField] private bool bLogEventsOnDevice = false;
#if UNITY_EDITOR
        [SerializeField] private bool bLogEventsInEditor = true;
#endif
        IYandexAppMetrica _yandexMetrica;

        public void Init() {
            _yandexMetrica = AppMetrica.Instance;
        }


        #region Ads Related
        public void VideoAdWatched(AdInfo AdInfo) {
            SendCustomEvent("video_ads_watch", GetAdAttributes(AdInfo));
        }

        public void VideoAdAvailable(AdInfo AdInfo) {
            SendCustomEvent("video_ads_available", GetAdAttributes(AdInfo));
        }

        public void VideoAdStarted(AdInfo AdInfo) {
            SendCustomEvent("video_ads_started", GetAdAttributes(AdInfo));
        }


        public void VideoAdError(MaxSdkBase.AdInfo adInfo, MaxSdkBase.ErrorInfo EInfo, string placement) {
            Dictionary<string, object> eventAttributes = new Dictionary<string, object>();

            string NetworkName = "unknown";
            if (adInfo != null && !string.IsNullOrEmpty(adInfo.NetworkName)) {
                NetworkName = adInfo.NetworkName;
            }

            string AdLoadFailureInfo = "NULL";
            string Message = "NULL";
            string Code = "NULL";
            if (EInfo != null) {
                if (!string.IsNullOrEmpty(EInfo.Message)) {
                    Message = EInfo.Message;
                }
                if (!string.IsNullOrEmpty(EInfo.AdLoadFailureInfo)) {
                    AdLoadFailureInfo = EInfo.AdLoadFailureInfo;
                }

                Code = EInfo.Code.ToString();
            }

            eventAttributes.Add("network", NetworkName);
            eventAttributes.Add("error_message", Message);
            eventAttributes.Add("error_code", Code);
            eventAttributes.Add("ad_load_failure_info", AdLoadFailureInfo);
            eventAttributes.Add("placement", placement);
            SendCustomEvent("ad_display_error", eventAttributes);
        }

        #endregion


        public void RateUs(int rateResult) {
            Dictionary<string, object> eventAttributes = new Dictionary<string, object>();
            eventAttributes.Add("rate_result", rateResult);
            SendCustomEvent("rate_us", eventAttributes);
        }

        public void ABTestInitMetricaAttributes(string Value) {
            YandexAppMetricaUserProfile profile = new YandexAppMetricaUserProfile();
            List<YandexAppMetricaUserProfileUpdate> profileUpdates = new List<YandexAppMetricaUserProfileUpdate>();

            profileUpdates.Add(new YandexAppMetricaStringAttribute("ab_test_group").WithValue(Value));

            _yandexMetrica.ReportUserProfile(profile.ApplyFromArray(profileUpdates));
            _yandexMetrica.SendEventsBuffer();
        }



        #region Purchases
        public void PurchaseSucceed(MPReceipt Receipt) {
            Dictionary<string, object> eventAttributes = new Dictionary<string, object>();
            eventAttributes.Add("inapp_id", Receipt.Product.definition.storeSpecificId);
            eventAttributes.Add("currency", Receipt.Product.metadata.isoCurrencyCode);
            eventAttributes.Add("price", (float)Receipt.Product.metadata.localizedPrice);
            SendCustomEvent("payment_succeed", eventAttributes);

            HandlePurchase(Receipt.Product, Receipt.Data, Receipt.Signature);
        }

        public void HandlePurchase(Product Product, string data, string signature) {
            YandexAppMetricaRevenue Revenue = new YandexAppMetricaRevenue(
                (decimal)Product.metadata.localizedPrice, Product.metadata.isoCurrencyCode);

            YandexAppMetricaReceipt Receipt = new YandexAppMetricaReceipt();
            Receipt.Signature = signature;
            Receipt.Data = data;

            Revenue.Receipt = Receipt;
            Revenue.Quantity = 1;
            Revenue.ProductID = Product.definition.storeSpecificId;

#if UNITY_EDITOR
            return;
#else
            _yandexMetrica.ReportRevenue(Revenue);
#endif
        }
        #endregion


        #region Helpers

        public void SendCustomEvent(string eventName, Dictionary<string, object> parameters, bool bSendEventsBuffer = false) {
            if (parameters == null) {
                parameters = new Dictionary<string, object>();
            }

            bool debugLog = bLogEventsOnDevice;

#if UNITY_EDITOR
            debugLog = bLogEventsInEditor;
#else
            if (_yandexMetrica != null) {
                _yandexMetrica.ReportEvent(eventName, parameters);

                if (bSendEventsBuffer) {
                    _yandexMetrica.SendEventsBuffer();
                }
            }
            else Debug.LogError("YandexMetrica instance is null");
#endif
            if (debugLog) {
                string eventParams = "";
                foreach (string key in parameters.Keys) {
                    eventParams = eventParams + "\n" + key + ": " + parameters[key].ToString();
                }

                Debug.Log($"Event: {eventName} and params: {eventParams}");
            }
        }


        private Dictionary<string, object> GetAdAttributes(AdInfo Info) {
            Dictionary<string, object> eventAttributes = new Dictionary<string, object>();
            string adType = "interstitial";
            if (Info.AdType == AdsManager.EAdType.REWARDED) {
                adType = "rewarded";
            } else if (Info.AdType == AdsManager.EAdType.BANNER) {
                adType = "banner";
            }
            eventAttributes.Add("ad_type",  adType);
            eventAttributes.Add("placement", Info.Placement);
            eventAttributes.Add("connection", Info.HasInternet ? 1 : 0);
            eventAttributes.Add("result", Info.Availability);

            return eventAttributes;
        }
        #endregion

    }
}
