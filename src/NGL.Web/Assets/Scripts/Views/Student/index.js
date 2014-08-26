Ngl.createNS('Ngl.student.index');

Ngl.student.index = (function () {
    var setUpStudentProfile = function() {
        profilePhotoButtons();
        enableAttendanceEditMode();
    }

    var profilePhotoButtons = function () {
        $('.ghost-btn').change(function() {
             $('form').submit();
        });
    }

    var enableAttendanceEditMode = function() {
        $('#edit-attendance').on('click', function() {
            $('.attendance-flags span:last-child')
                .after('<span class="fa fa-times-circle remove-flag"></span>');
            $('#editFlags').show();

            enterEditFlagsMode();
        });
    }

    var enterEditFlagsMode = function () {
        $('#edit-attendance').off('click');
        setupRemoveFlagsButton();
    }

    var setupRemoveFlagsButton = function() {
        $('.remove-flag').on('click', function () {
            var flagToRemove = $(this).prev();
            flagToRemove.remove();

            var flagCount = $('#flag-count').val();
            $('#flag-count').val(--flagCount);

            if (flagCount == 0) {
                $(this).remove();
            }
        });
    }

    return {
        init: setUpStudentProfile
    }
})();
