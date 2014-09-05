Ngl.createNS('Ngl.student.editProgramStatus');

Ngl.student.editProgramStatus = (function () {
    var init = function () {
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus.TestingAccommodation", "ProgramStatus_TestingAccommodationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus.SpecialEducation", "ProgramStatus_SpecialEducationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus.TitleParticipation", "ProgramStatus_TitleParticipationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("ProgramStatus.McKinneyVento", "ProgramStatus_McKinneyVentoFile");

        Ngl.shared.editProfile.setup('#readonly-program-status', '#collapseProgramStatus', '#editable-program-status > h4', '#editable-program-status > div', '#edit-program-status-button', '#save-program-status-edit', '#cancel-parent-info-edit', '/student/EditProgramStatus', '#edit-program-status-form'
             );
    }

    return {
        init: init
    }
})();
