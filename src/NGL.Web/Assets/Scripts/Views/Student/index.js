Ngl.createNS('Ngl.student.index');

Ngl.student.index = (function () {
    var profilePhotoButtons = function () {
        $('.ghost-button').change(function() {
             $('form').submit();
        });
    }

    return {
        init: profilePhotoButtons
    }
})();