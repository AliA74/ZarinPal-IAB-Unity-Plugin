using UnityEngine;

namespace Zarinpal
{
    [System.Serializable]
    public class PurchaseResult
    {
        public bool Success 
        {
            get
            {
                return success;
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

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Provider
        {
            get { return provider; }
        }

        public string RedirectUrl
        {
            get
            {
                return redirectUrl;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
        }

        public string TransactionID
        {
            get
            {
                return transactionId;
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
        }

        [SerializeField]
        private bool success;
        [SerializeField]
        private long amount;
        [SerializeField]
        private string date;
        [SerializeField]
        private string description;
        [SerializeField]
        private string provider;
        [SerializeField]
        private string redirectUrl;
        [SerializeField]
        private string status;
        [SerializeField]
        private string transactionId;

        [SerializeField]
        private string errorMessage;
    }
}