Ngl.createNS('Ngl.student.editHomeAddress');

Ngl.student.editHomeAddress = (function () {
    var init = function () {

    Ngl.shared.editProfile.setup('#readonly-home-address', '#collapseHomeAddress', '#editable-home-address > h4', '#editable-home-address > div', '#edit-home-address-button', '#submit-home-address', '#cancel-home-address-edit', '/student/editHomeAddress', "#edit-home-address-form");

    }

    return {
        init: init
    }
})();
