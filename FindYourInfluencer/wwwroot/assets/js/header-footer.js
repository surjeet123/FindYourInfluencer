
(function ($) {
   $('.search-btn').on('click', function () { 
      var $this = $(this);
      $('.navbar-collapse').collapse('hide');
      if ($this.hasClass('is-active')) {
         $this.attr('aria-expanded', 'false');
         $this.removeClass('is-active');
         $this.parents('.site-header').find('.search-inner').slideUp();
      } else {
         $this.attr('aria-expanded', 'true');
         $this.addClass('is-active');
         $this.parents('.site-header').find('.search-inner').slideDown();
         $this.parents('.site-header').find('.search-bar input[type=text]').trigger('focus');
      }
   })
   $('.navbar-toggler').on('click', function () {

      $('.search-btn').attr('aria-expanded', 'false');
      $('.search-btn').removeClass('is-active');
      $('.site-header').find('.search-inner').slideUp();

   })
}(jQuery));
