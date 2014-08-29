Ngl.createNS('Ngl.student.all');

Ngl.student.all = (function () {
    var init = function() {
        setupClearFlagsButton();
    }

    var setupClearFlagsButton = function () {
        $('#clear-all-flags').on('click', function() {
            $('#clear-all-flags-confirm').show();
        });

        $('#clearAllFlagsCancel').on('click', function() {
            $('#clear-all-flags-confirm').hide();
        });
    };

    return {
        init: init
    }
})();