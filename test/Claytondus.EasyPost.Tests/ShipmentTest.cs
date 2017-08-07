using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Claytondus.EasyPost.Models;
using Claytondus.PrintNode.Test;
using Xunit;

namespace Claytondus.EasyPost.Tests
{
    public class ShipmentTest
    {
        [Fact]
        public async Task CreateShipmentTest()
        {
            var client = new EasyPostClient(Configuration.GetSetting("EasyPostToken"));

            var request = new CreateShipmentRequest
            {
                shipment = new Shipment
                {
                    options = new Options {invoice_number = "17729NVXPBDK"},
                    from_address = new Address {id = "adr_c2004b0f3e864571823f955f5d421b33"},
                    to_address = new Address {id = "adr_db2c673615994177ae9ba5915d562a69"},
                    parcel = new Parcel {weight = 34.0f},
                    reference = "17729NVXPBDK",
                    carrier_accounts = new List<string>
                    {
                        "ca_da797b3cd75a46eb9fdecf633be774fe",
                        "ca_cc0e5d15e7954effbb62f858619588a3"
                    }
                }
            };
            var shipment = await client.CreateShipmentAsync(request);
            Assert.NotNull(shipment);
        }

        [Fact]
        public async Task CreateLabelTest()
        {
            var client = new EasyPostClient(Configuration.GetSetting("EasyPostToken"));

            var label = await client.GetShipmentLabelAsync("shp_8b3c1fc9fe7847e8b379513c0e76da94", "ZPL");
            Assert.NotNull(label);
        }
    }
}
