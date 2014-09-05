Ngl.createNS('Ngl.student.editParentInfo');

Ngl.student.editParentInfo = (function () {
    var setUp = function() {
        Ngl.shared.editProfile.setup('#readonly-parent-1-info', '#collapseParent-1-Info', '#editable-parent-1-info > h4', '#editable-parent-1-info > div', '#edit-parent-1-info-button', '#save-parent-1-info-edit', '#cancel-parent-1-info-edit', '/student/editParentInfo', "#edit-parent-1-info-form");
        Ngl.shared.editProfile.setup('#readonly-parent-2-info', '#collapseParent-2-Info', '#editable-parent-2-info > h4', '#editable-parent-2-info > div', '#edit-parent-2-info-button', '#save-parent-2-info-edit', '#cancel-parent-2-info-edit', '/student/editParentInfo', "#edit-parent-2-info-form");
        setUpSameAddressCheckbox();
    }

    var clearFieldsInElement = function (element) {
        element.find("select, input[type='text']").each(function () { $(this).val(''); });
    }

    var setUpSameAddressCheckbox = function () {
        if ($('#SameAddressAsStudent').is(':checked')) {
            disableFieldsInElement($('.edit-parent-address-section'));
        } else {
            enableFieldsInElement($('.edit-parent-address-section'));
        }

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

