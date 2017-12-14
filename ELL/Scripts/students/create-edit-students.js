$(document).ready(function () {
    initDateFields();

    //$("#EmergencyContactId").select2();
    $("#EmergencyContactId").select2({
        width: '50%',
    });
    
});

function initDateFields() {
    // Initialize field dates (elements with class fieldDate)
    $('.field-date').datepicker({
        format: "mm/dd/yyyy",
        autoclose: true,
        todayHighlight: true
    });
}