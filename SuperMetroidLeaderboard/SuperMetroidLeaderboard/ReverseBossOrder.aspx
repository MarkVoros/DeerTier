<%@ Page Title="Reverse Boss Order" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReverseBossOrder.aspx.cs" Inherits="SuperMetroidLeaderboard.ReverseBossOrder" %>
<%@ Import Namespace="SuperMetroidLeaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="floatLeft">
        <h1>Reverse Boss Order</h1>
    </div>
    
    <div id="submitButton">
        <h2>
            <asp:Button ID="aspSubmitButton" runat="server" text="Submit Time"/>
        </h2>
    </div>
    
    <div class="clear"></div>

    <div class="scoreTable">
        <table>
            <tr>
                <th class="rankColumn">
                    Rank
                </th>
                <th class="playerColumn">
                    Player
                </th>
                <th style="width:160px">
                    Real Time
                </th>
                <th class="proofColumn">
                    Video
                </th>
                <th class="commentColumn">
                    Comment
                </th>
            </tr>

            <asp:Repeater ID="GameTimeRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# ((Score)Container.DataItem).getRank() %>
                        </td>
                        <td>
                            <%# ((Score)Container.DataItem).getPlayer() %>
                        </td>
                        <td>
                            <%# ((Score)Container.DataItem).getRealTimeString() %>
                        </td>
                        <td class="videoLink">
                            <%# ((Score)Container.DataItem).getVideoURLAsLink()%>
                        </td>
                        <td>
                            <%# ((Score)Container.DataItem).getComment() %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </div>
</asp:Content>
