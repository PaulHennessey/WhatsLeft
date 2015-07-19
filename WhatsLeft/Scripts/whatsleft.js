var funds = (function ($) {

    var UpdateUrl = "/whatsleft/update";

    $(".DeleteAccountLink").on("click", DeleteAccountLinkClick);
    $(".DeleteFundLink").on("click", DeleteFundLinkClick);
    $(".UpdateBalanceLink").on("click", UpdateBalanceClick);

    function DeleteFundLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }

    function DeleteAccountLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }


    function UpdateBalanceClick(e) {

        e.preventDefault();
        
        var id = $("#Id").val();

        var balance = $("#Balance").val();

        var link = this.href + "/" + id + "/" + balance;

        window.location.href = link;
    }

})(jQuery);


