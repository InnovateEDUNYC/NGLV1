Ngl.createNS('Ngl.student.editProgramStatus');

Ngl.student.editProgramStatus = (function () {
    var init = function () {
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_TestingAccommodation", "ProgramStatus_TestingAccommodationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_SpecialEducation", "ProgramStatus_SpecialEducationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_TitleParticipation", "ProgramStatus_TitleParticipationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus_McKinneyVento", "ProgramStatus_McKinneyVentoFile");

        Ngl.shared.enableEditMode.init('#edit-program-status', '#collapseProgramStatus',
            '#readonly-program-status', '#editable-program-status > h4', '#editable-program-status > div');
    }

    return {
        init: init
    }
})();
