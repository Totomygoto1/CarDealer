<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarViewAdmin.aspx.cs" Inherits="CarDealer.CarViewAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Content/Site.css" rel="stylesheet" />
</head>
<body class="bg_image">
    <form id="form1" runat="server">
        <div>
        <p style="color:cornflowerblue;font-family:Calibri;font-size:18px">		
		Cars for Sale
		<span style="color:white;font-family:Calibri;font-size:18px">
		Content Management System
		</span>	
        </p>
        </div>

<div id = "dvGrid" style ="padding:10px;width:550px">

<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>

<asp:GridView ID="GridView1" runat="server"  Width = "550px"

AutoGenerateColumns = "false" Font-Names = "Verdana"

Font-Size = "11pt" 

HeaderStyle-BackColor = "#ffb84d" AllowPaging ="true"  ShowFooter = "true" 

OnPageIndexChanging = "OnPaging" onrowediting="EditCar"

onrowupdating="UpdateCar"  onrowcancelingedit="CancelEdit"

PageSize = "10" >

<Columns>

<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "CarId">

    <ItemTemplate>

        <asp:Label ID="lblCarId" runat="server"

        Text='<%# Eval("CarId")%>'></asp:Label>

    </ItemTemplate>

    <FooterTemplate>

        <asp:TextBox ID="txtCarId" Width = "40px"

            MaxLength = "5" runat="server"></asp:TextBox>

    </FooterTemplate>

</asp:TemplateField>

<asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "FullName">

    <ItemTemplate>

        <asp:Label ID="lblFullName" runat="server"

                Text='<%# Eval("FullName")%>'></asp:Label>

    </ItemTemplate>

    <EditItemTemplate>

        <asp:TextBox ID="txtFullName" runat="server"

            Text='<%# Eval("FullName")%>'></asp:TextBox>

    </EditItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>

    </FooterTemplate>

</asp:TemplateField>

<asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "Colour">

    <ItemTemplate>

        <asp:Label ID="lblColour" runat="server"

            Text='<%# Eval("Colour")%>'></asp:Label>

    </ItemTemplate>

    <EditItemTemplate>

        <asp:TextBox ID="txtColour" runat="server"

            Text='<%# Eval("Colour")%>'></asp:TextBox>

    </EditItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtColour" runat="server"></asp:TextBox>

    </FooterTemplate>

</asp:TemplateField>


<asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "ImageURL">

    <ItemTemplate>

        <asp:Label ID="lblImageURL" runat="server"

            Text='<%# Eval("ImageURL")%>'></asp:Label>

    </ItemTemplate>

    <EditItemTemplate>

        <asp:TextBox ID="txtImageURL" runat="server"

            Text='<%# Eval("ImageURL")%>'></asp:TextBox>

    </EditItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtImageURL" runat="server"></asp:TextBox>

    </FooterTemplate>

</asp:TemplateField>


<asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "ModelYear">

    <ItemTemplate>

        <asp:Label ID="lblModelYear" runat="server"

            Text='<%# Eval("ModelYear")%>'></asp:Label>

    </ItemTemplate>

    <EditItemTemplate>

        <asp:TextBox ID="txtModelYear" runat="server"

            Text='<%# Eval("ModelYear")%>'></asp:TextBox>

    </EditItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtModelYear" runat="server"></asp:TextBox>

    </FooterTemplate>

</asp:TemplateField>


<asp:TemplateField>

    <ItemTemplate>

        <asp:LinkButton ID="lnkRemove" runat="server"

            CommandArgument = '<%# Eval("CarId")%>'

         OnClientClick = "return confirm('Do you want to delete?')"

        Text = "Delete" OnClick = "DeleteCar"></asp:LinkButton>

    </ItemTemplate>

    <FooterTemplate>

        <asp:Button ID="btnAdd" runat="server" Text="Add"

            OnClick = "AddNewCar" />

    </FooterTemplate>

</asp:TemplateField>

<asp:CommandField  ShowEditButton="True" />

</Columns>



</asp:GridView>

</ContentTemplate>

<Triggers>

<asp:AsyncPostBackTrigger ControlID = "GridView1" />

</Triggers>

</asp:UpdatePanel>

</div>


     


<script type = "text/javascript">

    function BlockUI(elementID) {

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_beginRequest(function() {

    $("#" + elementID).block({ message: '<table align = "center"><tr><td>' +

     '<img src="images/loadingAnim.gif"/></td></tr></table>',

     css: {},

     overlayCSS: {backgroundColor:'#000000',opacity: 0.6, border:'3px solid #63B2EB'

    }

    });

    });

    prm.add_endRequest(function() {

        $("#" + elementID).unblock();

    });

    }

    $(document).ready(function() {

 

            BlockUI("dvGrid");

            $.blockUI.defaults.css = {};           

    });

</script>


        


    </form>
</body>
</html>
