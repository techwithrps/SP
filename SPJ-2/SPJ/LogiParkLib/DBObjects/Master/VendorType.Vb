Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorType
    ''' @author	: Amit K. Singh- 22/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class VendorType 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strVendorTypeCode As String ' Define Private Variable VendorTypeCode With DataType As String 
        Private strVendorTypeName As String ' Define Private Variable VendorTypeName With DataType As String 
        Private lngVendorTypeId As Long ' Define Private Variable VendorTypeId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() as Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VendorTypeCode
        ''' </summary>
        ''' <value>strVendorTypeCode</value>
        ''' <returns> Return strVendorTypeCode</returns>
        ''' <remarks> Get or Set the Value of VendorTypeCode  </remarks>
        '''
        Public Property VendorTypeCode() as String
            Get
                Return strVendorTypeCode
            End Get
            Set(ByVal value As String)
                strVendorTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VendorTypeName
        ''' </summary>
        ''' <value>strVendorTypeName</value>
        ''' <returns> Return strVendorTypeName</returns>
        ''' <remarks> Get or Set the Value of VendorTypeName  </remarks>
        '''
        Public Property VendorTypeName() as String
            Get
                Return strVendorTypeName
            End Get
            Set(ByVal value As String)
                strVendorTypeName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VendorTypeId
        ''' </summary>
        ''' <value>lngVendorTypeId</value>
        ''' <returns> Return lngVendorTypeId</returns>
        ''' <remarks> Get or Set the Value of VendorTypeId  </remarks>
        '''
        Public Property VendorTypeId() as Long
            Get
                Return lngVendorTypeId
            End Get
            Set(ByVal value As Long)
                lngVendorTypeId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() as String
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
            strVendorTypeCode = ""
            strVendorTypeName = ""
            lngVendorTypeId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pVendorType"></param>
        ''' <returns>Return pVendorType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVendorType As VendorType) As VendorType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorType.TerminalId)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorType.VendorTypeCode)
                db.AddParameter("p_VENDOR_TYPE_NAME", pVendorType.VendorTypeName)
                db.AddParameter("p_VENDOR_TYPE_ID", pVendorType.VendorTypeId)
                db.AddParameter("p_ErrorMsg", pVendorType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pVendorType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorType
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorType"></param>
        ''' <returns>Return pVendorType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVendorType As VendorType) As VendorType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorType.TerminalId)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorType.VendorTypeCode)
                db.AddParameter("p_VENDOR_TYPE_NAME", pVendorType.VendorTypeName)
                db.AddParameter("p_VENDOR_TYPE_ID", pVendorType.VendorTypeId)
                db.AddParameter("p_ErrorMsg", pVendorType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pVendorType.ErrorMsg = ex.Message
            End Try
            Return pVendorType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVendorType"></param>
        ''' <returns>Return pVendorType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVendorType As VendorType) As VendorType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorType.TerminalId)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorType.VendorTypeCode)
                db.AddParameter("p_VENDOR_TYPE_NAME", pVendorType.VendorTypeName)
                db.AddParameter("p_VENDOR_TYPE_ID", pVendorType.VendorTypeId)
                db.AddParameter("p_ErrorMsg", pVendorType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVendorType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorType"></param>
        ''' <returns>Return pVendorType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVendorType As VendorType) As VendorType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorType.TerminalId)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorType.VendorTypeCode)
                db.AddParameter("p_VENDOR_TYPE_NAME", pVendorType.VendorTypeName)
                db.AddParameter("p_VENDOR_TYPE_ID", pVendorType.VendorTypeId)
                db.AddParameter("p_ErrorMsg", pVendorType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVendorType.ErrorMsg = ex.Message
                End Try
            Return pVendorType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVendorType As VendorType) As VendorType
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVendorType.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_CODE").ToString <> "" Then
                                PVendorType.VendorTypeCode = dbr("VENDOR_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_NAME").ToString <> "" Then
                                PVendorType.VendorTypeName = dbr("VENDOR_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_ID").ToString <> "" Then
                                PVendorType.VendorTypeId = dbr("VENDOR_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVendorType.ErrorMsg = ex.Message
            End Try
            Return pVendorType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVendorType As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VendorType
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_CODE").ToString <> "" Then
                                temp.VendorTypeCode = dbr("VENDOR_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_NAME").ToString <> "" Then
                                temp.VendorTypeName = dbr("VENDOR_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_ID").ToString <> "" Then
                                temp.VendorTypeId = dbr("VENDOR_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                end If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnVendorType(ByVal pVendorType As VendorType) As VendorType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_TYPE", "' '")
                pVendorType = ReturnObjectValues(dbr, pVendorType)
                dbr.Close()
            Catch ex As Exception
                pVendorType.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorType
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorTypeList (ByVal pVendorType As VendorType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_TYPE_ALL", pVendorType.TerminalId)
                arrVendorType = ReturnObjectValuesList(dbr, arrVendorType)
                dbr.Close()
            Catch ex As Exception
                arrVendorType = Nothing
            End Try
            db.CloseDB()
            Return arrVendorType
        End Function
    End Class
End Namespace
