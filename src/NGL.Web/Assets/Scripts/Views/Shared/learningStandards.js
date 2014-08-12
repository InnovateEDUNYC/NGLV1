Ngl.createNS('Ngl.shared.learningStandards');

Ngl.shared.learningStandards = (function () {
    var init = function () {
        f();
    }
    var f = function() {
        $('#GradeLevel').on('change', function () {
            resetList();
            var gradeLevelTypeEnum = $(this).val();
            $.ajax({
                url: "/LearningStandard/GetCommonCoreStandards",
                type: "POST",
                dataType: "json",
                data: {
                    gradeLevelTypeEnum: gradeLevelTypeEnum,
                },

                success: function (listOfCommonCoreListItemModels) {
                    console.log(listOfCommonCoreListItemModels);
                    listOfCommonCoreListItemModels.forEach(function(e) {
                            $('#CommonCoreStandard').append('<option value="'+ e.LearningStandardId +'">'+ e.Description +'</option>');
                        }
                    );
                }
            });
        });
    }

    var resetList = function() {
        $('#CommonCoreStandard option').remove();
        $('#CommonCoreStandard').append('<option selected="selected" value></option>');
    }




    return {
        init: init
    }
})();
