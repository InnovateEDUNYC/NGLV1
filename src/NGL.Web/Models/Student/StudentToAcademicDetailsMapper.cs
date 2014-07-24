using System.Linq;

namespace NGL.Web.Models.Student
{
    public class StudentToAcademicDetailsMapper : MapperBase<Data.Entities.Student, ProfileAcademicDetailModel>
    {
        public override void Map(Data.Entities.Student source, ProfileAcademicDetailModel target)
        {
            target.ReadingScore = source.StudentAcademicDetails.First().ReadingScore;
            target.WritingScore = source.StudentAcademicDetails.First().WritingScore;
            target.MathScore = source.StudentAcademicDetails.First().MathScore;
        }
    }
}