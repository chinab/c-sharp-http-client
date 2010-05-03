/* Copyright (c) 2010 CodeScales.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CodeScales.Http.Common;

namespace CodeScales.Http.Tests.Server
{
    public partial class HttpMultipartPost200 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageData msgData = new MessageData();
            if (Request.Form != null
                && Request.Form.Count > 0)
            {
                foreach (string s in Request.Form.AllKeys)
                {
                    msgData.PostParameters.Add(new NameValuePair(s, Request.Form[s]));
                }                
            }
                        
            if (Request.Cookies != null
                && Request.Cookies.Count > 0)
            {
                foreach (string s in Request.Cookies.AllKeys)
                {
                    msgData.Cookies.Add(new NameValuePair(s, Request.Cookies[s].Value));
                }
            }

            if (Request.Files != null
                && Request.Files.Count > 0)
            {
                foreach (string key in Request.Files.AllKeys)
                {
                    msgData.Files.Add(new NameValuePair(Request.Files[key].FileName, Request.Files[key].ContentLength.ToString()));
                }
            }
            Response.Write(msgData.ToString());
        }
    }
}