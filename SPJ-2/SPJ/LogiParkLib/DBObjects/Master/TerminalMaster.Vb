Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TerminalMaster
    ''' @author	: Amit K. Singh- 5/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TerminalMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strTerminalCode As String ' Define Private Variable TerminalCode With DataType As String 
        Private strTerminalName As String ' Define Private Variable TerminalName With DataType As String 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private strCountry As String ' Define Private Variable Country With DataType As String 
        Private strContactPerson As String ' Define Private Variable ContactPerson With DataType As String 
        Private strEmailId As String ' Define Private Variable EmailId With DataType As String 
        Private strContactNo As String ' Define Private Variable ContactNo With DataType As String 
        Private strServiceTaxNo As String ' Define Private Variable ServiceTaxNo With DataType As String 
        Private strPanNo As String ' Define Private Variable PanNo With DataType As String 
        Private dblCartingRate As Double ' Define Private Variable CartingRate With DataType As Double 
        Private dblMinimumCartingWt As Double ' Define Private Variable MinimumCartingWt With DataType As Double 
        Private lngOwnerId As Long ' Define Private Variable OwnerId With DataType As Long 
        Private lngOperatorId As Long ' Define Private Variable OperatorId With DataType As Long 
        Private strWebSite As String ' Define Private Variable WebSite With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private LngGroupTerminal As Long ' Define Private Variable Errormsg With DataType As String 
        Private lngPortType As Long ' Define Private Variable Errormsg With DataType As String 
        Private arrLocationList As ArrayList

        Public Property TerminalLocationList() As ArrayList
            Get
                Return arrLocationList
            End Get
            Set(ByVal value As ArrayList)
                arrLocationList = value
            End Set
        End Property
                    
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
        Public Property GroupTerminal() As Long
            Get
                Return LngGroupTerminal
            End Get
            Set(ByVal value As Long)
                LngGroupTerminal = value
            End Set
        End Property
        Public Property PortType() As Long
            Get
                Return lngPortType
            End Get
            Set(ByVal value As Long)
                lngPortType = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TerminalCode
        ''' </summary>
        ''' <value>strTerminalCode</value>
        ''' <returns> Return strTerminalCode</returns>
        ''' <remarks> Get or Set the Value of TerminalCode  </remarks>
        '''
        Public Property TerminalCode() as String
            Get
                Return strTerminalCode
            End Get
            Set(ByVal value As String)
                strTerminalCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TerminalName
        ''' </summary>
        ''' <value>strTerminalName</value>
        ''' <returns> Return strTerminalName</returns>
        ''' <remarks> Get or Set the Value of TerminalName  </remarks>
        '''
        Public Property TerminalName() as String
            Get
                Return strTerminalName
            End Get
            Set(ByVal value As String)
                strTerminalName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks> Get or Set the Value of Address  </remarks>
        '''
        Public Property Address() as String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Country
        ''' </summary>
        ''' <value>strCountry</value>
        ''' <returns> Return strCountry</returns>
        ''' <remarks> Get or Set the Value of Country  </remarks>
        '''
        Public Property Country() as String
            Get
                Return strCountry
            End Get
            Set(ByVal value As String)
                strCountry = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContactPerson
        ''' </summary>
        ''' <value>strContactPerson</value>
        ''' <returns> Return strContactPerson</returns>
        ''' <remarks> Get or Set the Value of ContactPerson  </remarks>
        '''
        Public Property ContactPerson() as String
            Get
                Return strContactPerson
            End Get
            Set(ByVal value As String)
                strContactPerson = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EmailId
        ''' </summary>
        ''' <value>strEmailId</value>
        ''' <returns> Return strEmailId</returns>
        ''' <remarks> Get or Set the Value of EmailId  </remarks>
        '''
        Public Property EmailId() as String
            Get
                Return strEmailId
            End Get
            Set(ByVal value As String)
                strEmailId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContactNumber
        ''' </summary>
        ''' <value>strContactNumber</value>
        ''' <returns> Return strContactNumber</returns>
        ''' <remarks> Get or Set the Value of ContactNumber  </remarks>
        '''
        Public Property ContactNo() As String
            Get
                Return strContactNo
            End Get
            Set(ByVal value As String)
                strContactNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceTaxNo
        ''' </summary>
        ''' <value>strServiceTaxNo</value>
        ''' <returns> Return strServiceTaxNo</returns>
        ''' <remarks> Get or Set the Value of ServiceTaxNo  </remarks>
        '''
        Public Property ServiceTaxNo() as String
            Get
                Return strServiceTaxNo
            End Get
            Set(ByVal value As String)
                strServiceTaxNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PanNo
        ''' </summary>
        ''' <value>strPanNo</value>
        ''' <returns> Return strPanNo</returns>
        ''' <remarks> Get or Set the Value of PanNo  </remarks>
        '''
        Public Property PanNo() as String
            Get
                Return strPanNo
            End Get
            Set(ByVal value As String)
                strPanNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CartingRate
        ''' </summary>
        ''' <value>dblCartingRate</value>
        ''' <returns> Return dblCartingRate</returns>
        ''' <remarks> Get or Set the Value of CartingRate  </remarks>
        '''
        Public Property CartingRate() as Double
            Get
                Return dblCartingRate
            End Get
            Set(ByVal value As Double)
                dblCartingRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MinimumCartingWt
        ''' </summary>
        ''' <value>dblMinimumCartingWt</value>
        ''' <returns> Return dblMinimumCartingWt</returns>
        ''' <remarks> Get or Set the Value of MinimumCartingWt  </remarks>
        '''
        Public Property MinimumCartingWt() as Double
            Get
                Return dblMinimumCartingWt
            End Get
            Set(ByVal value As Double)
                dblMinimumCartingWt = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OwnerId
        ''' </summary>
        ''' <value>lngOwnerId</value>
        ''' <returns> Return lngOwnerId</returns>
        ''' <remarks> Get or Set the Value of OwnerId  </remarks>
        '''
        Public Property OwnerId() as Long
            Get
                Return lngOwnerId
            End Get
            Set(ByVal value As Long)
                lngOwnerId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OperatorId
        ''' </summary>
        ''' <value>lngOperatorId</value>
        ''' <returns> Return lngOperatorId</returns>
        ''' <remarks> Get or Set the Value of OperatorId  </remarks>
        '''
        Public Property OperatorId() as Long
            Get
                Return lngOperatorId
            End Get
            Set(ByVal value As Long)
                lngOperatorId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of WebSite
        ''' </summary>
        ''' <value>strWebSite</value>
        ''' <returns> Return strWebSite</returns>
        ''' <remarks> Get or Set the Value of WebSite  </remarks>
        '''
        Public Property WebSite() as String
            Get
                Return strWebSite
            End Get
            Set(ByVal value As String)
                strWebSite = value
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
            strTerminalCode = ""
            strTerminalName = ""
            strAddress = ""
            strCountry = ""
            strContactPerson = ""
            strEmailId = ""
            strContactNo = ""
            strServiceTaxNo = ""
            strPanNo = ""
            dblCartingRate = 0.0 
            dblMinimumCartingWt = 0.0 
            lngOwnerId = 0 
            lngOperatorId = 0 
            strWebSite = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            LngGroupTerminal = 0
            lngPortType = 0
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTerminalMaster"></param>
        ''' <returns>Return pTerminalMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalMaster.TerminalId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_CODE", pTerminalMaster.TerminalCode)
                db.AddParameter("p_TERMINAL_NAME", pTerminalMaster.TerminalName)
                db.AddParameter("p_ADDRESS", pTerminalMaster.Address)
                db.AddParameter("p_COUNTRY", pTerminalMaster.Country)
                db.AddParameter("p_CONTACT_PERSON", pTerminalMaster.ContactPerson)
                db.AddParameter("p_EMAIL_ID", pTerminalMaster.EmailId)
                db.AddParameter("p_CONTACT_NUMBER", pTerminalMaster.ContactNo)
                db.AddParameter("p_SERVICE_TAX_NO", pTerminalMaster.ServiceTaxNo)
                db.AddParameter("p_PAN_NO", pTerminalMaster.PanNo)
                db.AddParameter("p_CARTING_RATE", pTerminalMaster.CartingRate)
                db.AddParameter("p_MINIMUM_CARTING_WT", pTerminalMaster.MinimumCartingWt)
                db.AddParameter("p_OWNER_ID", pTerminalMaster.OwnerId)
                db.AddParameter("p_OPERATOR_ID", pTerminalMaster.OperatorId)
                db.AddParameter("p_WEB_SITE", pTerminalMaster.WebSite)
                db.AddParameter("p_CREATED_BY", pTerminalMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalMaster.CreatedOn)
                db.AddParameter("p_GROUP_TERMINAL", pTerminalMaster.GroupTerminal)
                db.AddParameter("p_PORT_TYPE", pTerminalMaster.PortType)
                db.AddParameter("p_ErrorMsg", pTerminalMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalMaster.TerminalId = db.Parameters.Item("p_TERMINAL_ID").value
                
                If pTerminalMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalMaster"></param>
        ''' <returns>Return pTerminalMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalMaster.TerminalId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_CODE", pTerminalMaster.TerminalCode)
                db.AddParameter("p_TERMINAL_NAME", pTerminalMaster.TerminalName)
                db.AddParameter("p_ADDRESS", pTerminalMaster.Address)
                db.AddParameter("p_COUNTRY", pTerminalMaster.Country)
                db.AddParameter("p_CONTACT_PERSON", pTerminalMaster.ContactPerson)
                db.AddParameter("p_EMAIL_ID", pTerminalMaster.EmailId)
                db.AddParameter("p_CONTACT_NUMBER", pTerminalMaster.ContactNo)
                db.AddParameter("p_SERVICE_TAX_NO", pTerminalMaster.ServiceTaxNo)
                db.AddParameter("p_PAN_NO", pTerminalMaster.PanNo)
                db.AddParameter("p_CARTING_RATE", pTerminalMaster.CartingRate)
                db.AddParameter("p_MINIMUM_CARTING_WT", pTerminalMaster.MinimumCartingWt)
                db.AddParameter("p_OWNER_ID", pTerminalMaster.OwnerId)
                db.AddParameter("p_OPERATOR_ID", pTerminalMaster.OperatorId)
                db.AddParameter("p_WEB_SITE", pTerminalMaster.WebSite)
                db.AddParameter("p_CREATED_BY", pTerminalMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalMaster.CreatedOn)
                db.AddParameter("p_GROUP_TERMINAL", pTerminalMaster.GroupTerminal)
                db.AddParameter("p_PORT_TYPE", pTerminalMaster.PortType)
                db.AddParameter("p_ErrorMsg", pTerminalMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalMaster.TerminalId = db.Parameters.Item("p_TERMINAL_ID").value
            Catch ex As Exception
                pTerminalMaster.ErrorMsg = ex.Message
            End Try
            Return pTerminalMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTerminalMaster"></param>
        ''' <returns>Return pTerminalMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalMaster.TerminalId)
                db.AddParameter("p_TERMINAL_CODE", pTerminalMaster.TerminalCode)
                db.AddParameter("p_TERMINAL_NAME", pTerminalMaster.TerminalName)
                db.AddParameter("p_ADDRESS", pTerminalMaster.Address)
                db.AddParameter("p_COUNTRY", pTerminalMaster.Country)
                db.AddParameter("p_CONTACT_PERSON", pTerminalMaster.ContactPerson)
                db.AddParameter("p_EMAIL_ID", pTerminalMaster.EmailId)
                db.AddParameter("p_CONTACT_NUMBER", pTerminalMaster.ContactNo)
                db.AddParameter("p_SERVICE_TAX_NO", pTerminalMaster.ServiceTaxNo)
                db.AddParameter("p_PAN_NO", pTerminalMaster.PanNo)
                db.AddParameter("p_CARTING_RATE", pTerminalMaster.CartingRate)
                db.AddParameter("p_MINIMUM_CARTING_WT", pTerminalMaster.MinimumCartingWt)
                db.AddParameter("p_OWNER_ID", pTerminalMaster.OwnerId)
                db.AddParameter("p_OPERATOR_ID", pTerminalMaster.OperatorId)
                db.AddParameter("p_WEB_SITE", pTerminalMaster.WebSite)
                db.AddParameter("p_CREATED_BY", pTerminalMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalMaster.CreatedOn)
                db.AddParameter("p_GROUP_TERMINAL", pTerminalMaster.GroupTerminal)
                db.AddParameter("p_PORT_TYPE", pTerminalMaster.PortType)
                db.AddParameter("p_ErrorMsg", pTerminalMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTerminalMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalMaster"></param>
        ''' <returns>Return pTerminalMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalMaster.TerminalId)
                db.AddParameter("p_TERMINAL_CODE", pTerminalMaster.TerminalCode)
                db.AddParameter("p_TERMINAL_NAME", pTerminalMaster.TerminalName)
                db.AddParameter("p_ADDRESS", pTerminalMaster.Address)
                db.AddParameter("p_COUNTRY", pTerminalMaster.Country)
                db.AddParameter("p_CONTACT_PERSON", pTerminalMaster.ContactPerson)
                db.AddParameter("p_EMAIL_ID", pTerminalMaster.EmailId)
                db.AddParameter("p_CONTACT_NUMBER", pTerminalMaster.ContactNo)
                db.AddParameter("p_SERVICE_TAX_NO", pTerminalMaster.ServiceTaxNo)
                db.AddParameter("p_PAN_NO", pTerminalMaster.PanNo)
                db.AddParameter("p_CARTING_RATE", pTerminalMaster.CartingRate)
                db.AddParameter("p_MINIMUM_CARTING_WT", pTerminalMaster.MinimumCartingWt)
                db.AddParameter("p_OWNER_ID", pTerminalMaster.OwnerId)
                db.AddParameter("p_OPERATOR_ID", pTerminalMaster.OperatorId)
                db.AddParameter("p_WEB_SITE", pTerminalMaster.WebSite)
                db.AddParameter("p_CREATED_BY", pTerminalMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalMaster.CreatedOn)
                db.AddParameter("p_GROUP_TERMINAL", pTerminalMaster.GroupTerminal)
                db.AddParameter("p_PORT_TYPE", pTerminalMaster.PortType)
                db.AddParameter("p_ErrorMsg", pTerminalMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTerminalMaster.ErrorMsg = ex.Message
                End Try
            Return pTerminalMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTerminalMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_CODE").ToString <> "" Then
                                PTerminalMaster.TerminalCode = dbr("TERMINAL_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_NAME").ToString <> "" Then
                                PTerminalMaster.TerminalName = dbr("TERMINAL_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PTerminalMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY").ToString <> "" Then
                                PTerminalMaster.Country = dbr("COUNTRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_PERSON").ToString <> "" Then
                                PTerminalMaster.ContactPerson = dbr("CONTACT_PERSON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                PTerminalMaster.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                pTerminalMaster.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX_NO").ToString <> "" Then
                                PTerminalMaster.ServiceTaxNo = dbr("SERVICE_TAX_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAN_NO").ToString <> "" Then
                                PTerminalMaster.PanNo = dbr("PAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARTING_RATE").ToString <> "" Then
                                PTerminalMaster.CartingRate = dbr("CARTING_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MINIMUM_CARTING_WT").ToString <> "" Then
                                PTerminalMaster.MinimumCartingWt = dbr("MINIMUM_CARTING_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OWNER_ID").ToString <> "" Then
                                PTerminalMaster.OwnerId = dbr("OWNER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPERATOR_ID").ToString <> "" Then
                                PTerminalMaster.OperatorId = dbr("OPERATOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEB_SITE").ToString <> "" Then
                                PTerminalMaster.WebSite = dbr("WEB_SITE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTerminalMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTerminalMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GROUP_TERMINAL").ToString <> "" Then
                                pTerminalMaster.GroupTerminal = dbr("GROUP_TERMINAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_TYPE").ToString <> "" Then
                                pTerminalMaster.PortType = dbr("PORT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTerminalMaster.ErrorMsg = ex.Message
            End Try
            Return pTerminalMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTerminalMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TerminalMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_CODE").ToString <> "" Then
                                temp.TerminalCode = dbr("TERMINAL_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_NAME").ToString <> "" Then
                                temp.TerminalName = dbr("TERMINAL_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                temp.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY").ToString <> "" Then
                                temp.Country = dbr("COUNTRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_PERSON").ToString <> "" Then
                                temp.ContactPerson = dbr("CONTACT_PERSON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                temp.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                temp.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX_NO").ToString <> "" Then
                                temp.ServiceTaxNo = dbr("SERVICE_TAX_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAN_NO").ToString <> "" Then
                                temp.PanNo = dbr("PAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARTING_RATE").ToString <> "" Then
                                temp.CartingRate = dbr("CARTING_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MINIMUM_CARTING_WT").ToString <> "" Then
                                temp.MinimumCartingWt = dbr("MINIMUM_CARTING_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OWNER_ID").ToString <> "" Then
                                temp.OwnerId = dbr("OWNER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPERATOR_ID").ToString <> "" Then
                                temp.OperatorId = dbr("OPERATOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEB_SITE").ToString <> "" Then
                                temp.WebSite = dbr("WEB_SITE")
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
                            If dbr("GROUP_TERMINAL").ToString <> "" Then
                                temp.GroupTerminal = dbr("GROUP_TERMINAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_TYPE").ToString <> "" Then
                                temp.PortType = dbr("PORT_TYPE")
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
        Public Shared Function ReturnTerminalMaster(ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_MASTER_BY_ID", pTerminalMaster.TerminalId)
                pTerminalMaster = ReturnObjectValues(dbr, pTerminalMaster)
                dbr.Close()
            Catch ex As Exception
                pTerminalMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTerminalMasterList (ByVal pTerminalMaster As TerminalMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_MASTER_ALL", " ")
                arrTerminalMaster = ReturnObjectValuesList(dbr, arrTerminalMaster)
                dbr.Close()
            Catch ex As Exception
                arrTerminalMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTerminalMasterListById(ByVal pTerminalMaster As TerminalMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_MASTER_BY_ID", pTerminalMaster.TerminalId)
                arrTerminalMaster = ReturnObjectValuesList(dbr, arrTerminalMaster)
                dbr.Close()
            Catch ex As Exception
                arrTerminalMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalMaster
        End Function
        Public Shared Function ReturnTerminalMasterListUserId(ByVal pUserId As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_MASTER_ALL_USER", "'" & pUserId & "'")
                arrTerminalMaster = ReturnObjectValuesList(dbr, arrTerminalMaster)
                dbr.Close()
            Catch ex As Exception
                arrTerminalMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalMaster
        End Function
        Public Shared Function InsertUpdateTerminalMaster(ByVal pTerminalMaster As TerminalMaster) As TerminalMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pTerminalMaster.TerminalId > 0 Then
                    TerminalMaster.UpdateTrn(db, pTerminalMaster)
                Else
                    TerminalMaster.InsertTrn(db, pTerminalMaster)
                End If

                If pTerminalMaster.Errormsg = "" AndAlso pTerminalMaster.TerminalId > 0 Then
                    For Each pTLM As TerminalLocationMaster In pTerminalMaster.TerminalLocationList
                        pTLM.TerminalId = pTerminalMaster.TerminalId
                        If pTLM.LocationId > 0 Then
                            TerminalLocationMaster.UpdateTrn(db, pTLM)
                        Else
                            TerminalLocationMaster.InsertTrn(db, pTLM)
                        End If
                        If pTLM.Errormsg <> "" Then
                            Throw New Exception(pTLM.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pTerminalMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pTerminalMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pTerminalMaster
        End Function

    End Class
End Namespace
