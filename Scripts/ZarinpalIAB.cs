using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zarinpal
{

    public static class ZarinpalIAB
    {

        #region EVENTS

        public static event System.Action<PurchaseResult> OnPurchase;

        public static event System.Action<QuerySkuResult> OnQuery;

        public static event System.Action<string> OnQueryError;

        #endregion

#if UNITY_ANDROID

        private static AndroidJavaObject unityActivity;

        private static AndroidJavaClass pluginClass;

#endif

        public static bool Initialized { get; private set; }

        static ZarinpalIAB()
        {
            Initialized = false;
        }

        public static void Init(bool showInvoice)
        {
            if(Initialized)
                return;

#if UNITY_ANDROID

            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            pluginClass = new AndroidJavaClass("com.zarrinpal.unityiab.ZarinPalBridge");

            pluginClass.CallStatic("Init", unityActivity, showInvoice, false);

#endif

            GameObject go = new GameObject("ZarinListener");
            var listener = go.AddComponent<ZarinListener>();
            listener.Init(OnPurchaseCb,OnQueryCb,OnQueryErrorCb);

            //preserve object through scene changes
            GameObject.DontDestroyOnLoad(go);

            go.hideFlags = HideFlags.HideAndDontSave;

            Initialized = true;
        }

        public static void PurchaseBySKU(string SkuID)
        {
            if (!Initialized)
            {
                throw new System.InvalidOperationException("[ZarinPal] Must call 'Init' before calling other methods");
            }


#if UNITY_ANDROID
            pluginClass.CallStatic("PurchaseBySKU", SkuID);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="amount"> Prince In Toman </param>
        /// <param name="callbackURL"></param>
        /// <param name="description"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="email"></param>
        public static void PurchaseByPaymentRequest(string merchantId, long amountInToman, string callbackURL, string description,
                                               string mobileNumber = null, string email = null)
        {
            if (!Initialized)
            {
                throw new System.InvalidOperationException("[ZarinPal] Must call 'Init' before calling other methods");
            }


#if UNITY_ANDROID
            pluginClass.CallStatic("PurchaseByPaymentRequest", merchantId, amountInToman, callbackURL, description, mobileNumber, email);
#endif
        }

        public static void PurchaseByAuthority(string Authority)
        {
            if (!Initialized)
            {
                throw new System.InvalidOperationException("[ZarinPal] Must call 'Init' before calling other methods");
            }


#if UNITY_ANDROID
            pluginClass.CallStatic("PurchaseByAuthority", Authority);
#endif
        }

        public static void QueryPurchasedSkusByMobile(string merchantId, string mobileNumber,string[] skuList)
        {
            if (!Initialized)
            {
                throw new System.InvalidOperationException("[ZarinPal] Must call 'Init' before calling other methods");
            }

            #if UNITY_ANDROID

            pluginClass.CallStatic("QuerySkuByMobile", merchantId, mobileNumber, skuList);

            #endif
        }

        public static void QueryPurchasedSkusByEmail(string merchantId, string email, string[] skuList)
        {
            if (!Initialized)
            {
                throw new System.InvalidOperationException("[ZarinPal] Must call 'Init' before calling other methods");
            }

#if UNITY_ANDROID

            pluginClass.CallStatic("QuerySkuByEmail", merchantId, email, skuList);

            #endif
        }

        public static void QueryPurchasedSkusCardPan(string merchantId, string cardPan, string[] skuList)
        {
            if (!Initialized)
            {
                throw new System.InvalidOperationException("[ZarinPal] Must call 'Init' before calling other methods");
            }

#if UNITY_ANDROID

            pluginClass.CallStatic("QuerySkuByCardPan", merchantId, cardPan, skuList);

            #endif
        }

        private static void OnPurchaseCb(PurchaseResult purchaseResult)
        {
            var t = OnPurchase;
            if (t != null)
                t.Invoke(purchaseResult);
        }

        private static void OnQueryCb(QuerySkuResult queryResult)
        {
            var t = OnQuery;
            if (t != null)
            {
                t.Invoke(queryResult);
            }
        }

        private static void OnQueryErrorCb(string errorMsg)
        {
            OnQueryError?.Invoke(errorMsg);
        }
    }

}
