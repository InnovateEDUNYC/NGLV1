Ngl.createNS('Ngl.assessment.result');

Ngl.assessment.result = (function () {
    var init = function () {
        var getResultsUrlTemplate = "/Assessment/Result?studentUsi={studentUsi}&sessionId={sessionId}";

        $("#SessionId").change(function () {
            var sessionId = $(this).val();
            updateGetResultsUrl(sessionId);
            $("#GetResultsButton").removeAttr("disabled");
        });

        $("#SessionId").on("cleared", function () {
            $("#GetResultsButton").attr("disabled", "disabled");
        });

        var updateGetResultsUrl = function (sessionId) {
            var studentUsi = $('#StudentUsi').val();
            var url = getResultsUrlTemplate
                .replace("{sessionId}", sessionId)
                .replace("{studentUsi}", studentUsi);

            $("#GetResultsButton").attr("href", url);

        }
    }

    return {
        init: init
        }
})(); 