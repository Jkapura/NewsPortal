$(function () {
    $(window).scroll(function () {
        var top = $(document).scrollTop();
        if (top < 100)
            $(".navpanel").css({ top: '0', position: 'relative' });
        else $(".navpanel").css({ top: '0', position: 'fixed' });

    });
});

function windowSize() {
    if ($(window).width() <= '1600') {

        $('.aLight').hide();
    }
    else {
        $(".aLight").show();
    }
}
$(window).on('load resize', windowSize);
$(function () {
    $("#logo").click(function () {
        $(".hiddenBar").slideToggle("slow");
        var top = $(document).scrollTop();
        if (top < 100)
            $(".hiddenBar").css({ top: '100', position: 'fixed' });
        else $(".hiddenBar").css({ top: '-30', position: 'fixed' });
    });
});

//function hiddenBarScroll(){
//    var top = $(document).scrollTop();
//    if (top < 100)
//        $(".navpanel").css({ top: '0', position: 'relative' });
//    else 
//        $(".navpanel").css({ top: '60', position: 'fixed' });
//}