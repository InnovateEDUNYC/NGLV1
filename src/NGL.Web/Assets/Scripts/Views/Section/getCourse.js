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
                                label: course.CourseCode + ": " + course.CourseTitle,
                                value: course.CourseCode
                            };
                        }));
                    }
                });
            },
            minLength: 2,
        });
    }

    return {
        init: findCourse
    }
})();