(function($) {
    "use strict";

    function preloader() {
        $('.preloader').delay(0).fadeOut();
    };
    $(window).on('load', function() {
        preloader();
    });

   
    if ($('.menu-area li.menu-item-has-children ul').length) {
        $('.menu-area .navigation li.menu-item-has-children').append('<div class="dropdown-btn"><span class="fa fa-angle-down"></span></div>');
    }
    $('#location').select2({
        placeholder: "Location",
        allowClear: true
    });
    $('#ptypes').select2({
        placeholder: "Property Types",
        allowClear: true
    });
    $('#price').select2({
        placeholder: "Price Range",
        allowClear: true
    });
    $('#Bedrooms').select2({
        placeholder: "Bed Rooms",
        allowClear: true
    });
    $('#Bathrooms').select2({
        placeholder: "Bathrooms",
        allowClear: true
    });
    if ($('.mobile-menu').length) {
        var mobileMenuContent = $('.menu-area .main-menu').html();
        $('.mobile-menu .menu-box .menu-outer').append(mobileMenuContent);
        $('.mobile-menu li.menu-item-has-children .dropdown-btn').on('click', function() {
            $(this).toggleClass('open');
            $(this).prev('ul').slideToggle(500);
        });
        $('.mobile-nav-toggler').on('click', function() {
            $('body').addClass('mobile-menu-visible');
        });
        $('.menu-backdrop, .mobile-menu .close-btn').on('click', function() {
            $('body').removeClass('mobile-menu-visible');
        });
    }
    $('.socialclick').on('click', function() {
        $('.header-top-right').toggle(1000);
    });
    $('.click-two-header').on('click', function() {
        $('.show-two-header').toggle(1000);
    });
    $('.close-two').on('click', function() {
        $('.show-two-header').hide(1000);
    });
    $('.click-three-header').on('click', function() {
        $('.show-three-header').toggle(1000);
    });
    $('.close-three').on('click', function() {
        $('.show-three-header').hide(1000);
    });
    $('.click-four-header').on('click', function() {
        $('.show-four-header').toggle(1000);
    });
    $('.close-four').on('click', function() {
        $('.show-four-header').hide(1000);
    });
    var list = document.querySelectorAll("div[data-image]");
    for (var i = 0; i < list.length; i++) {
        var url = list[i].getAttribute('data-image');
        list[i].style.backgroundImage = "url('" + url + "')";
    }
    $(window).on('scroll', function() {
        var scroll = $(window).scrollTop();
        if (scroll < 245) {
            $("#sticky-header").removeClass("sticky-menu");
            $('.scroll-to-target').removeClass('open');
        } else {
            $("#sticky-header").addClass("sticky-menu");
            $('.scroll-to-target').addClass('open');
        }
    });
    if ($('.scroll-to-target').length) {
        $(".scroll-to-target").on('click', function() {
            var target = $(this).attr('data-target');
            $('html, body').animate({
                scrollTop: $(target).offset().top
            }, 1000);
        });
    }
    var swiper = new Swiper(".mySwiper", {
        pagination: '.swiper-pagination',
        paginationClickable: true,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        spaceBetween: 0,
        parallax: true,
        autoplay: 400,
        speed: 800,
        autoplayDisableOnInteraction: false,
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
    $("[data-background]").each(function() {
        $(this).css("background-image", "url(" + $(this).attr("data-background") + ")")
    })
    $('.btn').on('mouseenter', function(e) {
        var parentOffset = $(this).offset(),
            relX = e.pageX - parentOffset.left,
            relY = e.pageY - parentOffset.top;
        $(this).find('span').css({
            top: relY,
            left: relX
        })
    }).on('mouseout', function(e) {
        var parentOffset = $(this).offset(),
            relX = e.pageX - parentOffset.left,
            relY = e.pageY - parentOffset.top;
        $(this).find('span').css({
            top: relY,
            left: relX
        })
    });
    $('.popup-youtube').magnificPopup({
        type: 'iframe'
    });
    $('.image-popup-vertical-fit').magnificPopup({
        type: 'image',
        mainClass: 'mfp-with-zoom',
        gallery: {
            enabled: true
        },
        zoom: {
            enabled: true,
            duration: 300,
            easing: 'ease-in-out',
            opener: function(openerElement) {
                return openerElement.is('img') ? openerElement : openerElement.find('img');
            }
        }
    });
    $('.owl-demo-test-4').owlCarousel({
        loop: true,
        autoplay: true,
        autoPlaySpeed: 5000,
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        margin: 15,
        responsiveClass: true,
        navText: ["<img src='/images/left-arrow-small.png'/>", "<img src='/images/right-arrow-small.png'/>"],
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 2,
                nav: false
            },
            1000: {
                items: 4,
                autoplay: false,
                autoplayHoverPause: false,
                nav: true,
                dots: false,
                loop: true
            }
        }
    })
    $('.owl-demo-test-3').owlCarousel({
        loop: true,
        autoplay: true,
        autoPlaySpeed: 5000,
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        margin: 15,
        responsiveClass: true,
        navText: ["<img src='./images/left-arrow-small.png'/>", "<img src='./images/right-arrow-small.png'/>"],
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 2,
                nav: false
            },
            1000: {
                items: 3,
                autoplay: false,
                autoplayHoverPause: false,
                nav: true,
                dots: false,
                loop: true
            }
        }
    })
    $('.owl-demo5').owlCarousel({
        loop: true,
        autoplay: true,
        autoPlaySpeed: 5000,
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        margin: 25,
        responsiveClass: true,
        navText: ["<img src='/images/left-arrow-small.png'/>", "<img src='/images/right-arrow-small.png'/>"],
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 2,
                nav: false
            },
            1000: {
                items: 3,
                autoplay: false,
                autoplayHoverPause: false,
                nav: true,
                dots: false,
                loop: true
            }
        }
    })
    $('.owl-demo2').owlCarousel({
        loop: true,
        autoplay: true,
        autoPlaySpeed: 5000,
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        margin: 25,
        responsiveClass: true,
        navText: ["<img src='./images/left-arrow-small.png'/>", "<img src='./images/right-arrow-small.png'/>"],
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 1,
                nav: false
            },
            1000: {
                items: 2,
                autoplay: true,
                autoplayHoverPause: false,
                nav: true,
                dots: false,
                loop: true
            }
        }
    })
    $('#demoslide4').owlCarousel({
        loop: true,
        autoplay: true,
        autoPlaySpeed: 5000,
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        margin: 25,
        responsiveClass: true,
        navText: ["<img src='./images/left-arrow-small.png'/>", "<img src='./images/right-arrow-small.png'/>"],
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 1,
                nav: false
            },
            1000: {
                items: 1,
                autoplay: true,
                autoplayHoverPause: false,
                nav: true,
                dots: false,
                loop: true
            }
        }
    })
    $(".set > a").on("click", function() {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
            $(this).siblings(".content").slideUp(200);
            $(".set > a i").removeClass("fa-minus").addClass("fa-plus");
        } else {
            $(".set > a i").removeClass("fa-minus").addClass("fa-plus");
            $(this).find("i").removeClass("fa-plus").addClass("fa-minus");
            $(".set > a").removeClass("active");
            $(this).addClass("active");
            $(".content").slideUp(200);
            $(this).siblings(".content").slideDown(200);
        }
    })
})(jQuery);