using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    //PROFANITY FILTER
    string testProfanity = "This is a test you little bitch"; //test variable that's passed in for now. This can be exchanged with textbox data.
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        byte[] buf = new byte[8192];

        //do get request
        HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create("http://www.purgomalum.com/service/plain?text=" + testProfanity);


        HttpWebResponse response = (HttpWebResponse)
            request.GetResponse();


        Stream resStream = response.GetResponseStream();

        string tempString = null;
        int count = 0;
        //read the data and print it
        do
        {
            count = resStream.Read(buf, 0, buf.Length);
            if (count != 0)
            {
                tempString = Encoding.ASCII.GetString(buf, 0, count);

                sb.Append(tempString);
            }
        }
        while (count > 0);
        Response.Write(sb.ToString());
    }
    //
}

