Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CompanyMaster
    ''' @author	: Amit K. Singh- 9/7/2020
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CompanyMaster

        Private strLogo As String ' Define Private Variable Logo With DataType As String 
        Private strCompanyName1 As String ' Define Private Variable CompanyName1 With DataType As String 
        Private strSignImg As String ' Define Private Variable SignImg With DataType As String 
        Private strCompanyCode As String ' Define Private Variable CompanyCode With DataType As String 
        Private strCompanyName As String ' Define Private Variable CompanyName With DataType As String 
        Private strCompanyClass As String ' Define Private Variable CompanyClass With DataType As String 
        Private strPanNo As String ' Define Private Variable PanNo With DataType As String 
        Private strTanNo As String ' Define Private Variable TanNo With DataType As String 
        Private strServiceTaxReg As String ' Define Private Variable ServiceTaxReg With DataType As String 
        Private strContactPerson As String ' Define Private Variable ContactPerson With DataType As String 
        Private strContactNo As String ' Define Private Variable ContactNo With DataType As String 
        Private strEmailId As String ' Define Private Variable EmailId With DataType As String 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private strCity As String ' Define Private Variable City With DataType As String 
        Private strState As String ' Define Private Variable State With DataType As String 
        Private lngCountry As Long ' Define Private Variable Country With DataType As Long 
        Private strPin As String ' Define Private Variable Pin With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private dblDieselRate As Double ' Define Private Variable DieselRate With DataType As Double 
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long 
        Private strStateCode As String ' Define Private Variable StateCode With DataType As String 
        Private strCompanyTypeName As String ' Define Private Variable CompanyName1 With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of Logo
        ''' </summary>
        ''' <value>strLogo</value>
        ''' <returns> Return strLogo</returns>
        ''' <remarks> Get or Set the Value of Logo  </remarks>
        '''
        Public Property Logo() As String
            Get
                Return strLogo
            End Get
            Set(ByVal value As String)
                strLogo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CompanyName1
        ''' </summary>
        ''' <value>strCompanyName1</value>
        ''' <returns> Return strCompanyName1</returns>
        ''' <remarks> Get or Set the Value of CompanyName1  </remarks>
        '''
        Public Property CompanyName1() As String
            Get
                Return strCompanyName1
            End Get
            Set(ByVal value As String)
                strCompanyName1 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of strCompanyTypeName
        ''' </summary>
        ''' <value>strCompanyTypeName</value>
        ''' <returns> Return strCompanyTypeName</returns>
        ''' <remarks> Get or Set the Value of CompanyTypeName  </remarks>
        '''
        Public Property CompanyTypeName() As String
            Get
                Return strCompanyTypeName
            End Get
            Set(ByVal value As String)
                strCompanyTypeName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SignImg
        ''' </summary>
        ''' <value>strSignImg</value>
        ''' <returns> Return strSignImg</returns>
        ''' <remarks> Get or Set the Value of SignImg  </remarks>
        '''
        Public Property SignImg() As String
            Get
                Return strSignImg
            End Get
            Set(ByVal value As String)
                strSignImg = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CompanyCode
        ''' </summary>
        ''' <value>strCompanyCode</value>
        ''' <returns> Return strCompanyCode</returns>
        ''' <remarks> Get or Set the Value of CompanyCode  </remarks>
        '''
        Public Property CompanyCode() As String
            Get
                Return strCompanyCode
            End Get
            Set(ByVal value As String)
                strCompanyCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CompanyName
        ''' </summary>
        ''' <value>strCompanyName</value>
        ''' <returns> Return strCompanyName</returns>
        ''' <remarks> Get or Set the Value of CompanyName  </remarks>
        '''
        Public Property CompanyName() As String
            Get
                Return strCompanyName
            End Get
            Set(ByVal value As String)
                strCompanyName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CompanyClass
        ''' </summary>
        ''' <value>strCompanyClass</value>
        ''' <returns> Return strCompanyClass</returns>
        ''' <remarks> Get or Set the Value of CompanyClass  </remarks>
        '''
        Public Property CompanyClass() As String
            Get
                Return strCompanyClass
            End Get
            Set(ByVal value As String)
                strCompanyClass = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PanNo
        ''' </summary>
        ''' <value>strPanNo</value>
        ''' <returns> Return strPanNo</returns>
        ''' <remarks> Get or Set the Value of PanNo  </remarks>
        '''
        Public Property PanNo() As String
            Get
                Return strPanNo
            End Get
            Set(ByVal value As String)
                strPanNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TanNo
        ''' </summary>
        ''' <value>strTanNo</value>
        ''' <returns> Return strTanNo</returns>
        ''' <remarks> Get or Set the Value of TanNo  </remarks>
        '''
        Public Property TanNo() As String
            Get
                Return strTanNo
            End Get
            Set(ByVal value As String)
                strTanNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceTaxReg
        ''' </summary>
        ''' <value>strServiceTaxReg</value>
        ''' <returns> Return strServiceTaxReg</returns>
        ''' <remarks> Get or Set the Value of ServiceTaxReg  </remarks>
        '''
        Public Property ServiceTaxReg() As String
            Get
                Return strServiceTaxReg
            End Get
            Set(ByVal value As String)
                strServiceTaxReg = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContactPerson
        ''' </summary>
        ''' <value>strContactPerson</value>
        ''' <returns> Return strContactPerson</returns>
        ''' <remarks> Get or Set the Value of ContactPerson  </remarks>
        '''
        Public Property ContactPerson() As String
            Get
                Return strContactPerson
            End Get
            Set(ByVal value As String)
                strContactPerson = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContactNo
        ''' </summary>
        ''' <value>strContactNo</value>
        ''' <returns> Return strContactNo</returns>
        ''' <remarks> Get or Set the Value of ContactNo  </remarks>
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
        ''' Get or Set the Value of EmailId
        ''' </summary>
        ''' <value>strEmailId</value>
        ''' <returns> Return strEmailId</returns>
        ''' <remarks> Get or Set the Value of EmailId  </remarks>
        '''
        Public Property EmailId() As String
            Get
                Return strEmailId
            End Get
            Set(ByVal value As String)
                strEmailId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks> Get or Set the Value of Address  </remarks>
        '''
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of City
        ''' </summary>
        ''' <value>strCity</value>
        ''' <returns> Return strCity</returns>
        ''' <remarks> Get or Set the Value of City  </remarks>
        '''
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of State
        ''' </summary>
        ''' <value>strState</value>
        ''' <returns> Return strState</returns>
        ''' <remarks> Get or Set the Value of State  </remarks>
        '''
        Public Property State() As String
            Get
                Return strState
            End Get
            Set(ByVal value As String)
                strState = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Country
        ''' </summary>
        ''' <value>lngCountry</value>
        ''' <returns> Return lngCountry</returns>
        ''' <remarks> Get or Set the Value of Country  </remarks>
        '''
        Public Property Country() As Long
            Get
                Return lngCountry
            End Get
            Set(ByVal value As Long)
                lngCountry = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Pin
        ''' </summary>
        ''' <value>strPin</value>
        ''' <returns> Return strPin</returns>
        ''' <remarks> Get or Set the Value of Pin  </remarks>
        '''
        Public Property Pin() As String
            Get
                Return strPin
            End Get
            Set(ByVal value As String)
                strPin = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DieselRate
        ''' </summary>
        ''' <value>dblDieselRate</value>
        ''' <returns> Return dblDieselRate</returns>
        ''' <remarks> Get or Set the Value of DieselRate  </remarks>
        '''
        Public Property DieselRate() As Double
            Get
                Return dblDieselRate
            End Get
            Set(ByVal value As Double)
                dblDieselRate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngCompanyId</value>
        ''' <returns> Return lngCompanyId</returns>
        ''' <remarks> Get or Set the Value of CompanyId  </remarks>
        '''
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of StateCode
        ''' </summary>
        ''' <value>strStateCode</value>
        ''' <returns> Return strStateCode</returns>
        ''' <remarks> Get or Set the Value of StateCode  </remarks>
        '''
        Public Property StateCode() As String
            Get
                Return strStateCode
            End Get
            Set(ByVal value As String)
                strStateCode = value
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
            strLogo = ""
            strCompanyName1 = ""
            strSignImg = ""
            strCompanyCode = ""
            strCompanyName = ""
            strCompanyClass = ""
            strPanNo = ""
            strTanNo = ""
            strServiceTaxReg = ""
            strContactPerson = ""
            strContactNo = ""
            strEmailId = ""
            strAddress = ""
            strCity = ""
            strState = ""
            lngCountry = 0
            strPin = ""
            strRemarks = ""
            dblDieselRate = 0.0
            lngCompanyId = 0
            strStateCode = ""
            strCompanyTypeName = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCompanyMaster"></param>
        ''' <returns>Return pCompanyMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_LOGO", pCompanyMaster.Logo)
                db.AddParameter("p_COMPANY_NAME1", pCompanyMaster.CompanyName1)
                db.AddParameter("p_SIGN_IMG", pCompanyMaster.SignImg)
                db.AddParameter("p_COMPANY_CODE", pCompanyMaster.CompanyCode, ParameterDirection.Output)
                db.AddParameter("p_COMPANY_NAME", pCompanyMaster.CompanyName)
                db.AddParameter("p_COMPANY_CLASS", pCompanyMaster.CompanyClass)
                db.AddParameter("p_PAN_NO", pCompanyMaster.PanNo)
                db.AddParameter("p_TAN_NO", pCompanyMaster.TanNo)
                db.AddParameter("p_SERVICE_TAX_REG", pCompanyMaster.ServiceTaxReg)
                db.AddParameter("p_CONTACT_PERSON", pCompanyMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCompanyMaster.ContactNo)
                db.AddParameter("p_EMAIL_ID", pCompanyMaster.EmailId)
                db.AddParameter("p_ADDRESS", pCompanyMaster.Address)
                db.AddParameter("p_CITY", pCompanyMaster.City)
                db.AddParameter("p_STATE", pCompanyMaster.State)
                db.AddParameter("p_COUNTRY", pCompanyMaster.Country)
                db.AddParameter("p_PIN", pCompanyMaster.Pin)
                db.AddParameter("p_REMARKS", pCompanyMaster.Remarks)
                db.AddParameter("p_DIESEL_RATE", pCompanyMaster.DieselRate)
                db.AddParameter("p_COMPANY_ID", pCompanyMaster.CompanyId)
                db.AddParameter("p_STATE_CODE", pCompanyMaster.StateCode)
                db.AddParameter("p_ErrorMsg", pCompanyMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COMPANY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCompanyMaster.CompanyCode = db.Parameters.Item("p_COMPANY_CODE").value

                If pCompanyMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCompanyMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCompanyMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCompanyMaster"></param>
        ''' <returns>Return pCompanyMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_LOGO", pCompanyMaster.Logo)
                db.AddParameter("p_COMPANY_NAME1", pCompanyMaster.CompanyName1)
                db.AddParameter("p_SIGN_IMG", pCompanyMaster.SignImg)
                db.AddParameter("p_COMPANY_CODE", pCompanyMaster.CompanyCode, ParameterDirection.Output)
                db.AddParameter("p_COMPANY_NAME", pCompanyMaster.CompanyName)
                db.AddParameter("p_COMPANY_CLASS", pCompanyMaster.CompanyClass)
                db.AddParameter("p_PAN_NO", pCompanyMaster.PanNo)
                db.AddParameter("p_TAN_NO", pCompanyMaster.TanNo)
                db.AddParameter("p_SERVICE_TAX_REG", pCompanyMaster.ServiceTaxReg)
                db.AddParameter("p_CONTACT_PERSON", pCompanyMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCompanyMaster.ContactNo)
                db.AddParameter("p_EMAIL_ID", pCompanyMaster.EmailId)
                db.AddParameter("p_ADDRESS", pCompanyMaster.Address)
                db.AddParameter("p_CITY", pCompanyMaster.City)
                db.AddParameter("p_STATE", pCompanyMaster.State)
                db.AddParameter("p_COUNTRY", pCompanyMaster.Country)
                db.AddParameter("p_PIN", pCompanyMaster.Pin)
                db.AddParameter("p_REMARKS", pCompanyMaster.Remarks)
                db.AddParameter("p_DIESEL_RATE", pCompanyMaster.DieselRate)
                db.AddParameter("p_COMPANY_ID", pCompanyMaster.CompanyId)
                db.AddParameter("p_STATE_CODE", pCompanyMaster.StateCode)
                db.AddParameter("p_ErrorMsg", pCompanyMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COMPANY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCompanyMaster.CompanyCode = db.Parameters.Item("p_COMPANY_CODE").value

            Catch ex As Exception
                pCompanyMaster.ErrorMsg = ex.Message
            End Try
            Return pCompanyMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCompanyMaster"></param>
        ''' <returns>Return pCompanyMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_LOGO", pCompanyMaster.Logo)
                db.AddParameter("p_COMPANY_NAME1", pCompanyMaster.CompanyName1)
                db.AddParameter("p_SIGN_IMG", pCompanyMaster.SignImg)
                db.AddParameter("p_COMPANY_CODE", pCompanyMaster.CompanyCode)
                db.AddParameter("p_COMPANY_NAME", pCompanyMaster.CompanyName)
                db.AddParameter("p_COMPANY_CLASS", pCompanyMaster.CompanyClass)
                db.AddParameter("p_PAN_NO", pCompanyMaster.PanNo)
                db.AddParameter("p_TAN_NO", pCompanyMaster.TanNo)
                db.AddParameter("p_SERVICE_TAX_REG", pCompanyMaster.ServiceTaxReg)
                db.AddParameter("p_CONTACT_PERSON", pCompanyMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCompanyMaster.ContactNo)
                db.AddParameter("p_EMAIL_ID", pCompanyMaster.EmailId)
                db.AddParameter("p_ADDRESS", pCompanyMaster.Address)
                db.AddParameter("p_CITY", pCompanyMaster.City)
                db.AddParameter("p_STATE", pCompanyMaster.State)
                db.AddParameter("p_COUNTRY", pCompanyMaster.Country)
                db.AddParameter("p_PIN", pCompanyMaster.Pin)
                db.AddParameter("p_REMARKS", pCompanyMaster.Remarks)
                db.AddParameter("p_DIESEL_RATE", pCompanyMaster.DieselRate)
                db.AddParameter("p_COMPANY_ID", pCompanyMaster.CompanyId)
                db.AddParameter("p_STATE_CODE", pCompanyMaster.StateCode)
                db.AddParameter("p_ErrorMsg", pCompanyMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COMPANY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCompanyMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCompanyMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCompanyMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCompanyMaster"></param>
        ''' <returns>Return pCompanyMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_LOGO", pCompanyMaster.Logo)
                db.AddParameter("p_COMPANY_NAME1", pCompanyMaster.CompanyName1)
                db.AddParameter("p_SIGN_IMG", pCompanyMaster.SignImg)
                db.AddParameter("p_COMPANY_CODE", pCompanyMaster.CompanyCode)
                db.AddParameter("p_COMPANY_NAME", pCompanyMaster.CompanyName)
                db.AddParameter("p_COMPANY_CLASS", pCompanyMaster.CompanyClass)
                db.AddParameter("p_PAN_NO", pCompanyMaster.PanNo)
                db.AddParameter("p_TAN_NO", pCompanyMaster.TanNo)
                db.AddParameter("p_SERVICE_TAX_REG", pCompanyMaster.ServiceTaxReg)
                db.AddParameter("p_CONTACT_PERSON", pCompanyMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCompanyMaster.ContactNo)
                db.AddParameter("p_EMAIL_ID", pCompanyMaster.EmailId)
                db.AddParameter("p_ADDRESS", pCompanyMaster.Address)
                db.AddParameter("p_CITY", pCompanyMaster.City)
                db.AddParameter("p_STATE", pCompanyMaster.State)
                db.AddParameter("p_COUNTRY", pCompanyMaster.Country)
                db.AddParameter("p_PIN", pCompanyMaster.Pin)
                db.AddParameter("p_REMARKS", pCompanyMaster.Remarks)
                db.AddParameter("p_DIESEL_RATE", pCompanyMaster.DieselRate)
                db.AddParameter("p_COMPANY_ID", pCompanyMaster.CompanyId)
                db.AddParameter("p_STATE_CODE", pCompanyMaster.StateCode)
                db.AddParameter("p_ErrorMsg", pCompanyMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COMPANY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCompanyMaster.ErrorMsg = ex.Message
            End Try
            Return pCompanyMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("LOGO").ToString <> "" Then
                                PCompanyMaster.Logo = dbr("LOGO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_NAME1").ToString <> "" Then
                                PCompanyMaster.CompanyName1 = dbr("COMPANY_NAME1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SIGN_IMG").ToString <> "" Then
                                PCompanyMaster.SignImg = dbr("SIGN_IMG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_CODE").ToString <> "" Then
                                PCompanyMaster.CompanyCode = dbr("COMPANY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_NAME").ToString <> "" Then
                                PCompanyMaster.CompanyName = dbr("COMPANY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_CLASS").ToString <> "" Then
                                PCompanyMaster.CompanyClass = dbr("COMPANY_CLASS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAN_NO").ToString <> "" Then
                                PCompanyMaster.PanNo = dbr("PAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAN_NO").ToString <> "" Then
                                PCompanyMaster.TanNo = dbr("TAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX_REG").ToString <> "" Then
                                PCompanyMaster.ServiceTaxReg = dbr("SERVICE_TAX_REG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_PERSON").ToString <> "" Then
                                PCompanyMaster.ContactPerson = dbr("CONTACT_PERSON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                PCompanyMaster.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                PCompanyMaster.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PCompanyMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CITY").ToString <> "" Then
                                PCompanyMaster.City = dbr("CITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE").ToString <> "" Then
                                PCompanyMaster.State = dbr("STATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY").ToString <> "" Then
                                PCompanyMaster.Country = dbr("COUNTRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PIN").ToString <> "" Then
                                PCompanyMaster.Pin = dbr("PIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PCompanyMaster.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIESEL_RATE").ToString <> "" Then
                                PCompanyMaster.DieselRate = dbr("DIESEL_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                PCompanyMaster.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                PCompanyMaster.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_TYPE_NAME").ToString <> "" Then
                                pCompanyMaster.CompanyTypeName = dbr("COMPANY_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCompanyMaster.ErrorMsg = ex.Message
            End Try
            Return pCompanyMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCompanyMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CompanyMaster
                        Try
                            If dbr("LOGO").ToString <> "" Then
                                temp.Logo = dbr("LOGO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_NAME1").ToString <> "" Then
                                temp.CompanyName1 = dbr("COMPANY_NAME1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SIGN_IMG").ToString <> "" Then
                                temp.SignImg = dbr("SIGN_IMG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_CODE").ToString <> "" Then
                                temp.CompanyCode = dbr("COMPANY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_NAME").ToString <> "" Then
                                temp.CompanyName = dbr("COMPANY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_CLASS").ToString <> "" Then
                                temp.CompanyClass = dbr("COMPANY_CLASS")
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
                            If dbr("TAN_NO").ToString <> "" Then
                                temp.TanNo = dbr("TAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX_REG").ToString <> "" Then
                                temp.ServiceTaxReg = dbr("SERVICE_TAX_REG")
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
                            If dbr("CONTACT_NO").ToString <> "" Then
                                temp.ContactNo = dbr("CONTACT_NO")
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
                            If dbr("ADDRESS").ToString <> "" Then
                                temp.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CITY").ToString <> "" Then
                                temp.City = dbr("CITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE").ToString <> "" Then
                                temp.State = dbr("STATE")
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
                            If dbr("PIN").ToString <> "" Then
                                temp.Pin = dbr("PIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIESEL_RATE").ToString <> "" Then
                                temp.DieselRate = dbr("DIESEL_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                temp.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_TYPE_NAME").ToString <> "" Then
                                temp.CompanyTypeName = dbr("COMPANY_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function
        Public Shared Function ReturnCompanyMaster(ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMPANY_MASTER_BY_CODE", "'" & pCompanyMaster.CompanyCode & "'")
                pCompanyMaster = ReturnObjectValues(dbr, pCompanyMaster)
                dbr.Close()
            Catch ex As Exception
                pCompanyMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCompanyMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCompanyMasterbyId(ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMPANY_MASTER_BY_ID", pCompanyMaster.CompanyId)
                pCompanyMaster = ReturnObjectValues(dbr, pCompanyMaster)
                dbr.Close()
            Catch ex As Exception
                pCompanyMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCompanyMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCompanyMasterList(ByVal pCompanyMaster As CompanyMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCompanyMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMPANY_MASTER_ALL", " ")
                arrCompanyMaster = ReturnObjectValuesList(dbr, arrCompanyMaster)
                dbr.Close()
            Catch ex As Exception
                arrCompanyMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCompanyMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCompanyMasterSearch(ByVal pCompanyMaster As CompanyMaster) As CompanyMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMPANY_MASTER_SEARCH", "")
                pCompanyMaster = ReturnObjectValues(dbr, pCompanyMaster)
                dbr.Close()
            Catch ex As Exception
                pCompanyMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCompanyMaster
        End Function
    End Class
End Namespace