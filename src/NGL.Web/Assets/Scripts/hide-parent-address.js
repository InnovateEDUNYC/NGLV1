$(document).on("ready", function() {
    if($("#FirstParent_SameAddressAsStudent").is(':checked'))
        $(".parent-address").hide(); 
    else
        $(".parent-address").show();

    $("#FirstParent_SameAddressAsStudent").on("click", function () {
        $(".parent-address").toggle();
    });
});

