<%@ Page 
    Title="Dettaglio Prodotto" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Detail.aspx.cs" 
    Inherits="WebApplication1._Detail" 
%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dettaglio Prodotto</h2>
    <div class="text-danger">
        <asp:ValidationSummary runat="server" />
    </div>
    <% if(p != null){ %>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Codice" Text="Codice" runat="Server"></asp:Label>
            </div>
            <div class="col-md-2">
                <% =codice %>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Descrizione" Text="Descrizione" runat ="Server"></asp:Label>
            </div>
            <div class="col-md-2">
                <% =descrizione %>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label1" Text="Quantita" runat ="Server"></asp:Label>

            </div>
            <div class="col-md-2">
                <asp:TextBox TextMode="Number" ID="quantita" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="ReqFieldValCodice"
                    ControlToValidate="quantita"
                    Display="Static"
                    CssClass="text-danger"
                    ErrorMessage="Inserisci la quantità"
                    runat="server" />
                <asp:RangeValidator
                    ID="RangeValCodice"
                    runat="server"
                    ControlToValidate="quantita"
                    Display="Static"
                    ErrorMessage="Devi scegliere da 1 a 5"
                    CssClass="text-danger"
                    Type="Integer"
                    MinimumValue="1"
                    MaximumValue="5" />
                <asp:CustomValidator
                    ID="CustomValidator1"
                    ControlToValidate="quantita"
                    Display="Static"
                    ErrorMessage="Scegli solo 3"
                    OnServerValidate="ControllaQuantita"
                    runat="server"></asp:CustomValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Button ID="TextBox1" OnClick="Add" Text="Aggiungi Al carrello" runat="server"></asp:Button>
            </div>
        </div>
    <%}else{ %>
        <div>
            <p>Nessun elemento trovato</p>
        </div>
    <%}%>
</asp:Content>