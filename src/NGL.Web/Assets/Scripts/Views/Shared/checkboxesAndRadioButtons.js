Ngl.createNS('Ngl.shared.checkboxesAndRadioButtons.js');

Ngl.shared.checkboxesAndRadioButtons = (function () {
    var init = function () {
        checkRadioButton();
    }

    var checkRadioButton = function () {

        $('input:checked + label > span').addClass('fa fa-check small-checkbox');
        $('input').click(function () {
            var spans = $(this).closest('tr').find('span');
            spans.removeClass('fa fa-check');

            $(this).next('label').children('span').addClass('fa fa-check small-checkbox');
        });
    }

    return {
        init: init
    }
})();
