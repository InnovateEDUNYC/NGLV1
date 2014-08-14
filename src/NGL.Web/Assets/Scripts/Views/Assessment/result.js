Ngl.createNS('Ngl.assessment.result');

Ngl.assessment.result = (function () {
    var init = function () {
        var getResultsUrlTemplate = "/Assessment/Result?studentUsi={studentUsi}&sessionId={sessionId}";

        $("#SessionId").change(function () {
            var sessionId = $(this).val();
            var url = updateGetResultsUrl(sessionId);
            window.location = url;
        });

        var updateGetResultsUrl = function (sessionId) {
            var studentUsi = $('#StudentUsi').val();
            var url = getResultsUrlTemplate
                .replace("{sessionId}", sessionId)
                .replace("{studentUsi}", studentUsi);

            return url;

        }
    }

    return {
        init: init
        }
})(); 