<%@ Page 
    Title="U carrellino" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Cart.aspx.cs" 
    Inherits="WebApplication1._Cart" 
%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Carrello</h2>
    <div>
        <ul class="list-group">
            <% if(products != null){ 
                    foreach(var p in products){ %>
                        <li><% =p.Codice %>, <%=p.Descrizione%></li>
                    <%}
             } %>
        </ul>
    </div>
    <div>
        <asp:Button ID="TextBox1" OnClick="Pulisci" Text="Pulisci carrello" runat="server"></asp:Button>
    </div>
</asp:Content>
