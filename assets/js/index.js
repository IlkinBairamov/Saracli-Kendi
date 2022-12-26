// let Child=document.querySelectorAll('#firstChild')
// // let firstChild=document.querySelectorAll('.firstChild')
// // let secondChild=document.querySelector('.secondChild')
// // let thirdChild=document.querySelector('.thirdChild')
// // let active=document.querySelector('.active-color')
// // let deactive=document.querySelector('.deactive-color')
// let ilkin=document.querySelector('.ilkin')


// // Child.forEach((e)=>{
//     ilkin.addEventListener("click", (e)=>{
//     if (e.target.classList.contains(".active")) {
//         //e.style.backgroundColor='#00628D'
//         console.log("salam");
//     }
//     })
// // })

//$(document).ready(function(){
    // $(".navbar-toggler").click(function(){
    //     $(".navList").slideDown("slow")
    //     $(".navList").css({"display":"block","right":"20px","left":"260px"});
    //     $(".dropdown-menu").css({"left":"1%","top":"28px"})
    //   });

//       $(window).scroll(function () {
//         let height=$(window).scrollTop()
//         if( $("#navbar").hasClass("transparant")){
//         if (height>0) {
//             $("#navbar").css({"background-color":"white","position":"fixed","top":"0"})
//         }
//         else
//         {
//             $("#navbar").css({ "position": "absolute",
//             "background-color": "transparent"})
//         }
//     }})

//     $(window).scroll(function () {
//         let height=$(window).scrollTop()
//         if (height>500) {
//             $(".scroll-icon").addClass("scroll-active")
//         }
//         else{
//             $(".scroll-icon").removeClass("scroll-active")
//         }
//     })
// })

    
$(document).ready(function () {

    $('.first-button').on('click', function () {
  
      $('.animated-icon1').toggleClass('open');
    });
    $('.second-button').on('click', function () {
  
      $('.animated-icon2').toggleClass('open');
    });
    $('.third-button').on('click', function () {
  
      $('.animated-icon3').toggleClass('open');
    });
  });