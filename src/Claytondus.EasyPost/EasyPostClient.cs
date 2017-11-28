using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.EasyPost.Models;

namespace Claytondus.EasyPost
{

	public class EasyPostClient : RestClient
	{
		public EasyPostClient(string authToken) : base(authToken)
		{
		}

	    public async Task<Address> CreateAddressAsync(Address address)
	    {
	        const string resource = "/addresses";
	        return await PostAsync<Address>(resource, address);
	    }

	    public async Task<Address> RetrieveAddressAsync(string id)
	    {
	        var resource = $"/addresses/{id}";
	        return await GetAsync<Address>(resource);
	    }

	    public async Task<Parcel> CreateParcelAsync(Parcel parcel)
	    {
            const string resource = "/parcels";
            return await PostAsync<Parcel>(resource, parcel);
        }

        public async Task<Parcel> RetrieveParcelAsync(string id)
        {
            var resource = $"/parcels/{id}";
            return await GetAsync<Parcel>(resource);
        }

        public async Task<Shipment> CreateShipmentAsync(CreateShipmentRequest request)
        {
            const string resource = "/shipments";
            return await PostAsync<Shipment>(resource, request);
        }

        public async Task<ShipmentList> RetrieveShipmentListAsync(RetrieveShipmentList request)
        {
            var resource = $"/shipments";
            return await GetAsync<ShipmentList>(resource, request);
        }

        public async Task<Shipment> RetrieveShipmentAsync(string id)
        {
            var resource = $"/shipments/{id}";
            return await GetAsync<Shipment>(resource);
        }

	    public async Task<Shipment> BuyShipmentAsync(string id, BuyShipmentRequest request)
	    {
            var resource = $"/shipments/{id}/buy";
	        return await PostAsync<Shipment>(resource, request);
	    }

        public async Task<Shipment> GetShipmentLabelAsync(string id, string fileFormat)
        {
            var resource = $"/shipments/{id}/label";
            return await GetAsync<Shipment>(resource, new {file_format = fileFormat});
        }

        public async Task<Shipment> RegenerateShipmentRatesAsync(string id)
        {
            var resource = $"/shipments/{id}/rates";
            return await GetAsync<Shipment>(resource);
        }

        public async Task<Shipment> InsureShipmentAsync(string id, InsureShipmentRequest request)
        {
            var resource = $"/shipments/{id}/insure";
            return await PostAsync<Shipment>(resource, request);
        }

        public async Task<Shipment> RefundShipmentAsync(string id)
        {
            var resource = $"/shipments/{id}/refund";
            return await PostAsync<Shipment>(resource, null);
        }

	    public async Task<Tracker> CreateTrackerAsync(Tracker tracker)
	    {
	        var resource = $"/trackers";
	        return await PostAsync<Tracker>(resource, tracker);
	    }

	    public async Task<Tracker> RetrieveTrackerAsync(string id)
	    {
	        var resource = $"/trackers/{id}";
	        return await GetAsync<Tracker>(resource);
	    }

    }
}