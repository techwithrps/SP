Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorMaster
    ''' @author	: Amit K. Singh- 19/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class VendorMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngVendorId As Long ' Define Private Variable VendorId With DataType As Long 
        Private strVendorCode As String ' Define Private Variable VendorCode With DataType As String 
        Private strContactPerson As String ' Define Private Variable VendorCode With DataType As String 

        Private strVendorName As String ' Define Private Variable VendorName With DataType As String 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private strCity As String ' Define Private Variable City With DataType As String 
        Private strPinCode As String ' Define Private Variable PinCode With DataType As String 
        Private strState As String ' Define Private Variable State With DataType As String 
        Private strCountry As String ' Define Private Variable Country With DataType As String 
        Private strEmailId1 As String ' Define Private Variable EmailId1 With DataType As String 
        Private strEmailId2 As String ' Define Private Variable EmailId2 With DataType As String 
        Private strContactNo As String ' Define Private Variable ContactNo With DataType As String 
        Private strMobileNo As String ' Define Private Variable MobileNo With DataType As String 
        Private strFax As String ' Define Private Variable Fax With DataType As String 
        Private strPaymentTerms As String ' Define Private Variable PaymentTerms With DataType As String 
        Private strPan As String ' Define Private Variable Pan With DataType As String 
        Private strTan As String ' Define Private Variable Tan With DataType As String 
        Private strServiceTaxReg As String ' Define Private Variable ServiceTaxReg With DataType As String 
        Private strBankName As String ' Define Private Variable BankName With DataType As String 
        Private strAcMapCode As String ' Define Private Variable AcMapCode With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strAccountNo As String ' Define Private Variable AccountNo With DataType As String 
        Private strIfsc As String ' Define Private Variable AccountNo With DataType As String 
        Private strBankBranch As String ' Define Private Variable AccountNo With DataType As String 
        Private dblRate As Double
        Private strGSTIN As String ' Define Private Variable AccountNo With DataType As String 
        Private lngState As Long
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strTallyVendorName As String
                    
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
        ''' Get or Set the Value of VendorCode
        ''' </summary>
        ''' <value>strVendorCode</value>
        ''' <returns> Return strVendorCode</returns>
        ''' <remarks> Get or Set the Value of VendorCode  </remarks>
        '''
        Public Property VendorCode() as String
            Get
                Return strVendorCode
            End Get
            Set(ByVal value As String)
                strVendorCode = value
            End Set
        End Property

        Public Property TallyVendorName() As String
            Get
                Return strTallyVendorName
            End Get
            Set(ByVal value As String)
                strTallyVendorName = value
            End Set
        End Property

        Public Property GSTIN() As String
            Get
                Return strGSTIN
            End Get
            Set(ByVal value As String)
                strGSTIN = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VendorName
        ''' </summary>
        ''' <value>strVendorName</value>
        ''' <returns> Return strVendorName</returns>
        ''' <remarks> Get or Set the Value of VendorName  </remarks>
        '''
        Public Property VendorName() as String
            Get
                Return strVendorName
            End Get
            Set(ByVal value As String)
                strVendorName = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of VendorName
        ''' </summary>
        ''' <value>strVendorName</value>
        ''' <returns> Return strVendorName</returns>
        ''' <remarks> Get or Set the Value of VendorName  </remarks>
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
        ''' Get or Set the Value of City
        ''' </summary>
        ''' <value>strCity</value>
        ''' <returns> Return strCity</returns>
        ''' <remarks> Get or Set the Value of City  </remarks>
        '''
        Public Property City() as String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PinCode
        ''' </summary>
        ''' <value>strPinCode</value>
        ''' <returns> Return strPinCode</returns>
        ''' <remarks> Get or Set the Value of PinCode  </remarks>
        '''
        Public Property PinCode() as String
            Get
                Return strPinCode
            End Get
            Set(ByVal value As String)
                strPinCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of State
        ''' </summary>
        ''' <value>strState</value>
        ''' <returns> Return strState</returns>
        ''' <remarks> Get or Set the Value of State  </remarks>
        '''
        Public Property State() as String
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
        ''' Get or Set the Value of EmailId1
        ''' </summary>
        ''' <value>strEmailId1</value>
        ''' <returns> Return strEmailId1</returns>
        ''' <remarks> Get or Set the Value of EmailId1  </remarks>
        '''
        Public Property EmailId1() as String
            Get
                Return strEmailId1
            End Get
            Set(ByVal value As String)
                strEmailId1 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EmailId2
        ''' </summary>
        ''' <value>strEmailId2</value>
        ''' <returns> Return strEmailId2</returns>
        ''' <remarks> Get or Set the Value of EmailId2  </remarks>
        '''
        Public Property EmailId2() as String
            Get
                Return strEmailId2
            End Get
            Set(ByVal value As String)
                strEmailId2 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContactNo
        ''' </summary>
        ''' <value>strContactNo</value>
        ''' <returns> Return strContactNo</returns>
        ''' <remarks> Get or Set the Value of ContactNo  </remarks>
        '''
        Public Property ContactNo() as String
            Get
                Return strContactNo
            End Get
            Set(ByVal value As String)
                strContactNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MobileNo
        ''' </summary>
        ''' <value>strMobileNo</value>
        ''' <returns> Return strMobileNo</returns>
        ''' <remarks> Get or Set the Value of MobileNo  </remarks>
        '''
        Public Property MobileNo() as String
            Get
                Return strMobileNo
            End Get
            Set(ByVal value As String)
                strMobileNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Fax
        ''' </summary>
        ''' <value>strFax</value>
        ''' <returns> Return strFax</returns>
        ''' <remarks> Get or Set the Value of Fax  </remarks>
        '''
        Public Property Fax() as String
            Get
                Return strFax
            End Get
            Set(ByVal value As String)
                strFax = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PaymentTerms
        ''' </summary>
        ''' <value>strPaymentTerms</value>
        ''' <returns> Return strPaymentTerms</returns>
        ''' <remarks> Get or Set the Value of PaymentTerms  </remarks>
        '''
        Public Property PaymentTerms() as String
            Get
                Return strPaymentTerms
            End Get
            Set(ByVal value As String)
                strPaymentTerms = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Pan
        ''' </summary>
        ''' <value>strPan</value>
        ''' <returns> Return strPan</returns>
        ''' <remarks> Get or Set the Value of Pan  </remarks>
        '''
        Public Property Pan() as String
            Get
                Return strPan
            End Get
            Set(ByVal value As String)
                strPan = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Tan
        ''' </summary>
        ''' <value>strTan</value>
        ''' <returns> Return strTan</returns>
        ''' <remarks> Get or Set the Value of Tan  </remarks>
        '''
        Public Property Tan() as String
            Get
                Return strTan
            End Get
            Set(ByVal value As String)
                strTan = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceTaxReg
        ''' </summary>
        ''' <value>strServiceTaxReg</value>
        ''' <returns> Return strServiceTaxReg</returns>
        ''' <remarks> Get or Set the Value of ServiceTaxReg  </remarks>
        '''
        Public Property ServiceTaxReg() as String
            Get
                Return strServiceTaxReg
            End Get
            Set(ByVal value As String)
                strServiceTaxReg = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BankName
        ''' </summary>
        ''' <value>strBankName</value>
        ''' <returns> Return strBankName</returns>
        ''' <remarks> Get or Set the Value of BankName  </remarks>
        '''
        Public Property BankName() as String
            Get
                Return strBankName
            End Get
            Set(ByVal value As String)
                strBankName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of AcMapCode
        ''' </summary>
        ''' <value>strAcMapCode</value>
        ''' <returns> Return strAcMapCode</returns>
        ''' <remarks> Get or Set the Value of AcMapCode  </remarks>
        '''
        Public Property AcMapCode() as String
            Get
                Return strAcMapCode
            End Get
            Set(ByVal value As String)
                strAcMapCode = value
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
        ''' Get or Set the Value of AccountNo
        ''' </summary>
        ''' <value>strAccountNo</value>
        ''' <returns> Return strAccountNo</returns>
        ''' <remarks> Get or Set the Value of AccountNo  </remarks>
        '''
        Public Property AccountNo() as String
            Get
                Return strAccountNo
            End Get
            Set(ByVal value As String)
                strAccountNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IFSC
        ''' </summary>
        ''' <value>strIfsc</value>
        ''' <returns> Return strFax</returns>
        ''' <remarks> Get or Set the Value of IFSC  </remarks>
        '''
        Public Property IFSC() As String
            Get
                Return strIfsc
            End Get
            Set(ByVal value As String)
                strIfsc = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BankBranch
        ''' </summary>
        ''' <value>strBankBranch</value>
        ''' <returns> Return strFax</returns>
        ''' <remarks> Get or Set the Value of BankBranch  </remarks>
        '''
        Public Property BankBranch() As String
            Get
                Return strBankBranch
            End Get
            Set(ByVal value As String)
                strBankBranch = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Toll
        ''' </summary>
        ''' <value>dblToll</value>
        ''' <returns> Return dblToll</returns>
        ''' <remarks> Get or Set the Value of Toll </remarks>
        '''
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal value As Double)
                dblRate = value
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
            strVendorCode = ""
            strVendorName = ""
            strContactPerson = ""
            strAddress = ""
            strCity = ""
            strPinCode = ""
            strState = ""
            strCountry = ""
            strEmailId1 = ""
            strEmailId2 = ""
            strContactNo = ""
            strMobileNo = ""
            strFax = ""
            strPaymentTerms = ""
            strPan = ""
            strTan = ""
            strServiceTaxReg = ""
            strBankName = ""
            strAcMapCode = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strAccountNo = ""
            strIfsc = ""
            strBankBranch = ""
            dblRate = 0.0
            strErrormsg = ""
            lngState = 0
            strGSTIN = ""
            strTallyVendorName = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pVendorMaster"></param>
        ''' <returns>Return pVendorMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVendorMaster As VendorMaster) As VendorMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorMaster.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorMaster.VendorId, ParameterDirection.Output)
                db.AddParameter("p_VENDOR_CODE", pVendorMaster.VendorCode)
                db.AddParameter("p_VENDOR_NAME", pVendorMaster.VendorName)
                db.AddParameter("p_ADDRESS", pVendorMaster.Address)
                db.AddParameter("p_CITY", pVendorMaster.City)
                db.AddParameter("p_PIN_CODE", pVendorMaster.PinCode)
                db.AddParameter("p_STATE", pVendorMaster.State)
                db.AddParameter("p_COUNTRY", pVendorMaster.Country)
                db.AddParameter("p_EMAIL_ID1", pVendorMaster.EmailId1)
                db.AddParameter("p_EMAIL_ID2", pVendorMaster.EmailId2)
                db.AddParameter("p_CONTACT_NO", pVendorMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pVendorMaster.MobileNo)
                db.AddParameter("p_FAX", pVendorMaster.Fax)
                db.AddParameter("p_PAYMENT_TERMS", pVendorMaster.PaymentTerms)
                db.AddParameter("p_PAN", pVendorMaster.Pan)
                db.AddParameter("p_TAN", pVendorMaster.Tan)
                db.AddParameter("p_SERVICE_TAX_REG", pVendorMaster.ServiceTaxReg)
                db.AddParameter("p_BANK_NAME", pVendorMaster.BankName)
                db.AddParameter("p_AC_MAP_CODE", pVendorMaster.AcMapCode)
                db.AddParameter("p_CREATED_BY", pVendorMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorMaster.CreatedOn)
                db.AddParameter("p_ACCOUNT_NO", pVendorMaster.AccountNo)
                db.AddParameter("p_IFSC", pVendorMaster.IFSC)
                db.AddParameter("p_BANK_BRANCH", pVendorMaster.BankBranch)
                db.AddParameter("p_CONTACT_PERSON", pVendorMaster.ContactPerson)
                db.AddParameter("p_RATE", pVendorMaster.Rate)
                db.AddParameter("p_ErrorMsg", pVendorMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorMaster.VendorId = db.Parameters.Item("p_VENDOR_ID").value
                pVendorMaster.VendorCode = db.Parameters.Item("p_VENDOR_CODE").value
                
                If pVendorMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorMaster"></param>
        ''' <returns>Return pVendorMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVendorMaster As VendorMaster) As VendorMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorMaster.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorMaster.VendorId, ParameterDirection.Output)
                db.AddParameter("p_VENDOR_CODE", pVendorMaster.VendorCode, ParameterDirection.Output)
                db.AddParameter("p_VENDOR_NAME", pVendorMaster.VendorName)
                db.AddParameter("p_ADDRESS", pVendorMaster.Address)
                db.AddParameter("p_CITY", pVendorMaster.City)
                db.AddParameter("p_PIN_CODE", pVendorMaster.PinCode)
                db.AddParameter("p_STATE", pVendorMaster.State)
                db.AddParameter("p_COUNTRY", pVendorMaster.Country)
                db.AddParameter("p_EMAIL_ID1", pVendorMaster.EmailId1)
                db.AddParameter("p_EMAIL_ID2", pVendorMaster.EmailId2)
                db.AddParameter("p_CONTACT_NO", pVendorMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pVendorMaster.MobileNo)
                db.AddParameter("p_FAX", pVendorMaster.Fax)
                db.AddParameter("p_PAYMENT_TERMS", pVendorMaster.PaymentTerms)
                db.AddParameter("p_PAN", pVendorMaster.Pan)
                db.AddParameter("p_TAN", pVendorMaster.Tan)
                db.AddParameter("p_SERVICE_TAX_REG", pVendorMaster.ServiceTaxReg)
                db.AddParameter("p_BANK_NAME", pVendorMaster.BankName)
                db.AddParameter("p_AC_MAP_CODE", pVendorMaster.AcMapCode)
                db.AddParameter("p_CREATED_BY", pVendorMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorMaster.CreatedOn)
                db.AddParameter("p_ACCOUNT_NO", pVendorMaster.AccountNo)
                db.AddParameter("p_IFSC", pVendorMaster.IFSC)
                db.AddParameter("p_BANK_BRANCH", pVendorMaster.BankBranch)
                db.AddParameter("p_CONTACT_PERSON", pVendorMaster.ContactPerson)
                db.AddParameter("p_RATE", pVendorMaster.Rate)
                db.AddParameter("p_GSTIN", pVendorMaster.GSTIN)
                db.AddParameter("p_TALLY_CUSTOMER_NAME", pVendorMaster.TallyVendorName)
                db.AddParameter("p_ErrorMsg", pVendorMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorMaster.VendorId = db.Parameters.Item("p_VENDOR_ID").value
                pVendorMaster.VendorCode = db.Parameters.Item("p_VENDOR_CODE").value
                
            Catch ex As Exception
                pVendorMaster.ErrorMsg = ex.Message
            End Try
            Return pVendorMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVendorMaster"></param>
        ''' <returns>Return pVendorMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVendorMaster As VendorMaster) As VendorMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorMaster.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorMaster.VendorId)
                db.AddParameter("p_VENDOR_CODE", pVendorMaster.VendorCode)
                db.AddParameter("p_VENDOR_NAME", pVendorMaster.VendorName)
                db.AddParameter("p_ADDRESS", pVendorMaster.Address)
                db.AddParameter("p_CITY", pVendorMaster.City)
                db.AddParameter("p_PIN_CODE", pVendorMaster.PinCode)
                db.AddParameter("p_STATE", pVendorMaster.State)
                db.AddParameter("p_COUNTRY", pVendorMaster.Country)
                db.AddParameter("p_EMAIL_ID1", pVendorMaster.EmailId1)
                db.AddParameter("p_EMAIL_ID2", pVendorMaster.EmailId2)
                db.AddParameter("p_CONTACT_NO", pVendorMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pVendorMaster.MobileNo)
                db.AddParameter("p_FAX", pVendorMaster.Fax)
                db.AddParameter("p_PAYMENT_TERMS", pVendorMaster.PaymentTerms)
                db.AddParameter("p_PAN", pVendorMaster.Pan)
                db.AddParameter("p_TAN", pVendorMaster.Tan)
                db.AddParameter("p_SERVICE_TAX_REG", pVendorMaster.ServiceTaxReg)
                db.AddParameter("p_BANK_NAME", pVendorMaster.BankName)
                db.AddParameter("p_AC_MAP_CODE", pVendorMaster.AcMapCode)
                db.AddParameter("p_CREATED_BY", pVendorMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorMaster.CreatedOn)
                db.AddParameter("p_ACCOUNT_NO", pVendorMaster.AccountNo)
                db.AddParameter("p_IFSC", pVendorMaster.IFSC)
                db.AddParameter("p_BANK_BRANCH", pVendorMaster.BankBranch)
                db.AddParameter("p_CONTACT_PERSON", pVendorMaster.ContactPerson)
                db.AddParameter("p_RATE", pVendorMaster.Rate)
                db.AddParameter("p_ErrorMsg", pVendorMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVendorMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorMaster"></param>
        ''' <returns>Return pVendorMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVendorMaster As VendorMaster) As VendorMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorMaster.TerminalId)
                db.AddParameter("p_VENDOR_ID", pVendorMaster.VendorId)
                db.AddParameter("p_VENDOR_CODE", pVendorMaster.VendorCode)
                db.AddParameter("p_VENDOR_NAME", pVendorMaster.VendorName)
                db.AddParameter("p_ADDRESS", pVendorMaster.Address)
                db.AddParameter("p_CITY", pVendorMaster.City)
                db.AddParameter("p_PIN_CODE", pVendorMaster.PinCode)
                db.AddParameter("p_STATE", pVendorMaster.State)
                db.AddParameter("p_COUNTRY", pVendorMaster.Country)
                db.AddParameter("p_EMAIL_ID1", pVendorMaster.EmailId1)
                db.AddParameter("p_EMAIL_ID2", pVendorMaster.EmailId2)
                db.AddParameter("p_CONTACT_NO", pVendorMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pVendorMaster.MobileNo)
                db.AddParameter("p_FAX", pVendorMaster.Fax)
                db.AddParameter("p_PAYMENT_TERMS", pVendorMaster.PaymentTerms)
                db.AddParameter("p_PAN", pVendorMaster.Pan)
                db.AddParameter("p_TAN", pVendorMaster.Tan)
                db.AddParameter("p_SERVICE_TAX_REG", pVendorMaster.ServiceTaxReg)
                db.AddParameter("p_BANK_NAME", pVendorMaster.BankName)
                db.AddParameter("p_AC_MAP_CODE", pVendorMaster.AcMapCode)
                db.AddParameter("p_CREATED_BY", pVendorMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorMaster.CreatedOn)
                db.AddParameter("p_ACCOUNT_NO", pVendorMaster.AccountNo)
                db.AddParameter("p_IFSC", pVendorMaster.IFSC)
                db.AddParameter("p_BANK_BRANCH", pVendorMaster.BankBranch)
                db.AddParameter("p_CONTACT_PERSON", pVendorMaster.ContactPerson)
                db.AddParameter("p_RATE", pVendorMaster.Rate)
                db.AddParameter("p_GSTIN", pVendorMaster.GSTIN)
                db.AddParameter("p_TALLY_CUSTOMER_NAME", pVendorMaster.TallyVendorName)
                db.AddParameter("p_ErrorMsg", pVendorMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVendorMaster.ErrorMsg = ex.Message
                End Try
            Return pVendorMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVendorMaster As VendorMaster) As VendorMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVendorMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                PVendorMaster.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_CODE").ToString <> "" Then
                                PVendorMaster.VendorCode = dbr("VENDOR_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_NAME").ToString <> "" Then
                                PVendorMaster.VendorName = dbr("VENDOR_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PVendorMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CITY").ToString <> "" Then
                                PVendorMaster.City = dbr("CITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PIN_CODE").ToString <> "" Then
                                PVendorMaster.PinCode = dbr("PIN_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE").ToString <> "" Then
                                PVendorMaster.State = dbr("STATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY").ToString <> "" Then
                                PVendorMaster.Country = dbr("COUNTRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID1").ToString <> "" Then
                                PVendorMaster.EmailId1 = dbr("EMAIL_ID1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID2").ToString <> "" Then
                                PVendorMaster.EmailId2 = dbr("EMAIL_ID2")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                PVendorMaster.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MOBILE_NO").ToString <> "" Then
                                PVendorMaster.MobileNo = dbr("MOBILE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FAX").ToString <> "" Then
                                PVendorMaster.Fax = dbr("FAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_TERMS").ToString <> "" Then
                                PVendorMaster.PaymentTerms = dbr("PAYMENT_TERMS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAN").ToString <> "" Then
                                PVendorMaster.Pan = dbr("PAN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAN").ToString <> "" Then
                                PVendorMaster.Tan = dbr("TAN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX_REG").ToString <> "" Then
                                PVendorMaster.ServiceTaxReg = dbr("SERVICE_TAX_REG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_NAME").ToString <> "" Then
                                PVendorMaster.BankName = dbr("BANK_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AC_MAP_CODE").ToString <> "" Then
                                PVendorMaster.AcMapCode = dbr("AC_MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PVendorMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PVendorMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_NO").ToString <> "" Then
                                PVendorMaster.AccountNo = dbr("ACCOUNT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IFSC").ToString <> "" Then
                                pVendorMaster.IFSC = dbr("IFSC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_BRANCH").ToString <> "" Then
                                pVendorMaster.BankBranch = dbr("BANK_BRANCH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_PERSON").ToString <> "" Then
                                pVendorMaster.ContactPerson = dbr("CONTACT_PERSON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                pVendorMaster.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GSTIN").ToString <> "" Then
                                pVendorMaster.GSTIN = dbr("GSTIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_VENDOR_NAME").ToString <> "" Then
                                pVendorMaster.TallyVendorName = dbr("TALLY_VENDOR_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVendorMaster.ErrorMsg = ex.Message
            End Try
            Return pVendorMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVendorMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VendorMaster
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
                            If dbr("VENDOR_CODE").ToString <> "" Then
                                temp.VendorCode = dbr("VENDOR_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_NAME").ToString <> "" Then
                                temp.VendorName = dbr("VENDOR_NAME")
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
                            If dbr("PIN_CODE").ToString <> "" Then
                                temp.PinCode = dbr("PIN_CODE")
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
                            If dbr("EMAIL_ID1").ToString <> "" Then
                                temp.EmailId1 = dbr("EMAIL_ID1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID2").ToString <> "" Then
                                temp.EmailId2 = dbr("EMAIL_ID2")
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
                            If dbr("MOBILE_NO").ToString <> "" Then
                                temp.MobileNo = dbr("MOBILE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FAX").ToString <> "" Then
                                temp.Fax = dbr("FAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_TERMS").ToString <> "" Then
                                temp.PaymentTerms = dbr("PAYMENT_TERMS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAN").ToString <> "" Then
                                temp.Pan = dbr("PAN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAN").ToString <> "" Then
                                temp.Tan = dbr("TAN")
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
                            If dbr("BANK_NAME").ToString <> "" Then
                                temp.BankName = dbr("BANK_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AC_MAP_CODE").ToString <> "" Then
                                temp.AcMapCode = dbr("AC_MAP_CODE")
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
                            If dbr("ACCOUNT_NO").ToString <> "" Then
                                temp.AccountNo = dbr("ACCOUNT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IFSC").ToString <> "" Then
                                temp.IFSC = dbr("IFSC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_BRANCH").ToString <> "" Then
                                temp.BankBranch = dbr("BANK_BRANCH")
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
                            If dbr("RATE").ToString <> "" Then
                                temp.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GSTIN").ToString <> "" Then
                                temp.GSTIN = dbr("GSTIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_VENDOR_NAME").ToString <> "" Then
                                temp.TallyVendorName = dbr("TALLY_VENDOR_NAME")
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
        Public Shared Function ReturnVendorMaster(ByVal pVendorMaster As VendorMaster) As VendorMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_BY_ID", pVendorMaster.TerminalId & "," & pVendorMaster.VendorId)
                pVendorMaster = ReturnObjectValues(dbr, pVendorMaster)
                dbr.Close()
            Catch ex As Exception
                pVendorMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorMasterList(ByVal pVendorMaster As VendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_ALL", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorMasterSurveyor(ByVal pVendorMaster As VendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_SERVEYOR", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListDomesticTransporter(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_DOM_TRANSPORTER", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

    End Class
End Namespace
