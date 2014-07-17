Ngl.createNS('Ngl.enrollment.enterProgramStatus');

Ngl.enrollment.enterProgramStatus = (function () {
    var setConditionalFileUploads = function()
    {
        allowFileUploadConditionally("TestingAccommodation", "TestingAccommodationFile");
        allowFileUploadConditionally("SpecialEducation", "SpecialEducationFile");
        allowFileUploadConditionally("TitleParticipation", "TitleParticipationFile");
        allowFileUploadConditionally("McKinneyVento", "McKinneyVentoFile");
    }

    var allowFileUploadConditionally = function (radioInputId, fileInputId) {
        var $fileInputField = $('#' + fileInputId);
        var $radioButtons = $('input[name=' + radioInputId + ']');
        var $checkedRadioButton = $('input[name=' + radioInputId + ']:checked');

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