// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



jQuery.validator.addMethod("validregno",
    function (value, element, param) {
        console.log(value);


        if (value == "PPP111") return true;
        return false;
    });
jQuery.validator.unobtrusive.adapters.addBool("validregno");