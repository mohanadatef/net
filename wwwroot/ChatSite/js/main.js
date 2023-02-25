$(window).on('load', function () {

    $('.loader').fadeOut(1000);

    new WOW().init();

    $('body').addClass('o-auto');

});



    $(document).ready(function () {

    "use strict";

    $(".close-open-nav").on("click", function () {

        $(this).toggleClass("active");

        if ($(this).hasClass("active")) {

            $(".heade_nav .nav").addClass("active");

        } else {

            $(".heade_nav .nav").removeClass("active");

        }

    });


    $("body").on("click", function () {

        if ($(".close-open-nav").hasClass("active")) {

            $(".close-open-nav").click();
        }

    });


    $(".close-open-nav, .heade_nav .nav").on("click", function (e) {

        e.stopPropagation();

    });


});
    










// // ADD IMAGE

$("#image").change(function (event) {
    $(this).parents('.images-upload-block').append('<div class="uploaded-block"><img src="' + URL.createObjectURL(event.target.files[0]) + '"><label class="close"> x </label></div>');
});

// REMOVE IMAGE
$('.images-upload-block').on('click', '.close', function () {
    $(this).parents('.uploaded-block').remove();
});




$('.owl-carousel').owlCarousel({
    loop: true,
    margin: 0,
    nav: false,
    dots: true,
    autoplay: true,
    autoplayTimeout: 3000,
    navText: ["<span><</span>", "<span>></span>"],


    responsive: {
        0: {
            items: 1
        }
    }
});

$(".accordum aside").on("click", function () {
    $(this).next("p").slideToggle();
    $(this).children("span").toggleClass("active");

    $(".accordum > p").not($(this).next("p")).slideUp();

    $(".accordum aside span").not($(this).children("span")).removeClass("active");

});


//$(document).ready(function () {

//    $(".chat-content").animate({
//        scrollTop: $('.chat-content').prop("scrollHeight")
//    }, 1000);

//    $('.writ_massage .form').on('submit', function (event) {
//        event.preventDefault();
//        var message = $('.content_sent').first().clone();
//        message.find('p').text($('.input-custom-size').val());
//        message.appendTo('.chat-content');
//        $('.input-custom-size').val('');

//        $(".chat-content").animate({
//            scrollTop: $('.chat-content').prop("scrollHeight")
//        }, 1000);

//    });


//    $("#sendimagechat").change(function (event) {
//        var messageimg = $('.content_sent').first().clone();
//        messageimg.find('p').html('<img src="' + URL.createObjectURL(event.target.files[0]) + '">');
//        messageimg.appendTo('.chat-content');
//        $(".chat-content").animate({
//            scrollTop: $('.chat-content').prop("scrollHeight")
//        }, 1000);

//    });

//});



    $(".chose_link input[type='file']").on("change", function () {
        
       
        $(this).parent(".chose_link").children(".form-control").val($(this).val().replace("C:\\fakepath\\", ""));
        
    });



$(".menu_sec > a").on("click", function (e) {
    
    e.preventDefault ();
    
    $(this).parent(".menu_sec").find("ul").toggle();
    
});


$("body").on("click", function () {
    
    $(".menu_sec ul").hide();
    
    
});

