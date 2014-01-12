   
	  
$( document ).ready(function() {
 
    $('a[href*=#]:not([href=#]):not([href=#collapseUm]):not([href=#collapseDois]):not([href=#collapseTres]):not([href=#login2]):not([href=#create]):not([href=#myModal])').click(function () {
          if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') 
              || location.hostname == this.hostname) {

            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
            if (target.length) {
              $('html,body').animate({
                scrollTop: target.offset().top
              }, 1000);
              return false;
            }
          }
        });
    $('#Valor').addClass('form-control');
	  
});	  

function PositionFooter() {
    var $footer = $("#footer"), footerHeight = $footer.height(),
    footerTop = ($(window).scrollTop() + $(window).height() - footerHeight) + "px";

    if (($(document.body).height() + footerHeight) < $(window).height()) {
        $footer.css({ position: "absolute", top: footerTop }); } 
    else { $footer.css({ position: "static" }); }

    $footer.fadeTo(1000, 0.8);
}

function GerenciarFooter() {
    $(window).resize(PositionFooter)
    PositionFooter();
}

$(document).ready(function () {
    GerenciarFooter();

    //Garante que a função será executada após um postback AJAX
    //prm = Sys.WebForms.PageRequestManager.getInstance();
    //prm.add_endRequest(PositionFooter);
});


