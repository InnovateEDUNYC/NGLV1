using System.Collections.Generic;
using ChameleonForms.Attributes;

namespace NGL.Web.Models.Section
{
    public class CreateModel
    {
        public CreateModel()
        {
            Periods = new List<ClassPeriodListItemModel>();
            Classrooms = new List<LocationListItemModel>();
        }

        public int? SessionId { get; set; }
        public string Session { get; set; }

        public List<ClassPeriodListItemModel> Periods { get; set; }

        [ExistsIn("Periods", "ClassPeriodName", "ClassPeriodName", false)]
        public string Period { get; set; }

        public List<LocationListItemModel> Classrooms { get; set; }

        [ExistsIn("Classrooms", "Classroom", "Classroom", false)]
        public string Classroom { get; set; }

        public string Course { get; set; }

        public string UniqueSectionCode { get; set; }

        public static CreateModel CreateNewWith(List<ClassPeriodListItemModel> classPeriods, List<LocationListItemModel> classRoomModels, Data.Entities.Session session)
        {
            var createModel = new CreateModel
            {
                Periods = classPeriods,
                Classrooms = classRoomModels,
            };

            if (session != null)
            {
                createModel.SessionId = session.SessionIdentity;
                createModel.Session = session.SessionName;
            }

            return createModel;
        }
    }
}