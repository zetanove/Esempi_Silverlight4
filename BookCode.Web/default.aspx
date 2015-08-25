<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BookCode.Web._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            color: #000099;
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/copertina.jpg" 
                        Width="200px" />
                </td>
                <td>
    
        <span class="style2"><strong>Sorgenti degli esempi del libro 
                    <a href="http://www.fag.it/scheda.aspx?ID=38841">Silverlight 4 Guida alla 
                    Programmazione</a></strong></span></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>Capitolo</b></td>
                <td>
                    <b>Descrizione</b></td>
                <td>
                    <b>link</b></td>
            </tr>
            <tr>
                <td>
                    Capitolo 2</td>
                <td>
                    Hello Silverlight</td>
                <td>
                    <a href="Cap%2002%20-%20HelloSilverlightTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td rowspan="4">
                    Capitolo 3</td>
                <td>
                    Attached Properties</td>
                <td>
                    <a href="Cap%2003%20-%20AttachedPropertiesTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Markup Extensions</td>
                <td>
                    <a href="Cap%2003%20-%20MarkupExtensionsTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Resources</td>
                <td>
                    <a href="Cap%2003%20-%20ResourcesTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    XAML Properties</td>
                <td>
                    <a href="Cap%2003%20-%20ResourcesTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Capitolo 4</td>
                <td>
                    Layout containers</td>
                <td>
                    <a href="Cap%2004%20-%20LayoutContainersTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td rowspan="2">
                    Capitolo 5</td>
                <td>
                    Navigation</td>
                <td>
                    <a href="Cap%2005%20-%20NavApplicationTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    User Interfaces</td>
                <td>
                    <a href="Cap%2005%20-%20UserInterfacesTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Capitolo 6</td>
                <td>
                    Graphics</td>
                <td>
                    <a href="Cap%2006%20-%20GraphicsTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Capitolo 7</td>
                <td>
                    Animations</td>
                <td>
                    <a href="Cap%2007%20-%20AnimationsTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Capitolo 8</td>
                <td>
                    Multimedia</td>
                <td>
                    <a href="Cap%2008%20-%20MultimediaTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Capitolo 9</td>
                <td>
                    Style e Template</td>
                <td>
                    <a href="Cap%2009%20-%20StylingAndTemplatesTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Capitolo 10</td>
                <td>
                    Data binding</td>
                <td>
                    <a href="Cap%2010%20-%20DataBindingTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td rowspan="4">
                    Capitolo 11</td>
                <td>
                    Custom Splash Screen</td>
                <td>
                    <a href="Cap%2011%20-%20CustomSplashScreenTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Advanced Silverlight</td>
                <td>
                    <a href="Cap%2011%20-%20AdvancedSilverlightTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Out of browser</td>
                <td>
                    <a href="Cap%2011%20-%20OOBSilverlightTestPage.aspx">vai</a></td>
            </tr>
            <tr>
                <td>
                    Printing</td>
                <td>
                    <a href="Cap%2011%20-%20PrintingTestPage.aspx">vai</a></td>
            </tr>
        </table>
    
    </div>
    </form>
    <p>
        Gli esempi DeepZoom si trovano nella directory deepzoomsample, con apposita 
        soluzione Visual Studio</p>
</body>
</html>
