Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects

	''' <summary>
	''' @Project/Product Name:  eLOGiFreight :: Freight Management System 
	''' @Version	: Version 1.0.0.0
	''' @Module/Class Name	: ItemMaster
	''' @author	: Amit K Singh- 01/03/2019
	''' </summary>
	''' <remarks> </remarks>
	'''
	Public Class ItemMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngItemId As Long ' Define Private Variable ItemId With DataType As Long 
        Private strItemCode As String ' Define Private Variable ItemCode With DataType As String 
        Private strItemName As String ' Define Private Variable ItemName With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngBalQnty As Long ' Define Private Variable BalQnty With DataType As Long 
		Private lngAlertQnty As Long ' Define Private Variable AlertQnty With DataType As Long 
		Private dbItemCost As Double ' Define Private Variable ItemCost With DataType As Double 
        Private strItemCostValidity As String ' Define Private Variable ItemCostValidity With DataType As Long 
        Private IngItemGroup As Long ' Define Private Variable ItemType With DataType As Long 
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
        ''' Get or Set the Value of ItemId
        ''' </summary>
        ''' <value>lngItemId</value>
        ''' <returns> Return lngItemId</returns>
        ''' <remarks> Get or Set the Value of ItemId  </remarks>
        '''
        Public Property ItemId() as Long
            Get
                Return lngItemId
            End Get
            Set(ByVal value As Long)
                lngItemId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ItemCode
        ''' </summary>
        ''' <value>strItemCode</value>
        ''' <returns> Return strItemCode</returns>
        ''' <remarks> Get or Set the Value of ItemCode  </remarks>
        '''
        Public Property ItemCode() as String
            Get
                Return strItemCode
            End Get
            Set(ByVal value As String)
                strItemCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ItemName
        ''' </summary>
        ''' <value>strItemName</value>
        ''' <returns> Return strItemName</returns>
        ''' <remarks> Get or Set the Value of ItemName  </remarks>
        '''
        Public Property ItemName() as String
            Get
                Return strItemName
            End Get
            Set(ByVal value As String)
                strItemName = value
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
        ''' Get or Set the Value of BalQnty
        ''' </summary>
        ''' <value>lngBalQnty</value>
        ''' <returns> Return lngBalQnty</returns>
        ''' <remarks> Get or Set the Value of BalQnty  </remarks>
        '''
        Public Property BalQnty() as Long
            Get
                Return lngBalQnty
            End Get
            Set(ByVal value As Long)
                lngBalQnty = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of AlertQnty
        ''' </summary>
        ''' <value>lngAlertQnty</value>
        ''' <returns> Return lngAlertQnty</returns>
        ''' <remarks> Get or Set the Value of AlertQnty  </remarks>
        '''
        Public Property AlertQnty() as Long
            Get
                Return lngAlertQnty
            End Get
            Set(ByVal value As Long)
                lngAlertQnty = value
            End Set
        End Property

		''' <summary>
		''' Get or Set the Value of ItemCost
		''' </summary>
		''' <value>dbItemCost</value>
		''' <returns> Return dbItemCost</returns>
		''' <remarks> Get or Set the Value of ItemCost  </remarks>
		'''
		Public Property ItemCost() As Double
			Get
				Return dbItemCost
			End Get
			Set(ByVal value As Double)
				dbItemCost = value
			End Set
		End Property

		''' <summary>
		''' Get or Set the Value of ItemCostValidity
		''' </summary>
		''' <value>strItemCostValidity</value>
		''' <returns> Return strItemCostValidity</returns>
		''' <remarks> Get or Set the Value of ItemCostValidity  </remarks>
		'''
		Public Property ItemCostValidity() As String
			Get
				Return strItemCostValidity
			End Get
			Set(ByVal value As String)
				strItemCostValidity = value
			End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ItemType
        ''' </summary>
        ''' <value>strItemType</value>
        ''' <returns> Return strItemType</returns>
        ''' <remarks> Get or Set the Value of strItemType  </remarks>
        '''
        Public Property ItemGroup() As Long
            Get
                Return IngItemGroup
            End Get
            Set(ByVal value As Long)
                IngItemGroup = value
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
            lngItemId = 0 
            strItemCode = ""
            strItemName = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngBalQnty = 0
			lngAlertQnty = 0
			dbItemCost = 0.0
            ItemCostValidity = ""
            IngItemGroup = 0
			strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pItemMaster"></param>
        ''' <returns>Return pItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pItemMaster As ItemMaster) As ItemMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemMaster.TerminalId)
                db.AddParameter("p_ITEM_ID", pItemMaster.ItemId, ParameterDirection.Output)
                db.AddParameter("p_ITEM_CODE", pItemMaster.ItemCode)
                db.AddParameter("p_ITEM_NAME", pItemMaster.ItemName)
                db.AddParameter("p_CREATED_BY", pItemMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemMaster.CreatedOn)
                db.AddParameter("p_BAL_QNTY", pItemMaster.BalQnty)
				db.AddParameter("p_ALERT_QNTY", pItemMaster.AlertQnty)
				db.AddParameter("p_ITEM_COST", pItemMaster.ItemCost)
                db.AddParameter("p_ITEM_COST_VALIDITY", pItemMaster.ItemCostValidity)
                db.AddParameter("p_ITEM_GROUP", pItemMaster.ItemGroup)
				db.AddParameter("p_ErrorMsg", pItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pItemMaster.ItemId  = db.Parameters.Item("p_ITEM_ID").value
                
                If pItemMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pItemMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pItemMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pItemMaster"></param>
        ''' <returns>Return pItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pItemMaster As ItemMaster) As ItemMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemMaster.TerminalId)
                db.AddParameter("p_ITEM_ID", pItemMaster.ItemId, ParameterDirection.Output)
                db.AddParameter("p_ITEM_CODE", pItemMaster.ItemCode)
                db.AddParameter("p_ITEM_NAME", pItemMaster.ItemName)
                db.AddParameter("p_CREATED_BY", pItemMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemMaster.CreatedOn)
                db.AddParameter("p_BAL_QNTY", pItemMaster.BalQnty)
				db.AddParameter("p_ALERT_QNTY", pItemMaster.AlertQnty)
				db.AddParameter("p_ITEM_COST", pItemMaster.ItemCost)
                db.AddParameter("p_ITEM_COST_VALIDITY", pItemMaster.ItemCostValidity)
                db.AddParameter("p_ITEM_GROUP", pItemMaster.ItemGroup)
				db.AddParameter("p_ErrorMsg", pItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pItemMaster.ItemId  = db.Parameters.Item("p_ITEM_ID").value
                
            Catch ex As Exception
                pItemMaster.ErrorMsg = ex.Message
            End Try
            Return pItemMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pItemMaster"></param>
        ''' <returns>Return pItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pItemMaster As ItemMaster) As ItemMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemMaster.TerminalId)
                db.AddParameter("p_ITEM_ID", pItemMaster.ItemId)
                db.AddParameter("p_ITEM_CODE", pItemMaster.ItemCode)
                db.AddParameter("p_ITEM_NAME", pItemMaster.ItemName)
                db.AddParameter("p_CREATED_BY", pItemMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemMaster.CreatedOn)
                db.AddParameter("p_BAL_QNTY", pItemMaster.BalQnty)
				db.AddParameter("p_ALERT_QNTY", pItemMaster.AlertQnty)
				db.AddParameter("p_ITEM_COST", pItemMaster.ItemCost)
                db.AddParameter("p_ITEM_COST_VALIDITY", pItemMaster.ItemCostValidity)
                db.AddParameter("p_ITEM_GROUP", pItemMaster.ItemGroup)
				db.AddParameter("p_ErrorMsg", pItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pItemMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pItemMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pItemMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pItemMaster"></param>
        ''' <returns>Return pItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pItemMaster As ItemMaster) As ItemMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemMaster.TerminalId)
                db.AddParameter("p_ITEM_ID", pItemMaster.ItemId)
                db.AddParameter("p_ITEM_CODE", pItemMaster.ItemCode)
                db.AddParameter("p_ITEM_NAME", pItemMaster.ItemName)
                db.AddParameter("p_CREATED_BY", pItemMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemMaster.CreatedOn)
                db.AddParameter("p_BAL_QNTY", pItemMaster.BalQnty)
				db.AddParameter("p_ALERT_QNTY", pItemMaster.AlertQnty)
				db.AddParameter("p_ITEM_COST", pItemMaster.ItemCost)
                db.AddParameter("p_ITEM_COST_VALIDITY", pItemMaster.ItemCostValidity)
                db.AddParameter("p_ITEM_GROUP", pItemMaster.ItemGroup)
				db.AddParameter("p_ErrorMsg", pItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pItemMaster.ErrorMsg = ex.Message
                End Try
            Return pItemMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pItemMaster As ItemMaster) As ItemMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PItemMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_ID").ToString <> "" Then
                                PItemMaster.ItemId = dbr("ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_CODE").ToString <> "" Then
                                PItemMaster.ItemCode = dbr("ITEM_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_NAME").ToString <> "" Then
                                PItemMaster.ItemName = dbr("ITEM_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PItemMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PItemMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_QNTY").ToString <> "" Then
                                PItemMaster.BalQnty = dbr("BAL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
						Try
							If dbr("ALERT_QNTY").ToString <> "" Then
								PItemMaster.AlertQnty = dbr("ALERT_QNTY")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("ITEM_COST").ToString <> "" Then
								pItemMaster.ItemCost = dbr("ITEM_COST")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("ITEM_COST_VALIDITY").ToString <> "" Then
								pItemMaster.ItemCostValidity = dbr("ITEM_COST_VALIDITY")
							End If
						Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP").ToString <> "" Then
                                pItemMaster.ItemGroup = dbr("ITEM_GROUP")
                            End If
                        Catch ex1 As Exception
                        End Try
					End While
                end If
            Catch ex As Exception
                pItemMaster.ErrorMsg = ex.Message
            End Try
            Return pItemMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrItemMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ItemMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("ITEM_CODE").ToString <> "" Then
                                temp.ItemCode = dbr("ITEM_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_NAME").ToString <> "" Then
                                temp.ItemName = dbr("ITEM_NAME")
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
                        Try
                            If dbr("BAL_QNTY").ToString <> "" Then
                                temp.BalQnty = dbr("BAL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
						Try
							If dbr("ALERT_QNTY").ToString <> "" Then
								temp.AlertQnty = dbr("ALERT_QNTY")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("ITEM_COST").ToString <> "" Then
								temp.ItemCost = dbr("ITEM_COST")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("ITEM_COST_VALIDITY").ToString <> "" Then
								temp.ItemCostValidity = dbr("ITEM_COST_VALIDITY")
							End If
						Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP").ToString <> "" Then
                                temp.ItemGroup = dbr("ITEM_GROUP")
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
        Public Shared Function ReturnItemMaster(ByVal pItemMaster As ItemMaster) As ItemMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ITEM_MASTER_BY_ID", pItemMaster.TerminalId & "," & pItemMaster.ItemId)
                pItemMaster = ReturnObjectValues(dbr, pItemMaster)
                dbr.Close()
            Catch ex As Exception
                pItemMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pItemMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnItemMasterList (ByVal pItemMaster As ItemMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrItemMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ITEM_MASTER_ALL", pItemMaster.TerminalId)
                arrItemMaster = ReturnObjectValuesList(dbr, arrItemMaster)
                dbr.Close()
            Catch ex As Exception
                arrItemMaster = Nothing
            End Try
            db.CloseDB()
            Return arrItemMaster
        End Function
    End Class
End Namespace
