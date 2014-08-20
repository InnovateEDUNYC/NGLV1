﻿Ngl.createNS('Ngl.report.getGrades');

Ngl.report.getGrades = (function() {
    var init = function() {
        var url = "/ParentCourse/Grades";
        var getResultsUrlTemplate = "?sectionId={sectionId}";

        $("#SectionId").on("populated", function() {
            var sectionId = $(this).val();
            var url = updateGetResultsUrl(sectionId);
            window.location = url;
        });

        var updateGetResultsUrl = function(sectionId) {
            url = url + getResultsUrlTemplate
                .replace("{sectionId}", sectionId);

            return url;
        }
    };

    return {
        init: init
    }
})();