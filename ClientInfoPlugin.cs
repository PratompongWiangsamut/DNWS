using System;
using System.Text;

namespace DNWS
{
  /// <summary>
  /// Gen HTML about client info using information from request header
  /// </summary>
  /// <returns>HTML client info</returns>

  public class ClientInfoPlugin : IPlugin
  {
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      StringBuilder sb = new StringBuilder();

      string[] client_endpoint = request.getPropertyByKey("RemoteEndPoint").Split(':');
      string val;
      sb.Append("<html><body>");
      sb.Append("Client Port: ").Append(client_endpoint[1]).Append("<br />\n");
      if ((val = request.getPropertyByKey("user-agent")) != null)
      {
        sb.Append("Browser Information: ").Append(val).Append("<br />\n");
      }
      if ((val = request.getPropertyByKey("accept-language")) != null)
      {
        sb.Append("Accept Language: ").Append(val).Append("<br />\n");
      }
      if ((val = request.getPropertyByKey("accept-encoding")) != null)
      {
        sb.Append("Accept Encoding: ").Append(val).Append("<br />\n");
      }
      sb.Append("</body></html>");
      HTTPResponse response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }

    public void PreProcessing(HTTPRequest request)
    {
      throw new NotImplementedException();
    }
  }
}//