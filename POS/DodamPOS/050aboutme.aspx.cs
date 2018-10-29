using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _005aboutme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dodam.Attributes.Add("onclick", "javascript:window.open('dodam.aspx','window','height=600,width=800,scrollbars');");
            isabella.Attributes.Add("onclick", "javascript:window.open('https://en.wikipedia.org/wiki/Isabella_d%27Este','window','height=600,width=800,scrollbars');");
        }
    }
}