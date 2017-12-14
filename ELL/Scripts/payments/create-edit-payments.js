var PaymentType = {
    Registration: 1,
    MonthlyPayment: 0,
    Other: 2
};
var studentIdElement = "StudentId";
var amountIdElement = "Amount";
var typeIdElement = "Type";
var descriptionIdElem = "Description";

$(document).ready(function () {
    initDateFields();

    updatePaymentData();

    $("#" + studentIdElement).select2({
        width: '50%',
    });
});

$("#" + typeIdElement).on("change", "", function () {

    updatePaymentData();

});

$("#" + studentIdElement).on("change", "", function () {

    updatePaymentData();

});

function updatePaymentData() {
    var typeElem = $("#" + typeIdElement);
    var descriptionElem = $("#" + descriptionIdElem);
    var amountElem = $("#" + amountIdElement);

    var type = typeElem.val();

    if (type == PaymentType.MonthlyPayment) {
        updateMonthlyPayment();
    } else {
        amountElem.val("");
    }

    if (type != PaymentType.Other) {
        // Set description as readonly
        descriptionElem.attr("readonly", true);

        // Set description
        var textType = typeElem.find(":selected").text();
        descriptionElem.val(textType);
    } else {
        descriptionElem.attr("readonly", false);
        descriptionElem.val("");
    }
}

function initDateFields() {
    // Initialize field dates (elements with class fieldDate)
    $('.field-date').datepicker({
        format: "mm/dd/yyyy",
        autoclose: true,
        language: 'en'
        //,
        //todayHighlight: true
    });
}

function getMothlyPayment(studentId) {
    // Get Monthly payment
    $.ajax({
        url: '/Students/GetMonthlyPayment',
        data: {
            studentId: studentId
        },
        dataType: 'json'
    })
    .done(function (data) {
        //alert(data);

        $("#" + amountIdElement).val(data);

    })
    .fail(function (jqxhr, textStatus, error) {
        alert("Error getting monthly payment of student. Please try again later.");
    })
    .always(function () {
        //alert("finished");
    });

    return 0;
}

function updateMonthlyPayment() {
    var studentId = $("#" + studentIdElement).val();

    getMothlyPayment(studentId);
}