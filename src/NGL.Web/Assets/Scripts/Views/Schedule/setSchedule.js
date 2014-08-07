Ngl.createNS('Ngl.schedule.setSchedule');

Ngl.schedule.setSchedule = (function () {
    var setupView = function() {
        configureSaveButton();
        setupUpdateDates();
        setHiddenSessionId();
    }

    var configureSaveButton = function() {
        $('button#schedule-student-button').click(function () {
            $.ajax({
                url: '/schedule/scheduleStudent',
                type: 'POST',
                dataType: 'json',
                data: $('form#schedule-student-form').serialize(),
                success: function (sectionListItem) {
                    console.log(sectionListItem);
                    var errors = sectionListItem.errors;
                    if (!errors == false) {
                        errors.forEach(function(error) {
                            $('.field-validation-error').append("<p>" + error.ErrorMessage + "</p>");
                        });
                    } else {
                        var name = sectionListItem.Name;
                        var beginDate = sectionListItem.BeginDate;
                        var endDate = sectionListItem.EndDate;
                        $('.current-section-list').append(
                            '<tr class="current-section-list-item new-item">' +
                                '<td class="scheduled-section-name">' + name + '</td>' +
                                '<td class="scheduled-section-dates">' +
                                    '<span class="scheduled-section-begin-date">' + beginDate + '</span> - ' +
                                    '<span class="scheduled-section-end-date">' + endDate + '</span>' +
                                '</td>' +
                                '<td class="hidden section-id">' + sectionListItem.SectionId + '</td>' +
                            '</tr>' +
                           '<tr class="spacer"></tr>');
                    }
                }
            });
            $('.field-validation-error').empty();
            clearSection();
        });
    };

    var setupUpdateDates = function () {
        $('#session-dropdown').on('change', function () {
            clearSection();

            var selectedSession = $(this).find(':selected')[0];

            setHiddenSessionId();

            var beginDate = selectedSession.getAttribute('beginDate');
            var endDate = selectedSession.getAttribute('endDate');
            updateDates(beginDate, endDate);

        });
    }

    var setHiddenSessionId = function () {
        var selectedSession = $('#session-dropdown').find(':selected')[0];
        var sessionId = $('#SessionId');
        sessionId.val(selectedSession.getAttribute('value'));
    }

    var updateDates = function(beginDate, endDate) {
        $('#BeginDate').val(beginDate);
        $('#BeginDate').datepicker('update');
        $('#EndDate').val(endDate);
        $('#EndDate').datepicker('update');
    };

    var clearSection = function () {
        $('#Section').val("");
        $('#SectionId').val("");
    };

    return {
        init: setupView
    }
})();