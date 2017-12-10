var PaymentType = {
    Registration: 0,
    MonthlyPayment: 1,
    Other: 2
};

$(document).ready(function () {
    initDateFields();

    updateDescriptionFromType();
});

$("#Type").on("change", "", function () {

    updateDescriptionFromType();
});

function updateDescriptionFromType() {
    var typeElem = $("#Type");
    var descriptionElem = $("#Description");

    var type = typeElem.val();

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
        autoclose: true
        //,
        //todayHighlight: true
    });
}