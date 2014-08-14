Ngl.createNS('Ngl.student.index');

Ngl.student.index = (function () {
    var setUpStudentProfile = function() {
        profilePhotoButtons();
        accordianArrows();
    }
    var profilePhotoButtons = function () {
        $('.ghost-button').change(function() {
             $('form').submit();
        });
    }

    var accordianArrows = function() {
        $(".panel").find("[data-toggle='collapse']").on("click", function() {
            var arrowElement = $(this).find("i");
            if (arrowElement.hasClass("fa-caret-down")) {
                arrowElement.removeClass("fa-caret-down").addClass("fa-caret-up");
            } else {
                arrowElement.removeClass("fa-caret-up").addClass("fa-caret-down");
            }

        });
    }

    return {
        init: setUpStudentProfile
    }
})();