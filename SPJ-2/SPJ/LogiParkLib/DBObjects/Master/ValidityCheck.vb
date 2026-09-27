Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ValidityCheck
    ''' @author	: Amit K. Singh- 2/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ValidityCheck

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngAllotId As Long ' Define Private Variable AllotId With DataType As Long 
        'Private lngContId As Long ' Define Private Variable ContId With DataType As Long
        Private lngDomJoId As Long ' Define Private Variable DomJoId With DataType As Long
        Private lngDfsJoId As Long ' Define Private Variable DomFsJoId With DataType As Long
        Private strJoValidityFlag As String ' Define Private Variable JoValidity With DataType As JoValidity
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of AllotId
        ''' </summary>
        ''' <value>lngAllotId</value>
        ''' <returns> Return lngAllotId</returns>
        ''' <remarks> Get or Set the Value of AllotId  </remarks>
        '''
        Public Property AllotId() As Long
            Get
                Return lngAllotId
            End Get
            Set(ByVal value As Long)
                lngAllotId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DomJoId
        ''' </summary>
        ''' <value>lngDomJoId</value>
        ''' <returns> Return lngDomJoId</returns>
        ''' <remarks> Get or Set the Value of DomJoId  </remarks>
        '''
        Public Property DomJoId() As Long
            Get
                Return lngDomJoId
            End Get
            Set(ByVal value As Long)
                lngDomJoId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DfsJoId
        ''' </summary>
        ''' <value>lngDfsJoId</value>
        ''' <returns> Return lngDfsJoId</returns>
        ''' <remarks> Get or Set the Value of DfsJoId  </remarks>
        '''
        Public Property DfsJoId() As Long
            Get
                Return lngDfsJoId
            End Get
            Set(ByVal value As Long)
                lngDfsJoId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of strJoValidityFlag
        ''' </summary>
        ''' <value>strJoValidityFlag</value>
        ''' <returns> Return strJoValidityFlag</returns>
        ''' <remarks> Get or Set the Value of strJoValidityFlag  </remarks>
        '''
        Public Property JoValidityFlag() As String
            Get
                Return strJoValidityFlag
            End Get
            Set(ByVal value As String)
                strJoValidityFlag = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngAllotId = 0
            lngDomJoId = 0
            lngDfsJoId = 0
            strJoValidityFlag = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pValidityCheck As ValidityCheck) As ValidityCheck
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        'Try
                        '    If dbr("TERMINAL_ID").ToString <> "" Then
                        '        pValidityCheck.TerminalId = dbr("TERMINAL_ID")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                        'Try
                        '    If dbr("Allot_ID").ToString <> "" Then
                        '        pValidityCheck.AllotId = dbr("Allot_ID")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                        Try
                            If dbr("JO_VALIDITY_FLAG").ToString <> "" Then
                                pValidityCheck.JoValidityFlag = dbr("JO_VALIDITY_FLAG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        'Try
                        '    If dbr("BANK_NAME").ToString <> "" Then
                        '        pBankMaster.BankName = dbr("BANK_NAME")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                        'Try
                        '    If dbr("IFSC_CODE").ToString <> "" Then
                        '        pBankMaster.IfscCode = dbr("IFSC_CODE")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                        'Try
                        '    If dbr("BANK_ADDRESS").ToString <> "" Then
                        '        pBankMaster.BankAddress = dbr("BANK_ADDRESS")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                        'Try
                        '    If dbr("CREATED_BY").ToString <> "" Then
                        '        pBankMaster.CreatedBy = dbr("CREATED_BY")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                        'Try
                        '    If dbr("CREATED_ON").ToString <> "" Then
                        '        pBankMaster.CreatedOn = dbr("CREATED_ON")
                        '    End If
                        'Catch ex1 As Exception
                        'End Try
                    End While
                End If
            Catch ex As Exception
                pValidityCheck.Errormsg = ex.Message
            End Try
            Return pValidityCheck
        End Function

        ' ''' <summary>
        ' ''' Preparing ReturnObjectValuesList Member Function
        ' ''' </summary>
        ' ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        ' '''
        'Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrValidity As ArrayList) As ArrayList
        '    Dim arrList As New ArrayList
        '    Try
        '        If dbr.HasRows Then
        '            While dbr.Read
        '                Dim temp As New ValidityCheck
        '                'Try
        '                '    If dbr("TERMINAL_ID").ToString <> "" Then
        '                '        temp.TerminalId = dbr("TERMINAL_ID")
        '                '    End If
        '                'Catch ex1 As Exception
        '                'End Try
        '                'Try
        '                '    If dbr("BANK_ID").ToString <> "" Then
        '                '        temp.BankId = dbr("BANK_ID")
        '                '    End If
        '                'Catch ex1 As Exception
        '                'End Try

        '                Try
        '                    If dbr("JO_VALIIDTY_FLAG").ToString <> "" Then
        '                        temp.JoValidityFlag = dbr("JO_VALIIDTY_FLAG")
        '                    End If
        '                Catch ex1 As Exception
        '                End Try
        '                arrList.Add(temp)
        '            End While
        '        End If
        '    Catch ex As Exception
        '        arrList = Nothing
        '    End Try
        '    Return arrList
        'End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnAllotValidity(ByVal pValidityCheck As ValidityCheck) As ValidityCheck
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALLOT_JO_VALIDITY", pValidityCheck.TerminalId & "," & pValidityCheck.AllotId)
                pValidityCheck = ReturnObjectValues(dbr, pValidityCheck)
                dbr.Close()
            Catch ex As Exception
                pValidityCheck.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pValidityCheck
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnStuffingJoValidity(ByVal pValidityCheck As ValidityCheck) As ValidityCheck
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_STUFFING_JO_VALIDITY", pValidityCheck.TerminalId & "," & pValidityCheck.DomJoId)
                pValidityCheck = ReturnObjectValues(dbr, pValidityCheck)
                dbr.Close()
            Catch ex As Exception
                pValidityCheck.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pValidityCheck
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTptJoValidity(ByVal pValidityCheck As ValidityCheck) As ValidityCheck
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TPT_JO_VALIDITY", pValidityCheck.TerminalId & "," & pValidityCheck.DfsJoId)
                pValidityCheck = ReturnObjectValues(dbr, pValidityCheck)
                dbr.Close()
            Catch ex As Exception
                pValidityCheck.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pValidityCheck
        End Function

    End Class
End Namespace
