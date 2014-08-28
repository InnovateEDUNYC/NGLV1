Ngl.createNS('Ngl.shared.learningStandards');

Ngl.shared.learningStandards = (function () {
    var init = function () {
        setUpGradeLevelChangeEvent();
        setUpLearningStandardChangeEvent();
    }

    var setUpGradeLevelChangeEvent = function() {
        $('#GradeLevel').on('change', setUpStandards);
    }

    var setUpLearningStandardChangeEvent = function () {
        $('#LearningStandard').on('change', setUpStandards);
    }

    var setUpStandards = function () {
        resetList();
        var gradeLevelTypeEnum = $('#GradeLevel').val();
        var academicSubjectDescriptorEnum = $('#LearningStandard').val();

        $.ajax({
            url: "/LearningStandard/GetCommonCoreStandards",
            type: "POST",
            dataType: "json",
            data: {
                gradeLevelTypeEnum: gradeLevelTypeEnum,
                academicSubjectDescriptorEnum: academicSubjectDescriptorEnum
            },

            success: function (listOfCommonCoreListItemModels) {
                if (!listOfCommonCoreListItemModels.BadInput) {
                    listOfCommonCoreListItemModels.forEach(function (e) {
                        $('#CommonCoreStandard').append('<option value="' + e.LearningStandardId + '">' + e.Description + '</option>');
                    });
                }
            }
        });
    };

    var resetList = function() {
        $('#CommonCoreStandard option').remove();
        $('#CommonCoreStandard').append('<option selected="selected" value></option>');
    }




    return {
        init: init
    }
})();
