Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetJoItemDtls
    ''' @author	: Santosh Singh- 29/9/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetJoItemDtls 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngJoDtlsId As Long ' Define Private Variable JoDtlsId With DataType As Long 
        Private lngJoId As Long ' Define Private Variable JoId With DataType As Long 
        Private lngItemId As Long ' Define Private Variable ItemId With DataType As Long 
        Private lngJoQnty As Long ' Define Private Variable JoQnty With DataType As Long 
        Private lngJoPrice As Double ' Define Private Variable JoPrice With DataType As Long 
        Private IngScrap As Double ' Define Private Variable JoPrice With DataType As Long 
        Private lngCloseQnty As Long ' Define Private Variable CloseQnty With DataType As Long
        Private strItemName As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngAvlQnty As Long ' Define Private Variable JoQnty With DataType As Long 
        Private lngItemGroupId As Long
        Private lngAvgRate As Double
        Private strPart1 As String
        Private strPart2 As String
        Private strPart3 As String
        Private strPart4 As String
        Private strPart5 As String

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
        ''' Get or Set the Value of JoDtlsId
        ''' </summary>
        ''' <value>lngJoDtlsId</value>
        ''' <returns> Return lngJoDtlsId</returns>
        ''' <remarks> Get or Set the Value of JoDtlsId  </remarks>
        '''
        Public Property JoDtlsId() as Long
            Get
                Return lngJoDtlsId
            End Get
            Set(ByVal value As Long)
                lngJoDtlsId = value
            End Set
        End Property

        Public Property AvgRate() As Double
            Get
                Return lngAvgRate
            End Get
            Set(ByVal value As Double)
                lngAvgRate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of JoDtlsId
        ''' </summary>
        ''' <value>lngJoDtlsId</value>
        ''' <returns> Return lngJoDtlsId</returns>
        ''' <remarks> Get or Set the Value of JoDtlsId  </remarks>
        '''
        Public Property AVlQnty() As Long
            Get
                Return lngAvlQnty
            End Get
            Set(ByVal value As Long)
                lngAvlQnty = value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                Return strItemName
            End Get
            Set(ByVal value As String)
                strItemName = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of JoId
        ''' </summary>
        ''' <value>lngJoId</value>
        ''' <returns> Return lngJoId</returns>
        ''' <remarks> Get or Set the Value of JoId  </remarks>
        '''
        Public Property JoId() as Long
            Get
                Return lngJoId
            End Get
            Set(ByVal value As Long)
                lngJoId = value
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
        ''' Get or Set the Value of ItemId
        ''' </summary>
        ''' <value>lngItemId</value>
        ''' <returns> Return lngItemId</returns>
        ''' <remarks> Get or Set the Value of ItemId  </remarks>
        '''
        Public Property ItemGroupId() As Long
            Get
                Return lngItemGroupId
            End Get
            Set(ByVal value As Long)
                lngItemGroupId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of JoQnty
        ''' </summary>
        ''' <value>lngJoQnty</value>
        ''' <returns> Return lngJoQnty</returns>
        ''' <remarks> Get or Set the Value of JoQnty  </remarks>
        '''
        Public Property JoQnty() as Long
            Get
                Return lngJoQnty
            End Get
            Set(ByVal value As Long)
                lngJoQnty = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JoPrice
        ''' </summary>
        ''' <value>lngJoPrice</value>
        ''' <returns> Return lngJoPrice</returns>
        ''' <remarks> Get or Set the Value of JoPrice  </remarks>
        '''
        Public Property JoPrice() As Double
            Get
                Return lngJoPrice
            End Get
            Set(ByVal value As Double)
                lngJoPrice = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Scrap
        ''' </summary>
        ''' <value>lngScrap</value>
        ''' <returns> Return lngScrap</returns>
        ''' <remarks> Get or Set the Value of Scrap  </remarks>
        '''
        Public Property Scrap() As Double
            Get
                Return IngScrap
            End Get
            Set(ByVal value As Double)
                IngScrap = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CloseQnty
        ''' </summary>
        ''' <value>lngCloseQnty</value>
        ''' <returns> Return lngCloseQnty</returns>
        ''' <remarks> Get or Set the Value of CloseQnty  </remarks>
        '''
        Public Property CloseQnty() as Long
            Get
                Return lngCloseQnty
            End Get
            Set(ByVal value As Long)
                lngCloseQnty = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Part1
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Part1() As String
            Get
                Return strPart1
            End Get
            Set(ByVal value As String)
                strPart1 = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Part1
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Part2() As String
            Get
                Return strPart2
            End Get
            Set(ByVal value As String)
                strPart2 = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Part1
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Part3() As String
            Get
                Return strPart3
            End Get
            Set(ByVal value As String)
                strPart3 = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Part1
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Part4() As String
            Get
                Return strPart4
            End Get
            Set(ByVal value As String)
                strPart4 = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Part1
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Part5() As String
            Get
                Return strPart5
            End Get
            Set(ByVal value As String)
                strPart5 = value
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
            lngJoDtlsId = 0 
            lngJoId = 0 
            lngItemId = 0 
            lngJoQnty = 0 
            lngJoPrice = 0
            IngScrap = 0
            lngCloseQnty = 0
            lngAvlQnty = 0
            strItemName = ""
            strErrormsg = ""
            strPart1 = ""
            strPart2 = ""
            strPart3 = ""
            strPart4 = ""
            strPart5 = ""
            lngAvgRate = 0
            lngItemGroupId = 0
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetJoItemDtls"></param>
        ''' <returns>Return pFleetJoItemDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetJoItemDtls As FleetJoItemDtls) As FleetJoItemDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoItemDtls.TerminalId)
                db.AddParameter("p_JO_DTLS_ID", pFleetJoItemDtls.JoDtlsId, ParameterDirection.Output)
                db.AddParameter("p_JO_ID", pFleetJoItemDtls.JoId)
                db.AddParameter("p_ITEM_ID", pFleetJoItemDtls.ItemId)
                db.AddParameter("p_JO_QNTY", pFleetJoItemDtls.JoQnty)
                db.AddParameter("p_JO_PRICE", pFleetJoItemDtls.JoPrice)
                db.AddParameter("p_CLOSE_QNTY", pFleetJoItemDtls.CloseQnty)
                db.AddParameter("p_PART_1", pFleetJoItemDtls.Part1)
                db.AddParameter("p_PART_2", pFleetJoItemDtls.Part2)
                db.AddParameter("p_PART_3", pFleetJoItemDtls.Part3)
                db.AddParameter("p_PART_4", pFleetJoItemDtls.Part4)
                db.AddParameter("p_PART_5", pFleetJoItemDtls.Part5)
                db.AddParameter("p_SCRAP", pFleetJoItemDtls.Scrap)
                db.AddParameter("p_ErrorMsg", pFleetJoItemDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_JO_ITEM_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoItemDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetJoItemDtls.JoDtlsId  = db.Parameters.Item("p_JO_DTLS_ID").value
                
                If pFleetJoItemDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetJoItemDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetJoItemDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetJoItemDtls"></param>
        ''' <returns>Return pFleetJoItemDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetJoItemDtls As FleetJoItemDtls) As FleetJoItemDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoItemDtls.TerminalId)
                db.AddParameter("p_JO_DTLS_ID", pFleetJoItemDtls.JoDtlsId, ParameterDirection.Output)
                db.AddParameter("p_JO_ID", pFleetJoItemDtls.JoId)
                db.AddParameter("p_ITEM_ID", pFleetJoItemDtls.ItemId)
                db.AddParameter("p_ITEM_NAME", pFleetJoItemDtls.ItemName)
                db.AddParameter("p_JO_QNTY", pFleetJoItemDtls.JoQnty)
                db.AddParameter("p_JO_PRICE", pFleetJoItemDtls.JoPrice)
                db.AddParameter("p_CLOSE_QNTY", pFleetJoItemDtls.CloseQnty)
                db.AddParameter("p_ITEM_GROUP_ID", pFleetJoItemDtls.ItemGroupId)
                db.AddParameter("p_PART_1", pFleetJoItemDtls.Part1)
                db.AddParameter("p_PART_2", pFleetJoItemDtls.Part2)
                db.AddParameter("p_PART_3", pFleetJoItemDtls.Part3)
                db.AddParameter("p_PART_4", pFleetJoItemDtls.Part4)
                db.AddParameter("p_PART_5", pFleetJoItemDtls.Part5)
                db.AddParameter("p_SCRAP", pFleetJoItemDtls.Scrap)
                db.AddParameter("p_AVG_RATE", pFleetJoItemDtls.AvgRate)
                db.AddParameter("p_ErrorMsg", pFleetJoItemDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_JO_ITEM_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoItemDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetJoItemDtls.JoDtlsId  = db.Parameters.Item("p_JO_DTLS_ID").value
                
            Catch ex As Exception
                pFleetJoItemDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetJoItemDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetJoItemDtls"></param>
        ''' <returns>Return pFleetJoItemDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetJoItemDtls As FleetJoItemDtls) As FleetJoItemDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoItemDtls.TerminalId)
                db.AddParameter("p_JO_DTLS_ID", pFleetJoItemDtls.JoDtlsId)
                db.AddParameter("p_JO_ID", pFleetJoItemDtls.JoId)
                db.AddParameter("p_ITEM_ID", pFleetJoItemDtls.ItemId)
                db.AddParameter("p_JO_QNTY", pFleetJoItemDtls.JoQnty)
                db.AddParameter("p_JO_PRICE", pFleetJoItemDtls.JoPrice)
                db.AddParameter("p_CLOSE_QNTY", pFleetJoItemDtls.CloseQnty)
                db.AddParameter("p_ITEM_GROUP_ID", pFleetJoItemDtls.ItemGroupId)
                db.AddParameter("p_SCRAP", pFleetJoItemDtls.Scrap)
                db.AddParameter("p_ErrorMsg", pFleetJoItemDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_JO_ITEM_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoItemDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetJoItemDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetJoItemDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetJoItemDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetJoItemDtls"></param>
        ''' <returns>Return pFleetJoItemDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetJoItemDtls As FleetJoItemDtls) As FleetJoItemDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoItemDtls.TerminalId)
                db.AddParameter("p_JO_DTLS_ID", pFleetJoItemDtls.JoDtlsId)
                db.AddParameter("p_JO_ID", pFleetJoItemDtls.JoId)
                db.AddParameter("p_ITEM_ID", pFleetJoItemDtls.ItemId)
                db.AddParameter("p_JO_QNTY", pFleetJoItemDtls.JoQnty)
                db.AddParameter("p_JO_PRICE", pFleetJoItemDtls.JoPrice)
                db.AddParameter("p_CLOSE_QNTY", pFleetJoItemDtls.CloseQnty)
                db.AddParameter("p_ITEM_GROUP_ID", pFleetJoItemDtls.ItemGroupId)
                db.AddParameter("p_SCRAP", pFleetJoItemDtls.Scrap)
                db.AddParameter("p_AVG_RATE", pFleetJoItemDtls.AvgRate)
                db.AddParameter("p_ErrorMsg", pFleetJoItemDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_JO_ITEM_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoItemDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetJoItemDtls.ErrorMsg = ex.Message
                End Try
            Return pFleetJoItemDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetJoItemDtls As FleetJoItemDtls) As FleetJoItemDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetJoItemDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DTLS_ID").ToString <> "" Then
                                PFleetJoItemDtls.JoDtlsId = dbr("JO_DTLS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                PFleetJoItemDtls.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_ID").ToString <> "" Then
                                PFleetJoItemDtls.ItemId = dbr("ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("ITEM_GROUP_ID").ToString <> "" Then
                                pFleetJoItemDtls.ItemGroupId = dbr("ITEM_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("JO_QNTY").ToString <> "" Then
                                PFleetJoItemDtls.JoQnty = dbr("JO_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_PRICE").ToString <> "" Then
                                PFleetJoItemDtls.JoPrice = dbr("JO_PRICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_QNTY").ToString <> "" Then
                                PFleetJoItemDtls.CloseQnty = dbr("CLOSE_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AVL_QNTY").ToString <> "" Then
                                pFleetJoItemDtls.AVlQnty = dbr("AVL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_NAME").ToString <> "" Then
                                pFleetJoItemDtls.ItemName = dbr("ITEM_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_1").ToString <> "" Then
                                pFleetJoItemDtls.Part1 = dbr("PART_1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_2").ToString <> "" Then
                                pFleetJoItemDtls.Part2 = dbr("PART_2")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_3").ToString <> "" Then
                                pFleetJoItemDtls.Part3 = dbr("PART_3")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_4").ToString <> "" Then
                                pFleetJoItemDtls.Part4 = dbr("PART_4")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_5").ToString <> "" Then
                                pFleetJoItemDtls.Part5 = dbr("PART_5")
                            End If
                            Try
                                If dbr("SCRAP").ToString <> "" Then
                                    pFleetJoItemDtls.Scrap = dbr("SCRAP")
                                End If
                            Catch ex1 As Exception
                            End Try
                            Try
                                If dbr("AVG_RATE").ToString <> "" Then
                                    pFleetJoItemDtls.AvgRate = dbr("AVG_RATE")
                                End If
                            Catch ex1 As Exception
                            End Try
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetJoItemDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetJoItemDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetJoItemDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetJoItemDtls
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DTLS_ID").ToString <> "" Then
                                temp.JoDtlsId = dbr("JO_DTLS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                temp.JoId = dbr("JO_ID")
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
                            If dbr("JO_QNTY").ToString <> "" Then
                                temp.JoQnty = dbr("JO_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_PRICE").ToString <> "" Then
                                temp.JoPrice = dbr("JO_PRICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_QNTY").ToString <> "" Then
                                temp.CloseQnty = dbr("CLOSE_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AVL_QNTY").ToString <> "" Then
                                temp.AVlQnty = dbr("AVL_QNTY")
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
                            If dbr("PART_1").ToString <> "" Then
                                temp.Part1 = dbr("PART_1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_2").ToString <> "" Then
                                temp.Part2 = dbr("PART_2")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_3").ToString <> "" Then
                                temp.Part3 = dbr("PART_3")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_4").ToString <> "" Then
                                temp.Part4 = dbr("PART_4")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PART_5").ToString <> "" Then
                                temp.Part5 = dbr("PART_5")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP_ID").ToString <> "" Then
                                temp.ItemGroupId = dbr("ITEM_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SCRAP").ToString <> "" Then
                                temp.Scrap = dbr("SCRAP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AVG_RATE").ToString <> "" Then
                                temp.AvgRate = dbr("AVG_RATE")
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
        Public Shared Function ReturnFleetJoItemDtls(ByVal pFleetJoItemDtls As FleetJoItemDtls) As FleetJoItemDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_JO_ITEM_DTLS_BY_ID", pFleetJoItemDtls.TerminalId & "," & pFleetJoItemDtls.JoDtlsId)
                pFleetJoItemDtls = ReturnObjectValues(dbr, pFleetJoItemDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetJoItemDtls.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetJoItemDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetJoItemDtlsList (ByVal pFleetJoItemDtls As FleetJoItemDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetJoItemDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_JO_ITEM_DTLS_BY_JO", pFleetJoItemDtls.TerminalId & "," & pFleetJoItemDtls.JoId)
                arrFleetJoItemDtls = ReturnObjectValuesList(dbr, arrFleetJoItemDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetJoItemDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetJoItemDtls
        End Function
    End Class
End Namespace
