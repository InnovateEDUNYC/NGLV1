Ngl.createNS('Ngl.shared.editProfile');

Ngl.shared.editProfile = (function () {

    var setup = function (readOnlySectionSelector, editableSectionSelector, editButtonSelector, saveButtonSelector, cancelButtonSelector, route, formSelector) {
        setupEditButton(editButtonSelector, readOnlySectionSelector, editableSectionSelector);
        setupCancelButton(cancelButtonSelector);
        setupSaveButton(saveButtonSelector, route, formSelector);
    }

    var setupEditButton = function (editButtonSelector, readOnlySectionSelector, editableSectionSelector) {
        $(editButtonSelector).on('click', function () {
            $(readOnlySectionSelector).hide();
            $(editableSectionSelector).show();
        });
    };

    var setupCancelButton = function (cancelButtonSelector) {
        $(cancelButtonSelector).on('click', function () {
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

    var ajaxEditPost = function (route, formSelector) {
        console.log("clicked");
        console.log(route);
        console.log(formSelector);
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

    var setupSaveButton = function (saveButtonSelector, route, formSelector) {
        $(saveButtonSelector).on('click', function () {
            ajaxEditPost(route, formSelector);
        });
    }

    return {
        setup: setup
    };
})();