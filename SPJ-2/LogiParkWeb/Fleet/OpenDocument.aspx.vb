Imports System.Net
Partial Class Fleet_OpenDocument

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
   
         Dim filepath As String = Request.QueryString("filepath")
        'Dim User As New WebClient()
        'Dim FileBuffer As [Byte]() = User.DownloadData(filepath)
        'If FileBuffer IsNot Nothing Then
        '    Response.ContentType = "application/pdf"
        '    Response.AddHeader("content-length", FileBuffer.Length.ToString())
        '    Response.BinaryWrite(FileBuffer)
        'End If
        Dim file As New System.IO.FileInfo(filepath)
        If (file.Exists) Then
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "application/pdf"
            Response.WriteFile(file.FullName)
            Response.[End]()
            Response.Close()
            file = Nothing
        End If





    End Sub
End Class
