$(function () {

    $('#navigation a').stop().animate({ 'marginLeft': '-85px' }, 1000);

    $('#navigation li a').hover(
        function () {
            $($(this)).stop().animate({ 'marginLeft': '-2px' }, 200);
        },
        function () {
            $($(this)).stop().animate({ 'marginLeft': '-85px' }, 200);
        }
    );
});