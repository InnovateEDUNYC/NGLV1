Ngl.createNS('Ngl.student.editAcademicDetails');

Ngl.student.editAcademicDetails = (function () {
    var init = function () {
        var formSelector = "#edit-academic-details-form";

        var onSuccess = function () {
            $(formSelector).submit();
        };

        Ngl.shared.editProfile.setup('#readonly-academic-details', '#collapseAcademicDetails', '#editable-academic-details > h4', '#editable-academic-details > div', '#edit-academic-details-button', '#save-academic-details-edit', '#cancel-academic-details-edit', '/student/validateEditedAcademicDetails', formSelector,
            onSuccess);

    }

    return {
        init: init
    }
})();
