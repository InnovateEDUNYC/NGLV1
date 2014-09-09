Ngl.createNS('Ngl.report.getGrades');

Ngl.report.getGrades = (function() {
    var init = function(window) {
        var getResultsUrlTemplate = "/ParentCourseGrade/Get?sessionId={sessionId}&parentCourseId={parentCourseId}";
        var url;

        $("#ParentCourseId").on("populated", function() {
            var parentCourseId = $(this).val();
            var sessionId = $("#SessionId").val();
            var url = updateGetResultsUrl(sessionId, parentCourseId);
            if (parentCourseId != "" && sessionId != "") {
                window.location = url;
            }
        });

        $("#SessionId").on("populated", function () {
            var sessionId = $(this).val();
            var parentCourseId = $("#ParentCourseId").val();
            var url = updateGetResultsUrl(sessionId, parentCourseId);
            if (sessionId != "" && parentCourseId != "") {
                window.location = url;
            }
        });

        var updateGetResultsUrl = function(sessionId, parentCourseId) {
            url = getResultsUrlTemplate
                .replace("{sessionId}", sessionId)
                .replace("{parentCourseId}", parentCourseId);

            return url;
        }
    };

    return {
        init: init
    }
})();