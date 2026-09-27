Imports System.Net
Imports System.IO

Partial Class demo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SendSMS("9810296622", "9810296622", "Hi")
        Dim sURL As String
        Dim objReader As StreamReader
        sURL = "http://ubaid.tk/sms/sms.aspx?uid=9810296622&pwd=way2smspwd&msg=Hi&phone = 9810296622 & provider=way2sms"
        Dim sResponse As WebRequest
        sResponse = WebRequest.Create(sURL)
        Try
            Dim objStream As Stream
            objStream = sResponse.GetResponse.GetResponseStream()
            objReader = New StreamReader(objStream)
            Response.Write(objReader.ReadToEnd())
            objReader.Close()
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Sub SendSMS(ByVal FromNumber As String, ByVal ToNumber As String, ByVal SMS As String)
        Response.ContentType = "text/xml; charset=utf-8"
        Dim url As String = "https://www.sendandreceivesms.com/api/"
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        Dim postData As String = "FromNumber=" & FromNumber
        postData += "&"
        postData += "ToNumber=" & ToNumber
        postData += "&"
        postData += "SMS=" & SMS
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.Headers.Add("APIToken", "GoOu9H0h9G")
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim _webresponse As WebResponse = request.GetResponse()
        dataStream = _webresponse.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Response.Write(responseFromServer)
        reader.Close()
        dataStream.Close()
        'Response.Close()     
    End Sub
End Class