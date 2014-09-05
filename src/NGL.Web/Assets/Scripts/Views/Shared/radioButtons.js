Ngl.createNS('Ngl.shared.radioButtons');

Ngl.shared.radioButtons = (function() {
    var init = function() {
        initRadioButtons();
    }

    var initRadioButtons = function () {
        $('.custom-checkbox').click(function () {
            $(this).parent().children('label').removeClass('checked');
            var inputValue;
            if ($(this).hasClass('true')) {
                inputValue = "True";
            } else {
                inputValue = "False";
            }
            $(this).siblings('input[value="' + inputValue + '"]').click();
            $(this).addClass('checked');
        });
    }

    return {
        init: init
    }
})();