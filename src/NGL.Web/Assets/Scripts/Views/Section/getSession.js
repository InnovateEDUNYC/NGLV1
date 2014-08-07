Ngl.createNS('Ngl.section.getSession');

Ngl.section.getSession = (function () {
    var init = function() {
        clearHiddenFieldsOnPressingAnyKeyButEnter();
        getSession();
    }

    var clearHiddenFieldsOnPressingAnyKeyButEnter = function ()
    {
        $('#Session').on('keypress', function(e) {
        // 13 is the keycode for enter
         if(e.keyCode != 13) {
            $('#SessionId').val("");
        }
        });

    }

        var getSession = function() {
            $('#Session').autocomplete({
                source: function(request, response) {
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
                        success: function(data) {
                            response($.map(data, function (session) {
                                return {
                                    label: session.SessionName,
                                    value: session.SessionName,
                                    sessionId: session.SessionId
                                };
                            }));
                        }
                    });
                },
                select: function(event, ui) {
                    var selectedSession = ui.item;
                    $("#SessionId").val(selectedSession.sessionId);
                },
                minLength: 2,
            });
        }

    return {
        init: init
    }
})();
