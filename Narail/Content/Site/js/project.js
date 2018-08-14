$(document).ready(function () {

    $('#software').click(function () {
        $('#softwareDiv').show();
        $('#humanDiv').hide();
        $('#financeDiv').hide();

    });

    $('#human').click(function () {
        $('#humanDiv').show();
        $('#softwareDiv').hide();
        $('#financeDiv').hide();
    });
    $('#finance').click(function () {
        $('#financeDiv').show();
        $('#humanDiv').hide();
        $('#softwareDiv').hide();
    });
})

$('.service-catergory li').on('click', function () {

    $('li').removeClass('active');
    $(this).addClass('active');


});