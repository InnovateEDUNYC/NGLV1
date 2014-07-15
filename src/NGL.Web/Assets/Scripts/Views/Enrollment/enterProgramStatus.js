Ngl.createNS('Ngl.enrollment.enterProgramStatus');

Ngl.enrollment.enterProgramStatus = (function () {
    var allowFileUploadConditionally = function() {
        var $accomodationFile = $('#TestingAccommodationFile');
        $accomodationFile.attr('disabled', 'disabled');

        $('input[name=TestingAccommodation]').click(function () {
            var self = $(this);
            if (self.val() === 'True')
                $accomodationFile.removeAttr('disabled');
            else {
                 $accomodationFile.attr('disabled', 'disabled');
                 $accomodationFile.val('');
            }
        });
    };

    return {
        init: allowFileUploadConditionally
        }
})(); 