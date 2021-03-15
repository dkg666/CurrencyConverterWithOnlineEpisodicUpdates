$("#Date").change(function () {
    Filter();
});

$("#To").change(function () {
    Filter();
});

$("#From").change(function () {
    Filter();
});


function Filter() {
    var from = $('#From').val();
    var to = $('#To').val();
    var date = $('#Date').val();

    //if(!isValidDate(date) || isValidDate(date) && Date.parse(date) <= Date.parse('1999-01-01 12:00:00 AM')){
    //    $('span[data-valmsg-for="Date"]').text('Date is required and should be higher than 1999 year');
    //    return;
    //}

    $.get(window.location.origin + `/Home/GetCurrencyRate?from=${from}&to=${to}&date=${date}`).done(function(results) {
        $('#selected-rate').text(results);
    });
};


$(document).ready(function () {
    $(".datepicker").datepicker({
        format: 'yyyy-mm-dd',
        endDate: '+0d',
        autoclose:true,
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true
    });

    Filter();
});


function isValidDate(d) {
    return d instanceof Date && !isNaN(d);
}