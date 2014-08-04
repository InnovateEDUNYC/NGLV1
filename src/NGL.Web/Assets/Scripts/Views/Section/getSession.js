Ngl.createNS('Ngl.section.getSession');

Ngl.section.getSession = (function () {

    var getSchedule = function () {
        $('#Session').autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/section/GetSessions",
                    type: "POST",
                    dataType: "json",
                    data: {
                        featureClass: "P",
                        style: "full",
                        maxRows: 12,
                        searchString: request.term
                    },
                    success: function (data) {
                        response($.map(data, function (section) {
                            return {
                                label: section.SessionName,
                                value: section.SessionName,
                                term: section.Term,
                                school: section.SchoolYear,
                            };
                        }));
                    }
                });
            },
            select: function (event, ui) {
                var selectedSession = ui.item;
                $("#SchoolYear").val(selectedSession.school);
                $("#Term").val(selectedSession.term);
            },
            minLength: 2,
        });
    }

    return {
        init: getSchedule
    }
})();