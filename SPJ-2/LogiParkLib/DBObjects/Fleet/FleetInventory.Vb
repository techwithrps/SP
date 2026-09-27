Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetInventory
    ''' @author	: Santosh Singh- 26/9/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetInventory 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngInventId As Long ' Define Private Variable InventId With DataType As Long 
        Private strItems As String ' Define Private Variable Items With DataType As String 
        Private lngVendorId As Long ' Define Private Variable VendorId With DataType As Long 
        Private lngUnitPrice As Long ' Define Private Variable UnitPrice With DataType As Long 
        Private lngQnty As Long ' Define Private Variable Qnty With DataType As Long 
        Private strBuyDate As String ' Define Private Variable BuyDate With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngItemId As Long ' Define Private Variable TerminalId With DataType As Long 

                    
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
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property ItemId() As Long
            Get
                Return lngItemId
            End Get
            Set(ByVal value As Long)
                lngItemId = value
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
        ''' Get or Set the Value of Items
        ''' </summary>
        ''' <value>strItems</value>
        ''' <returns> Return strItems</returns>
        ''' <remarks> Get or Set the Value of Items  </remarks>
        '''
        Public Property Items() as String
            Get
                Return strItems
            End Get
            Set(ByVal value As String)
                strItems = value
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
        ''' Get or Set the Value of UnitPrice
        ''' </summary>
        ''' <value>lngUnitPrice</value>
        ''' <returns> Return lngUnitPrice</returns>
        ''' <remarks> Get or Set the Value of UnitPrice  </remarks>
        '''
        Public Property UnitPrice() as Long
            Get
                Return lngUnitPrice
            End Get
            Set(ByVal value As Long)
                lngUnitPrice = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Qnty
        ''' </summary>
        ''' <value>lngQnty</value>
        ''' <returns> Return lngQnty</returns>
        ''' <remarks> Get or Set the Value of Qnty  </remarks>
        '''
        Public Property Qnty() as Long
            Get
                Return lngQnty
            End Get
            Set(ByVal value As Long)
                lngQnty = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BuyDate
        ''' </summary>
        ''' <value>strBuyDate</value>
        ''' <returns> Return strBuyDate</returns>
        ''' <remarks> Get or Set the Value of BuyDate  </remarks>
        '''
        Public Property BuyDate() as String
            Get
                Return strBuyDate
            End Get
            Set(ByVal value As String)
                strBuyDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() as String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property CreatedOn() as String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
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
            lngInventId = 0 
            strItems = ""
            lngVendorId = 0 
            lngUnitPrice = 0 
            lngQnty = 0 
            strBuyDate = ""
            strCreatedBy = ""
            lngItemId = 0
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetInventory"></param>
        ''' <returns>Return pFleetInventory Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetInventory As FleetInventory) As FleetInventory
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventory.TerminalId)
                db.AddParameter("p_INVENT_ID", pFleetInventory.InventId, ParameterDirection.Output)
                db.AddParameter("p_ITEMS", pFleetInventory.Items)
                db.AddParameter("p_ITEM_ID", pFleetInventory.ItemId)

                db.AddParameter("p_VENDOR_ID", pFleetInventory.VendorId)
                db.AddParameter("p_UNIT_PRICE", pFleetInventory.UnitPrice)
                db.AddParameter("p_QNTY", pFleetInventory.Qnty)
                db.AddParameter("p_BUY_DATE", pFleetInventory.BuyDate)
                db.AddParameter("p_CREATED_BY", pFleetInventory.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetInventory.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetInventory.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_INVENTORY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventory.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetInventory.InventId  = db.Parameters.Item("p_INVENT_ID").value
                
                If pFleetInventory.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetInventory.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetInventory
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetInventory"></param>
        ''' <returns>Return pFleetInventory Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetInventory As FleetInventory) As FleetInventory
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventory.TerminalId)
                db.AddParameter("p_INVENT_ID", pFleetInventory.InventId, ParameterDirection.Output)
                db.AddParameter("p_ITEMS", pFleetInventory.Items)
                db.AddParameter("p_ITEM_ID", pFleetInventory.ItemId)

                db.AddParameter("p_VENDOR_ID", pFleetInventory.VendorId)
                db.AddParameter("p_UNIT_PRICE", pFleetInventory.UnitPrice)
                db.AddParameter("p_QNTY", pFleetInventory.Qnty)
                db.AddParameter("p_BUY_DATE", pFleetInventory.BuyDate)
                db.AddParameter("p_CREATED_BY", pFleetInventory.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetInventory.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetInventory.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_INVENTORY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventory.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetInventory.InventId  = db.Parameters.Item("p_INVENT_ID").value
                
            Catch ex As Exception
                pFleetInventory.ErrorMsg = ex.Message
            End Try
            Return pFleetInventory
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetInventory"></param>
        ''' <returns>Return pFleetInventory Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetInventory As FleetInventory) As FleetInventory
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventory.TerminalId)
                db.AddParameter("p_INVENT_ID", pFleetInventory.InventId)
                db.AddParameter("p_ITEMS", pFleetInventory.Items)
                db.AddParameter("p_ITEM_ID", pFleetInventory.ItemId)

                db.AddParameter("p_VENDOR_ID", pFleetInventory.VendorId)
                db.AddParameter("p_UNIT_PRICE", pFleetInventory.UnitPrice)
                db.AddParameter("p_QNTY", pFleetInventory.Qnty)
                db.AddParameter("p_BUY_DATE", pFleetInventory.BuyDate)
                db.AddParameter("p_CREATED_BY", pFleetInventory.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetInventory.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetInventory.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_INVENTORY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventory.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetInventory.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetInventory.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetInventory
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetInventory"></param>
        ''' <returns>Return pFleetInventory Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetInventory As FleetInventory) As FleetInventory
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetInventory.TerminalId)
                db.AddParameter("p_INVENT_ID", pFleetInventory.InventId)
                db.AddParameter("p_ITEMS", pFleetInventory.Items)
                db.AddParameter("p_ITEM_ID", pFleetInventory.ItemId)

                db.AddParameter("p_VENDOR_ID", pFleetInventory.VendorId)
                db.AddParameter("p_UNIT_PRICE", pFleetInventory.UnitPrice)
                db.AddParameter("p_QNTY", pFleetInventory.Qnty)
                db.AddParameter("p_BUY_DATE", pFleetInventory.BuyDate)
                db.AddParameter("p_CREATED_BY", pFleetInventory.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetInventory.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetInventory.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_INVENTORY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetInventory.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetInventory.ErrorMsg = ex.Message
                End Try
            Return pFleetInventory
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetInventory As FleetInventory) As FleetInventory
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetInventory.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVENT_ID").ToString <> "" Then
                                PFleetInventory.InventId = dbr("INVENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEMS").ToString <> "" Then
                                PFleetInventory.Items = dbr("ITEMS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_ID").ToString <> "" Then
                                pFleetInventory.ItemId = dbr("ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                PFleetInventory.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UNIT_PRICE").ToString <> "" Then
                                PFleetInventory.UnitPrice = dbr("UNIT_PRICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                PFleetInventory.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUY_DATE").ToString <> "" Then
                                PFleetInventory.BuyDate = dbr("BUY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PFleetInventory.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFleetInventory.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetInventory.ErrorMsg = ex.Message
            End Try
            Return pFleetInventory
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetInventory As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetInventory
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("ITEMS").ToString <> "" Then
                                temp.Items = dbr("ITEMS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_ID").ToString <> "" Then
                                temp.ItemId = dbr("ITEM_ID")
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
                            If dbr("UNIT_PRICE").ToString <> "" Then
                                temp.UnitPrice = dbr("UNIT_PRICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                temp.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUY_DATE").ToString <> "" Then
                                temp.BuyDate = dbr("BUY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
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
        Public Shared Function ReturnFleetInventory(ByVal pFleetInventory As FleetInventory) As FleetInventory
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_INVENTORY_BY_ID", pFleetInventory.TerminalId & "," & pFleetInventory.InventId)
                pFleetInventory = ReturnObjectValues(dbr, pFleetInventory)
                dbr.Close()
            Catch ex As Exception
                pFleetInventory.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetInventory
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetInventoryList (ByVal pFleetInventory As FleetInventory) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetInventory As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_INVENTORY_ALL", pFleetInventory.TerminalId)
                arrFleetInventory = ReturnObjectValuesList(dbr, arrFleetInventory)
                dbr.Close()
            Catch ex As Exception
                arrFleetInventory = Nothing
            End Try
            db.CloseDB()
            Return arrFleetInventory
        End Function
    End Class
End Namespace
