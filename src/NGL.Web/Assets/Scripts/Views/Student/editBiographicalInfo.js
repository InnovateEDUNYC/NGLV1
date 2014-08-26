Ngl.createNS('Ngl.student.editBiographicalInfo');

Ngl.student.editBiographicalInfo = (function () {

    var setUp = function() {
        $('#edit-biographical-info').on('click', function () {
            $('#readonly-biographical-info').hide();
            $('#editable-biographical-info').show();
        });
        $('#cancel-biographical-info-edit').on('click', function() {
            $('#readonly-biographical-info').show();
            $('#editable-biographical-info').hide();
        });

    }

    return {
        init: setUp
}
})();