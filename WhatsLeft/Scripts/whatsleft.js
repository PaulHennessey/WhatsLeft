var funds = (function ($) {

    $('#NextPayDay').datepicker({ format: 'dd/mm/yyyy' });

    $('#productTable').DataTable({
        "paging": false,
        "ordering": false,
        "info": false
    });

    $('#regularPaymentsTable').DataTable({
        "paging": false,
        "ordering": false,
        "info": false
    });

    $('#fundsTable').DataTable({
        "paging": false,
        "ordering": false,
        "info": false
    });



    var UpdateUrl = "/whatsleft/update";

    $(".DeleteLink").on("click", DeleteLinkClick);
    $(".UpdateBalanceLink").on("click", UpdateBalanceClick);

    function DeleteLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }


    function UpdateBalanceClick(e) {

        e.preventDefault();
        
        var id = $("#Id").val();
        var balance = $("#Balance").val();
        var nextPayDate = $("#NextPayDate").val();        
        var link = this.href + "/" + id + "/" + balance + "/" + nextPayDate;

        window.location.href = link;
    }


    $('#tabs').tab();
    

})(jQuery);


