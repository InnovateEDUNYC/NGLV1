Ngl.createNS('Ngl.schedule.setSchedule');

Ngl.schedule.setSchedule = (function () {
    var setupView = function() {
        setScheduleAutocomplete();
        configureSaveButton();
        configureSessionDropdown();
        setupUpdateDates();
    }

    var setScheduleAutocomplete = function () {
            $('#Section').autocomplete({
                source: function(request, response) {
                    $.ajax({
                        url: "/schedule/GetSections",
                        type: "POST",
                        dataType: "json",
                        data: {
                            featureClass: "P",
                            style: "full",
                            maxRows: 12,
                            searchString: request.term,
                            sessionId: $('#session-dropdown :selected').val()
                        },
                        success: function (data) {
                            response($.map(data, function(section) {
                                return {
                                    label: section.LabelName,
                                    value: section.ValueName,
                                    sectionId: section.Id
                                };
                            }));
                        }
                    });
                },
                select: function(event, ui) {
                    $('#SectionId').val(ui.item.sectionId);
                },
                minLength: 2,
            });
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
                        $('.current-section-list').append('<div class="current-section-list-item">' +
                           '<span class="scheduled-section-name">' + name + '</span>' +
                           '<span class="scheduled-section-begin-date">' + beginDate + '</span> - ' +
                           '<span class="scheduled-section-end-date">' + endDate + '</span>' +
                           '<span class="hidden section-id">' + sectionListItem.SectionId + "</span></div>");
                    }
                }
            });
            $('.field-validation-error').empty();
            clearSection();
        });
    };

    var setupUpdateDates = function () {
        $('#session-dropdown').on('change', function () {
            var selectedSession = $('#session-dropdown :selected')[0];

            var beginDate = selectedSession.getAttribute('beginDate');
            var endDate = selectedSession.getAttribute('endDate');
            updateDates(beginDate, endDate);

        });
    }

    var updateDates = function(beginDate, endDate) {
        $('#BeginDate').val(beginDate);
        $('#BeginDate').datepicker('update');
        $('#EndDate').val(endDate);
        $('#EndDate').datepicker('update');
    };

    var configureSessionDropdown = function() {
        $('#Session').on('change', function() {
            clearSection();

        });
    };

    var clearSection = function () {
        $('#Section').val("");
        $('#SectionId').val("");
    };

    return {
        init: setupView
    }
})();