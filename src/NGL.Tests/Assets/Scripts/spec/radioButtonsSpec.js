describe("radioButtons", function() {
    describe("clicked custom-checkbox", function () {
        it("assigns the checked class to the current checkbox", function () {
            document.body.innerHTML += '<div class="custom-checkbox"></div>';

            Ngl.shared.radioButtons.init();
            $('.custom-checkbox').first().click();

            expect($('.custom-checkbox').hasClass('checked')).toBeTruthy();
        });

        it("removes the checked class from all neighbouring checkboxes", function () {
            document.body.innerHTML += '<div class="custom-checkbox"></div>';
            document.body.innerHTML += '<div class="custom-checkbox"></div>';

            Ngl.shared.radioButtons.init();
            $('.custom-checkbox').first().click();

            var otherCheckboxClasses = $('.custom-checkbox')[1].getAttribute('class');
            expect(otherCheckboxClasses.contains("checked")).toBeFalsy();
        });

        it("clicks its sibling input", function() {
            document.body.innerHTML += '<div class="custom-checkbox true"></div>';
            document.body.innerHTML += '<input value="True" type="radio">';
            document.body.innerHTML += '<div class="custom-checkbox false"></div>';
            document.body.innerHTML += '<input value="False" type="radio">';
            var clicked = false;
            $("input[value=True]").on("click", function () {
                clicked = true;
                console.log("hi");
            });

            Ngl.shared.radioButtons.init();
            $('.custom-checkbox').first().click();

            expect(clicked).toBeTruthy();
        });
    });
});