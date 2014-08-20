Ngl.createNS('Ngl.attendance.take');

Ngl.attendance.take = (function () {
    var init = function () {
        setUpEvents();
    }
    var getStudentsUrlTemplate = "/Attendance/GetStudents?sectionId={sectionId}&sessionId={sessionId}&section={section}&session={session}&date={date}";

    var getStudents = function () {
        var url = getStudentsUrlTemplate
            .replace("{sectionId}", $('#SectionId').val())
            .replace("{sessionId}", $('#SessionId').val())
            .replace("{section}", $('#Section').val())
            .replace("{session}", $('#Session').val())
            .replace("{date}", $('#Date').val());
        window.location = url;
    }

    var clearStudentList = function() {
        $(".attendance-list").hide();
    }

    var setUpEvents = function () {
        $("#get-students-btn").click(getStudents);

        $("#Date").on('change', clearStudentList);
        $("#Session").on('change', clearStudentList);
        $("#Section").on('change', clearStudentList);
    };

    return {
        init: init
    }
})();