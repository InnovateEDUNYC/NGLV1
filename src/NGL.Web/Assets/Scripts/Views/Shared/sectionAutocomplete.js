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
        var noResultsLabel = "No results";
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

                    error: function () {
                        // errorPlaceholder's value does not matter
                        var errorPlaceholder = ['1'];
                        response($.map(errorPlaceholder, function () {
                            return {
                                label: noResultsLabel,
                            };
                        }));
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

                if (ui.item.label === noResultsLabel) {
                    event.preventDefault();
                } else {
                    $("#SectionId").trigger('populated');
                }
            },
            focus: function (event, ui) {
                if (ui.item.label === noResultsLabel) {
                    event.preventDefault();
                }
            },
            minLength: 2,
        });
    }

    $("#SessionId").on('change cleared',function () {
        $('#Section').val("");
        $('#SectionId').val("");
    });

    return {
        init: setupSectionAutocomplete
    }
})();
