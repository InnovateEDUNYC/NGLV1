Ngl.createNS('Ngl.schedule.getSchedule');

Ngl.schedule.getSchedule = (function () {
    var getSchedule = function () {
            $("#Section").autocomplete({
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
                                    label: section.UniqueSectionCode,
                                    value: section.UniqueSectionCode
                                };
                            }));

                        }
                    });
                },
                minLength: 2,
                messages: {
                    noResults: "",
                    results: ""
                }
            });
    }

    return {
        init: getSchedule
    }
})();