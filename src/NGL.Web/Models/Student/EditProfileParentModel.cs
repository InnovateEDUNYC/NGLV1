﻿using System.ComponentModel.DataAnnotations;
using NGL.Web.Data.Entities;

namespace NGL.Web.Models.Student
{
    public class EditProfileParentModel
    {
        public int ParentUSI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexTypeEnum Sex { get; set; }

        [Display(Name = "Relationship")]
        public string RelationshipForDisplay { get; set; }
        public RelationTypeEnum Relationship { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool SameAddressAsStudent { get; set; }
        public EditableParentAddressModel EditableParentAddressModel { get; set; }
    }
}