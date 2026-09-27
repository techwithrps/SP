Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_IsoCodeMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvISOcode.Visible = False
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Sub LoadTreeViewData()
        Dim pIsoCode As New IsoCode
        'pIsoCode.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As IsoCode In IsoCode.ReturnIsoCodeList(pIsoCode)
                Functions.treeViewNodeSetup(tvISOcode, "0", obj.IsoCodeId, obj.IsoCode)
                Exit For
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvISOcode.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvISOcode.SelectedNode.ValuePath
            tvISOcode.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvISOcode.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Private Sub selectFirstNode()
        If tvISOcode.Nodes.Count > 0 Then
            tvISOcode.Nodes(0).Selected = True
            prepareControls(tvISOcode.Nodes(0))
        End If
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textISOCode.Text.Trim <> Nothing Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then

        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'tvISOcode.Nodes.Clear()
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvISOcode.Enabled = False
        textSearchIsoCode.Text = ""
        textSearchIsoCode.Enabled = False
        Functions.ControlFocus(textISOCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textISOCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvISOcode.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textISOCode)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvISOcode.SelectedNode Is Nothing Then
            prepareControls(tvISOcode.SelectedNode)
        End If
        manageUserControls(True)
        tvISOcode.Enabled = True
        textSearchIsoCode.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvISOcode_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvISOcode.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvISOcode.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textISOCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblISOCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textISOCode)
            Return rtnBool
            Exit Function
        End If
        If textISODescription.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblISODescription.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textISODescription)
            Return rtnBool
            Exit Function
        End If
        If textContSize.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContSize.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textContSize)
            Return rtnBool
            Exit Function
        End If
        If textContType.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContType.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textContType)
            Return rtnBool
            Exit Function
        End If
        If textTareWeight.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTareWeight.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTareWeight)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pIsoCode As IsoCode = ReturnObject()
        If hdnISOId.Value <> Nothing Then
            IsoCode.Update(pIsoCode)
        Else
            IsoCode.Insert(pIsoCode)
        End If

        If pIsoCode.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pIsoCode.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvISOcode, pIsoCode.IsoCode, pIsoCode.IsoCodeId, hdnISOId.Value)
        hdnISOId.Value = pIsoCode.IsoCodeId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvISOcode.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As IsoCode
        Dim p As New IsoCode
        If hdnISOId.Value <> "" AndAlso hdnISOId.Value > 0 Then
            p.IsoCodeId = hdnISOId.Value
        End If
        'p.TerminalId = Session.Item("LoginTerminal")
        p.IsoCode = textISOCode.Text
        p.IsoCodeDetails = textISODescription.Text
        p.ContSize = textContSize.Text
        p.ContType = textContType.Text
        p.TareWt = textTareWeight.Text
        Try
            p.Width = textWidth.Text
        Catch ex As Exception
        End Try
        Try
            p.Length = textLength.Text
        Catch ex As Exception
        End Try
        Try
            p.Height = textHeight.Text
        Catch ex As Exception
        End Try
        Try
            p.HazClass = textHazClass.Text
        Catch ex As Exception

        End Try
        If chkHighCubeStatus.Checked = True Then
            p.HighCubeStatus = "Y"
        Else
            p.HighCubeStatus = "N"
        End If
        If chkRefferStatus.Checked = True Then
            p.ReeferStatus = "Y"
        Else
            p.ReeferStatus = "N"
        End If
        If chkOpenTopStatus.Checked = True Then
            p.OpenTopStatus = "Y"
        Else
            p.OpenTopStatus = "N"
        End If
        If chkHazStatus.Checked = True Then
            p.HazStatus = "Y"
        Else
            p.HazStatus = "N"
        End If
        p.CreatedBy = Session.Item("LoginUser")
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New IsoCode
        'p.TerminalId = Session.Item("LoginTerminal")
        p.IsoCodeId = pCodevalue.Value
        IsoCode.ReturnIsoCode(p)
        hdnISOId.Value = p.IsoCodeId
        textISOCode.Text = p.IsoCode
        textISODescription.Text = p.IsoCodeDetails
        textContSize.Text = p.ContSize
        textContType.Text = p.ContType
        textTareWeight.Text = p.TareWt
        textWidth.Text = p.Width
        textLength.Text = p.Length
        textHeight.Text = p.Height
        textHazClass.Text = p.HazClass
        If p.HighCubeStatus = "Y" Then
            chkHighCubeStatus.Checked = True
        End If
        If p.ReeferStatus = "Y" Then
            chkRefferStatus.Checked = True
        End If
        If p.OpenTopStatus = "Y" Then
            chkOpenTopStatus.Checked = True
        End If
        If p.HazStatus = "Y" Then
            chkHazStatus.Checked = True
        End If
    End Sub
    Protected Sub btnSearchIsoCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchIsoCode.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textSearchIsoCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The search Value")
            Functions.ControlFocus(textSearchIsoCode)
            Exit Sub
        End If
        tvISOcode.Nodes.Clear()
        LoadTreeViewDataIsoCode()
        If tvISOcode.Nodes.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Record Not Found")
        End If
        tvISOcode.Visible = True
    End Sub
    Sub LoadTreeViewDataIsoCode()
        Dim pIsoCode As New IsoCode
        'pIsoCode.TerminalId = Session.Item("LoginTerminal")
        pIsoCode.IsoCode = textSearchIsoCode.Text.Trim
        Try
            For Each obj As IsoCode In IsoCode.ReturnIsoCodeSearchByIsoCode(pIsoCode)
                Functions.treeViewNodeSetup(tvISOcode, "0", obj.IsoCodeId, obj.IsoCode)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class