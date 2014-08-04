Ngl.createNS('Ngl.section.getSession');

Ngl.section.getSession = (function () {
    var getSession = function () {
        $("#Session").autocomplete({
            select: function(e, ui) {
                console.log("Selected");
                console.log("Term Type Id:");
                console.log(ui.item.value.termTypeId);
                console.log("School Year:");
                console.log(ui.item.value.schoolYear);
                $("#Term").val(ui.item.value.termTypeId);
                $("#SchoolYear").val(ui.item.value.schoolYear);
            },
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
                        response($.map(data, function (session) {
                            console.log(session);
                            return {
                                label: session.SessionName,
                                value: {termTypeId: session.TermTypeId, schoolYear: session.SchoolYear}
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
        init: getSession
    }
})();