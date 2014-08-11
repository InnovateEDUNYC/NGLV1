Ngl.createNS('Ngl.schedule.removeStudent');

Ngl.schedule.removeStudent = (function () {
    var setUpRemoveStudentLink = function () {
        console.log("setup removing..");
        $('.remove-student').click(function () {
            var studentSectionId = $(this).data('student-section-id');

            var self = $(this);
            $.ajax({
                url: '/schedule/removeStudent',
                type: 'POST',
                dataType: 'json',
                data: {
                    studentSectionId: studentSectionId
                },
                success: function () {
                    self.closest("tr").remove();
                }
            });
        });
    };

    return {
        init: setUpRemoveStudentLink
    }
})();