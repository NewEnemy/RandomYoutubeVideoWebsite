// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




$(document).ready(function () {
    $.get("/Test", null, function (data, textStatus) {
        console.log("?");
        console.log(data);
    })
});

function PopcornAnimation(element,onelement) {
    console.log(element);
    
    styleString = "";
    if (Math.random() > 0.5) {
        styleString = "-"
    } else {
        styleString = "";
    }
    if (onelement) {
        element.style.transform = "rotate(" + styleString + "15deg)";
        document.getElementsByClassName("NextVideo")[0].style.transform = "rotate(" + styleString + "15deg)";
        element.classList.add("img_hovered")
        element.classList.remove("img_reset")
        document.getElementsByClassName("NextVideo")[0].classList.remove("img_reset")
        document.getElementsByClassName("NextVideo")[0].classList.add("img_hovered")
    } else {
        element.style.width = "10rem";
        element.style.transform = "rotate(0deg)";
        document.getElementsByClassName("NextVideo")[0].style.transform = "rotate(0deg)";

        element.classList.remove("img_hovered")
        element.classList.add("img_reset")
        document.getElementsByClassName("NextVideo")[0].classList.add("img_reset")
        document.getElementsByClassName("NextVideo")[0].classList.remove("img_hovered")
    }
    
}

function PopcornSize(element, mousedown) {

    if (mousedown) {
        element.style.width = "8rem";
    } else {
        element.style.width = "10rem"
    }
}

function NextVideo(element) {
    document.getElementsByClassName("NextVideo")[0].style.transform = "rotate(345deg)";
}