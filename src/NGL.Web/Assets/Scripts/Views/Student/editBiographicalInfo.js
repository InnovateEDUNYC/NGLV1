Ngl.createNS('Ngl.student.editBiographicalInfo');

Ngl.student.editBiographicalInfo = (function () {

    var setup = function () {
        Ngl.shared.editProfile.setup('#readonly-biographical-info', '#editable-biographical-info', '#edit-biographical-info-button', '#save-biographical-info-edit', '#cancel-biographical-info-edit', '/student/EditBiographicalInfo', '#edit-biographical-information');
    }

    return {
        init: setup
    }
})();