<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SuperMetroidLeaderboard.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
        <h1>Log In</h1>
        <br />

        <div class="loginSignUpForm">
            Username:
            <asp:TextBox ID="UsernameTextBox" runat="server" /><br />
            Password:
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" /><br />
        </div>

        <div class="genericButton">
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" />
        </div>

        <div class="statusLiteral">
            <asp:Literal ID="StatusLiteral" runat="server" />
        </div>

    </div>
</asp:Content>
