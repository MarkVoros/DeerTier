<%@ Page Title="Deer Force Hall of Fame" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SuperMetroidLeaderboard.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainPageContent">
        <div class="title">
            <h1>Welcome, Super Metroid Speedrunners!</h1>
        </div>

        <div class="japaneseTitle">
            ようこそ、日本のスーパーメトロイドスピードラナーズ!
        </div>

        <br />
        Hello and welcome to the <b>Deer Force Hall of Fame</b>! The aim of this site is to showcase the
        best of the best in the <b>Super Metroid</b> speedrunning community. Submit your records and see how you stack up against your fellow speedrunners!
        <br /><br />
        Please note that the leaderboards on this site are for the NTSC version of the game. Times should also follow
        <a href="http://speedrunslive.com/" target="_blank"><span class="link">SpeedRunsLive</span></a> conventions. To quote the rules, this means:
        <br /><br />

        <div class="quoteContainer">
            <div class="quote">
                <ul>
                    <li>All files ... should start at 0:00 with the intro sequence completed so play begins in the Ceres station.</li>
                    <li>SNES9x 1.43 and ZSNES are banned.</li>
                    <li>Gold Torizo code is banned.</li>
                    <li>Save the critters at your own discretion.</li>
                </ul>
            </div>
        </div>
    
        <br />


        In addition, the leaderboards operate on the honour system. Please do not attempt to pass off fake records as your own. 
        If any times look suspicious, they may be removed. The best way to establish credibility is to hang out and race with the 
        <a href="http://speedrunslive.com/gamelist/#!/supermetroid/1" target="_blank"><span class="link">SRL Super Metroid community</span></a>. 
        With that said, enjoy the competition! Will you ascend to <span class="deerTierFont">Deer Tier?</span>
    </div>
</asp:Content>
