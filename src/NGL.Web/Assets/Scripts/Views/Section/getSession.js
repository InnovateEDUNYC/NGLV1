Ngl.createNS('Ngl.section.getSession');

Ngl.section.getSession = (function () {
    var getSession = function () {
        $("#Session").autocomplete({
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
                        console.log(data);
                        response($.map(data, function (session) {
                            console.log(session.SessionName);
                            return {
                                label: session.SessionName,
                                value: session.SessionName
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