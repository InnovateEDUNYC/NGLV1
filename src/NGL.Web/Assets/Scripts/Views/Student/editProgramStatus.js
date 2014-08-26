Ngl.createNS('Ngl.student.editProgramStatus');

Ngl.student.editProgramStatus = (function () {
    var setConditionalFileUploads = function () {
        allowFileUploadConditionally("ProgramStatus_TestingAccommodation", "ProgramStatus_TestingAccommodationFile");
        allowFileUploadConditionally("ProgramStatus_SpecialEducation", "ProgramStatus_SpecialEducationFile");
        allowFileUploadConditionally("ProgramStatus_TitleParticipation", "ProgramStatus_TitleParticipationFile");
        allowFileUploadConditionally("ProgramStatus_McKinneyVento", "ProgramStatus_McKinneyVentoFile");
    }

    var allowFileUploadConditionally = function (radioInputId, fileInputId) {
        var $fileInputField = $('#' + fileInputId);
        var $radioButtons = $('input[id=' + radioInputId + ']');
        var $checkedRadioButton = $('input[id=' + radioInputId + ']:checked');

        enableOrDisableFileUploadInput($fileInputField, $checkedRadioButton.val());
        $radioButtons.click(function () {
            enableOrDisableFileUploadInput($fileInputField, $(this).val());
        });
    };

    var enableOrDisableFileUploadInput = function (fileInputField, radioButtonVal) {
        if (radioButtonVal === 'True') {
            fileInputField.removeAttr('disabled');
        }
        else {
            fileInputField.attr('disabled', 'disabled');
            fileInputField.val('');
        }
    }


    return {
        init: setConditionalFileUploads
    }
})();