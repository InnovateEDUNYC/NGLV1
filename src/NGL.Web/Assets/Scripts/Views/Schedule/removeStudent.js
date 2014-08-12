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
                success: function (result) {
                    if (result.DeletedCompletely) {
                        self.closest("tr").remove();
                    } else {
                        updateEndDate(self, result.EndDate);
                    }
                }
            });
        });
    };

    var updateEndDate = function(row, endDate) {
        row.closest("tr").find(".scheduled-section-end-date").text(endDate);
    }

    return {
        init: setUpRemoveStudentLink
    }
})();