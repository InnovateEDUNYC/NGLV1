using System;
using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Enrollment
{
    public class ParentEnrollmentInfoModel
    {
        [Required]
        [StringLength(75)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(75)]
        public String LastName { get; set; }

        [Required]
        public RelationTypeEnum? RelationshipToStudent { get; set; }

        [StringLength(24)]
        public String TelephoneNumber { get; set; }

        [StringLength(128)]
        public String EmailAddress { get; set; }

        public bool MakeThisPrimaryContact { get; set; }
       
        [Required]
        public SexTypeEnum? Sex { get; set; }

        public bool SameAddressAsStudent { get; set; }

        [StringLength(150)]
        public String Address { get; set; }

        [StringLength(20)]
        public String Address2 { get; set; }

        [StringLength(30)]
        public String City { get; set; }

        [StringLength(17)]
        public String PostalCode { get; set; }

        public StateAbbreviationTypeEnum? State { get; set; }
    }
}