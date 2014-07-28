using System.Linq;
using Castle.Core.Internal;
using NGL.Web.Data.Entities;
using NGL.Web.Infrastructure.Azure;

namespace NGL.Web.Models.Student
{
    public class StudentToAcademicDetailsMapper : MapperBase<Data.Entities.Student, ProfileAcademicDetailModel>
    {
        private readonly IFileDownloader _azureStorageDownloader;

        public StudentToAcademicDetailsMapper(IFileDownloader azureStorageDownloader)
        {
            _azureStorageDownloader = azureStorageDownloader;
        }

        public override void Map(Data.Entities.Student source, ProfileAcademicDetailModel target)
        {
            var studentAcademicDetail = source.StudentAcademicDetails.First();

            target.SchoolYear = studentAcademicDetail.SchoolYear;
            target.ReadingScore = studentAcademicDetail.ReadingScore;
            target.WritingScore = studentAcademicDetail.WritingScore;
            target.MathScore = studentAcademicDetail.MathScore;
            target.PerformanceHistoryFileUrl = CreateSignitureUri(studentAcademicDetail.PerformanceHistoryFile);
            target.PerformanceHistory = studentAcademicDetail.PerfomanceHistory;
        }

        private string CreateSignitureUri(string filename)
        {
            if (filename.IsNullOrEmpty()) return null;
            var fileDownloader = _azureStorageDownloader;
            return fileDownloader.DownloadPath(ConfigManager.StudentBlobContainer, filename);
        }
    }
}