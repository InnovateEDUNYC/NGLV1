Ngl.createNS('Ngl.enrollment.enterProgramStatus');

Ngl.enrollment.enterProgramStatus = (function () {
    var setConditionalFileUploads = function()
    {
        Ngl.shared.programStatus.allowFileUploadConditionally("TestingAccommodation", "TestingAccommodationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("SpecialEducation", "SpecialEducationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("TitleParticipation", "TitleParticipationFile");
        Ngl.shared.programStatus.allowFileUploadConditionally("McKinneyVento", "McKinneyVentoFile");
    }

    return {
        init: setConditionalFileUploads
        }
})(); 