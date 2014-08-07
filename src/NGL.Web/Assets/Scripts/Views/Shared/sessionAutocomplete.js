Ngl.createNS('Ngl.shared.sessionAutocomplete');

Ngl.shared.sessionAutocomplete = (function () {
    var init = function() {
        clearHiddenFieldsOnPressingAnyKeyButEnter();
        sessionAutocomplete();
    }

    var clearHiddenFieldsOnPressingAnyKeyButEnter = function ()
    {
        $('#Session').on('keydown', function(e) {
            var enter = 13;
            var tab = 9;

            if(e.keyCode != enter && e.keyCode != tab) {
            $('#SessionId').val("");
        }
        });

    }

    var sessionAutocomplete = function () {
        var noResultsLabel = "No results";
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
                select: function (event, ui) {
                    if (ui.item.label === noResultsLabel) {
                        event.preventDefault();
                    }
                    var selectedSession = ui.item;
                    $("#SessionId").val(selectedSession.sessionId);
                },
                focus: function (event, ui) {
                    if (ui.item.label === noResultsLabel) {
                        event.preventDefault();
                    }
                },
                minLength: 2,
            });
        }

    return {
        init: init
    }
})();
