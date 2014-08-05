using System;
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
            target.Name = source.LocalCourseCode;
            target.BeginDate = source.BeginDate.ToString("dd.MM.yyyy");
            if (source.EndDate != null) 
                target.EndDate = ((DateTime)source.EndDate).ToString("dd.MM.yyyy");

            var query = new SectionByPrimaryKeysQuery(
                source.SchoolYear, source.TermTypeId, source.ClassPeriodName,
                source.ClassroomIdentificationCode, source.LocalCourseCode);
            target.SectionId = _genericRepository.Get(query).SectionIdentity;
        }
    }
}