Ngl.createNS('Ngl.section.getCourse');

Ngl.section.getCourse = (function () {

    var findCourse = function () {
        $('#Course').autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/section/GetCourses",
                    type: "POST",
                    dataType: "json",
                    data: {
                        featureClass: "P",
                        style: "full",
                        maxRows: 12,
                        searchString: request.term
                    },
                    success: function (data) {
                        response($.map(data, function (course) {
                            return {
                                label: course.CourseTitle,
                                value: course.CourseCode
                            };
                        }));
                    }
                });
            },
//            select: function (event, ui) {
//                console.log(ui);
//                var selectedSession = ui.item;
//                $("#SchoolYear").val(selectedSession.school);
//                $("#Term").val(selectedSession.term);
//            },
            minLength: 2,
        });
    }

    return {
        init: findCourse
    }
})();