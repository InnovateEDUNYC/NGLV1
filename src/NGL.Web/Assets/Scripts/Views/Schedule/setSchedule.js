Ngl.createNS('Ngl.schedule.setSchedule');

Ngl.schedule.setSchedule = (function () {
    var setupView = function() {
        setSchedule();
        configureSaveButton();
        configureSessionDropdown();
    }

    var setSchedule = function () {
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
                            sessionId: $('#Session :selected').val()
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
                        $('.current-section-list').append("<li class='current-section-list-item'>" +
                            name + " " + beginDate + " - " + endDate + "<div class='hidden section-id'>" + sectionListItem.SectionId + "</div></li>");
                    }
                }
            });
            $('.field-validation-error').empty();
            clearSection();
        });
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