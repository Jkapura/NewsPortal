$(function () {
    $(window).scroll(function () {
        var top = $(document).scrollTop();
        if (top < 160) {
            $(".navpanel").css({ top: '0', position: 'relative' });
            $(".hdnBar").css({marginTop:'160'});
        }
        else $(".navpanel").css({ top: '0', position: 'fixed' });

    });
    $("#hoverCategory").mouseenter(function () {
        $("#hoverCategory").css({
            "backgroundColor": "#86b300",
            "color": "white"
        });
    })
    $("#hoverCategory").mouseleave(function () {
        $("#hoverCategory").css({
            "backgroundColor": "#f6f6ee",
            "color": "#222211"
        });
    })
    //$("#hoverCategory").click(function () {
    //    $(".hiddenBar").slideToggle();
    //})
    $(".offerNews").click(function () {
        $(".addHdnNewsPanel").slideToggle("slow");
    });    
});
function mouseMove() {
    $("#hoverCategory").css({
        "backgroundColor": "#86b300",
        "color": "white"
    });
    $(".hiddenBar").slideDown();
    var top = $(document).scrollTop();
}
function mouseLeave() {   
    $("#hoverCategory").css({
        "backgroundColor": "#f6f6ee",
        "color": "#222211"
    });
    
}
function outBar() {
    $(".hiddenBar").slideUp();
}
function cssStay() {
    $("#hoverCategory").css({
        "backgroundColor": "#86b300",
        "color": "white"
    });
}
//function windowSize() {
//    if ($(window).width() <= '1600') {

//        $('.aLight').hide();
//    }
//    else {
//        $(".aLight").show();
//    }
//}
//$(window).on('load resize', windowSize);

