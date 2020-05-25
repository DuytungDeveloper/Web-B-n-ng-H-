
$(document).ready(function () {

    $('#sanphamcungtamgia').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        dots: false,
        navElement: "div",
        navClass: ["prev-please", "next-please"],
        // autoplay: true,
        autoplayHoverPause: true,
        animateOut: 'slideOutUp',
        animateIn: 'slideInUp',
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            700: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    });
    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        dots: false,
        navElement: "div",
        navClass: ["prev-please", "next-please"],
        // autoplay: true,
        autoplayHoverPause: true,
        animateOut: 'slideOutUp',
        animateIn: 'slideInUp',
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            700: {
                items: 2
            },
            1000: {
                items: 4
            }
        }
    });
    $(".prev-please").html(`<svg class="bi bi-caret-left-fill" width="2em" height="2em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
    <path d="M3.86 8.753l5.482 4.796c.646.566 1.658.106 1.658-.753V3.204a1 1 0 00-1.659-.753l-5.48 4.796a1 1 0 000 1.506z"/>
  </svg>`);
    $(".next-please").html(`<svg class="bi bi-caret-right-fill" width="2em" height="2em" viewBox="0 0 16 16" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
  <path d="M12.14 8.753l-5.482 4.796c-.646.566-1.658.106-1.658-.753V3.204a1 1 0 011.659-.753l5.48 4.796a1 1 0 010 1.506z"/>
</svg>`);
    // $('.slick-side-for').slick({
    //     slidesToShow: 1,
    //     slidesToScroll: 1,
    //     arrows: false,
    //     fade: true,
    //     asNavFor: '.slick-side-nav'
    // });
    // $('.slick-side-nav').slick({
    //     slidesToShow: 3,
    //     slidesToScroll: 1,
    //     asNavFor: '.slick-side-for',
    //     dots: true,
    //     centerMode: true,
    //     focusOnSelect: true
    // });





    if ($(".slider-main").length != 0)
        $('.slider-main').slick({
            slidesToShow: 1,
            arrows: false,
            asNavFor: '.slider-nav',
            // vertical: true,
            // autoplay: true,
            // verticalSwiping: true,
            // easing: "bounceOut",
            // speed : 3000,
            // centerMode: true,
            speed: 500,
            // fade: true,
            // cssEase: 'linear'
        });
    if ($(".slider-nav").length != 0)
        $('.slider-nav').slick({
            slidesToShow: 3,
            asNavFor: '.slider-main',
            vertical: true,
            focusOnSelect: true,
            autoplay: false,
            centerMode: true,
            prevArrow: `<button class="btn btn-slider-prev"><i class="fas fa-chevron-circle-up"></i></button>`,
            nextArrow: `<button class="btn btn-slider-next"><i class="fas fa-chevron-circle-down"></i></button>`
        });

    $(".btn-xemthemdacdiem").click((e) => {
        var showMore = $(e.target).html() == "Xem thêm" ? true : false;
        if (showMore) {
            $(".tbl-dacdiemnoibat").removeClass("showless");
            $(e.target).html("Ẩn bớt");
        }
        else {
            $(".tbl-dacdiemnoibat").addClass("showless");
            $(e.target).html("Xem thêm");
        }
    });
    $(".btn-xemthemthongsokythuat").click((e) => {
        var showMore = $(e.target).html() == "Xem thêm" ? true : false;
        if (showMore) {
            $(".tbl-thongsokythuat").removeClass("showless");
            $(e.target).html("Ẩn bớt");
        }
        else {
            $(".tbl-thongsokythuat").addClass("showless");
            $(e.target).html("Xem thêm");
        }
    });

    function gioThanhToan() {
        $("#hoanThanhDonHang").steps({
            headerTag: "h3",
            bodyTag: "section",
            transitionEffect: "slideLeft",
            autoFocus: true
        });
    }
    // gioThanhToan();
    // $('#smartwizard').smartWizard();
    if ($('#smartwizard').length != 0)
        $('#smartwizard').smartWizard({
            theme: 'arrows',
            transitionEffect: 'fade', // Effect on navigation, none/slide/fade
            transitionSpeed: '400',
            toolbarSettings: {
                toolbarPosition: 'both', // none, top, bottom, both
                toolbarButtonPosition: 'right', // left, right
                // showNextButton: true, // show/hide a Next button
                // showPreviousButton: true, // show/hide a Previous button
                // toolbarExtraButtons: [
                //     $('<button></button>').text('Finish')
                //         .addClass('btn btn-info')
                //         .on('click', function () {
                //             alert('Finsih button click');
                //         }),
                //     $('<button></button>').text('Cancel')
                //         .addClass('btn btn-danger')
                //         .on('click', function () {
                //             alert('Cancel button click');
                //         })
                // ]
            },
            lang: {  // Language variables
                next: 'Tiếp',
                previous: 'Trở lại'
            },
        });


    // $('#smartwizard').smartWizard({
    //     selected: 0,  // Initial selected step, 0 = first step
    //     keyNavigation: true, // Enable/Disable keyboard navigation(left and right keys are used if enabled)
    //     autoAdjustHeight: true, // Automatically adjust content height
    //     cycleSteps: false, // Allows to cycle the navigation of steps
    //     backButtonSupport: true, // Enable the back button support
    //     useURLhash: true, // Enable selection of the step based on url hash
    //     lang: {  // Language variables
    //         next: 'Next',
    //         previous: 'Previous'
    //     },
    //     toolbarSettings: {
    //         toolbarPosition: 'bottom', // none, top, bottom, both
    //         toolbarButtonPosition: 'right', // left, right
    //         showNextButton: true, // show/hide a Next button
    //         showPreviousButton: true, // show/hide a Previous button
    //         toolbarExtraButtons: [
    //             $('<button></button>').text('Finish')
    //                 .addClass('btn btn-info')
    //                 .on('click', function () {
    //                     alert('Finsih button click');
    //                 }),
    //             $('<button></button>').text('Cancel')
    //                 .addClass('btn btn-danger')
    //                 .on('click', function () {
    //                     alert('Cancel button click');
    //                 })
    //         ]
    //     },
    //     anchorSettings: {
    //         anchorClickable: true, // Enable/Disable anchor navigation
    //         enableAllAnchors: false, // Activates all anchors clickable all times
    //         markDoneStep: true, // add done css
    //         enableAnchorOnDoneStep: true // Enable/Disable the done steps navigation
    //     },
    //     contentURL: null, // content url, Enables Ajax content loading. can set as data data-content-url on anchor
    //     disabledSteps: [],    // Array Steps disabled
    //     errorSteps: [],    // Highlight step with errors
    //     theme: 'dots',
    //     transitionEffect: 'fade', // Effect on navigation, none/slide/fade
    //     transitionSpeed: '400'
    // });
    $(function() {
			
        $(' #da-thumbs > li ').each( function() { $(this).hoverdir(); } );

    });
});