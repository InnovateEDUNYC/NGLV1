Ngl.createNS('Ngl.shared.programStatus');

Ngl.shared.programStatus = (function () {
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
        allowFileUploadConditionally: allowFileUploadConditionally
    };
})();