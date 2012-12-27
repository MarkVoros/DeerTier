<%@ Page Title="Add Time" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddTime.aspx.cs" Inherits="SuperMetroidLeaderboard.AddTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="addTime">
        <div class="addTimeTitle">
            <asp:Literal ID="titleLiteral" runat="server" />
        </div>

        <br />

        <div class="addTimeForm">
            Real time:<br />            
            <asp:TextBox CssClass="addTimeTextField" ID="realTimeTextBox" runat="server" /><br />

            <asp:PlaceHolder ID="gameTimePlaceHolder" runat="server" >
                Game time:</br>
                <asp:TextBox CssClass="addTimeTextField" id="gameTimeTextBox" runat="server" /><br />
            </asp:PlaceHolder>

            Video URL:<br />
            <asp:TextBox CssClass="videoLinkTextField" ID="videoLinkTextBox" runat="server" /><br />

            Comment:</br>
            <asp:TextBox CssClass="commentTextField" ID="commentTextBot" runat="server" /><br />
        </div>


        <div class="genericButton">
            <asp:Button ID="submitButton" runat="server" Text="Submit" />
        </div>
    
        <div class="statusLiteral">
            <asp:Literal ID="StatusLiteral" runat="server" />
        </div>
    </div>

</asp:Content>
