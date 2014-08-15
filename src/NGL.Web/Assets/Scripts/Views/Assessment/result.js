﻿Ngl.createNS('Ngl.assessment.result');

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

//        $('#month').on('click', function() {
//            $(this).removeClass('unselected');
//            $(this).addClass('selected');
//            $('#week').removeClass('selected');
//            $('#week').addClass('unselected');
//        });
//
//        $('#week').on('click', function () {
//            $(this).removeClass('unselected');
//            $(this).addClass('selected');
//            $('#month').removeClass('selected');
//            $('#month').addClass('unselected');
//        });

            };

    return {
        init: init
        }
})(); 