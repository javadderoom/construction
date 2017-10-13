<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        //Grab the URL for matching the pattern. Returns the current URL path.
        //e.g. http://example.com/displayproduct/1/visual-studio
        HttpContext incoming = HttpContext.Current;
        string oldpath = incoming.Request.Path.ToLower();
     
        //Declare variables for Query Strings.
        string productid = string.Empty;
        string productname = string.Empty;
       
        // Regular expressions to grab the productid and productname from the page.aspx
        //Here I am using regular expression to match tghe pattern.
        Regex regex = new Regex(@"displayproduct/(\d+)/(.+)", RegexOptions.IgnoreCase
        | RegexOptions.IgnorePatternWhitespace);
        MatchCollection matches = regex.Matches(oldpath);

        //If Matches found then Grab the product id and name and rewrite it as our typical query string format.
        //e.g: http://example.com/page.aspx?productid=1&productname=visual-studio
        if (matches.Count > 0)
        {
            productid = matches[0].Groups[1].ToString();
            productname = matches[0].Groups[2].ToString();
            incoming.RewritePath(String.Concat("~/page.aspx?productid=", productid, "&productname=", productname ), false);
        }
    }
       
</script>
