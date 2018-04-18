<%@ Page 
    Title="Richiesta D'ordine" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Request.aspx.cs" 
    Inherits="WebApplication1._Request" 
%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Richiesta D'ordine</h2>
    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="Codice" Text="Codice" runat="Server"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="id" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <asp:Label ID="Descrizione" Text="Descrizione" runat ="Server"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="descr" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <asp:Button ID="TextBox1" OnClick="Cerca" Text="Cerca" runat="server"></asp:Button>
        </div>
    </div>
    <div class="table" style="margin-top:25px">
        <asp:Table ID="Table1" runat="server" width="100%"
            CellPadding="10"
            GridLines="None"
            HorizontalAlign="Center">
        </asp:Table>
    </div>
</asp:Content>

