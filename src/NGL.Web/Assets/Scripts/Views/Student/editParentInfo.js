Ngl.createNS('Ngl.student.editParentInfo');

Ngl.student.editParentInfo = (function () {
    var setUp = function() {
        Ngl.shared.editProfile.setup('#readonly-parent-info', '#editable-parent-info', '#edit-parent-info-button', '#save-parent-info-edit', '#cancel-parent-info-edit', '/student/editParentInfo', "#edit-parent-info");
    }

    return {
        init: setUp
    }
})();

