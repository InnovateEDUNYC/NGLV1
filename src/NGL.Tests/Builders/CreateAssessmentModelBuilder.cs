using System;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;

namespace NGL.Tests.Builders
{
    public class CreateAssessmentModelBuilder
    {
        private const string AssessmentTitle = "Awesome Quiz";
        private static DateTime _adminsteredDate = new DateTime(2014, 9, 10);
        private const AssessmentCategoryTypeEnum QuestionType = AssessmentCategoryTypeEnum.AdvancedPlacement;
        private GradeLevelTypeEnum _gradeLevel;
        private readonly decimal? _nearMastery = 60;
        private readonly decimal? _mastery = 90;
        private int _sessionId = 1;
        private int _sectionId = 7;
        private string _session = TermTypeEnum.FallSemester.Humanize() + " "
            + SchoolYearTypeEnum.Year2014.Humanize();
        private string _section = "ENGL400 - DI";
        private string _commonCourseStandard = "Functions";


        public CreateModel Build()
        {
            return new CreateModel
            {
                AssessmentTitle = AssessmentTitle,
                AdministeredDate = _adminsteredDate,
                QuestionType = QuestionType,
                GradeLevel = _gradeLevel,
                NearMastery = _nearMastery,
                Mastery = _mastery,
                Session = _session,
                SessionId = _sessionId,
                SectionId = _sectionId,
                Section = _section,
                CommonCoreStandard = _commonCourseStandard
            };
        }

        public CreateAssessmentModelBuilder WithGradeLevelTypeId(int gradeLevelTypeId)
        {
            _gradeLevel = (GradeLevelTypeEnum) gradeLevelTypeId;
            return this;
        }
    }
}
