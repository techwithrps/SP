Imports System.Net.Mail
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class Functions

    ' to insert the records in transport system 



    Public Shared Function TransportInterface(ByVal p_TO_LOCATION As Integer, ByVal p_BILLED_TO As Integer, ByVal p_LINE_ID As Integer, ByVal p_CONT_NO As String, ByVal p_CONT_SIZE As String, ByVal p_DOC_TYPE As String, ByVal p_PASS_NUMBER As Integer, ByVal p_PASS_DATE As String, ByVal p_SHIPPING_LINE As String, ByVal p_LOCATION_NAME As String, ByVal p_CUSTOMER_NAME As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim con As New SqlClient.SqlConnection("Data Source=server;Initial Catalog=INTERFACE;Persist Security Info=True;User ID=sa;Password=abc123$a")
            Dim cmd As New SqlCommand()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "insert into INTERFACE_DTLS( TO_LOCATION, BILLED_TO, LINE_ID, CONT_NO, CONT_SIZE, DOC_TYPE,  PASS_NUMBER,PASS_DATE,SHIPPINGLINE,STATION_NAME,CUSTOMER_NAME ) values ('" & p_TO_LOCATION & "','" & p_BILLED_TO & "','" & p_LINE_ID & "','" & p_CONT_NO & "','" & p_CONT_SIZE & "','" & p_DOC_TYPE & "','" & p_PASS_NUMBER & "','" & Convert.ToDateTime(p_PASS_DATE) & "','" & p_SHIPPING_LINE & "','" & p_LOCATION_NAME & "','" & p_CUSTOMER_NAME & "')"
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function
    Public Shared Function TransportGateinUpdate(ByVal p_GATE_IN_DATE As String, ByVal p_Pass_NO As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim con As New SqlClient.SqlConnection("Data Source=server;Initial Catalog=INTERFACE;Persist Security Info=True;User ID=sa;Password=abc123$a")

            Dim cmd As New SqlCommand()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "UPDATE INTERFACE_DTLS SET GATE_IN_DATE='" & p_GATE_IN_DATE & "' WHERE PASS_NUMBER='" & p_Pass_NO & "' "
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function
    Public Shared Function TransportGateOutUpdate(ByVal p_GATE_OUT_DATE As String, ByVal p_TRUCKNO As String, ByVal p_DRIVERNAME As String, ByVal p_Pass_NO As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim con As New SqlClient.SqlConnection("Data Source=server;Initial Catalog=INTERFACE;Persist Security Info=True;User ID=sa;Password=abc123$a")

            Dim cmd As New SqlCommand()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "UPDATE INTERFACE_DTLS SET GATE_OUT_DATE='" & p_GATE_OUT_DATE & "' WHERE PASS_NUMBER='" & p_Pass_NO & "' "
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function

    Public Shared Function TransportSelectGrNo(ByVal p_PASS_NUMBER As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim con As New SqlClient.SqlConnection("Data Source=server;Initial Catalog=INTERFACE;Persist Security Info=True;User ID=sa;Password=abc123$a")

            con.Open()
            Dim ada As SqlDataAdapter = New SqlDataAdapter("SELECT GR_PREF,GR_DATE,TRUCKNO,DRIVERNAME FROM INTERFACE_DTLS WHERE PASS_NUMBER='" & p_PASS_NUMBER & "' ", con)
            Dim ds As New DataSet("GL")
            ada.Fill(ds)
            returnStr = ds.Tables(0).Rows(0)("GR_PREF").ToString() & "," & ds.Tables(0).Rows(0)("GR_DATE").ToString() & "," & ds.Tables(0).Rows(0)("TRUCKNO").ToString() & "," & ds.Tables(0).Rows(0)("DRIVERNAME").ToString()
        Catch ex As Exception
            returnStr = ""
        End Try
        Return returnStr
    End Function

    Enum ErrMsgMode
        Errors = 1
        Message = 2
        Clear = 3
    End Enum

    Public Shared Function message_set(ByVal messagetext As String, ByVal bcolor As Drawing.Color, ByVal fcolor As Drawing.Color, ByVal errormessage As Label) As Label
        errormessage.Text = messagetext
        errormessage.BackColor = bcolor
        errormessage.ForeColor = fcolor
        Return errormessage
    End Function

    Public Shared Function setErrorMessage_img(ByVal lblErrorMessage As Label, ByVal pErrorMessage As String) As Label
        lblErrorMessage.ForeColor = Drawing.Color.Red
        lblErrorMessage.Text = pErrorMessage
        Return lblErrorMessage
    End Function

    Private Shared Sub MenuChildParentSetup(ByVal child_id As MenuItem, ByVal parentid As String, ByVal mnMenu As Menu, Optional ByVal parent As MenuItem = Nothing)
        Dim m1 As MenuItem
        Dim i As Integer = 0
        If parent Is Nothing Then
            For Each m1 In mnMenu.Items
                If m1.Value = parentid Then
                    mnMenu.Items(i).ChildItems.Add(child_id)
                    Exit For
                ElseIf m1.ChildItems.Count > 0 Then
                    MenuChildParentSetup(child_id, parentid, mnMenu, m1)
                End If
                i += 1
            Next
        Else
            For Each m1 In parent.ChildItems
                If m1.Value = parentid Then
                    parent.ChildItems(i).ChildItems.Add(child_id)
                    Exit For
                ElseIf m1.ChildItems.Count > 0 Then
                    MenuChildParentSetup(child_id, parentid, mnMenu, m1)
                End If
                i += 1
            Next
        End If
    End Sub

    Public Shared Sub ControlSetup(ByVal pEnable As Boolean, ByVal arrControl As ControlCollection)
        For i As Integer = 0 To arrControl.Count - 1
            If arrControl(i).HasControls Then

                ''Checks if the Control has some controls inside and calls same function recursively
                ControlSetup(pEnable, arrControl(i).Controls)

            ElseIf TypeOf (arrControl(i)) Is TextBox Then ''If it is a textbox
                Dim wbConrl As TextBox = arrControl(i)
                If pEnable Then
                    'wbConrl.Attributes("onkeydown") = "javascript:keyPressInput.kp_val();"
                Else
                    wbConrl.AutoCompleteType = AutoCompleteType.Disabled
                End If
                wbConrl.Attributes("onkeydown") = ""
                wbConrl.Enabled = Not pEnable
                'wbConrl.ReadOnly = pEnable
            ElseIf TypeOf (arrControl(i)) Is DropDownList _
                Or TypeOf (arrControl(i)) Is CheckBox _
                Or TypeOf (arrControl(i)) Is FileUpload Then ''If it is a DropDownList or CheckBox

                Dim wbConrl As WebControl = arrControl(i)
                wbConrl.Enabled = Not pEnable
            End If
        Next
    End Sub

    Public Shared Function findDataPathFromValuePath(ByVal tv As TreeView, ByVal valPath As String, Optional ByVal pathSeperator As String = "->") As String
        Dim dataPath As String = ""
        Dim str As String = ""
        Dim data As String() = valPath.Split(tv.PathSeparator)
        For i As Integer = 0 To data.Length - 1
            If str = "" Then
                str = data(i)
            Else
                str = str & tv.PathSeparator & data(i)
            End If
            Dim nd As TreeNode = tv.FindNode(str)
            If dataPath = "" Then
                dataPath = nd.Text
            Else
                dataPath = dataPath & pathSeperator & nd.Text
            End If
        Next
        Return dataPath
    End Function

    Public Shared Sub treeViewNodeSetup(ByVal tvControl As TreeView, ByVal strParentId As String, ByVal strTreeNodeValue As String, ByVal strTreeNodeText As String, Optional ByVal blnCheckBoxStatus As Boolean = False)
        Dim tv As New TreeNode
        If blnCheckBoxStatus = True Then
            tv.ShowCheckBox = True

        End If
        tv.Text = strTreeNodeText
        tv.Value = strTreeNodeValue
        If strParentId = "0" Then
            tvControl.Nodes.Add(tv)
        Else
            Functions.addChildParentChield(tvControl, tv, strParentId)
        End If
    End Sub

    Public Shared Sub addChildParentChield(ByVal tv As TreeView, ByVal child_id As TreeNode, ByVal parentid As String, Optional ByVal parent As TreeNode = Nothing)
        Dim m1 As TreeNode
        Dim i As Integer = 0

        ''if parent variable is not present then first call to this method
        If parent Is Nothing Then
            For Each m1 In tv.Nodes
                If m1.Value = parentid Then
                    ''Parent found so add new node in its child nodes
                    tv.Nodes(i).ChildNodes.Add(child_id)
                    Exit For
                ElseIf m1.ChildNodes.Count > 0 Then
                    ''The node has child nodes so search in child nodes
                    ''Recursive call
                    addChildParentChield(tv, child_id, parentid, m1)
                End If
                i += 1
            Next
        Else
            For Each m1 In parent.ChildNodes
                If m1.Value = parentid Then
                    ''Parent found so add new node in its child nodes
                    parent.ChildNodes(i).ChildNodes.Add(child_id)
                    Exit For
                ElseIf m1.ChildNodes.Count > 0 Then
                    ''The node has child nodes so search in child nodes
                    ''Recursive call
                    addChildParentChield(tv, child_id, parentid, m1)
                End If
                i += 1
            Next
        End If
    End Sub

    Public Shared Sub clearControls(ByVal controllist As ControlCollection)
        For i As Integer = 0 To controllist.Count - 1
            If controllist(i).HasControls Then
                clearControls(controllist(i).Controls)
            ElseIf controllist.Item(i).GetType.Name = "TextBox" Then
                Dim txtControl As TextBox
                txtControl = controllist.Item(i)
                txtControl.Text = Nothing
            ElseIf controllist.Item(i).GetType.Name = "DropDownList" Then
                Dim lstControl As DropDownList
                lstControl = controllist.Item(i)
                If lstControl.Items.Count > 0 Then
                    lstControl.SelectedIndex = 0
                End If
            ElseIf controllist.Item(i).GetType.Name = "HiddenField" Then
                Dim hdnControl As HiddenField
                hdnControl = controllist.Item(i)
                hdnControl.Value = Nothing
            ElseIf controllist.Item(i).GetType.Name = "CheckBox" Then
                Dim chkControl As CheckBox
                chkControl = controllist.Item(i)
                chkControl.Checked = False

            End If
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tv"></param>
    ''' <param name="pText"></param>
    ''' <param name="pValue"></param>
    ''' <param name="pk"></param>
    ''' <remarks></remarks>
    Public Shared Sub addOrModifyNode(ByVal tv As TreeView, ByVal pText As String, ByVal pValue As String, ByVal pk As String)
        If pk Is Nothing Or pk.ToString = "" Then       ''New Node added
            If Not tv.SelectedNode Is Nothing Then  'A node is selected
                tv.SelectedNode.ChildNodes.Add(New TreeNode(pText, pValue))
                ''Select newly added node
                tv.SelectedNode.ChildNodes(tv.SelectedNode.ChildNodes.Count - 1).Select()
            Else
                ''Else add node in tree
                tv.Nodes.Add(New TreeNode(pText, pValue))
                tv.Nodes(tv.Nodes.Count - 1).Select()
            End If
        Else        ''Old node modified
            If Not tv.SelectedNode Is Nothing Then
                tv.SelectedNode.Text = pText
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tv"></param>
    ''' <param name="pText"></param>
    ''' <param name="pValue"></param>
    ''' <param name="pk"></param>
    ''' <remarks></remarks>
    Public Shared Sub addOrModifyLeaf(ByVal tv As TreeView, ByVal pText As String, ByVal pValue As String, ByVal pk As String)
        If pk Is Nothing Or pk.ToString = "" Then       ''New Node added
            tv.Nodes.Add(New TreeNode(pText, pValue))
            tv.Nodes(tv.Nodes.Count - 1).Select()
        Else        ''Old node modified
            If Not tv.SelectedNode Is Nothing Then
                tv.SelectedNode.Text = pText
            End If
        End If
    End Sub

    Public Shared Function setMsgErrorClear_Setup_Images(ByVal Mode As ErrMsgMode, ByVal lblErrorMessage As Label, ByVal pErrorMessage As String, ByVal imgMsg As Image, ByVal imgErr As Image) As Label
        If Mode = ErrMsgMode.Errors Then
            lblErrorMessage.ForeColor = Drawing.Color.Red
            lblErrorMessage.Text = pErrorMessage
            imgErr.ImageUrl = "~/Images/imgError.gif"
            imgMsg.ImageUrl = "~/Images/imgMsg.gif"
            imgErr.Visible = True
            imgMsg.Visible = False
        ElseIf Mode = ErrMsgMode.Message Then
            lblErrorMessage.ForeColor = Drawing.Color.Green
            lblErrorMessage.Text = pErrorMessage
            imgErr.ImageUrl = "~/Images/imgError.gif"
            imgMsg.ImageUrl = "~/Images/imgMsg.gif"
            imgErr.Visible = False
            imgMsg.Visible = True
        Else
            lblErrorMessage.ForeColor = Drawing.Color.White
            lblErrorMessage.Text = Nothing
            imgErr.ImageUrl = Nothing
            imgMsg.ImageUrl = Nothing
            imgErr.Visible = False
            imgMsg.Visible = False
        End If

        Return lblErrorMessage
    End Function

    Public Shared Function setMsgErrorClear_Setup(ByVal Mode As ErrMsgMode, ByVal lblErrorMessage As Label, ByVal pErrorMessage As String) As Label
        If Mode = ErrMsgMode.Errors Then
            lblErrorMessage.ForeColor = Drawing.Color.Red
            lblErrorMessage.Text = pErrorMessage
        ElseIf Mode = ErrMsgMode.Message Then
            lblErrorMessage.ForeColor = Drawing.Color.Green
            lblErrorMessage.Text = pErrorMessage
        Else
            lblErrorMessage.ForeColor = Drawing.Color.White
            lblErrorMessage.Text = Nothing
        End If
        Return lblErrorMessage
    End Function

    Public Shared Function clearErrorMessage_img(ByVal lblErrorMessage As Label, ByVal imgErr As Image) As Label
        'lblErrorMessage.BackColor = Drawing.Color.White
        lblErrorMessage.ForeColor = Drawing.Color.White
        lblErrorMessage.Text = Nothing
        imgErr.ImageUrl = Nothing
        imgErr.Visible = False
        Return lblErrorMessage
    End Function

    Public Shared Sub ControlFocus(ByRef ctrl As WebControl)
        Dim sm As ScriptManager = ScriptManager.GetCurrent(ctrl.Page)
        sm.SetFocus(ctrl)
    End Sub

    Public Shared Function validateEmailId(ByVal pEmailId As String) As Boolean
        Dim result As Boolean = True
        Dim reg As New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        If reg.IsMatch(pEmailId) Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Public Shared Function validateWebSite(ByVal pWebsite As String) As Boolean
        Dim result As Boolean = True
        Dim reg As New Regex("http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")
        If reg.IsMatch(pWebsite) Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Public Shared Function validatePassword(ByVal pPassword As String) As Boolean
        Dim result As Boolean = True
        Dim reg As New Regex("^[a-zA-Z0-9]{6,20}$")
        If reg.IsMatch(pPassword) Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Public Shared Function ToTitle(ByVal strVar As String) As String
        Dim a_strArgs() As String
        Dim strRetVal As String = ""
        a_strArgs = Split(strVar.ToLower, " ")
        If a_strArgs.Length <> Nothing Then
            For i As Integer = 0 To a_strArgs.Length - 1
                If Asc(Mid(a_strArgs(i), 1, 1)) >= 97 And Asc(Mid(a_strArgs(i), 1, 1)) <= 122 Then
                    strRetVal = strRetVal & Mid(a_strArgs(i), 1, 1).ToUpper & Mid(a_strArgs(i), 2, a_strArgs(i).Length - 1) & " "
                End If
            Next
        End If
        Return strRetVal
    End Function

    Public Shared Function CloneDropDownList(ByVal plstSource As DropDownList, ByVal pId As String) As DropDownList
        Dim lstRetList As New DropDownList

        lstRetList.ID = pId

        For Each i As ListItem In plstSource.Items
            lstRetList.Items.Add(New ListItem(i.Text, i.Value))
        Next

        lstRetList.Attributes.Add("class", plstSource.Attributes.Item("class"))
        lstRetList.Width = plstSource.Width

        Return lstRetList
    End Function

    Public Shared Function CloneControls(ByVal o As Object) As Object
        Dim type As Type = o.GetType()
        Dim properties As System.Reflection.PropertyInfo() = type.GetProperties()
        Dim retObject As Object = type.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, Nothing, o, Nothing)
        For Each pPropertyInfo As System.Reflection.PropertyInfo In properties
            If pPropertyInfo.CanWrite Then
                pPropertyInfo.SetValue(retObject, pPropertyInfo.GetValue(o, Nothing), Nothing)
            End If
        Next
        Return retObject
    End Function

    Public Shared Function sendmail(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True

            'objMM.BodyEncoding = Encoding.Default
            'objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream
            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port
            'sm.EnableSsl = True
            sm.DeliveryMethod = SmtpDeliveryMethod.Network
            sm.Send(objMM)
            sm = Nothing

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function
    Public Shared Function sendMailToCcBcc(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            If BccIds.Length > 0 Then
                objMM.Bcc.Add(BccIds)
            End If
            'objMM.CC.Add(CCIds)
            'objMM.Bcc.Add(BccIds)

            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True


            '            objMM.BodyEncoding = Encoding.Default
            '            objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream

            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port
            sm.EnableSsl = False
            sm.DeliveryMethod = SmtpDeliveryMethod.Network
            ' sm.UseDefaultCredentials = True
            sm.Send(objMM)
            sm = Nothing

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function

    Public Shared Function sendMailToCcBccWithAttachment(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            If fromName <> Nothing Then
                Dim arrAtt As String() = fromName.Split(",")
                For i = 0 To arrAtt.Length - 1
                    If arrAtt(i) <> "" Then
                        For j As Integer = i + 1 To arrAtt.Length - 1
                            If arrAtt(j) <> "" Then
                                If arrAtt(i) = arrAtt(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrAtt(i) <> "" Then
                        If unique Then
                            Dim attachment As New Attachment(arrAtt(i))
                            objMM.Attachments.Add(attachment)
                            'objMM.Attachments.Add(New Attachment(arrAtt(i)))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If

            If CCIds.Length > 0 Then
                objMM.CC.Add(CCIds)
                ' objMM.Attachments.Add("D:\New.text")
            End If
            If BccIds.Length > 0 Then
                objMM.Bcc.Add(BccIds)
            End If
            'objMM.CC.Add(CCIds)
            'objMM.Bcc.Add(BccIds)

            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True


            '            objMM.BodyEncoding = Encoding.Default
            '            objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream

            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port
            sm.EnableSsl = False
            sm.DeliveryMethod = SmtpDeliveryMethod.Network
            ' sm.UseDefaultCredentials = True
            sm.Send(objMM)
            sm = Nothing

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function

    Public Shared Function FindFileExtension(ByVal strSrcString As String) As String
        Dim destString As String = ""
        Dim i As Integer = strSrcString.Length
        Do While i > 0 Or Mid(strSrcString, i, 1) <> "."
            If Mid(strSrcString, i, 1) = "." Then
                Exit Do
            End If
            destString = Mid(strSrcString, i, 1) & destString
            i = i - 1
        Loop
        Return destString
    End Function

    Public Shared Function FindFileName(ByVal strSrcString As String) As String
        Dim destString As String = ""
        Dim i As Integer = strSrcString.Length
        Do While i > 0 Or Mid(strSrcString, i, 1) <> "/" Or Mid(strSrcString, i, 1) <> "\"
            If Mid(strSrcString, i, 1) = "/" Or Mid(strSrcString, i, 1) = "\" Then
                Exit Do
            End If
            destString = Mid(strSrcString, i, 1) & destString
            i = i - 1
        Loop
        Return destString
    End Function

    Public Shared Function ContainerNumberValidation(ByVal CntNo As String) As Boolean
        Dim blnStatus As Boolean = True
        Dim m_tot As Integer = 0
        Dim m_i As Integer = 1
        Dim m_ch As String
        Dim m_val As Integer = 0
        Dim m_Alpha As Integer = 0
        Dim m_dgt As Integer = 0


        If CntNo.Length < 11 Then
            Return (False)
        End If

        For m_i = 1 To 10
            m_ch = Mid(CntNo, m_i, 1)

            If m_i < 5 Then
                If m_ch = "A" Then
                    m_val = 10
                ElseIf m_ch = "B" Then
                    m_val = 12
                ElseIf m_ch = "C" Then
                    m_val = 13
                ElseIf m_ch = "D" Then
                    m_val = 14
                ElseIf m_ch = "E" Then
                    m_val = 15
                ElseIf m_ch = "F" Then
                    m_val = 16
                ElseIf m_ch = "G" Then
                    m_val = 17
                ElseIf m_ch = "H" Then
                    m_val = 18
                ElseIf m_ch = "I" Then
                    m_val = 19
                ElseIf m_ch = "J" Then
                    m_val = 20
                ElseIf m_ch = "K" Then
                    m_val = 21
                ElseIf m_ch = "L" Then
                    m_val = 23
                ElseIf m_ch = "M" Then
                    m_val = 24
                ElseIf m_ch = "N" Then
                    m_val = 25
                ElseIf m_ch = "O" Then
                    m_val = 26
                ElseIf m_ch = "P" Then
                    m_val = 27
                ElseIf m_ch = "Q" Then
                    m_val = 28
                ElseIf m_ch = "R" Then
                    m_val = 29
                ElseIf m_ch = "S" Then
                    m_val = 30
                ElseIf m_ch = "T" Then
                    m_val = 31
                ElseIf m_ch = "U" Then
                    m_val = 32
                ElseIf m_ch = "V" Then
                    m_val = 34
                ElseIf m_ch = "W" Then
                    m_val = 35
                ElseIf m_ch = "X" Then
                    m_val = 36
                ElseIf m_ch = "Y" Then
                    m_val = 37
                ElseIf m_ch = "Z" Then
                    m_val = 38
                End If
            Else
                If m_ch <> "1" And m_ch <> "2" And m_ch <> "3" And m_ch <> "4" And m_ch <> "5" And m_ch <> "6" And m_ch <> "7" And m_ch <> "8" And m_ch <> "9" And m_ch <> "0" Then
                    Return (False)
                End If
                m_val = m_ch
            End If
            m_tot = m_tot + (m_val * ((2 ^ (m_i - 1))))
        Next
        m_dgt = m_tot Mod 11

        If m_dgt = 10 Then
            m_dgt = 0
        End If

        If m_dgt <> Mid(CntNo, 11, 1) Then
            Return (False)
        Else
            Return (True)
        End If
    End Function
    'Public Shared Function verifyMenu(ByVal url As String, ByVal job_id As String) As Boolean
    '    Dim arrMenuItems As ArrayList = HttpContext.Current.Session.Item("dataMenuItems")
    '    If Not arrMenuItems Is Nothing Then
    '        For Each obj As JobMenuDetails In arrMenuItems
    '            If obj.Url.ToUpper.Replace("~", "") <> String.Empty Then
    '                If url.ToUpper.EndsWith(obj.Url.ToUpper.Replace("~", "").Replace("\", "/")) Then
    '                    Return True
    '                End If
    '            End If
    '        Next
    '    End If
    '    Return False
    'End Function

    Public Shared Function todate_ddmmyyyyhh24mi(ByVal datestr As String) As ArrayList
        Try
            Dim arrDate As Array = datestr.Split(" ")
            Dim arr As New ArrayList
            arr.Add(arrDate(0))
            Try
                Dim arrTime As Array = arrDate(1).ToString.Split(":")
                Dim hrs As String = arrTime(0)
                Dim min As String = arrTime(1)
                arr.Add(arrTime(0))
                arr.Add(arrTime(1))
            Catch ex As Exception
            End Try
            Return arr
        Catch ex As Exception
            Return New ArrayList
        End Try
    End Function

    ''' <summary>
    ''' converts the string to date 
    ''' </summary>
    ''' <param name="datestr"></param>
    ''' <returns></returns>
    ''' <remarks>String should be in mm/dd/yyyy format</remarks>
    Public Shared Function todate_mmddyyyy(ByVal datestr As String, ByVal seperator As String) As Date
        Try
            Dim pos1 As Integer = datestr.IndexOf(seperator)
            Dim pos2 As Integer = datestr.IndexOf(seperator, pos1 + 1)
            Dim length1 As Integer = datestr.Substring(0, pos1).Length
            Dim from_mon As String = datestr.Substring(0, length1)
            Dim length2 As Integer = datestr.Substring(pos1 + 1, pos2 - pos1 - 1).Length
            Dim from_day As String = datestr.Substring(pos1 + 1, length2)
            Dim from_yr As String = datestr.Substring(pos2 + 1)

            Return New Date(CType(from_yr, Integer), CType(from_mon, Integer), CType(from_day, Integer))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' converts the string to date 
    ''' </summary>
    ''' <param name="datestr"></param>
    ''' <returns></returns>
    ''' <remarks>String should be in dd/mm/yyyy format</remarks>
    Public Shared Function todate_ddmmyyyy(ByVal datestr As String, ByVal seperator As String) As Date
        Try
            Dim pos1 As Integer = datestr.IndexOf(seperator)
            Dim pos2 As Integer = datestr.IndexOf(seperator, pos1 + 1)
            Dim length1 As Integer = datestr.Substring(0, pos1).Length
            Dim from_day As String = datestr.Substring(0, length1)
            Dim length2 As Integer = datestr.Substring(pos1 + 1, pos2 - pos1 - 1).Length
            Dim from_mon As String = datestr.Substring(pos1 + 1, length2)
            Dim from_yr As String = datestr.Substring(pos2 + 1)

            Return New Date(CType(from_yr, Integer), CType(from_mon, Integer), CType(from_day, Integer))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Shared Sub addChildParentChield(ByVal treeView As TreeView, ByVal p2 As Integer, ByVal p3 As String)
        Throw New NotImplementedException
    End Sub
    Public Shared Function sendMailToCcBccWithAttachmentExcel(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            If CCIds.Length > 0 Then
                objMM.CC.Add(CCIds)
                ' objMM.Attachments.Add("D:\New.text")

            End If

            If File.Exists(fromName) Then
                objMM.Attachments.Add(New Attachment(fromName))
            End If

            If BccIds.Length > 0 Then
                objMM.Bcc.Add(BccIds)
            End If
            'objMM.CC.Add(CCIds)
            'objMM.Bcc.Add(BccIds)

            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True


            '            objMM.BodyEncoding = Encoding.Default
            '            objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream

            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port
            sm.EnableSsl = True
            sm.DeliveryMethod = SmtpDeliveryMethod.Network
            ' sm.UseDefaultCredentials = True
            sm.Send(objMM)
            sm = Nothing

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function
    Public Shared Function sendMailToCcBccID(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            If CCIds.Length > 0 Then
                objMM.CC.Add(CCIds)
                ' objMM.Attachments.Add("D:\New.text")
                'objMM.Attachments.Add(New Attachment(fromName))

            End If
            If BccIds.Length > 0 Then
                objMM.Bcc.Add(BccIds)
            End If
            'objMM.CC.Add(CCIds)
            'objMM.Bcc.Add(BccIds)

            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True


            '            objMM.BodyEncoding = Encoding.Default
            '            objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream

            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port
            sm.EnableSsl = True
            sm.DeliveryMethod = SmtpDeliveryMethod.Network
            ' sm.UseDefaultCredentials = True
            sm.Send(objMM)
            sm = Nothing

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function

    Public Shared Sub ExportToCSV(currentPage As Page, gridViewControl As GridView)
        currentPage.Response.Clear()
        currentPage.Response.Buffer = True
        currentPage.Response.AddHeader("content-disposition", "attachment;filename=ExportedData.csv")
        currentPage.Response.Charset = ""
        currentPage.Response.ContentType = "text/csv"
        gridViewControl.AllowPaging = False
        Dim sb As StringBuilder = New StringBuilder()

        For Each cell As TableCell In gridViewControl.HeaderRow.Cells
            Dim cellText = cell.Text
            If String.IsNullOrWhiteSpace(cellText) Then
                Continue For
            End If
            If cellText.Contains("<span") Then
                Dim startIndex = cellText.IndexOf("<", StringComparison.Ordinal)
                cellText = cellText.Remove(startIndex, cellText.Length - startIndex)
            End If
            'Append data with separator.
            If Not cellText.Trim().Equals("&nbsp;", StringComparison.OrdinalIgnoreCase) Then
                sb.Append(cellText.Trim() & ",")
            End If
        Next
        'Append new line character.
        sb.Append(vbCr & vbLf)
        Dim rowIndex = 0
        For Each row As GridViewRow In gridViewControl.Rows

            For Each cell As TableCell In row.Cells
                'Append data with separator.

                If String.IsNullOrWhiteSpace(cell.Text) Then
                    Dim cc = cell.Controls
                    For i As Integer = 0 To cc.Count - 1
                        If cc.Item(i).GetType.Name = "TextBox" Then
                            Dim txtControl As TextBox
                            txtControl = CType(cc.Item(i), TextBox)
                            sb.Append(AddEscapeSequenceInCsvField(txtControl.Text.Trim()) & ",")
                            Exit For
                        ElseIf cc.Item(i).GetType.Name = "Label" Then
                            Dim labelControl As Label
                            labelControl = CType(cc.Item(i), Label)
                            sb.Append(AddEscapeSequenceInCsvField(labelControl.Text.Trim()) & ",")
                            Exit For
                        ElseIf cc.Item(i).GetType.Name = "DataBoundLiteralControl" Then
                            Dim dbLiteralControl As DataBoundLiteralControl
                            dbLiteralControl = CType(cc.Item(i), DataBoundLiteralControl)
                            sb.Append(AddEscapeSequenceInCsvField(dbLiteralControl.Text.Trim()) & ",")
                            Exit For
                        ElseIf cc.Item(i).GetType.Name = "LinkButton" Then
                            Dim linkControl As LinkButton
                            linkControl = CType(cc.Item(i), LinkButton)
                            sb.Append(AddEscapeSequenceInCsvField(linkControl.Text.Trim()) & ",")
                            Exit For
                        End If
                    Next
                Else
                    If Not cell.Text.Equals("&nbsp;", StringComparison.OrdinalIgnoreCase) Then
                        sb.Append(AddEscapeSequenceInCsvField(cell.Text.Trim()) & ",")
                    Else
                        sb.Append(",")
                    End If
                End If
            Next
            'Append new line character.
            sb.Append(vbCr & vbLf)
        Next

        currentPage.Response.Output.Write(sb.ToString())
        currentPage.Response.Flush()
        currentPage.Response.End()
    End Sub

    Private Shared Function AddEscapeSequenceInCsvField(ByVal ValueToEscape As String) As String
        If ValueToEscape.Contains(",") Then
            Return """" & ValueToEscape & """"
        Else
            Return ValueToEscape
        End If
    End Function

    Public Shared Function ExportToDT(currentPage As Page, gridViewControl As GridView) As DataTable
        gridViewControl.AllowPaging = False
        Dim tableGvData As New DataTable()

        For Each cell As TableCell In gridViewControl.HeaderRow.Cells
            Dim cellText = cell.Text
            If String.IsNullOrWhiteSpace(cellText) Then
                Continue For
            End If
            If cellText.Contains("<span") Then
                Dim startIndex = cellText.IndexOf("<", StringComparison.Ordinal)
                cellText = cellText.Remove(startIndex, cellText.Length - startIndex)
            End If
            'Append column.
            tableGvData.Columns.Add(cellText.Trim())
        Next

        'Loop through the GridView and copy rows.
        For Each row As GridViewRow In gridViewControl.Rows
            tableGvData.Rows.Add()
            For i As Integer = 0 To row.Cells.Count - 1
                If row.Cells(i).Text.Trim().Equals("&nbsp;", StringComparison.OrdinalIgnoreCase) Then
                    tableGvData.Rows(row.RowIndex)(i) = String.Empty
                Else
                    tableGvData.Rows(row.RowIndex)(i) = row.Cells(i).Text.Trim()
                End If

            Next
        Next
        Return tableGvData
    End Function

End Class

Public Module Helpers
    <Extension()>
    Public Function ToWritableString(ByVal dtDataTable As DataTable) As String
        Dim sw As New StringBuilder()
        'headers    
        For i As Integer = 0 To dtDataTable.Columns.Count - 1
            sw.Append(dtDataTable.Columns(i))

            If i < dtDataTable.Columns.Count - 1 Then
                sw.Append(",")
            End If
        Next

        sw.AppendLine()

        For Each dr As DataRow In dtDataTable.Rows
            For i As Integer = 0 To dtDataTable.Columns.Count - 1
                If Not Convert.IsDBNull(dr(i)) Then
                    Dim value As String = dr(i).ToString()

                    If value.Contains(","c) Then
                        value = String.Format("""{0}""", value)
                        sw.Append(value)
                    Else
                        sw.Append(dr(CInt(i)).ToString())
                    End If
                End If

                If i < dtDataTable.Columns.Count - 1 Then
                    sw.Append(",")
                End If
            Next

            sw.AppendLine()
        Next
        Return sw.ToString()
    End Function

End Module
