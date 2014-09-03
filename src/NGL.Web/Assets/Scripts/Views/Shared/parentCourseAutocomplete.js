Ngl.createNS('Ngl.shared.parentCourseAutoComplete');

Ngl.shared.parentCourseAutocomplete = (function () {
    var setupParentCourseAutocomplete = function () {
        parentcourseAutocomplete();
        clearHiddenFieldsOnPressingAnyKeyButEnterOrTab();
        setupParentCourseIdListener();
    }

    var clearHiddenFieldsOnPressingAnyKeyButEnterOrTab = function () {
        $('#ParentCourse').on('keydown', function (e) {
            var enter = 13;
            var tab = 9;

            if (e.keyCode != enter && e.keyCode != tab) {
                $('#ParentCourseId').val("");
            }
        });
    }

    var parentcourseAutocomplete = function () {
        var noResultsLabel = "No results";
        $('#ParentCourse').autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/parentCourse/GetParentCourses",
                    type: "POST",
                    dataType: "json",
                    data: {
                        featureClass: "P",
                        style: "full",
                        maxRows: 12,
                        searchString: request.term
                    },

                    error: function () {
                        // errorPlaceholder's value does not matter
                        var errorPlaceholder = ['1'];
                        response($.map(errorPlaceholder, function () {
                            return {
                                label: noResultsLabel,
                            };
                        }));
                    },

                    success: function (data) {
                        response($.map(data, function (parentCourse) {
                            return {
                                label: parentCourse.LabelName,
                                value: parentCourse.ValueName,
                                parentCourseId: parentCourse.Id
                            };
                        }));
                    }
                });
            },
            select: function (event, ui) {
                $('#ParentCourseId').val(ui.item.parentCourseId);

                if (ui.item.label === noResultsLabel) {
                    event.preventDefault();
                } else {
                    $("#ParentCourseId").trigger('populated');
                }
            },
            focus: function (event, ui) {
                if (ui.item.label === noResultsLabel) {
                    event.preventDefault();
                }
            },
            minLength: 2,
        });
    }
    var setupParentCourseIdListener = function() {
        $("#ParentCourseId").on('change cleared', function() {
            $('#ParentCourse').val("");
            $('#ParentCourseId').val("");
        });
    }

    return {
        init: setupParentCourseAutocomplete
    }
})();
