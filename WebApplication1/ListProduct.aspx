<%@ Page 
    Title="Lista prodotti" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="ListProduct.aspx.cs" 
    Inherits="WebApplication1._ListProduct" 
%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista prodotti</h2>
    <div>
        <% if(products.Count > 0){
                foreach(var p in products){ 
                    string proviamo = $"TextBox{p.Codice}"; %>
                    <div class="row">
                        <div class="col-md-2">
                            <% =p.Codice %>
                        </div>
                        <div class="col-md-2">
                            <%=p.Descrizione%>
                        </div>
                        <div style="display:none;">
                            <asp:Label ID="number" Text=<% Response.Write(proviamo);%> runat ="Server"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID=Button1 OnClick="Dettaglio" Text="Dettaglio" runat="server"></asp:Button>
                        </div>
                    </div>
                <%}
            }else{ %>
                <p>Nessun prodotto</p>
            <% }%>
    </div>
</asp:Content>
