$((function(e){$(".slide-show").on("click",(function(e){var i=$(this),s=i.next(),n=".slide-menu";if(s.is(n)&&s.is(":visible"))s.slideUp(300,(function(){s.removeClass("open")})),s.parent("li").removeClass("is-expanded");else if(s.is(n)&&!s.is(":visible")){var a=i.parents("ul").first();a.find("ul:visible").slideUp(300).removeClass("open");var l=i.parent("li");s.slideDown(300,(function(){s.addClass("open"),a.find("li.is-expanded").removeClass("is-expanded"),l.addClass("is-expanded")}))}s.is(n)&&e.preventDefault()})),$(document).ready((function(){$(".support-sidebar li a").each((function(){var e=window.location.href.split(/[?#]/)[0];this.href==e&&($(this).addClass("active"),$(this).parent().parent().prev().addClass("active"),$(this).parent().parent().prev().click())}))}))}));