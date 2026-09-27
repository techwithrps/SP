Imports System.IO.Ports
Partial Class testweight
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click

        Dim sp As New SerialPort()
        sp.PortName = "COM1"
        sp.BaudRate = 9600
        sp.DataBits = 8
        sp.Open()
        textWieght.text = sp.ReadLine().ToString()
        sp.Close()

    End Sub
End Class
