$(document).ready(function () {

    var table = $('#students-table').DataTable({
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        order: [0, "asc"], 
        pageLength: 10,
    });
});