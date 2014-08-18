Ngl.createNS('Ngl.attendance.take');

Ngl.attendance.take = (function () {
    var init = function () {
        var getStudentsUrlTemplate = "/Attendance/GetStudents?sectionId={sectionId}&sessionId={sessionId}&section={section}&session={session}&date={date}";

        $("#get-students-btn").click(function () {
            var url = getStudentsUrlTemplate
                .replace("{sectionId}", $('#SectionId').val())
                .replace("{sessionId}", $('#SessionId').val())
                .replace("{section}", $('#Section').val())
                .replace("{session}", $('#Session').val())
                .replace("{date}", $('#Date').val());
            window.location = url;
        });
    }

    return {
        init: init
        }
})(); 