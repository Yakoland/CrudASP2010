<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="stefanini2.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Personas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PanelMod" runat="server">
        asd</asp:Panel>
    <asp:Panel ID="PanelCon" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label">Filtrar Nombre : </asp:Label>
        <asp:TextBox
            ID="txtNombre" runat="server">
        </asp:TextBox>
        <asp:Button
            ID="btnBuscar" runat="server" Text="Button" onclick="btnBuscar_Click" />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            AllowPaging="True" OnPageIndexChanging="paginacion" GridLines="None" 
            PageSize="12" AutoGenerateColumns="False" 
            onrowcommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField ButtonType="Image" DataTextField="Id" HeaderText="Editar" 
                    ImageUrl="~/Imagenes/b_edit.gif" Text="Botón">
                <HeaderStyle Width="55px" />
                </asp:ButtonField>
                <asp:BoundField DataField="Id" HeaderText="Id">
                <HeaderStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                <HeaderStyle Width="160px" />
                </asp:BoundField>
                <asp:BoundField DataField="Inicial" HeaderText="Inicial">
                <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Apellido" HeaderText="Apellido">
                <HeaderStyle Width="160px" />
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" DataTextField="Id" HeaderText="Eliminar" 
                    ImageUrl="~/Imagenes/delete.gif" Text="Botón" CommandName="Borrar" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" CssClass = "titulosgrid" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelAdd" runat="server">
    </asp:Panel>
</asp:Content>
