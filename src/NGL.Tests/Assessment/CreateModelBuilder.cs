using System;
using NGL.Web.Data.Entities;
using NGL.Web.Models.Assessment;

namespace NGL.Tests.Assessment
{
    public class CreateModelBuilder
    {
        private const string AssessmentTitle = "MATH 2090 Pop Quiz";
        private static DateTime _adminsteredDate = new DateTime(2003, 9, 9);
        private const AssessmentCategoryTypeEnum QuestionType = AssessmentCategoryTypeEnum.AdvancedPlacement;
        private GradeLevelTypeEnum _gradeLevel;
        private readonly decimal? _nearMastery = 60;
        private readonly decimal? _mastery = 90;

        public CreateModel Build()
        {
            return new CreateModel
            {
                AssessmentTitle = AssessmentTitle,
                AdministeredDate = _adminsteredDate,
                QuestionType = QuestionType,
                GradeLevel = _gradeLevel,
                NearMastery = _nearMastery,
                Mastery = _mastery
            };
        }

        public CreateModelBuilder WithGradeLevelTypeId(int gradeLevelTypeId)
        {
            _gradeLevel = (GradeLevelTypeEnum) gradeLevelTypeId;
            return this;
        }
    }
}
