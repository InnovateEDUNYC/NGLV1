using System;
using Humanizer;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Queries;

namespace NGL.Web.Models.Section
{
    public class StudentSectionAssociationToSectionListItemModelMapper : MapperBase<StudentSectionAssociation, SectionListItemModel>
    {
        private readonly IGenericRepository _genericRepository;

        public StudentSectionAssociationToSectionListItemModelMapper(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public override void Map(StudentSectionAssociation source, SectionListItemModel target)
        {
            target.Name = source.LocalCourseCode + " (" + source.ClassPeriodName + ", " + ((TermTypeEnum)source.TermTypeId).Humanize() + ")";
            target.BeginDate = source.BeginDate.ToShortDateString();
            if (source.EndDate != null) 
                target.EndDate = ((DateTime)source.EndDate).ToShortDateString();

            var query = new SectionByPrimaryKeysQuery(
                source.SchoolYear, source.TermTypeId, source.ClassPeriodName,
                source.ClassroomIdentificationCode, source.LocalCourseCode);
            target.SectionId = _genericRepository.Get(query).SectionIdentity;

            target.StudentSectionId = source.StudentSectionAssociationIdentity;
        }
    }
}