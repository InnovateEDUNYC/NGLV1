Ngl.createNS('Ngl.assessment.result');

Ngl.assessment.result = (function () {
    var init = function () {
        var weekUrl = "/Assessment/Week";
        var monthUrl = "/Assessment/Month";
        var getResultsUrlTemplate = "?studentUsi={studentUsi}&sessionId={sessionId}";

        $("#SessionId").change(function () {
            var sessionId = $(this).val();
            var url = updateGetResultsUrl(sessionId);
            window.location = url;
        });

        $('.popover-dismiss').popover({
            trigger: 'focus',
            content: function () {
                var assessmentInfo = $(this).data('contentwrapper');
                return $(assessmentInfo).html();
            }
        });

        var updateGetResultsUrl = function(sessionId) {
            var studentUsi = $('#StudentUsi').val();
            var url = weekUrl;

            if ($('#month').hasClass('selected')) {
                url = monthUrl;
            }

            url = url + getResultsUrlTemplate
                .replace("{sessionId}", sessionId)
                .replace("{studentUsi}", studentUsi);

            return url;
        }
    };

    return {
        init: init
        }
})(); 