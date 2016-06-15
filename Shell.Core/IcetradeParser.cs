using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell.Core
{
    class IcetradeParser
    {
        //private string documentText = string.Empty;

        //public Tender GetTender(string url)
        //{
        //    Tender tender = new Tender();

        //    GetTenderPage(url);

        //    while (documentText == string.Empty)
        //    {
        //        Application.DoEvents();
        //    }

        //    XDocument xmlDoc = ConvertHTMLtoXML(documentText);

        //    try
        //    {
        //        tender.FullName = xmlDoc.XPathSelectElement("/body/div/div/div/div/div/div/div/div/div/h1").Value.Replace("\n", "").Replace("\r", "").Replace("\t", "").Trim();
        //        tender.Name = tender.FullName.Substring(20);
        //        tender.Year = tender.Name.Substring(0, 4);
        //        tender.Id = tender.Name.Substring(5);

        //        var table = xmlDoc.XPathSelectElement("/body/div/div/div/div/div/div/div/div/div/div/div/table");

        //        foreach (var item in table.Elements())
        //        {
        //            var header = item.Elements().ElementAt(0).Value.Trim();

        //            if (item.Elements().Count() == 2)
        //            {
        //                var value = item.Elements().ElementAt(1).Value.Trim();

        //                if (Regex.IsMatch(header, @"(\d\d\.\d\d\.\d\d\d\d)((.|\n)*?)(\d\d:\d\d:\d\d)"))
        //                {
        //                    try
        //                    {
        //                        var dates = header.Split(new string[] { "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
        //                        var date = dates[0];
        //                        var time = dates[1];

        //                        tender.Events.Add(new TenderEvent()
        //                        {
        //                            Date = date,
        //                            Time = time,
        //                            EventName = value
        //                        });
        //                    }
        //                    catch (Exception eventEx)
        //                    {

        //                    }
        //                }
        //                else if (header.Equals(string.Empty))
        //                {
        //                    try
        //                    {
        //                        var regexString = "(?:href=\"([^\"]*?)\">)" + value.Split(new string[] { "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("(", @"\(").Replace(")", @"\)");
        //                        var documentMatches = Regex.Matches(documentText, regexString);
        //                        var documentURL = documentMatches[0].Groups[1].Value.Replace("getFile", "download");

        //                        WebClient client = new WebClient();
        //                        client.Credentials = CredentialCache.DefaultCredentials;
        //                        client.Proxy.Credentials = CredentialCache.DefaultCredentials;
        //                        var doc = new byte[0]; //client.DownloadData(documentURL);

        //                        tender.Documents.Add(new TenderDocument()
        //                        {
        //                            URL = documentURL,
        //                            Name = "",
        //                            Document = doc
        //                        });
        //                    }
        //                    catch (Exception docEx)
        //                    {

        //                    }
        //                }
        //                else if (value != string.Empty)
        //                {
        //                    tender.Fields.Add(new TenderField() { Header = header, Value = value });
        //                }
        //            }
        //            else
        //            {
        //                if (!header.StartsWith("Лоты") && !header.StartsWith("№ лота") && !header.StartsWith("Аукционные документы") && !header.StartsWith("События в хронологическом порядке"))
        //                {
        //                    //tender.Fields.Add(new TenderField() { Header = header });
        //                }
        //            }
        //        }

        //        var lotsTable = table.XPathSelectElement("//table/tr/td/form/table");
        //        int lastLot = 1;
        //        try
        //        {
        //            lastLot = int.Parse(lotsTable.Elements().Last().Attribute(XName.Get("id")).Value.Last().ToString());
        //        }
        //        catch
        //        { }

        //        for (int i = 1; i <= lastLot; i++)
        //        {
        //            var lot = GetLot(i, int.Parse(tender.Id), 0);

        //            var lotElement = lotsTable.XPathSelectElement("//table/tr[@id='lotRow1']");
        //            if (lotElement != null)
        //            {
        //                string node = lotElement.ToString();
        //                node = Regex.Replace(node, "(?:<(\\w+)(?:\\s)+\\w+=\"(?:.|\n)*?\"(?:\\s)*>)", "<$1>");
        //                node = Regex.Replace(node, "(?:<span>((?:.|\n)*?)</span>)", "$1");
        //                node = Regex.Replace(node, "(<b>(\\s|\n)*?</b>)", "");
        //                var lotDoc = XDocument.Parse(node);

        //                for (int j = 0; j < lotDoc.Root.Elements().Count(); j++)
        //                {
        //                    var item = lotDoc.Root.Elements().ElementAt(j);
        //                    var value = item.Value.Trim();

        //                    if (!value.Equals(string.Empty))
        //                    {
        //                        switch (j)
        //                        {
        //                            case 0:
        //                                lot.LotNumber = value;
        //                                break;
        //                            case 1:
        //                                lot.Item = value;
        //                                break;
        //                            case 2:
        //                                lot.NumberAndCount = value;
        //                                break;
        //                            case 3:
        //                                lot.Status = value;
        //                                break;
        //                            default:
        //                                var x = 9;
        //                                break;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {

        //            }

        //            tender.Lots.Add(lot);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        documentText = string.Empty;
        //    }

        //    return tender;
        //}

        //private XDocument ConvertHTMLtoXML(string documentText)
        //{
        //    XDocument xmlDoc;

        //    try
        //    {
        //        var html = Regex.Match(documentText, @"((?:<body>)(?:.|\n)*?(?:<\/body>))").Groups[1].Value;
        //        html = Regex.Replace(html, "((?:<!--//)(?:.|\n)*?//-->)", "");
        //        html = Regex.Replace(html, "((?:<script)(?:.|\n)*?(?:</script>))", "");
        //        html = Regex.Replace(html, "(?:<a((?:.|\n)*?)</a>)", "<b$1</b>");
        //        html = Regex.Replace(html, "(</a>)", "");
        //        html = Regex.Replace(html, "(<div id=\"footer\">(?:.|\n)*?</div>)", "");
        //        html = Regex.Replace(html, "(<img(?:.|\n)*?>)", "");
        //        html = Regex.Replace(html, "(href=\"[^\"]*?\")", "");
        //        html = Regex.Replace(html, "(target=\"(?:.)*?\")", "");
        //        html = Regex.Replace(html, "(&laquo;|&nbsp;|&ndash;)", "");
        //        html = Regex.Replace(html, "(?:<b>((?:.|\n)*?)</b>)", "$1");
        //        html = Regex.Replace(html, "(<b onclick(?:.|\n)*?</b>)", "");
        //        html = Regex.Replace(html, "(<br>|<br/>|<br />)", "");
        //        xmlDoc = XDocument.Parse(html);
        //    }
        //    catch (Exception ex)
        //    {
        //        xmlDoc = new XDocument();
        //    }

        //    return xmlDoc;
        //}

        //private void GetTenderPage(string url)
        //{
        //    System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
        //    browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(ParseDocument);
        //    browser.Url = new Uri(url);
        //}

        //private void ParseDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    System.Windows.Forms.WebBrowser browser = ((System.Windows.Forms.WebBrowser)sender);
        //    documentText = browser.DocumentText;
        //    browser.Dispose();
        //}

        //private TenderLot GetLot(int id, int auction_id, int revision_id)
        //{
        //    TenderLot result = new TenderLot();

        //    try
        //    {
        //        var request = (HttpWebRequest)WebRequest.Create("http://www.icetrade.by/lots/view");

        //        var postData = string.Format("id={0}&auction_id={1}&revision_id={2}", id, auction_id, revision_id);

        //        var data = Encoding.ASCII.GetBytes(postData);

        //        request.Method = "POST";
        //        request.ContentType = "application/x-www-form-urlencoded";
        //        request.ContentLength = data.Length;

        //        using (var stream = request.GetRequestStream())
        //        {
        //            stream.Write(data, 0, data.Length);
        //        }

        //        request.Credentials = CredentialCache.DefaultCredentials;
        //        request.Proxy.Credentials = CredentialCache.DefaultCredentials;

        //        var response = (HttpWebResponse)request.GetResponse();

        //        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        //        responseString = Regex.Replace(responseString, "(&laquo;|&nbsp;|&ndash;)", "");
        //        responseString = Regex.Replace(responseString, "(?:<div>((?:.|\n)*?)</div>)", "$1");
        //        responseString = Regex.Replace(responseString, "(?:<(\\w+)(?:\\s)+\\w+=\"(?:.|\n)*?\"(?:\\s)*>)", "<$1>");
        //        responseString = Regex.Replace(responseString, "(<td>(\\s|\n)*?</td>)", "");

        //        if (!responseString.Equals(string.Empty))
        //        {
        //            XDocument lotDoc = XDocument.Parse("<root>" + responseString + "</root>");

        //            foreach (var item in lotDoc.Root.Elements())
        //            {
        //                if (item.Elements().Count() > 0)
        //                {
        //                    var header = item.Elements().ElementAt(0).Value.Trim();

        //                    if (item.Elements().Count() > 1)
        //                    {
        //                        var value = item.Elements().ElementAt(1).Value.Trim();

        //                        result.Fields.Add(new TenderField() { Header = header, Value = value });
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return result;
        //}
    }
}
