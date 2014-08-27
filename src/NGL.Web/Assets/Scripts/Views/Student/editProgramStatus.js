Ngl.createNS('Ngl.student.editProgramStatus');

Ngl.student.editProgramStatus = (function () {
    var init = function () {
        console.log(Ngl);
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_TestingAccommodation", "ProgramStatus_TestingAccommodationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_SpecialEducation", "ProgramStatus_SpecialEducationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_TitleParticipation", "ProgramStatus_TitleParticipationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_McKinneyVento", "ProgramStatus_McKinneyVentoFile");

        enableEditMode();
    }

    var enableEditMode = function () {
        $('#edit-program-status').on('click', function () {
            $('#readonly-program-status').hide();
            $('#editable-program-status > h4').show();
            $('#editable-program-status > div').slideDown({
                duration: "950",
                easing: "linear"
            });
        });
    }

    return {
        init: init
    }
})();
