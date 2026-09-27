Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetInventoryDtls
    ''' @author	: Santosh Singh- 27/9/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetInventoryDtls 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngInventDtls As Long ' Define Private Variable InventDtls With DataType As Long 
        Private lngInventId As Long ' Define Private Variable InventId With DataType As Long 
        Private strItemNo As String ' Define Private Variable ItemNo With DataType As String 
        Private strItemType As String ' Define Private Variable ItemType With DataType As String 
        Private strModelNo As String ' Define Private Variable ModelNo With DataType As String 
        Private strManufacture As String ' Define Private Variable Manufacture With DataType As String 
        Private strBuyingDate As String ' Define Private Variable BuyingDate With DataType As String 
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
        ''' Get or Set the Value of InventDtls
        ''' </summary>
        ''' <value>lngInventDtls</value>
        ''' <returns> Return lngInventDtls</returns>
        ''' <remarks> Get or Set the Value of InventDtls  </remarks>
        '''
        Public Property InventDtls() as Long
            Get
                Return lngInventDtls
            End Get
            Set(ByVal value As Long)
                lngInventDtls = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InventId
        ''' </summary>
        ''' <value>lngInventId</value>
        ''' <returns> Return lngInventId</returns>
        ''' <remarks> Get or Set the Value of InventId  </remarks>
        '''
        Public Property InventId() as Long
            Get
                Return lngInventId
            End Get
            Set(ByVal value As Long)
                lngInventId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ItemNo
        ''' </summary>
        ''' <value>strItemNo</value>
        ''' <returns> Return strItemNo</returns>
        ''' <remarks> Get or Set the Value of ItemNo  </remarks>
        '''
        Public Property ItemNo() as String
            Get
                Return strItemNo
            End Get
            Set(ByVal value As String)
                strItemNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ItemType
        ''' </summary>
        ''' <value>strItemType</value>
        ''' <returns> Return strItemType</returns>
        ''' <remarks> Get or Set the Value of ItemType  </remarks>
        '''
        Public Property ItemType() as String
            Get
                Return strItemType
            End Get
            Set(ByVal value As String)
                strItemType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ModelNo
        ''' </summary>
        ''' <value>strModelNo</value>
        ''' <returns> Return strModelNo</returns>
        ''' <remarks> Get or Set the Value of ModelNo  </remarks>
        '''
        Public Property ModelNo() as String
            Get
                Return strModelNo
            End Get
            Set(ByVal value As String)
                strModelNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Manufacture
        ''' </summary>
        ''' <value>strManufacture</value>
        ''' <returns> Return strManufacture</returns>
        ''' <remarks> Get or Set the Value of Manufacture  </remarks>
        '''
        Public Property Manufacture() as String
            Get
                Return strManufacture
            End Get
            Set(ByVal value As String)
                strManufacture = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BuyingDate
        ''' </summary>
        ''' <value>strBuyingDate</value>
        ''' <returns> Return strBuyingDate</returns>
        ''' <remarks> Get or Set the Value of BuyingDate  </remarks>
        '''
        Public Property BuyingDate() as String
            Get
                Return strBuyingDate
            End Get
            Set(ByVal value As String)
                strBuyingDate = value
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
            lngInventDtls = 0 
            lngInventId = 0 
            strItemNo = ""
            strItemType = ""
            strModelNo = ""
            strManufacture = ""
            strBuyingDate = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetInventoryDtls"></param>
        ''' <returns>Return pFleetInventoryDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetInventoryDtls As FleetInventoryDtls) As FleetInventoryDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventoryDtls.TerminalId)
                db.AddParameter("p_INVENT_DTLS", pFleetInventoryDtls.InventDtls, ParameterDirection.Output)
                db.AddParameter("p_INVENT_ID", pFleetInventoryDtls.InventId)
                db.AddParameter("p_ITEM_NO", pFleetInventoryDtls.ItemNo)
                db.AddParameter("p_ITEM_TYPE", pFleetInventoryDtls.ItemType)
                db.AddParameter("p_MODEL_NO", pFleetInventoryDtls.ModelNo)
                db.AddParameter("p_MANUFACTURE", pFleetInventoryDtls.Manufacture)
                db.AddParameter("p_BUYING_DATE", pFleetInventoryDtls.BuyingDate)
                db.AddParameter("p_ErrorMsg", pFleetInventoryDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_INVENTORY_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventoryDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetInventoryDtls.InventDtls  = db.Parameters.Item("p_INVENT_DTLS").value
                
                If pFleetInventoryDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetInventoryDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetInventoryDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetInventoryDtls"></param>
        ''' <returns>Return pFleetInventoryDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetInventoryDtls As FleetInventoryDtls) As FleetInventoryDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventoryDtls.TerminalId)
                db.AddParameter("p_INVENT_DTLS", pFleetInventoryDtls.InventDtls, ParameterDirection.Output)
                db.AddParameter("p_INVENT_ID", pFleetInventoryDtls.InventId)
                db.AddParameter("p_ITEM_NO", pFleetInventoryDtls.ItemNo)
                db.AddParameter("p_ITEM_TYPE", pFleetInventoryDtls.ItemType)
                db.AddParameter("p_MODEL_NO", pFleetInventoryDtls.ModelNo)
                db.AddParameter("p_MANUFACTURE", pFleetInventoryDtls.Manufacture)
                db.AddParameter("p_BUYING_DATE", pFleetInventoryDtls.BuyingDate)
                db.AddParameter("p_ErrorMsg", pFleetInventoryDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_INVENTORY_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventoryDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetInventoryDtls.InventDtls  = db.Parameters.Item("p_INVENT_DTLS").value
                
            Catch ex As Exception
                pFleetInventoryDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetInventoryDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetInventoryDtls"></param>
        ''' <returns>Return pFleetInventoryDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetInventoryDtls As FleetInventoryDtls) As FleetInventoryDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventoryDtls.TerminalId)
                db.AddParameter("p_INVENT_DTLS", pFleetInventoryDtls.InventDtls)
                db.AddParameter("p_INVENT_ID", pFleetInventoryDtls.InventId)
                db.AddParameter("p_ITEM_NO", pFleetInventoryDtls.ItemNo)
                db.AddParameter("p_ITEM_TYPE", pFleetInventoryDtls.ItemType)
                db.AddParameter("p_MODEL_NO", pFleetInventoryDtls.ModelNo)
                db.AddParameter("p_MANUFACTURE", pFleetInventoryDtls.Manufacture)
                db.AddParameter("p_BUYING_DATE", pFleetInventoryDtls.BuyingDate)
                db.AddParameter("p_ErrorMsg", pFleetInventoryDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_INVENTORY_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventoryDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetInventoryDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetInventoryDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetInventoryDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetInventoryDtls"></param>
        ''' <returns>Return pFleetInventoryDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetInventoryDtls As FleetInventoryDtls) As FleetInventoryDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventoryDtls.TerminalId)
                db.AddParameter("p_INVENT_DTLS", pFleetInventoryDtls.InventDtls)
                db.AddParameter("p_INVENT_ID", pFleetInventoryDtls.InventId)
                db.AddParameter("p_ITEM_NO", pFleetInventoryDtls.ItemNo)
                db.AddParameter("p_ITEM_TYPE", pFleetInventoryDtls.ItemType)
                db.AddParameter("p_MODEL_NO", pFleetInventoryDtls.ModelNo)
                db.AddParameter("p_MANUFACTURE", pFleetInventoryDtls.Manufacture)
                db.AddParameter("p_BUYING_DATE", pFleetInventoryDtls.BuyingDate)
                db.AddParameter("p_ErrorMsg", pFleetInventoryDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_INVENTORY_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventoryDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetInventoryDtls.ErrorMsg = ex.Message
                End Try
            Return pFleetInventoryDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetInventoryDtls As FleetInventoryDtls) As FleetInventoryDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetInventoryDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVENT_DTLS").ToString <> "" Then
                                PFleetInventoryDtls.InventDtls = dbr("INVENT_DTLS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVENT_ID").ToString <> "" Then
                                PFleetInventoryDtls.InventId = dbr("INVENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_NO").ToString <> "" Then
                                PFleetInventoryDtls.ItemNo = dbr("ITEM_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_TYPE").ToString <> "" Then
                                PFleetInventoryDtls.ItemType = dbr("ITEM_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODEL_NO").ToString <> "" Then
                                PFleetInventoryDtls.ModelNo = dbr("MODEL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MANUFACTURE").ToString <> "" Then
                                PFleetInventoryDtls.Manufacture = dbr("MANUFACTURE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUYING_DATE").ToString <> "" Then
                                PFleetInventoryDtls.BuyingDate = dbr("BUYING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetInventoryDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetInventoryDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetInventoryDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetInventoryDtls
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVENT_DTLS").ToString <> "" Then
                                temp.InventDtls = dbr("INVENT_DTLS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVENT_ID").ToString <> "" Then
                                temp.InventId = dbr("INVENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_NO").ToString <> "" Then
                                temp.ItemNo = dbr("ITEM_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_TYPE").ToString <> "" Then
                                temp.ItemType = dbr("ITEM_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODEL_NO").ToString <> "" Then
                                temp.ModelNo = dbr("MODEL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MANUFACTURE").ToString <> "" Then
                                temp.Manufacture = dbr("MANUFACTURE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUYING_DATE").ToString <> "" Then
                                temp.BuyingDate = dbr("BUYING_DATE")
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
        Public Shared Function ReturnFleetInventoryDtls(ByVal pFleetInventoryDtls As FleetInventoryDtls) As FleetInventoryDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_INVENTORY_DTLS", "' '")
                pFleetInventoryDtls = ReturnObjectValues(dbr, pFleetInventoryDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetInventoryDtls.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetInventoryDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetInventoryDtlsList (ByVal pFleetInventoryDtls As FleetInventoryDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetInventoryDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_INVENTORY_DTLS_BY_ID", pFleetInventoryDtls.InventId)
                arrFleetInventoryDtls = ReturnObjectValuesList(dbr, arrFleetInventoryDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetInventoryDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetInventoryDtls
        End Function
    End Class
End Namespace
