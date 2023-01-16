$(document).ready(function(){
    $(".navbar-toggler").click(function(){
        $(".navList").toggle("slow")
        $(".navList").css({"display":"block","left":"-16px"});
        $(".dropdown-menu").css({"left":"1%","top":"28px"})
      });

      $(window).scroll(function () {
        let height=$(window).scrollTop()
        if( $("#navbar").hasClass("transparant")){
        if (height>0) {
            $("#navbar").css({"background-color":"white","position":"fixed","top":"0"})
            $(".navImg").css({
                display:'none',
            })
        }
        else
        {
            $("#navbar").css({ "position": "absolute",
            "background-color": "transparent"})
            $(".navImg").css({
                display:'block',
            })
        }
    }})

    // $(window).scroll(function () {
    //     let height=$(window).scrollTop()
    //     if (height>500) {
    //         $(".scroll-icon").addClass("scroll-active")
    //     }
    //     else{
    //         $(".scroll-icon").removeClass("scroll-active")
    //     }
    // })
})
