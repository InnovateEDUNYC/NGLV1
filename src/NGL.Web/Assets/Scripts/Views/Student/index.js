Ngl.createNS('Ngl.student.index');

Ngl.student.index = (function () {
    var setUpStudentProfile = function() {
        profilePhotoButtons();
    }
    var profilePhotoButtons = function () {
        $('.ghost-btn').change(function() {
             $('form').submit();
        });
    }

    return {
        init: setUpStudentProfile
    }
})();