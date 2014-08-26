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
    };

    var setUpCancelButton = function() {
        $('#cancel-biographical-info-edit').on('click', function () {
            $('#readonly-biographical-info').show();
            $('#editable-biographical-info').hide();
        });
    };

    var ajaxEditPost = function () {
        $.ajax({
            url: '/student/editBiographicalInfo',
            type: 'POST',
            dataType: 'json',
            data: $('#edit-biographical-information').serialize(),
            success: function (returnValue) {
                var errors = returnValue.errors;
                if (!errors == false) {
                    errors.forEach(function (error) {
                        $('.field-validation-error').append("<p>" + error.ErrorMessage + "</p>");
                    });
                } else {
                    location.reload(true);
                }
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