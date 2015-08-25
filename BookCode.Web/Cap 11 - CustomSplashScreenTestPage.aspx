<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CustomSplashScreen</title>
    <style type="text/css">
    html, body {
	    height: 100%;
	    overflow: auto;
    }
    body {
	    padding: 0;
	    margin: 0;
    }
    #silverlightControlHost {
	    height: 100%;
	    text-align:center;
    }
    </style>
    <!-- custom splash -->
    <script type="text/javascript">
        function onSourceDownloadProgressChanged(sender, eventArgs) {
            var progressBar = sender.findName("progressBar");
            var progressBg = sender.findName("progressBg");
            var txtProgress = sender.findName("txtProgress");
            if (eventArgs.progress) {
                txtProgress.Text = Math.round(eventArgs.progress * 100) + "%";
                progressBar.Width = eventArgs.progress * progressBg.Width;
            }
            else {
                txtProgress.Text = Math.round(eventArgs.get_progress() * 100) + "%";
                progressBar.Width = eventArgs.get_progress() * progressBg.Width;
            }

        }

        function onSourceDownloadCompleted(sender, eventArgs) {
            var txtProgress = sender.findName("txtProgress");
            txtProgress.Text = "100%";
        }
    </script>

    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
              appSource = sender.getHost().Source;
            }
            
            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
              return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " +  appSource + "\n" ;

            errMsg += "Code: "+ iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {           
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " +  args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
    </script>
</head>
<a href="default.aspx">Torna all'indice</a>
    <br />
<body style="background-image: url('/bg.jpg')">
    <form id="form1" runat="server" style="height:100%">
    <div id="silverlightControlHost">
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		  <param name="source" value="ClientBin/CustomSplashScreen.xap?<%= DateTime.Now.Ticks %>"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="blue" />
		  <param name="minRuntimeVersion" value="4.0.50826.0" />
		  <param name="autoUpgrade" value="true" />
          <param name="splashscreensource" value="SplashScreen.xaml"/>    
          <param name="onSourceDownloadProgressChanged" value="onSourceDownloadProgressChanged" /> 

		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50826.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object>
        <iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>
    </form>
</body>
</html>
