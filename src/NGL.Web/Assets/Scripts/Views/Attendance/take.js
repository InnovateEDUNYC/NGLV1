Ngl.createNS('Ngl.attendance.take');

Ngl.attendance.take = (function () {
    var init = function () {
        setUpEvents();
        checkRadioButton();
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
        $(".attendance-list-and-buttons").hide();
    }

    var setUpEvents = function () {
        $("#get-students-btn").click(getStudents);

        $("#Date").on('change', clearStudentList);
        $("#Session").on('change', clearStudentList);
        $("#Section").on('change', clearStudentList);
    };

    var checkRadioButton = function() {
        $('table.attendance-list input:checked + label > span').addClass('fa fa-check fa-2x');
        $('table.attendance-list input').click(function () {
            var spans = $(this).closest('tr').find('span');
            spans.removeClass('fa fa-check fa-2x');

            $(this).next('label').children('span').addClass('fa fa-check fa-2x');
        });
    }

    return {
        init: init
    }
})();
