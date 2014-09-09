using System;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;

namespace NGL.Tests.Builders
{
    public class CreateAssessmentModelBuilder
    {
        private const string AssessmentTitle = "Awesome Quiz";
        private static readonly DateTime AdminsteredDate = new DateTime(2014, 9, 10);
        private const AssessmentCategoryTypeEnum QuestionType = AssessmentCategoryTypeEnum.AdvancedPlacement;
        private GradeLevelTypeEnum _gradeLevel;
        private readonly decimal? _nearMastery = 60;
        private readonly decimal? _mastery = 90;
        private const int SessionId = 1;
        private const int SectionId = 7;

        private readonly string _session = TermTypeEnum.FallSemester.Humanize() + " "
            + SchoolYearTypeEnum.Year2014.Humanize();

        private const string Section = "ENGL400 - DI";
        private const string CommonCourseStandard = "Functions";


        public CreateModel Build()
        {
            return new CreateModel
            {
                AssessmentTitle = AssessmentTitle,
                AdministeredDate = AdminsteredDate,
                QuestionType = QuestionType,
                GradeLevel = _gradeLevel,
                NearMastery = _nearMastery,
                Mastery = _mastery,
                Session = _session,
                SessionId = SessionId,
                SectionId = SectionId,
                Section = Section,
                CommonCoreStandard = CommonCourseStandard
            };
        }

        public CreateAssessmentModelBuilder WithGradeLevelTypeId(int gradeLevelTypeId)
        {
            _gradeLevel = (GradeLevelTypeEnum) gradeLevelTypeId;
            return this;
        }
    }
}
