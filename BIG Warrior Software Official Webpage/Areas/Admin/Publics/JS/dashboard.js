$(document).ready(function () {
    $("a.mobile").click(function () {
        $(".MainSidebar").slideToggle('fast');
    });

    window.onresize = function () {
        if ($(window).width() > 320) {
            $(".MainSidebar").show();
        }
    };
});