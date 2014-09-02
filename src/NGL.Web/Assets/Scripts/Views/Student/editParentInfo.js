Ngl.createNS('Ngl.student.editParentInfo');

Ngl.student.editParentInfo = (function () {
    var setUp = function() {
        Ngl.shared.editProfile.setup('#readonly-parent-info', '#collapseParentInfo', '#editable-parent-info > h4', '#editable-parent-info > div', '#edit-parent-info-button', '#save-parent-info-edit', '#cancel-parent-info-edit', '/student/editParentInfo', "#edit-parent-info-form");
        setUpSameAddressCheckbox();
    }

    var clearFieldsInElement = function (element) {
        element.find("select, input[type='text']").each(function () { $(this).val(''); });
    }

    var setUpSameAddressCheckbox = function() {
        $('#SameAddressAsStudent').on('click', function() {
            clearFieldsInElement($('.edit-parent-address-section'));

            if ($(this).is(':checked')) {
                disableFieldsInElement($('.edit-parent-address-section'));
            } else {
                enableFieldsInElement($('.edit-parent-address-section'));
            }
        });
    };

    var disableFieldsInElement = function(element) {
        element.find("select, input[type='text']").each(function() {
            $(this).attr('disabled', 'disabled');
        });
    }

    var enableFieldsInElement = function(element) {
        element.find("select, input[type='text']").each(function () {
            $(this).removeAttr('disabled');
        });
    }


    return {
        init: setUp
    }
})();

