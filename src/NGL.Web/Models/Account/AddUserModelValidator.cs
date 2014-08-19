using System;
using FluentValidation;
using NGL.Web.Data.Repositories;

namespace NGL.Web.Models.Account
{
    public class AddUserModelValidator : AbstractValidator<AddUserModel>
    {
        public AddUserModelValidator(IStaffRepository staffRepository)
        {
            RuleFor(m => m.Username)
                .NotNull()
                .Length(1, 256);

            RuleFor(m => m.Password)
                .NotNull()
                .Length(6, 100)
                .WithMessage("The {0} must be at least 6 characters long.");

            RuleFor(m => m.ConfirmPassword).NotNull()
                .Equal(m => m.Password)
                .WithMessage("The password and confirmation password do not match.");

            RuleFor(m => m.StaffUSI)
                .NotNull()
                .Must(NotAlreadyExistAStaffWithSameStaffUSI(staffRepository))
                .WithMessage("A staff member with this Staff USI already exists.");

            RuleFor(m => m.TeacherUSI).NotNull();
            RuleFor(m => m.PeronalTitlePrefix).Length(1, 75);

            RuleFor(m => m.FirstName)
                .NotNull()
                .Length(1, 75);

            RuleFor(m => m.LastName)
                .NotNull()
                .Length(1, 75);

            RuleFor(m => m.OldEthnicityType).NotNull();

            RuleFor(m => m.GenerationCodeSuffix)
                .Length(1, 75);

            RuleFor(m => m.MaidenName)
                .Length(1, 75);

            RuleFor(m => m.BirthDate).NotNull();
            RuleFor(m => m.Sex).NotNull();
            RuleFor(m => m.PersonalEmail).NotEmpty().EmailAddress();
            RuleFor(m => m.HighestCompletedLevelOfEducation).NotNull();
            RuleFor(m => m.CitizenshipStatus).NotNull();
            RuleFor(m => m.YearsOfPriorProfessionalExperience).NotNull();
            RuleFor(m => m.YearsOfPriorTeachingExperience).NotNull();
            RuleFor(m => m.SSN)
                .NotNull()
                .Length(8, 11);
            RuleFor(m => m.Certificate1)
                .NotNull()
                .Length(1, 60);
            RuleFor(m => m.Certificate2)
                .NotNull()
                .Length(1, 60);
            RuleFor(m => m.Certificate3)
                .NotNull()
                .Length(1, 60);
            RuleFor(m => m.Certificate4)
                .NotNull()
                .Length(1, 60);
            RuleFor(m => m.CriminalBackgroundCheck).Equal(true).WithMessage("Criminal Background Check is required for staff");
            RuleFor(m => m.Fingerprinted).Equal(true).WithMessage("Finger printing is required for staff");
        }

        private Func<int?, bool> NotAlreadyExistAStaffWithSameStaffUSI(IStaffRepository staffRepository)
        {
            return staffUSI => staffUSI != null && staffRepository.GetStaffByStaffUSI(staffUSI.Value) == null;
        }
    }
}