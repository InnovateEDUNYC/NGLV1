Ngl.createNS('Ngl.shared.sectionAutoComplete');

Ngl.shared.sectionAutocomplete = (function () {
    var setupSectionAutocomplete = function () {
        sectionAutocomplete();
        clearHiddenFieldsOnPressingAnyKeyButEnterOrTab();
    }

    var clearHiddenFieldsOnPressingAnyKeyButEnterOrTab = function () {
        $('#Section').on('keydown', function (e) {
            var enter = 13;
            var tab = 9;

            if (e.keyCode != enter && e.keyCode != tab) {
                $('#SectionId').val("");
            }
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
