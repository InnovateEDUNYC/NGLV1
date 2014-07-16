Ngl.createNS('Ngl.enrollment.createStudent');

Ngl.enrollment.createStudent = (function () {

    var clearFieldsInElement = function(element) {
        element.find("select, input[type='text']").each(function() { $(this).val(''); });
    }

    var showHideOptionalAddresses = function() {
        var sameAddressAsStudentCheckboxes = ["#FirstParent_SameAddressAsStudent", "#SecondParent_SameAddressAsStudent"];
        sameAddressAsStudentCheckboxes.forEach(function (checkbox) {
            var addressPanel = $(checkbox).parent().parent().find(".parent-address");
            if ($(checkbox).is(':checked'))
                addressPanel.hide();
            else
                addressPanel.show();
        });

        $(".same-address-as-student").on("click", function () {
            var addressPanel = $(this.parentElement.parentElement);
            addressPanel.find(".parent-address").toggle();
            clearFieldsInElement(addressPanel);
        });
    };

    var showHideSecondParent = function() {
        var hasSecondParentCheckbox = $("#AddSecondParent");
        var secondParentPanel = $("#second-parent");

        if(hasSecondParentCheckbox.is(":checked"))
            secondParentPanel.show();
        else
            secondParentPanel.hide();

        hasSecondParentCheckbox.on("click", function () {
            secondParentPanel.toggle();
            clearFieldsInElement(secondParentPanel);
        });
    };

    var setup = function() {
        showHideOptionalAddresses();
        showHideSecondParent();
    };

    return {
        init: setup
    }
})();
