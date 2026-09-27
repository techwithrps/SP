Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml

Partial Class Fleet_VehicleMaster
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 0
    Dim arrRailOperator As ArrayList


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ButtonControlSetup(True)
           
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If

        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        manageUserControls(True)

        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Private Sub SetDefaultView()
        mvVehicleMster.ActiveViewIndex = 0
    End Sub
    Protected Sub lnkEquipMentSummary_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 0
    End Sub
    Protected Sub lnkTireAndWheels_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 1
    End Sub
    Protected Sub lnkParts_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 2
    End Sub
    Protected Sub lnkFilter_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 3
    End Sub
    Protected Sub lnkDocuments_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 4
    End Sub
    Protected Sub lnkGrDtls_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 5
    End Sub

    Protected Sub lnkLubeService_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 6
    End Sub
    Protected Sub lnkRepairs_Click(sender As Object, e As EventArgs)
        mvVehicleMster.ActiveViewIndex = 7
    End Sub
    

End Class
