describe("parentcourseAutocomplete", function () {
    describe("When user enters characters", function() {
        it("POSTs ParentCourses from the server", function () {
            spyOn($, 'ajax').and.returnValue({ label: "A Session Name" });

            var parentCourseField = document.createElement("input");
            parentCourseField.id = "ParentCourse";
            parentCourseField.hidden = true;
            document.body.appendChild(parentCourseField);

            Ngl.shared.parentcourseAutocomplete.init();
            $('#ParentCourse').val("Fa");
            $('#Session').autocomplete();

            expect().toBe({ label: "A Session Name" });
        });
    });
});