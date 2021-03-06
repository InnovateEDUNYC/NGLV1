﻿using System;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class CreateParentModel
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public SexTypeEnum? Sex { get; set; }
        public RelationTypeEnum? RelationshipToStudent { get; set; }

        public String TelephoneNumber { get; set; }

        public String EmailAddress { get; set; }

        public bool MakeThisPrimaryContact { get; set; }

        public bool SameAddressAsStudent { get; set; }

        public String Address { get; set; }

        public String Address2 { get; set; }

        public String City { get; set; }

        public StateAbbreviationTypeEnum? State { get; set; }
        public String PostalCode { get; set; }
    }
}