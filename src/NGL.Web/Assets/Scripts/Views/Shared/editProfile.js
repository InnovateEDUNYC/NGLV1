Ngl.createNS('Ngl.shared.editProfile');

Ngl.shared.editProfile = (function () {

    var setup = function (readOnlyDiv, collapseDiv, editableHeader, editableDiv, pencil, saveButtonSelector, cancelButtonSelector, route, formSelector) {
        setupEdit(pencil, collapseDiv, readOnlyDiv, editableHeader, editableDiv);
        setupCancelButton(cancelButtonSelector);
        setupSaveButton(saveButtonSelector, route, formSelector);
    }

    var setupEdit = function (pencil, collapseDiv, readonlyDiv, editableHeader, editableDiv) {

        $(pencil).on('click', function () {

            if (!$(collapseDiv).is(':visible')) {
                $(readonlyDiv).hide();
                $(editableHeader).show();
                $(editableDiv).slideDown({
                    duration: "950",
                    easing: "linear"
                });
            } else {
                $(readonlyDiv).hide();
                $(editableHeader).show();
                $(editableDiv).show();
            }
        });
    }

    var setupCancelButton = function (cancelButtonSelector) {
        $(cancelButtonSelector).on('click', function () {
            location.reload();
        });
    };

    var setupSaveButton = function (saveButtonSelector, route, formSelector) {
        $(saveButtonSelector).on('click', function () {
            console.log("I GOT HERE");
            ajaxEditPost(route, formSelector);
        });
    }

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

    var ajaxEditPost = function (route, formSelector) {
        $.ajax({
            url: route,
            type: 'POST',
            dataType: 'json',
            data: $(formSelector).serialize(),
            success: function (returnValue) {
                var errors = returnValue.nglErrors;
                if (!errors == false) {
                    displayErrors(errors);
                    
                } else {
                    location.reload(true);
                }
            }
        });
    }

    return {
        setup: setup
    };
})();