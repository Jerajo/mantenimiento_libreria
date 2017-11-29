<%@ Page Title="Mantenimiento Generos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Genero.aspx.cs" Inherits="webLibreria.Mantenimientos.Genero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="w3-row"></div>
    <hr />
    <div class="w3-row">

        <div class="w3-third">
            <p></p>
        </div>
        <div class="w3-twothird">
            <asp:GridView ID="Listado" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="Listado_SelectedIndexChanged" OnRowUpdating="Update" OnRowCancelingEdit="Listado_RowCancelingEdit" OnRowDeleting="Delete" OnRowEditing="Listado_RowEditing" OnRowDataBound="Listado_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            
                            <asp:Label runat='server' ID='lbID' Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Genero">
                        <ItemTemplate>
                            <asp:Label runat='server' ID='lbName' Text='<%# Eval("Genero") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Genero") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total de libros" ItemStyle-CssClass="w3-center">
                        <ItemTemplate >
                            <asp:Label runat='server' ID='lbTotal' Text='<%# Eval("Total_Libros") %>'></asp:Label>
                        </ItemTemplate>

<ItemStyle CssClass="w3-center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"  HeaderText="Acciones" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibreriaHC_ConString %>" SelectCommand="SELECT * FROM [vwGenerosLibrosCount]"></asp:SqlDataSource>
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-third">
            <p></p>
        </div>
        <div class="w3-twothird">
            Genero:<br />
            <asp:TextBox ID="txtGenero" runat="server" Width="140" />
            &nbsp;
            <asp:Button ID="btnAdd" runat="server" Text="Añadir" OnClick="btnAdd_Click" />

        </div>
    </div>

    <div class="w3-row"></div>


</asp:Content>
