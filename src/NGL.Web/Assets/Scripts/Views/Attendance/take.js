Ngl.createNS('Ngl.attendance.take');

Ngl.attendance.take = (function () {
    var init = function () {
        var getStudentsUrlTemplate = "/Attendance/GetStudents?sectionId={sectionId}&date={date}";

        $("#get-students-btn").click(function () {
            var url = getStudentsUrlTemplate
                .replace("{sectionId}", $('#SectionId').val())
                .replace("{date}", $('#Date').val());
            window.location = url;
        });
    }

    return {
        init: init
        }
})(); 