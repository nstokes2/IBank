<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoIBank._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.10.2.min.js"></script>

    <script type="text/javascript">
    function getBankAccounts() {
        $.getJSON("api/BankAccounts",
            function (data) {
                $('#bankAccounts').empty(); // Clear the table body.

                // Loop through the list of bank Accounts.
                $.each(data, function (key, val) {
                    // Add a table row for the bank Account.
                    var row = '<td>' + val.Name + '</td><td>' +val.AccountNumber +'</td>';
                    $('<tr>'+ row + '</tr>')  // Append the name.
                        .appendTo($('#bankAccounts'));
                });
            });
        }
        if (<%: Context.User.Identity.GetUserName()  %> == "nstokes2@memphis.edu")
        $(document).ready(getBankAccounts);
</script>
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <h2>Bank Accounts</h2>
    <table>
    <thead>
        <tr><th>Name</th><th>Balance</th></tr>
    </thead>
    <tbody id="bankAccounts">
    </tbody>
    </table>
</asp:Content>
