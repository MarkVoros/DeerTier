<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="SuperMetroidLeaderboard.SignUp" %>

<%@ Import Namespace="SuperMetroidLeaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="signUp">
        <h1>Sign Up</h1>
        <br />

        <div class="loginSignUpForm">
            Username:
            <asp:TextBox ID="UsernameTextbox" runat="server" /><br />
            Password:
            <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password" /><br />
            Confirm password:
            <asp:TextBox ID="ConfirmedPasswordTextbox" runat="server" TextMode="Password" /><br />
        </div>

        <div class="genericButton">
            <asp:Button id="SubmitButton" runat="server" Text="Submit" />
        </div>

        <div class="statusLiteral">
            <asp:Literal ID="StatusLiteral" runat="server" />
        </div>
        
        <br />

    </div>
</asp:Content>
