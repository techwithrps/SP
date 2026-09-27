Imports LogiParkLib.LogiParkObjects
Partial Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Home_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim pCM As New CompanyMaster()

        pCM.CompanyId = Session.Item("CompanyId")
        CompanyMaster.ReturnCompanyMasterbyId(pCM)

        If pCM.Logo Is "" Then
            Logo.ImageUrl = "~/Master/Images/" + pCM.Logo
        Else
            Logo.ImageUrl = "~/Master/Images/" + pCM.Logo
        End If
    End Sub
End Class
