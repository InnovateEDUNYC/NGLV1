Ngl.createNS('Ngl.shared.accordianArrows');

Ngl.shared.accordianArrows = (function () {

    var accordianArrows = function () {
        $(".panel[data-toggle='collapse']").on("click", function () {
            var arrowElement = $(this).find("i");
            if (arrowElement.hasClass("fa-caret-down")) {
                arrowElement.removeClass("fa-caret-down").addClass("fa-caret-up");
            } else {
                arrowElement.removeClass("fa-caret-up").addClass("fa-caret-down");
            }
        });
    }
    return {
        init: accordianArrows
    }
})();