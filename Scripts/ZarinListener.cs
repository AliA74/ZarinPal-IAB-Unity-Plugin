using UnityEngine;

namespace Zarinpal
{
    public class ZarinListener:MonoBehaviour
    {
        private System.Action<PurchaseResult> purchaseCb;

        private System.Action<QuerySkuResult> queryCb;

        private System.Action<string> queryErrorCb;

        private bool m_LoggingEnabled = false;

        public void Init(System.Action<PurchaseResult> OnPurchase,System.Action<QuerySkuResult> queryCb,System.Action<string> queryErrorCb
            ,bool logEnabled)
        {
            this.purchaseCb = OnPurchase;
            this.queryCb = queryCb;
            this.queryErrorCb = queryErrorCb;
            this.m_LoggingEnabled = logEnabled;
        }

        private void OnPurchaseResult(string rawJson)
        {
            if(m_LoggingEnabled)
                Debug.Log("[ZarinPal] OnPurchaseResult: "+rawJson);
            var result = UnityEngine.JsonUtility.FromJson<PurchaseResult>(rawJson);

            if(purchaseCb!=null)
                purchaseCb.Invoke(result);
        }

        private void OnQueryResult(string rawJson)
        {
            if(m_LoggingEnabled)
                Debug.Log("[ZarinPal] OnQueryResult: "+rawJson);
            
            var result = UnityEngine.JsonUtility.FromJson<QuerySkuResult>(rawJson);

            if(queryCb!=null)
                queryCb.Invoke(result);
        }

        private void OnQueryFailed(string rawError)
        {
            if(m_LoggingEnabled)
                Debug.LogError("[ZarinPal] OnQueryError: "+rawError);

            queryErrorCb?.Invoke(rawError);
        }
    }
}

