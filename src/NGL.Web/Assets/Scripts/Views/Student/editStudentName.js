Ngl.createNS('Ngl.student.editStudentName');

Ngl.student.editStudentName = (function () {

    var setUp = function () {
        setUpEditButton();
        setUpCancelButton();
        setUpSaveButton();


    }

    var setUpEditButton = function () {
        $('#edit-student-name-button').on('click', function () {
            $('#readonly-student-name').hide();
            $('#editable-student-name').show();
        });
    }

    var setUpCancelButton = function () {
        $('#cancel-student-name-edit').on('click', function () {
            location.reload();
        });
    };

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
            url: '/student/editStudentName',
            type: 'POST',
            dataType: 'json',
            data: $('#edit-student-name').serialize(),
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
        $('#save-student-name-edit').on('click', ajaxEditPost);
    }
    return {
        init: setUp
    }
})();