$(document).ready(function() {
    $('#createLink').click(function() {
        $('#createPanel').animate({
            opacity: 0.7,
            display:'block',
            height: '300px'
        }, 1000, function () {
            // Animation complete.
        });
    });
});

var cancelCreation = function () {
    $('#createPanel').animate({
        opacity: 0,
        display: 'hidden',
        height: '0px'
    }, 1000, function () {
        // Animation complete.
    });
}