Ngl.createNS('Ngl.shared.sectionAutoComplete');

Ngl.shared.sectionAutocomplete = (function () {
    var setupSectionAutocomplete = function () {
        sectionAutocomplete();
        clearHiddenFieldsOnError();
    }

    var clearHiddenFieldsOnError = function () {
        $('#Section').on('change', function () {
            $('#SectionId').val("");
        });
    }

    var sectionAutocomplete = function () {
        $('#Section').autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/schedule/GetSections",
                    type: "POST",
                    dataType: "json",
                    data: {
                        featureClass: "P",
                        style: "full",
                        maxRows: 12,
                        searchString: request.term,
                        sessionId: $('#SessionId').val()
                    },
                    success: function (data) {
                        response($.map(data, function (section) {
                            return {
                                label: section.LabelName,
                                value: section.ValueName,
                                sectionId: section.Id
                            };
                        }));
                    }
                });
            },
            select: function (event, ui) {
                $('#SectionId').val(ui.item.sectionId);
            },
            minLength: 2,
        });
    }



    return {
        init: setupSectionAutocomplete
    }
})();