Ngl.createNS('Ngl.shared.enableEditMode');

Ngl.shared.enableEditMode = (function () {

    var enableEditMode = function (pencil, collapseDiv, readonlyDiv, editableHeader, editableDiv) {

        $(pencil).on('click', function () {

            if (!$(collapseDiv).is(':visible')) {
                $(readonlyDiv).hide();
                $(editableHeader).show();
                $(editableDiv).slideDown({
                    duration: "950",
                    easing: "linear"
                });
            } else {
                $(readonlyDiv).hide();
                $(editableHeader).show();
                $(editableDiv).show();
            }
        });
    }

    return {
        init: enableEditMode
    }
})();
