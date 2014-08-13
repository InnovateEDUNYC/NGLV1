using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;

namespace NGL.Tests.Builders
{
    public class CreateAssessmentModelBuilder
    {
        private const string AssessmentTitle = "MATH 2090 Pop Quiz";
        private static DateTime _adminsteredDate = new DateTime(2003, 9, 9);
        private const AssessmentCategoryTypeEnum QuestionType = AssessmentCategoryTypeEnum.AdvancedPlacement;
        private GradeLevelTypeEnum _gradeLevel;
        private readonly decimal? _nearMastery = 60;
        private readonly decimal? _mastery = 90;
        private int _sessionId = 1;

        public CreateAssessmentModel Build()
        {
            return new CreateAssessmentModel
            {
                AssessmentTitle = AssessmentTitle,
                AdministeredDate = _adminsteredDate,
                QuestionType = QuestionType,
                GradeLevel = _gradeLevel,
                NearMastery = _nearMastery,
                Mastery = _mastery,
                SessionId = _sessionId
            };
        }

        public CreateAssessmentModelBuilder WithGradeLevelTypeId(int gradeLevelTypeId)
        {
            _gradeLevel = (GradeLevelTypeEnum) gradeLevelTypeId;
            return this;
        }
    }
}
