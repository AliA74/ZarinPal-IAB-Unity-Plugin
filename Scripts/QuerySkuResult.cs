using UnityEngine;

namespace Zarinpal
{
    [System.Serializable]
    public class QuerySkuResult
    {
        public SkuPurchased[] Results => results;

        [SerializeField]
        private SkuPurchased[] results;
    }
}