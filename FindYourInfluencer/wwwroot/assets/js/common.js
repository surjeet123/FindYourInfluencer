(function ($) {
    function slickWcag() {
        $('.slick-slider').removeAttr('aria-label').removeAttr('role');
    }
    $(window).on('load', function () {
        slickWcag()
    })
    if ($("body").find(".Influencers-slider").length) {
        $('.Influencers-slider').slick({
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 4,
            accessibility: true,
            responsive: [
                {
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 4,
                    },
                },
                {
                    breakpoint: 1008,
                    settings: {
                        slidesToShow: 3,
                    },
                },
                {
                    breakpoint: 800,
                    settings: {
                        slidesToShow: 1,
                    },
                },
            ],
        });
    }
    
}(jQuery));

