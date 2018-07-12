/*--------------------------------------------------------*/
/* TABLE OF CONTENTS: */
/*--------------------------------------------------------*/
/* 01 - VARIABLES */
/* 02 - page calculations */
/* 03 - function on document ready */
/* 04 - function on page load */
/* 05 - function on page resize */
/* 06 - function on page scroll */
/* 07 - swiper sliders */
/* 08 - buttons, clicks, hovers */
var _functions = {};
$(function() {
"use strict";
/*===============================================
preloader js
===============================================*/
$(window).on('load', function() {
$('#preloader').fadeOut('slow', function() { $(this).remove(); });
});
/*================*/
/* 01 - VARIABLES */
/*================*/
var swipers = [], winW, winH, headerH, winScr, footerTop, _isresponsive, _ismobile = navigator.userAgent.match(/Android/i) || navigator.userAgent.match(/webOS/i) || navigator.userAgent.match(/iPhone/i) || navigator.userAgent.match(/iPad/i) || navigator.userAgent.match(/iPod/i), _isFF = 'MozAppearance' in document.documentElement.style, headerHeight;
/*========================*/
/* 02 - page calculations */
/*========================*/
_functions.pageCalculations = function(){
winW = $(window).width();
winH = $(window).height();
headerHeight = $('header').outerHeight();
if ( winW > 992 ) {
$('.headerClearFix').css('height', $('.headerTopInfo').outerHeight() );
} else {
$('.headerClearFix').css('height', $('header').outerHeight() );
}
$('.navScroll').css('max-height', winH - 60 );
};
/*==============================*/
/* 03 - function on page scroll */
/*==============================*/
$(window).on('scroll', function(){
_functions.scrollCall();
});
var headerTimeout, headerTimeoutOff = 0;
_functions.scrollCall = function(){
winScr = $(window).scrollTop();
if ( winScr >= 300 ) {
$('header').addClass('header-scrolled');
setTimeout(function(){$('header').addClass('header-scrolled-animated');},0);
}
else {
$('header').removeClass('header-scrolled header-scrolled-animated');
$('header').removeClass('header-scrolled');
}
if ( winScr > headerHeight + 100 ) {
$('header').addClass('responsiveHeaderSrolled');
} else {
$('header').removeClass('responsiveHeaderSrolled');
}
};
/*=================================*/
/* 04 - function on document ready */
/*=================================*/
if(_ismobile) $('body').addClass('mobile');
_functions.pageCalculations();
$('.SelectBox').SumoSelect();
$('#loader-wrapper').fadeOut();
/*============================*/
/* 05 - function on page load */
/*============================*/
$(window).load(function(){
_functions.initSwiper();
$('body').addClass('loaded');
_functions.scrollCall();
});
/*==============================*/
/* 06 - function on page resize */
/*==============================*/
_functions.resizeCall = function(){
_functions.pageCalculations();
};
if(!_ismobile){
$(window).on('resize', function(){
_functions.resizeCall();
});
} else{
window.addEventListener("orientationchange", function() {
_functions.resizeCall();
}, false);
}
/*=====================*/
/* 07 - swiper sliders */
/*=====================*/
var initIterator = 0;
_functions.initSwiper = function(){
$('.swiper-container').not('.initialized').each(function(){								  
var $t = $(this);								  
var index = 'swiper-unique-id-'+initIterator;
$t.addClass('swiper-'+index+' initialized').attr('id', index);
$t.find('>.swiper-pagination').addClass('swiper-pagination-'+index);
$t.parent().find('>.swiper-button-prev').addClass('swiper-button-prev-'+index);
$t.parent().find('>.swiper-button-next').addClass('swiper-button-next-'+index);
var slidesPerViewVar = ($t.data('slides-per-view'))?$t.data('slides-per-view'):1;
if(slidesPerViewVar!='auto') slidesPerViewVar = parseInt(slidesPerViewVar, 10);
swipers['swiper-'+index] = new Swiper('.swiper-'+index,{
pagination: '.swiper-pagination-'+index,
paginationClickable: true,
nextButton: '.swiper-button-next-'+index,
prevButton: '.swiper-button-prev-'+index,
slidesPerView: slidesPerViewVar,
autoHeight:($t.is('[data-auto-height]'))?parseInt($t.data('auto-height'), 10):0,
loop: ($t.is('[data-loop]'))?parseInt($t.data('loop'), 10):0,
autoplay: ($t.is('[data-autoplay]'))?parseInt($t.data('autoplay'), 10):0,
breakpoints: ($t.is('[data-breakpoints]'))? { 767: { slidesPerView: parseInt($t.attr('data-xs-slides'), 10) }, 991: { slidesPerView: parseInt($t.attr('data-sm-slides'), 10) }, 1199: { slidesPerView: parseInt($t.attr('data-md-slides'), 10) } } : {},
initialSlide: ($t.is('[data-ini]'))?parseInt($t.data('ini'), 10):0,
speed: ($t.is('[data-speed]'))?parseInt($t.data('speed'), 10):500,
keyboardControl: true,
mousewheelControl: ($t.is('[data-mousewheel]'))?parseInt($t.data('mousewheel'), 10):0,
mousewheelReleaseOnEdges: true,
direction: ($t.is('[data-direction]'))?$t.data('direction'):'horizontal',
spaceBetween: ($t.is('[data-space]'))?parseInt($t.data('space'), 10):0,
parallax: (_isFF)?($t.data('parallax'), 0): ($t.is('[data-parallax]'))?parseInt($t.data('parallax'), 10):0,
effect: ($t.is('[data-effect]'))?($t.data('effect'), 'fade'):'slide',
autoplayDisableOnInteraction: false
});
swipers['swiper-'+index].update();
initIterator++;
});
$('.swiper-container.swiper-control-top').each(function(){
swipers['swiper-'+$(this).attr('id')].params.control = swipers['swiper-'+$(this).parent().find('.swiper-control-bottom').attr('id')];
});
$('.swiper-container.swiper-control-bottom').each(function(){
swipers['swiper-'+$(this).attr('id')].params.control = swipers['swiper-'+$(this).parent().find('.swiper-control-top').attr('id')];
});
};


//special_search

$('body').on('click','.special_search_label',function(e){
		var div_type = $(this).data('div_type');
		var hide_seek = $(this).data('hide_seek');
		$(this).find('i').toggleClass('fa-level-down fa-level-up');
		if(hide_seek === 1){
			$(this).data('hide_seek', 0);
			$('#'+div_type).slideToggle();
		} 
		else if(hide_seek === 0)
		{
			$(this).data('hide_seek', 1);
			$('#'+div_type).slideToggle();
		}
	});

//Tabs
var tabsFinish = 0;
$('.tab-menu').on('click', function() {
if($(this).hasClass('active') || tabsFinish) return false;
tabsFinish = 1;
var tabsWrapper = $(this).closest('.tabs-block'),
tabsMenu = tabsWrapper.find('.tab-menu'),
tabsItem = tabsWrapper.find('.tab-entry'),
index = tabsMenu.index(this);
tabsItem.filter(':visible').fadeOut(function(){
tabsItem.eq(index).fadeIn(function(){
tabsFinish = 0;
});
});
tabsMenu.removeClass('active');
$(this).addClass('active');
});

//Smooth Scroll
if(!_ismobile) {
SmoothScroll({ stepSize: 100 })
};
//Gallery
$('.openGalleryPopup').on('click', function(){
var index = $(this).index();
openPopup('10');
swipers['swiper-'+$('.galleryPopup .swiper-container').attr('id')].slideTo(index, 0);
return false;
});
//Responsive menu
$('.menuIcon').on('click', function() {
$(this).toggleClass('menuIconActive');
$('.responsiveWrapper').toggleClass('open');
});
//Responsive drop down
$('nav i.fa').on('click', function() {
$(this).parent().find('> ul').slideToggle(350);
$(this).toggleClass('rotated');
});

//lightbox gallery
var lightbox = $('.lightbox').simpleLightbox({
disableScroll: false,
captionSelector: 'self',
closeText: '',
alertErrorMessage: "Error",
history: false,
navText: ['','']
});

});
// $(window).on('scroll', function () {

 //            var scrollToTop = $('.scroll-to-top a')
 //            if ($(window).scrollTop() > 500) {
 //                scrollToTop.fadeIn(1000);
 //            } else {
 //                scrollToTop.fadeOut(1000);
 //            }
 //              });