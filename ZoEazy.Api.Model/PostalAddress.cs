﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public class PostalAddress
    {

        public PostalAddress(IAddress address, Subscriber human)
        {
            var name = human.FirstName + " " + human.LastName;
            Address1 = address.Street;
            var country = address.State.Country.Abbreviation;

            var apt = address.Apartment;

            var czs = address.City + ", " + address.State.Code + ", " + address.PostalCode;

            Phone = (human.Phones.Count > 0) ? human.Phones[0].Number : string.Empty;

            var isApt = !string.IsNullOrEmpty(apt);
            Address2 = isApt ? apt : czs;
            Address3 = isApt ? czs : "";

        }


        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public string Phone { get; set; }

       
    }
}