Ngl.createNS('Ngl.student.editHomeAddress');

Ngl.student.editHomeAddress = (function () {
    var init = function () {

        Ngl.shared.enableEditMode.init('#edit-home-address', '#collapseHomeAddress',
    '#readonly-home-address', '#editable-home-address > h4', '#editable-home-address > div');

        setUpSaveButton();
    }

    var removeOldErrors = function () {
        $('.field-validation-error')
        .addClass("field-validation-valid")
        .removeClass("field-validation-error")
        .text("");
        $('.control-label').parent().removeClass('has-error');
    }

    var displayErrors = function (errors) {
        removeOldErrors();

        errors.forEach(function (error) {
            $('.field-validation-valid[data-valmsg-for="' + error.Field + '"]')
                .addClass("field-validation-error")
                .removeClass("field-validation-valid")
                .text(error.Message);
            $('.control-label[for="' + error.Field + '"]').parent().addClass('has-error');
        });
    };


    var ajaxEditPost = function () {
        $.ajax({
            url: '/student/editHomeAddress',
            type: 'POST',
            dataType: 'json',
            data: $('#edit-home-address-form').serialize(),
            success: function (returnValue) {
                var errors = returnValue.nglErrors;
                if (!errors == false) {
                    displayErrors(errors);
                } else {
                    location.reload(true);
                };
            }
        });
    }

    var setUpSaveButton = function () {
        $('#submit-home-address').on('click', ajaxEditPost);
    }

    return {
        init: init
    }
})();
