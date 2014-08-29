Ngl.createNS('Ngl.student.editBiographicalInfo');

Ngl.student.editBiographicalInfo = (function () {

    var setUp = function() {
        setUpEditButton();
        setUpCancelButton();
        setUpSaveButton();
    }

    var setUpEditButton = function() {
        $('#edit-biographical-info-button').on('click', function () {
            $('#readonly-biographical-info').hide();
            $('#editable-biographical-info').show();
        });
    }

    var setUpCancelButton = function() {
        $('#cancel-biographical-info-edit').on('click', function () {
            location.reload();
        });
    };

    var removeOldErrors = function ()
    {
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
            url: '/student/editBiographicalInfo',
            type: 'POST',
            dataType: 'json',
            data: $('#edit-biographical-information').serialize(),
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
        $('#save-biographical-info-edit').on('click', ajaxEditPost);
    }
    return {
        init: setUp
}
})();