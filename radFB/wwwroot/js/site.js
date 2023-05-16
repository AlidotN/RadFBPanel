// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $(".alert").delay(5000).fadeOut();


    if ($(".nav-sidebar li a").hasClass("active")) {
        $(".nav-sidebar li a.active").removeClass("active");
    }
    $(".nav-sidebar li a").each(function () {
        if ($(this).children("p").html().trim() == $("h1").html().trim()) {
            $(this).addClass("active");
            $(this).parent().parent().parent().addClass("menu-open");
        }
    });



})
