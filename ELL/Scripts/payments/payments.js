$(document).ready(function () {

    var table = $('#payments-table').DataTable({
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        order: [0, "asc"], 
        pageLength: 10,
        //dom: 'lBfrtip',
        dom: '<"container-fluid"<"row"<"pull-right"B>><"row"<"col-md-6"l><"col-md-6 pull-right"f>>>rtip',
        //buttons: [
        //    'excel','csv',
        //    'pdf',
        //    'print'
        //]
        buttons: [
        //{
        //    extend: 'excel',
        //    text: '<i class="fa fa-file-excel-o"></i> Excel'
        //},
        {
            extend: 'csv',
            text: '<i class="fa fa-file-excel-o"></i> CSV'
        },
        {
            extend: 'pdf',
            text: '<i class="fa fa-file-pdf-o"></i> PDF'
        },
        {
            extend: 'print',
            text: '<i class="fa fa-file-print-o"></i> Print'
        }
        ]

    });
});