Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorTypeDetails
    ''' @author	: Amit K. Singh- 22/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class VendorTypeDetails 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngVendorId As Long ' Define Private Variable VendorId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private strTdsCode As String ' Define Private Variable TdsCode With DataType As String 
        Private strVenderTypeCode As String ' Define Private Variable VenderTypeCode With DataType As String 
        Private strImport As String ' Define Private Variable Import With DataType As String 
        Private strExport As String ' Define Private Variable Export With DataType As String 
        Private strDomestic As String ' Define Private Variable Domestic With DataType As String 
        Private strStatus As String ' Define Private Variable Status With DataType As String 
        Private lngVendorKeyId As Long ' Define Private Variable VendorKeyId With DataType As Long 
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
        ''' Get or Set the Value of VendorId
        ''' </summary>
        ''' <value>lngVendorId</value>
        ''' <returns> Return lngVendorId</returns>
        ''' <remarks> Get or Set the Value of VendorId  </remarks>
        '''
        Public Property VendorId() as Long
            Get
                Return lngVendorId
            End Get
            Set(ByVal value As Long)
                lngVendorId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() as Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TdsCode
        ''' </summary>
        ''' <value>strTdsCode</value>
        ''' <returns> Return strTdsCode</returns>
        ''' <remarks> Get or Set the Value of TdsCode  </remarks>
        '''
        Public Property TdsCode() as String
            Get
                Return strTdsCode
            End Get
            Set(ByVal value As String)
                strTdsCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VenderTypeCode
        ''' </summary>
        ''' <value>strVenderTypeCode</value>
        ''' <returns> Return strVenderTypeCode</returns>
        ''' <remarks> Get or Set the Value of VenderTypeCode  </remarks>
        '''
        Public Property VenderTypeCode() as String
            Get
                Return strVenderTypeCode
            End Get
            Set(ByVal value As String)
                strVenderTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Import
        ''' </summary>
        ''' <value>strImport</value>
        ''' <returns> Return strImport</returns>
        ''' <remarks> Get or Set the Value of Import  </remarks>
        '''
        Public Property Import() as String
            Get
                Return strImport
            End Get
            Set(ByVal value As String)
                strImport = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Export
        ''' </summary>
        ''' <value>strExport</value>
        ''' <returns> Return strExport</returns>
        ''' <remarks> Get or Set the Value of Export  </remarks>
        '''
        Public Property Export() as String
            Get
                Return strExport
            End Get
            Set(ByVal value As String)
                strExport = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Domestic
        ''' </summary>
        ''' <value>strDomestic</value>
        ''' <returns> Return strDomestic</returns>
        ''' <remarks> Get or Set the Value of Domestic  </remarks>
        '''
        Public Property Domestic() as String
            Get
                Return strDomestic
            End Get
            Set(ByVal value As String)
                strDomestic = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>strStatus</value>
        ''' <returns> Return strStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property Status() as String
            Get
                Return strStatus
            End Get
            Set(ByVal value As String)
                strStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VendorKeyId
        ''' </summary>
        ''' <value>lngVendorKeyId</value>
        ''' <returns> Return lngVendorKeyId</returns>
        ''' <remarks> Get or Set the Value of VendorKeyId  </remarks>
        '''
        Public Property VendorKeyId() as Long
            Get
                Return lngVendorKeyId
            End Get
            Set(ByVal value As Long)
                lngVendorKeyId = value
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
            lngVendorId = 0 
            lngServiceId = 0 
            strTdsCode = ""
            strVenderTypeCode = ""
            strImport = ""
            strExport = ""
            strDomestic = ""
            strStatus = ""
            lngVendorKeyId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pVendorTypeDetails"></param>
        ''' <returns>Return pVendorTypeDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVendorTypeDetails As VendorTypeDetails) As VendorTypeDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorTypeDetails.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorTypeDetails.VendorId)
                db.AddParameter("p_SERVICE_ID", pVendorTypeDetails.ServiceId)
                db.AddParameter("p_TDS_CODE", pVendorTypeDetails.TdsCode)
                db.AddParameter("p_VENDER_TYPE_CODE", pVendorTypeDetails.VenderTypeCode)
                db.AddParameter("p_IMPORT", pVendorTypeDetails.Import)
                db.AddParameter("p_EXPORT", pVendorTypeDetails.Export)
                db.AddParameter("p_DOMESTIC", pVendorTypeDetails.Domestic)
                db.AddParameter("p_STATUS", pVendorTypeDetails.Status)
                db.AddParameter("p_VENDOR_KEY_ID", pVendorTypeDetails.VendorKeyId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pVendorTypeDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_TYPE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorTypeDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorTypeDetails.VendorKeyId  = db.Parameters.Item("p_VENDOR_KEY_ID").value
                
                If pVendorTypeDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorTypeDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorTypeDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorTypeDetails"></param>
        ''' <returns>Return pVendorTypeDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVendorTypeDetails As VendorTypeDetails) As VendorTypeDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorTypeDetails.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorTypeDetails.VendorId)
                db.AddParameter("p_SERVICE_ID", pVendorTypeDetails.ServiceId)
                db.AddParameter("p_TDS_CODE", pVendorTypeDetails.TdsCode)
                db.AddParameter("p_VENDER_TYPE_CODE", pVendorTypeDetails.VenderTypeCode)
                db.AddParameter("p_IMPORT", pVendorTypeDetails.Import)
                db.AddParameter("p_EXPORT", pVendorTypeDetails.Export)
                db.AddParameter("p_DOMESTIC", pVendorTypeDetails.Domestic)
                db.AddParameter("p_STATUS", pVendorTypeDetails.Status)
                db.AddParameter("p_VENDOR_KEY_ID", pVendorTypeDetails.VendorKeyId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pVendorTypeDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_TYPE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorTypeDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorTypeDetails.VendorKeyId  = db.Parameters.Item("p_VENDOR_KEY_ID").value
                
            Catch ex As Exception
                pVendorTypeDetails.ErrorMsg = ex.Message
            End Try
            Return pVendorTypeDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVendorTypeDetails"></param>
        ''' <returns>Return pVendorTypeDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVendorTypeDetails As VendorTypeDetails) As VendorTypeDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorTypeDetails.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorTypeDetails.VendorId)
                db.AddParameter("p_SERVICE_ID", pVendorTypeDetails.ServiceId)
                db.AddParameter("p_TDS_CODE", pVendorTypeDetails.TdsCode)
                db.AddParameter("p_VENDER_TYPE_CODE", pVendorTypeDetails.VenderTypeCode)
                db.AddParameter("p_IMPORT", pVendorTypeDetails.Import)
                db.AddParameter("p_EXPORT", pVendorTypeDetails.Export)
                db.AddParameter("p_DOMESTIC", pVendorTypeDetails.Domestic)
                db.AddParameter("p_STATUS", pVendorTypeDetails.Status)
                db.AddParameter("p_VENDOR_KEY_ID", pVendorTypeDetails.VendorKeyId)
                db.AddParameter("p_ErrorMsg", pVendorTypeDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_TYPE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorTypeDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVendorTypeDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorTypeDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorTypeDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorTypeDetails"></param>
        ''' <returns>Return pVendorTypeDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVendorTypeDetails As VendorTypeDetails) As VendorTypeDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorTypeDetails.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorTypeDetails.VendorId)
                db.AddParameter("p_SERVICE_ID", pVendorTypeDetails.ServiceId)
                db.AddParameter("p_TDS_CODE", pVendorTypeDetails.TdsCode)
                db.AddParameter("p_VENDER_TYPE_CODE", pVendorTypeDetails.VenderTypeCode)
                db.AddParameter("p_IMPORT", pVendorTypeDetails.Import)
                db.AddParameter("p_EXPORT", pVendorTypeDetails.Export)
                db.AddParameter("p_DOMESTIC", pVendorTypeDetails.Domestic)
                db.AddParameter("p_STATUS", pVendorTypeDetails.Status)
                db.AddParameter("p_VENDOR_KEY_ID", pVendorTypeDetails.VendorKeyId)
                db.AddParameter("p_ErrorMsg", pVendorTypeDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_TYPE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorTypeDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVendorTypeDetails.ErrorMsg = ex.Message
                End Try
            Return pVendorTypeDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVendorTypeDetails As VendorTypeDetails) As VendorTypeDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVendorTypeDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                PVendorTypeDetails.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PVendorTypeDetails.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TDS_CODE").ToString <> "" Then
                                PVendorTypeDetails.TdsCode = dbr("TDS_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDER_TYPE_CODE").ToString <> "" Then
                                PVendorTypeDetails.VenderTypeCode = dbr("VENDER_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMPORT").ToString <> "" Then
                                PVendorTypeDetails.Import = dbr("IMPORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXPORT").ToString <> "" Then
                                PVendorTypeDetails.Export = dbr("EXPORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOMESTIC").ToString <> "" Then
                                PVendorTypeDetails.Domestic = dbr("DOMESTIC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                PVendorTypeDetails.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_KEY_ID").ToString <> "" Then
                                PVendorTypeDetails.VendorKeyId = dbr("VENDOR_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVendorTypeDetails.ErrorMsg = ex.Message
            End Try
            Return pVendorTypeDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVendorTypeDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VendorTypeDetails
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                temp.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TDS_CODE").ToString <> "" Then
                                temp.TdsCode = dbr("TDS_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDER_TYPE_CODE").ToString <> "" Then
                                temp.VenderTypeCode = dbr("VENDER_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMPORT").ToString <> "" Then
                                temp.Import = dbr("IMPORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXPORT").ToString <> "" Then
                                temp.Export = dbr("EXPORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOMESTIC").ToString <> "" Then
                                temp.Domestic = dbr("DOMESTIC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                temp.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_KEY_ID").ToString <> "" Then
                                temp.VendorKeyId = dbr("VENDOR_KEY_ID")
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
        Public Shared Function ReturnVendorTypeDetails(ByVal pVendorTypeDetails As VendorTypeDetails) As VendorTypeDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_TYPE_DETAILS", "' '")
                pVendorTypeDetails = ReturnObjectValues(dbr, pVendorTypeDetails)
                dbr.Close()
            Catch ex As Exception
                pVendorTypeDetails.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorTypeDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorTypeDetailsList (ByVal pVendorTypeDetails As VendorTypeDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorTypeDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_TYPE_DETAILS_ALL", pVendorTypeDetails.TerminalId & "," & pVendorTypeDetails.VendorId)
                arrVendorTypeDetails = ReturnObjectValuesList(dbr, arrVendorTypeDetails)
                dbr.Close()
            Catch ex As Exception
                arrVendorTypeDetails = Nothing
            End Try
            db.CloseDB()
            Return arrVendorTypeDetails
        End Function
    End Class
End Namespace
