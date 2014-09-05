Ngl.createNS('Ngl.shared.programStatus');

Ngl.shared.programStatus = (function () {
    var allowFileUploadConditionally = function (radioInputName, fileInputId) {
        var $fileInputField = $('#' + fileInputId);
        var $radioButtons = $('input[name="' + radioInputName + '"]');
        var $checkedRadioButton = $('input[name="' + radioInputName + '"]:checked');

        enableOrDisableFileUploadInput($fileInputField, $checkedRadioButton.val());
        $radioButtons.on("click", function () {
            enableOrDisableFileUploadInput($fileInputField, $(this).val());
        });
    };

    var enableOrDisableFileUploadInput = function (fileInputField, radioButtonVal) {
        if (radioButtonVal === 'true') {
            fileInputField.removeAttr('disabled');
        }
        else {
            fileInputField.attr('disabled', 'disabled');
            fileInputField.val('');
        }
    }

    return {
        allowFileUploadConditionally: allowFileUploadConditionally
    };
})();