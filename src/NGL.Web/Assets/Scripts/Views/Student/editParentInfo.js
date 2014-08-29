Ngl.createNS('Ngl.student.editParentInfo');

Ngl.student.editParentInfo = (function () {
    var setUp = function() {
        Ngl.shared.editProfile.setup('#readonly-parent-info', '#collapseParentInfo', '#editable-parent-info > h4', '#editable-parent-info > div', '#edit-parent-info-button', '#save-parent-info-edit', '#cancel-parent-info-edit', '/student/editParentInfo', "#edit-parent-info-form");
    }

    return {
        init: setUp
    }
})();

