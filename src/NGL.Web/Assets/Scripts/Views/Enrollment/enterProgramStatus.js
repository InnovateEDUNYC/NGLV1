Ngl.createNS('Ngl.enrollment.enterProgramStatus');

Ngl.enrollment.enterProgramStatus = (function () {
    var setConditionalFileUploads = function()
    {
        allowFileUploadConditionally("TestingAccommodation", "TestingAccommodationFile");
    }

    var allowFileUploadConditionally = function (radioInputId, fileInputId) {
        var $accomodationFile = $('#' + fileInputId);

        $('input[name='+radioInputId+']').click(function () {
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
        init: setConditionalFileUploads
        }
})(); 