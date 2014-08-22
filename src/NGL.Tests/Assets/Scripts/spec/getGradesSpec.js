describe("report", function () {
    describe("getGrades.init", function () {
        it("updates window location when #SectionId is populated", function () {
            var sectionIdField = document.createElement("input");
            sectionIdField.id = "SectionId";
            sectionIdField.hidden = true;
            document.body.appendChild(sectionIdField);
            var window = {};

            $('#SectionId').val(1);
            Ngl.report.getGrades.init(window);
            $("#SectionId").trigger("populated");

            expect(window.location).toBe("/ParentCourse/Grades/1");
        });
    })
});