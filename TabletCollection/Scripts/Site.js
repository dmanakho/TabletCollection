// glyphicons on buttons support
$(document).ready(function () {
    $(".icon-input-btn").each(function () {
        var btnFont = $(this).find(".btn").css("font-size");
        var btnColor = $(this).find(".btn").css("color");
        $(this).find(".glyphicon").css("font-size", btnFont);
        $(this).find(".glyphicon").css("color", btnColor);
        if ($(this).find(".btn-xs").length) {
            $(this).find(".glyphicon").css("top", "24%");
        }
    });
});


