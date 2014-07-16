Ngl.createNS('Ngl.enrollment.createStudent');

Ngl.enrollment.createStudent = (function () {
    var hideParentAddress = function() {

        var sameAddressAsStudentCheckboxes = ["#FirstParent_SameAddressAsStudent", "#SecondParent_SameAddressAsStudent"];
        sameAddressAsStudentCheckboxes.forEach(function(checkbox) {
            var addressPanel = $(checkbox).parent().parent().find(".parent-address");
            if ($(checkbox).is(':checked'))
                addressPanel.hide();
            else
                addressPanel.show();
        });

        $(".same-address-as-student").on("click", function () {
            var addressPanel = $(this.parentElement.parentElement);
            addressPanel.find(".parent-address").toggle();
            addressPanel.find("select, input").each(function() { $(this).val(''); });
        });
        };

        return {
            init: hideParentAddress
        }
})();
