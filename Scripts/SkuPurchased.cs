using UnityEngine;

namespace Zarinpal
{
    [System.Serializable]
    public class SkuPurchased
    {
        public string ProductId
        {
            get
            {
                return productId;
            }
        }

        public string Authority
        {
            get
            {
                return authority;
            }
        }

        public long Amount
        {
            get
            {
                return amount;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
        }

        [SerializeField]
        private string productId;

        [SerializeField]
        private string authority;

        [SerializeField]
        private long amount;

        [SerializeField]
        private string date;
    }
}