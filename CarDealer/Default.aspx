<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarDealer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <div class="txt_style">
    <p class="txt_style">
        Märke: <asp:TextBox ID="txtTextBox1" runat="server"></asp:TextBox>
    &nbsp;Färg:
        <asp:TextBox ID="txtTextBox2" runat="server"></asp:TextBox>
&nbsp;Årsmodell:
        <asp:TextBox ID="txtTextBox3" runat="server"></asp:TextBox>&nbsp;

        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Sök" />
    </p>
    </div>

    <p>&nbsp;</p>

        <div class="txt_style_car_box">          

            <asp:Panel ID="Panel1" runat="server">

            </asp:Panel>       

            <asp:Label ID="lblError" runat="server"></asp:Label>

        </div>

</asp:Content>
