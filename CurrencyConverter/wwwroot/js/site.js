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

    $.get(window.location.origin + `/Home/GetCurrencyRate?from=${from}&to=${to}&date=${date}`).done(function(results) {
        if (results === 0)
            $('#infoModal').modal('show');

        $('#selected-rate').text(Number(results).toFixed(4));
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

jQuery.validator.addMethod("greaterThan2000", 
    function(value, element, params) {

        if (!/Invalid|NaN/.test(new Date(value))) {
            return (new Date(value) > new Date('2000-01-01')) && (new Date(value) <= new Date());
        }

        return isNaN(value) 
            || (Number(value) < Number('2000-01-01'))
            || (Number(value) >= Number(new Date().toISOString().split('T')[0])); 
    },'Must be greater than {0} and less than current date.');

$(document).ready(function ()   
{  
    $('form').validate({  
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',  
        errorPlacement: function (error, e) {  
            e.parents('.form-group > div').append(error);  
        },  
        highlight: function (e) {  
        
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');  
            $(e).closest('.help-block').remove();  
        },  
        success: function (e) {  
            e.closest('.form-group').removeClass('has-success has-error');  
            e.closest('.help-block').remove();  
        },  
        rules: {  
            'From': {  
                required: true
            },  
      
            'To': {  
                required: true
            },  
      
            'Amount': {  
                required: true,  
                minlength: 1,
                min: 0.1,
                number: true
            },
            'Date': {
                required: true,
                date: true,
                greaterThan2000: '2000-01-01'
            }
        },  
        messages: {  
            'From': {  
                required: 'Please choose valid currency'
            },  
      
            'To': {  
                required: 'Please choose valid currency'
            },  
      
            'Amount': {  
                required: 'Amount is required',  
                minlength: 'Must be at least 1 character long',
                min: 'Must be 0.1 or greater'
            },
            'Date': {
                required: 'Date is required',
                date: "Enter date only"
            }
        }  
    });  
});   

