$(document).ready(function () {
    initDateFields();

});

function initDateFields() {
    // Initialize field dates (elements with class fieldDate)
    $('.field-date').datepicker({
        format: "mm/dd/yyyy",
        autoclose: true,
        todayHighlight: true
    });
}