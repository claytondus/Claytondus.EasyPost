﻿using System;

namespace Claytondus.EasyPost.Models
{
    public class Options
    {
        public bool? additional_handling { get; set; }
        public string? address_validation_level { get; set; }
        public bool? alcohol { get; set; }
        public string? bill_receiver_account { get; set; }
        public string? bill_receiver_postal_code { get; set; }
        public string? bill_third_party_account { get; set; }
        public string? bill_third_party_country { get; set; }
        public string? bill_third_party_postal_code { get; set; }
        public bool? by_drone { get; set; }
        public bool? carbon_neutral { get; set; }
        public string? carrier_insurance_amount { get; set; }
        public string? carrier_notification_email { get; set; }
        public string? carrier_notification_sms { get; set; }
        public string? cod_address_id { get; set; }
        public string? cod_amount { get; set; }
        public string? cod_method { get; set; }
        public string? commercial_invoice_format { get; set; }
        public string? commercial_invoice_size { get; set; }
        public string? cost_center { get; set; }
        public string? currency { get; set; }
        public string? customs_broker_address_id { get; set; }
        public double? declared_value { get; set; }
        public bool? delivered_duty_paid { get; set; }
        public string? delivery_confirmation { get; set; }
        public string? delivery_time_preference { get; set; }
        public string? duty_payment_account { get; set; }
        public DutyPayment? duty_payment { get; set; }
        public bool? dry_ice { get; set; }
        public string? dry_ice_medical { get; set; }
        public string? dry_ice_weight { get; set; }
        public string? freight_charge { get; set; }
        public string? group { get; set; }
        public string? handling_instructions { get; set; }
        public string? hazmat { get; set; }
        public bool? hold_for_pickup { get; set; }
        public string? image_format { get; set; }
        public string? incoterm { get; set; }
        public string? invoice_number { get; set; }
        public DateTime? label_date { get; set; }
        public string? label_format { get; set; }
        public string? label_size { get; set; }
        public string? machinable { get; set; }
        public bool? neutral_delivery { get; set; }
        public bool? non_contract { get; set; }
        public Payment? payment { get; set; }
        public string? po_sort { get; set; }
        public string? print_custom_1 { get; set; }
        public string? print_custom_2 { get; set; }
        public string? print_custom_3 { get; set; }
        public string? print_custom_1_code { get; set; }
        public string? print_custom_2_code { get; set; }
        public string? print_custom_3_code { get; set; }
        public bool? print_custom_1_barcode { get; set; }
        public bool? print_custom_2_barcode { get; set; }
        public bool? print_custom_3_barcode { get; set; }
        public bool? print_rate { get; set; }
        public string? return_service { get; set; }
        public bool? saturday_delivery { get; set; }
        public string? settlement_method { get; set; }
        public string? smartpost_hub { get; set; }
        public string? smartpost_manifest { get; set; }
        public string? special_rates_eligibility { get; set; }
        public string? commercial_invoice_signature { get; set; }
        public string? parties_to_transaction_are_related { get; set; }
        public string? import_state_tax_id { get; set; }
        public string? import_federal_tax_id { get; set; }
        public string? customs_include_shipping { get; set; }
        public string? importer_address_id { get; set; }
    }
}
