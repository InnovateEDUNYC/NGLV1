Ngl.createNS('Ngl.schedule.getSchedule');

Ngl.schedule.getSchedule = (function () {
    var setupView = function() {
        getSchedule();
        configureSubmitButton();
    }

    var getSchedule = function () {
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
                            searchString: request.term
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
                    $('#sectionId').val(ui.item.SectionId);
                },
                minLength: 2,
            });
    }

    var configureSubmitButton = function() {
        $('button#schedule-student-button').click(function() {
            $.ajax({
                url: '/schedule/scheduleStudent',
                type: 'POST',
                dataType: 'json',
                data: $('form#schedule-student-form').serialize(),
                success: alert()
            });
        });
    };

    return {
        init: setupView
    }
})();