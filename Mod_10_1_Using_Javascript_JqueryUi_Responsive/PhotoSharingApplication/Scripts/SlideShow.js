var percentIncrement;
var percentCurrent = 100;

function slideSwitch() {
    percentIncrement += percentIncrement;
    if (percentCurrent > 100) {
        percentCurrent = percentIncrement;
    }

    $('#slideshow-progress-bar').progressbar({
        value: percentCurrent
    })

    var $activeCard = $('#slide-show DIV.active-card');
    if ($activeCard.length == 0) {
        $activeCard = $('#slide-show DIV.slide-show-card:last');
    }
    var $nextCard = $activeCard.next();
    if ($nextCard.length == 0) {
        $nextCard = $('#slide-show DIV.slide-show-card:first');
    }
    $activeCard.addClass('last-active-card');

    $nextCard.css({ opacity: 0.0 });

    $nextCard.addClass('active-card');

    calculateIncrement();

    $nextCard.animate({ opacity: 1.0 }, 5000, function () {
        $activeCard.removeClass('active-card last-active-card');
    });
    
}

$(document).ready(function(){
    setInterval("slideSwitch()", 5000);
});

function calculateIncrement() {
    var cardCount = $('#slide-show DIV.slide-show-card').length;
    percentIncrement = 100 / cardCount;

    $('#slideshow-progress-bar').progressbar({
        value: 100
    });
}

