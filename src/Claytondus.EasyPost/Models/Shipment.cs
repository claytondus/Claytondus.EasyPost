using System;
using System.Collections.Generic;
using System.Linq;

namespace Claytondus.EasyPost.Models {
    public class Shipment {
        public string id { get; set; }
        public string mode { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string tracking_code { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public bool? is_return { get; set; }
        public Options options { get; set; }
        public List<Message> messages { get; set; }
        public CustomsInfo customs_info { get; set; }
        public Address from_address { get; set; }
        public Address to_address { get; set; }
        public Parcel parcel { get; set; }
        public PostageLabel postage_label { get; set; }
        public List<Rate> rates { get; set; }
        public List<Fee> fees { get; set; }
        public ScanForm scan_form { get; set; }
        public List<Form> forms { get; set; }
        public Rate selected_rate { get; set; }
        public Tracker tracker { get; set; }
        public Address buyer_address { get; set; }
        public Address return_address { get; set; }
        public string refund_status { get; set; }
        public string insurance { get; set; }
        public string batch_status { get; set; }
        public string batch_message { get; set; }
        public string usps_zone { get; set; }
        public string stamp_url { get; set; }
        public string barcode_url { get; set; }
        public List<string> carrier_accounts { get; set; }



        /// <summary>
        /// Get the lowest rate for the shipment. Optionally whitelist/blacklist carriers and servies from the search.
        /// </summary>
        /// <param name="includeCarriers">Carriers whitelist.</param>
        /// <param name="includeServices">Services whitelist.</param>
        /// <param name="excludeCarriers">Carriers blacklist.</param>
        /// <param name="excludeServices">Services blacklist.</param>
        /// <returns>EasyPost.Rate instance or null if no rate was found.</returns>
        public Rate LowestRate(IEnumerable<string> includeCarriers = null, IEnumerable<string> includeServices = null,
                               IEnumerable<string> excludeCarriers = null, IEnumerable<string> excludeServices = null) {
            if (rates == null)
                throw new Exception("Rates is null");

            List<Rate> result = new List<Rate>(rates);

            if (includeCarriers != null)
                filterRates(ref result, rate => includeCarriers.Contains(rate.carrier));
            if (includeServices != null)
                filterRates(ref result, rate => includeServices.Contains(rate.service));
            if (excludeCarriers != null)
                filterRates(ref result, rate => !excludeCarriers.Contains(rate.carrier));
            if (excludeServices != null)
                filterRates(ref result, rate => !excludeServices.Contains(rate.service));

            return result.OrderBy(rate => double.Parse(rate.rate)).FirstOrDefault();
        }

        private void filterRates(ref List<Rate> rates, Func<Rate, bool> filter) {
            rates = rates.Where(filter).ToList();
        }
    }

    public class BuyShipmentRequest
    {
        public Rate rate { get; set; }
        public string insurance { get; set; }
    }

    public class InsureShipmentRequest
    {
        public decimal amount { get; set; }
    }
}
