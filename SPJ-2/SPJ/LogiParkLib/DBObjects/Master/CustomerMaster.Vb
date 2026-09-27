Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CustomerMaster
    ''' @author	: Amit K. Singh- 25/4/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CustomerMaster

        Public Enum enumCustomerTypeCode As Long
            Line = 1
            Agent = 2
            Cha = 3
            Consignee = 4
            Consignor = 5
            Forwarder = 6
            Shipper = 7
        End Enum

        Public Enum enumDocType As Long
            All = 0
            Import = 1
            Export = 2
            Domestic = 3
        End Enum

        Public Enum enumStatus As Long
            All = 0
            Yes = 1
        End Enum

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strCustomerCode As String ' Define Private Variable CustomerCode With DataType As String 
        Private strCustomerName As String ' Define Private Variable CustomerName With DataType As String 
        Private strCustomerType As String ' Define Private Variable CustomerType With DataType As String 
        Private strContactPerson As String ' Define Private Variable ContactPerson With DataType As String 
        Private strContactNo As String ' Define Private Variable ContactNo With DataType As String 
        Private strMobileNo As String ' Define Private Variable MobileNo With DataType As String 
        Private strEmailCommercial As String ' Define Private Variable EmailCommercial With DataType As String 
        Private strEmailOperational As String ' Define Private Variable EmailOperational With DataType As String 
        Private strPaymentTerms As String ' Define Private Variable PaymentTerms With DataType As String 
        Private lngOpeningAmount As Long ' Define Private Variable OpeningAmount With DataType As Long 
        Private lngTdsAmount As Long ' Define Private Variable TdsAmount With DataType As Long 
        Private lngCreditPeriod As Long ' Define Private Variable CreditPeriod With DataType As Long 
        Private lngCreditLimit As Long ' Define Private Variable CreditLimit With DataType As Long 
        Private strAccountNo As String ' Define Private Variable AccountNo With DataType As String 
        Private strAccountMapCode As String ' Define Private Variable AccountMapCode With DataType As String 
        Private strServiceTaxNo As String ' Define Private Variable ServiceTaxNo With DataType As String 
        Private strTanNo As String ' Define Private Variable TanNo With DataType As String 
        Private strPanNo As String ' Define Private Variable PanNo With DataType As String 
        Private strBinNo As String ' Define Private Variable BinNo With DataType As String 
        Private lngExemption As Long ' Define Private Variable Exemption With DataType As Long 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private strCity As String ' Define Private Variable City With DataType As String 
        Private lngPin As Long ' Define Private Variable Pin With DataType As Long 
        Private lngCountryId As Long ' Define Private Variable CountryId With DataType As Long 
        Private strStatus As String ' Define Private Variable Status With DataType As String 
        Private strExport As String ' Define Private Variable Export With DataType As String 
        Private strImport As String ' Define Private Variable Import With DataType As String 
        Private strDomestic As String ' Define Private Variable Domestic With DataType As String 
        Private lngBankId As Long ' Define Private Variable BankId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strUpdatedBy As String ' Define Private Variable UpdatedBy With DataType As String 
        Private strUpdatedOn As String ' Define Private Variable UpdatedOn With DataType As String 
        Private lngOperaterId As Long ' Define Private Variable CountryId With DataType As Long 
        Private strStateCode As String ' Define Private Variable StateCode DataType As String 
        Private strGSTN As String ' Define Private Variable GSTN DataType As String 
        Private strCreditType As String
        Private lngdiscountDays As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngCustomerGroupId As Long
        Private strTallyTptCustomerName As String
        Private strTallyFrtCustomerName As String
        Private strTallyPurchaseCustomerName As String
        Private strCreditDiscountType As String
        Private strTDSStatus As String
        Private strTallyBillOfSupplyCustomerName As String
        Private lngCustSubId As Long ' Define Private Variable CustSubId With DataType As Long 
        Private lngBankIdUSD As Long ' Define Private Variable BankIdUSD  With DataType As Long 
        Public Property CreditType() As String
            Get
                Return strCreditType
            End Get
            Set(ByVal value As String)
                strCreditType = value
            End Set
        End Property

        Public Property CreditDiscountType() As String
            Get
                Return strCreditDiscountType
            End Get
            Set(ByVal value As String)
                strCreditDiscountType = value
            End Set
        End Property


        Public Property discountDays() As Long
            Get
                Return lngdiscountDays
            End Get
            Set(ByVal value As Long)
                lngdiscountDays = value
            End Set
        End Property
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

        Public Property CustomerGroupId() As Long
            Get
                Return lngCustomerGroupId
            End Get
            Set(ByVal value As Long)
                lngCustomerGroupId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerCode
        ''' </summary>
        ''' <value>strCustomerCode</value>
        ''' <returns> Return strCustomerCode</returns>
        ''' <remarks> Get or Set the Value of CustomerCode  </remarks>
        '''
        Public Property CustomerCode() As String
            Get
                Return strCustomerCode
            End Get
            Set(ByVal value As String)
                strCustomerCode = value
            End Set
        End Property
        Public Property TDS() As String
            Get
                Return strTDSStatus
            End Get
            Set(ByVal value As String)
                strTDSStatus = value
            End Set
        End Property

        Public Property TallyTptCustomerName() As String
            Get
                Return strTallyTptCustomerName
            End Get
            Set(ByVal value As String)
                strTallyTptCustomerName = value
            End Set
        End Property

        Public Property TallyPurchaseCustomerName() As String
            Get
                Return strTallyPurchaseCustomerName
            End Get
            Set(ByVal value As String)
                strTallyPurchaseCustomerName = value
            End Set
        End Property

        Public Property TallyFrtCustomerName() As String
            Get
                Return strTallyFrtCustomerName
            End Get
            Set(ByVal value As String)
                strTallyFrtCustomerName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerName
        ''' </summary>
        ''' <value>strCustomerName</value>
        ''' <returns> Return strCustomerName</returns>
        ''' <remarks> Get or Set the Value of CustomerName  </remarks>
        '''
        Public Property CustomerName() As String
            Get
                Return strCustomerName
            End Get
            Set(ByVal value As String)
                strCustomerName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerType
        ''' </summary>
        ''' <value>strCustomerType</value>
        ''' <returns> Return strCustomerType</returns>
        ''' <remarks> Get or Set the Value of CustomerType  </remarks>
        '''
        Public Property CustomerType() As String
            Get
                Return strCustomerType
            End Get
            Set(ByVal value As String)
                strCustomerType = value
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
        ''' Get or Set the Value of MobileNo
        ''' </summary>
        ''' <value>strMobileNo</value>
        ''' <returns> Return strMobileNo</returns>
        ''' <remarks> Get or Set the Value of MobileNo  </remarks>
        '''
        Public Property MobileNo() As String
            Get
                Return strMobileNo
            End Get
            Set(ByVal value As String)
                strMobileNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EmailCommercial
        ''' </summary>
        ''' <value>strEmailCommercial</value>
        ''' <returns> Return strEmailCommercial</returns>
        ''' <remarks> Get or Set the Value of EmailCommercial  </remarks>
        '''
        Public Property EmailCommercial() As String
            Get
                Return strEmailCommercial
            End Get
            Set(ByVal value As String)
                strEmailCommercial = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EmailOperational
        ''' </summary>
        ''' <value>strEmailOperational</value>
        ''' <returns> Return strEmailOperational</returns>
        ''' <remarks> Get or Set the Value of EmailOperational  </remarks>
        '''
        Public Property EmailOperational() As String
            Get
                Return strEmailOperational
            End Get
            Set(ByVal value As String)
                strEmailOperational = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PaymentTerms
        ''' </summary>
        ''' <value>strPaymentTerms</value>
        ''' <returns> Return strPaymentTerms</returns>
        ''' <remarks> Get or Set the Value of PaymentTerms  </remarks>
        '''
        Public Property PaymentTerms() As String
            Get
                Return strPaymentTerms
            End Get
            Set(ByVal value As String)
                strPaymentTerms = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OpeningAmount
        ''' </summary>
        ''' <value>lngOpeningAmount</value>
        ''' <returns> Return lngOpeningAmount</returns>
        ''' <remarks> Get or Set the Value of OpeningAmount  </remarks>
        '''
        Public Property OpeningAmount() As Long
            Get
                Return lngOpeningAmount
            End Get
            Set(ByVal value As Long)
                lngOpeningAmount = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TdsAmount
        ''' </summary>
        ''' <value>lngTdsAmount</value>
        ''' <returns> Return lngTdsAmount</returns>
        ''' <remarks> Get or Set the Value of TdsAmount  </remarks>
        '''
        Public Property TdsAmount() As Long
            Get
                Return lngTdsAmount
            End Get
            Set(ByVal value As Long)
                lngTdsAmount = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreditPeriod
        ''' </summary>
        ''' <value>lngCreditPeriod</value>
        ''' <returns> Return lngCreditPeriod</returns>
        ''' <remarks> Get or Set the Value of CreditPeriod  </remarks>
        '''
        Public Property CreditPeriod() As Long
            Get
                Return lngCreditPeriod
            End Get
            Set(ByVal value As Long)
                lngCreditPeriod = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreditLimit
        ''' </summary>
        ''' <value>lngCreditLimit</value>
        ''' <returns> Return lngCreditLimit</returns>
        ''' <remarks> Get or Set the Value of CreditLimit  </remarks>
        '''
        Public Property CreditLimit() As Long
            Get
                Return lngCreditLimit
            End Get
            Set(ByVal value As Long)
                lngCreditLimit = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of AccountNo
        ''' </summary>
        ''' <value>strAccountNo</value>
        ''' <returns> Return strAccountNo</returns>
        ''' <remarks> Get or Set the Value of AccountNo  </remarks>
        '''
        Public Property AccountNo() As String
            Get
                Return strAccountNo
            End Get
            Set(ByVal value As String)
                strAccountNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of AccountMapCode
        ''' </summary>
        ''' <value>strAccountMapCode</value>
        ''' <returns> Return strAccountMapCode</returns>
        ''' <remarks> Get or Set the Value of AccountMapCode  </remarks>
        '''
        Public Property AccountMapCode() As String
            Get
                Return strAccountMapCode
            End Get
            Set(ByVal value As String)
                strAccountMapCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceTaxNo
        ''' </summary>
        ''' <value>strServiceTaxNo</value>
        ''' <returns> Return strServiceTaxNo</returns>
        ''' <remarks> Get or Set the Value of ServiceTaxNo  </remarks>
        '''
        Public Property ServiceTaxNo() As String
            Get
                Return strServiceTaxNo
            End Get
            Set(ByVal value As String)
                strServiceTaxNo = value
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
        ''' Get or Set the Value of BinNo
        ''' </summary>
        ''' <value>strBinNo</value>
        ''' <returns> Return strBinNo</returns>
        ''' <remarks> Get or Set the Value of BinNo  </remarks>
        '''
        Public Property BinNo() As String
            Get
                Return strBinNo
            End Get
            Set(ByVal value As String)
                strBinNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Exemption
        ''' </summary>
        ''' <value>lngExemption</value>
        ''' <returns> Return lngExemption</returns>
        ''' <remarks> Get or Set the Value of Exemption  </remarks>
        '''
        Public Property Exemption() As Long
            Get
                Return lngExemption
            End Get
            Set(ByVal value As Long)
                lngExemption = value
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
        ''' Get or Set the Value of Pin
        ''' </summary>
        ''' <value>lngPin</value>
        ''' <returns> Return lngPin</returns>
        ''' <remarks> Get or Set the Value of Pin  </remarks>
        '''
        Public Property Pin() As Long
            Get
                Return lngPin
            End Get
            Set(ByVal value As Long)
                lngPin = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CountryId
        ''' </summary>
        ''' <value>lngCountryId</value>
        ''' <returns> Return lngCountryId</returns>
        ''' <remarks> Get or Set the Value of CountryId  </remarks>
        '''
        Public Property CountryId() As Long
            Get
                Return lngCountryId
            End Get
            Set(ByVal value As Long)
                lngCountryId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>strStatus</value>
        ''' <returns> Return strStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property Status() As String
            Get
                Return strStatus
            End Get
            Set(ByVal value As String)
                strStatus = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Export
        ''' </summary>
        ''' <value>strExport</value>
        ''' <returns> Return strExport</returns>
        ''' <remarks> Get or Set the Value of Export  </remarks>
        '''
        Public Property Export() As String
            Get
                Return strExport
            End Get
            Set(ByVal value As String)
                strExport = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Import
        ''' </summary>
        ''' <value>strImport</value>
        ''' <returns> Return strImport</returns>
        ''' <remarks> Get or Set the Value of Import  </remarks>
        '''
        Public Property Import() As String
            Get
                Return strImport
            End Get
            Set(ByVal value As String)
                strImport = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Domestic
        ''' </summary>
        ''' <value>strDomestic</value>
        ''' <returns> Return strDomestic</returns>
        ''' <remarks> Get or Set the Value of Domestic  </remarks>
        '''
        Public Property Domestic() As String
            Get
                Return strDomestic
            End Get
            Set(ByVal value As String)
                strDomestic = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BankId
        ''' </summary>
        ''' <value>lngBankId</value>
        ''' <returns> Return lngBankId</returns>
        ''' <remarks> Get or Set the Value of BankId  </remarks>
        '''
        Public Property BankId() As Long
            Get
                Return lngBankId
            End Get
            Set(ByVal value As Long)
                lngBankId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() As String
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
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UpdatedBy
        ''' </summary>
        ''' <value>strUpdatedBy</value>
        ''' <returns> Return strUpdatedBy</returns>
        ''' <remarks> Get or Set the Value of UpdatedBy  </remarks>
        '''
        Public Property UpdatedBy() As String
            Get
                Return strUpdatedBy
            End Get
            Set(ByVal value As String)
                strUpdatedBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UpdatedOn
        ''' </summary>
        ''' <value>strUpdatedOn</value>
        ''' <returns> Return strUpdatedOn</returns>
        ''' <remarks> Get or Set the Value of UpdatedOn  </remarks>
        '''
        Public Property UpdatedOn() As String
            Get
                Return strUpdatedOn
            End Get
            Set(ByVal value As String)
                strUpdatedOn = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of OperaterId
        ''' </summary>
        ''' <value>lngOperaterId</value>
        ''' <returns> Return lngOperaterId</returns>
        ''' <remarks> Get or Set the Value of OperaterId  </remarks>
        '''
        Public Property OperaterId() As Long
            Get
                Return lngOperaterId
            End Get
            Set(ByVal value As Long)
                lngOperaterId = value
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
        ''' StateCode
        ''' </summary>
        ''' <value>strStateCode</value>
        ''' <returns> Return strStateCode</returns>
        ''' <remarks></remarks>
        Public Property StateCode() As String
            Get
                Return strStateCode
            End Get
            Set(ByVal value As String)
                strStateCode = value
            End Set
        End Property

        ''' <summary>
        ''' GSTN
        ''' </summary>
        ''' <value>strGSTN</value>
        ''' <returns> Return strGSTN</returns>
        ''' <remarks></remarks>
        Public Property GSTN() As String
            Get
                Return strGSTN
            End Get
            Set(ByVal value As String)
                strGSTN = value
            End Set
        End Property
        Public Property TallyUSDCustomerName() As String
            Get
                Return strTallyBillOfSupplyCustomerName
            End Get
            Set(ByVal value As String)
                strTallyBillOfSupplyCustomerName = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of CustSubId
        ''' </summary>
        ''' <value>lngCustSubId</value>
        ''' <returns> Return lngCustSubId</returns>
        ''' <remarks> Get or Set the Value of CustSubId  </remarks>
        '''
        Public Property CustSubId() As Long
            Get
                Return lngCustSubId
            End Get
            Set(ByVal value As Long)
                lngCustSubId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of BankIdUSD
        ''' </summary>
        ''' <value>lngBankIdUSD</value>
        ''' <returns> Return lngBankIdUSD</returns>
        ''' <remarks> Get or Set the Value of BankIdUSD  </remarks>
        '''
        Public Property BankIdUSD() As Long
            Get
                Return lngBankIdUSD
            End Get
            Set(ByVal value As Long)
                lngBankIdUSD = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngCustomerId = 0
            strCustomerCode = ""
            strCustomerName = ""
            strCustomerType = ""
            strContactPerson = ""
            strContactNo = ""
            strMobileNo = ""
            strEmailCommercial = ""
            strEmailOperational = ""
            strPaymentTerms = ""
            lngOpeningAmount = 0
            lngTdsAmount = 0
            lngCreditPeriod = 0
            lngCreditLimit = 0
            strAccountNo = ""
            strAccountMapCode = ""
            strServiceTaxNo = ""
            strTanNo = ""
            strPanNo = ""
            strBinNo = ""
            lngExemption = 0
            strAddress = ""
            strCity = ""
            lngPin = 0
            lngCountryId = 0
            strStatus = ""
            strExport = ""
            strImport = ""
            strDomestic = ""
            lngBankId = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strUpdatedBy = ""
            strUpdatedOn = ""
            lngOperaterId = 0
            strStateCode = ""
            strGSTN = ""
            lngdiscountDays = 0
            strCreditType = ""
            strErrormsg = ""
            lngCustomerGroupId = 0
            strTallyFrtCustomerName = ""
            strTallyTptCustomerName = ""
            strTallyBillOfSupplyCustomerName = ""
            strTDSStatus = ""
            strTallyPurchaseCustomerName = ""
            strCreditDiscountType = ""
            lngCustSubId = 0
            lngBankIdUSD = 0
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerMaster"></param>
        ''' <returns>Return pCustomerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerMaster.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMaster.CustomerId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_CODE", pCustomerMaster.CustomerCode)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMaster.CustomerName)
                db.AddParameter("p_CUSTOMER_TYPE", pCustomerMaster.CustomerType)
                db.AddParameter("p_CONTACT_PERSON", pCustomerMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCustomerMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pCustomerMaster.MobileNo)
                db.AddParameter("p_EMAIL_COMMERCIAL", pCustomerMaster.EmailCommercial)
                db.AddParameter("p_EMAIL_OPERATIONAL", pCustomerMaster.EmailOperational)
                db.AddParameter("p_PAYMENT_TERMS", pCustomerMaster.PaymentTerms)
                db.AddParameter("p_OPENING_AMOUNT", pCustomerMaster.OpeningAmount)
                db.AddParameter("p_TDS_AMOUNT", pCustomerMaster.TdsAmount)
                db.AddParameter("p_CREDIT_PERIOD", pCustomerMaster.CreditPeriod)
                db.AddParameter("p_CREDIT_LIMIT", pCustomerMaster.CreditLimit)
                db.AddParameter("p_ACCOUNT_NO", pCustomerMaster.AccountNo)
                db.AddParameter("p_ACCOUNT_MAP_CODE", pCustomerMaster.AccountMapCode)
                db.AddParameter("p_SERVICE_TAX_NO", pCustomerMaster.ServiceTaxNo)
                db.AddParameter("p_TAN_NO", pCustomerMaster.TanNo)
                db.AddParameter("p_PAN_NO", pCustomerMaster.PanNo)
                db.AddParameter("p_BIN_NO", pCustomerMaster.BinNo)
                db.AddParameter("p_EXEMPTION", pCustomerMaster.Exemption)
                db.AddParameter("p_ADDRESS", pCustomerMaster.Address)
                db.AddParameter("p_CITY", pCustomerMaster.City)
                db.AddParameter("p_PIN", pCustomerMaster.Pin)
                db.AddParameter("p_COUNTRY_ID", pCustomerMaster.CountryId)
                db.AddParameter("p_STATUS", pCustomerMaster.Status)
                db.AddParameter("p_EXPORT", pCustomerMaster.Export)
                db.AddParameter("p_IMPORT", pCustomerMaster.Import)
                db.AddParameter("p_DOMESTIC", pCustomerMaster.Domestic)
                db.AddParameter("p_BANK_ID", pCustomerMaster.BankId)
                db.AddParameter("p_CREATED_BY", pCustomerMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCustomerMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCustomerMaster.UpdatedOn)
                db.AddParameter("p_OPERATOR_ID", pCustomerMaster.OperaterId)
                db.AddParameter("p_STATE_CODE", pCustomerMaster.StateCode)
                db.AddParameter("p_GSTN", pCustomerMaster.GSTN)
                db.AddParameter("p_CREDIT_TYPE", pCustomerMaster.CreditType)
                db.AddParameter("p_DISCOUNT_DAYS", pCustomerMaster.discountDays)
                db.AddParameter("p_CUSTOMER_GROUP_ID", pCustomerMaster.CustomerGroupId)
                db.AddParameter("p_TALLY_TPT_CUSTOMER_NAME", pCustomerMaster.TallyTptCustomerName)
                db.AddParameter("p_TALLY_FRT_CUSTOMER_NAME", pCustomerMaster.TallyFrtCustomerName)
                db.AddParameter("p_TDS", pCustomerMaster.TDS)
                db.AddParameter("p_TALLY_PURCHASE_CUSTOMER_NAME", pCustomerMaster.TallyPurchaseCustomerName)
                db.AddParameter("p_CREDIT_DISCOUNT_DAYS", pCustomerMaster.CreditDiscountType)
                db.AddParameter("p_MAP_USD_CUSTOMER_NAME", pCustomerMaster.TallyUSDCustomerName)
                db.AddParameter("p_CUST_SUB_ID", pCustomerMaster.CustSubId)
                db.AddParameter("p_BANK_ID_USD", pCustomerMaster.BankIdUSD)
                db.AddParameter("p_ErrorMsg", pCustomerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerMaster.CustomerId = db.Parameters.Item("p_CUSTOMER_ID").value
                pCustomerMaster.CustomerCode = db.Parameters.Item("p_CUSTOMER_CODE").value.ToString

                If pCustomerMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerMaster"></param>
        ''' <returns>Return pCustomerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerMaster.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMaster.CustomerId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_CODE", pCustomerMaster.CustomerCode)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMaster.CustomerName)
                db.AddParameter("p_CUSTOMER_TYPE", pCustomerMaster.CustomerType)
                db.AddParameter("p_CONTACT_PERSON", pCustomerMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCustomerMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pCustomerMaster.MobileNo)
                db.AddParameter("p_EMAIL_COMMERCIAL", pCustomerMaster.EmailCommercial)
                db.AddParameter("p_EMAIL_OPERATIONAL", pCustomerMaster.EmailOperational)
                db.AddParameter("p_PAYMENT_TERMS", pCustomerMaster.PaymentTerms)
                db.AddParameter("p_OPENING_AMOUNT", pCustomerMaster.OpeningAmount)
                db.AddParameter("p_TDS_AMOUNT", pCustomerMaster.TdsAmount)
                db.AddParameter("p_CREDIT_PERIOD", pCustomerMaster.CreditPeriod)
                db.AddParameter("p_CREDIT_LIMIT", pCustomerMaster.CreditLimit)
                db.AddParameter("p_ACCOUNT_NO", pCustomerMaster.AccountNo)
                db.AddParameter("p_ACCOUNT_MAP_CODE", pCustomerMaster.AccountMapCode)
                db.AddParameter("p_SERVICE_TAX_NO", pCustomerMaster.ServiceTaxNo)
                db.AddParameter("p_TAN_NO", pCustomerMaster.TanNo)
                db.AddParameter("p_PAN_NO", pCustomerMaster.PanNo)
                db.AddParameter("p_BIN_NO", pCustomerMaster.BinNo)
                db.AddParameter("p_EXEMPTION", pCustomerMaster.Exemption)
                db.AddParameter("p_ADDRESS", pCustomerMaster.Address)
                db.AddParameter("p_CITY", pCustomerMaster.City)
                db.AddParameter("p_PIN", pCustomerMaster.Pin)
                db.AddParameter("p_COUNTRY_ID", pCustomerMaster.CountryId)
                db.AddParameter("p_STATUS", pCustomerMaster.Status)
                db.AddParameter("p_EXPORT", pCustomerMaster.Export)
                db.AddParameter("p_IMPORT", pCustomerMaster.Import)
                db.AddParameter("p_DOMESTIC", pCustomerMaster.Domestic)
                db.AddParameter("p_BANK_ID", pCustomerMaster.BankId)
                db.AddParameter("p_CREATED_BY", pCustomerMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCustomerMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCustomerMaster.UpdatedOn)
                db.AddParameter("p_STATE_CODE", pCustomerMaster.StateCode)
                db.AddParameter("p_GSTN", pCustomerMaster.GSTN)
                db.AddParameter("p_CREDIT_TYPE", pCustomerMaster.CreditType)
                db.AddParameter("p_DISCOUNT_DAYS", pCustomerMaster.discountDays)
                db.AddParameter("p_MAP_USD_CUSTOMER_NAME", pCustomerMaster.TallyUSDCustomerName)
                db.AddParameter("p_ErrorMsg", pCustomerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerMaster.CustomerId = db.Parameters.Item("p_CUSTOMER_ID").value
                pCustomerMaster.CustomerId = db.Parameters.Item("p_CUSTOMER_ID").value.ToString

            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerMaster"></param>
        ''' <returns>Return pCustomerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerMaster.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMaster.CustomerId)
                db.AddParameter("p_CUSTOMER_CODE", pCustomerMaster.CustomerCode)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMaster.CustomerName)
                db.AddParameter("p_CUSTOMER_TYPE", pCustomerMaster.CustomerType)
                db.AddParameter("p_CONTACT_PERSON", pCustomerMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCustomerMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pCustomerMaster.MobileNo)
                db.AddParameter("p_EMAIL_COMMERCIAL", pCustomerMaster.EmailCommercial)
                db.AddParameter("p_EMAIL_OPERATIONAL", pCustomerMaster.EmailOperational)
                db.AddParameter("p_PAYMENT_TERMS", pCustomerMaster.PaymentTerms)
                db.AddParameter("p_OPENING_AMOUNT", pCustomerMaster.OpeningAmount)
                db.AddParameter("p_TDS_AMOUNT", pCustomerMaster.TdsAmount)
                db.AddParameter("p_CREDIT_PERIOD", pCustomerMaster.CreditPeriod)
                db.AddParameter("p_CREDIT_LIMIT", pCustomerMaster.CreditLimit)
                db.AddParameter("p_ACCOUNT_NO", pCustomerMaster.AccountNo)
                db.AddParameter("p_ACCOUNT_MAP_CODE", pCustomerMaster.AccountMapCode)
                db.AddParameter("p_SERVICE_TAX_NO", pCustomerMaster.ServiceTaxNo)
                db.AddParameter("p_TAN_NO", pCustomerMaster.TanNo)
                db.AddParameter("p_PAN_NO", pCustomerMaster.PanNo)
                db.AddParameter("p_BIN_NO", pCustomerMaster.BinNo)
                db.AddParameter("p_EXEMPTION", pCustomerMaster.Exemption)
                db.AddParameter("p_ADDRESS", pCustomerMaster.Address)
                db.AddParameter("p_CITY", pCustomerMaster.City)
                db.AddParameter("p_PIN", pCustomerMaster.Pin)
                db.AddParameter("p_COUNTRY_ID", pCustomerMaster.CountryId)
                db.AddParameter("p_STATUS", pCustomerMaster.Status)
                db.AddParameter("p_EXPORT", pCustomerMaster.Export)
                db.AddParameter("p_IMPORT", pCustomerMaster.Import)
                db.AddParameter("p_DOMESTIC", pCustomerMaster.Domestic)
                db.AddParameter("p_BANK_ID", pCustomerMaster.BankId)
                db.AddParameter("p_CREATED_BY", pCustomerMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCustomerMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCustomerMaster.UpdatedOn)
                db.AddParameter("p_OPERATER_ID", pCustomerMaster.OperaterId)
                db.AddParameter("p_STATE_CODE", pCustomerMaster.StateCode)
                db.AddParameter("p_GSTN", pCustomerMaster.GSTN)
                db.AddParameter("p_CREDIT_TYPE", pCustomerMaster.CreditType)
                db.AddParameter("p_DISCOUNT_DAYS", pCustomerMaster.discountDays)
                db.AddParameter("p_CUSTOMER_GROUP_ID", pCustomerMaster.CustomerGroupId)
                db.AddParameter("p_TALLY_TPT_CUSTOMER_NAME", pCustomerMaster.TallyTptCustomerName)
                db.AddParameter("p_TALLY_FRT_CUSTOMER_NAME", pCustomerMaster.TallyFrtCustomerName)
                db.AddParameter("p_TDS", pCustomerMaster.TDS)
                db.AddParameter("p_TALLY_PURCHASE_CUSTOMER_NAME", pCustomerMaster.TallyPurchaseCustomerName)
                db.AddParameter("p_CREDIT_DISCOUNT_DAYS", pCustomerMaster.CreditDiscountType)
                db.AddParameter("p_MAP_USD_CUSTOMER_NAME", pCustomerMaster.TallyUSDCustomerName)
                db.AddParameter("p_CUST_SUB_ID", pCustomerMaster.CustSubId)
                db.AddParameter("p_BANK_ID_USD", pCustomerMaster.BankIdUSD)
                db.AddParameter("p_ErrorMsg", pCustomerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerMaster"></param>
        ''' <returns>Return pCustomerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerMaster.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMaster.CustomerId)
                db.AddParameter("p_CUSTOMER_CODE", pCustomerMaster.CustomerCode)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMaster.CustomerName)
                db.AddParameter("p_CUSTOMER_TYPE", pCustomerMaster.CustomerType)
                db.AddParameter("p_CONTACT_PERSON", pCustomerMaster.ContactPerson)
                db.AddParameter("p_CONTACT_NO", pCustomerMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pCustomerMaster.MobileNo)
                db.AddParameter("p_EMAIL_COMMERCIAL", pCustomerMaster.EmailCommercial)
                db.AddParameter("p_EMAIL_OPERATIONAL", pCustomerMaster.EmailOperational)
                db.AddParameter("p_PAYMENT_TERMS", pCustomerMaster.PaymentTerms)
                db.AddParameter("p_OPENING_AMOUNT", pCustomerMaster.OpeningAmount)
                db.AddParameter("p_TDS_AMOUNT", pCustomerMaster.TdsAmount)
                db.AddParameter("p_CREDIT_PERIOD", pCustomerMaster.CreditPeriod)
                db.AddParameter("p_CREDIT_LIMIT", pCustomerMaster.CreditLimit)
                db.AddParameter("p_ACCOUNT_NO", pCustomerMaster.AccountNo)
                db.AddParameter("p_ACCOUNT_MAP_CODE", pCustomerMaster.AccountMapCode)
                db.AddParameter("p_SERVICE_TAX_NO", pCustomerMaster.ServiceTaxNo)
                db.AddParameter("p_TAN_NO", pCustomerMaster.TanNo)
                db.AddParameter("p_PAN_NO", pCustomerMaster.PanNo)
                db.AddParameter("p_BIN_NO", pCustomerMaster.BinNo)
                db.AddParameter("p_EXEMPTION", pCustomerMaster.Exemption)
                db.AddParameter("p_ADDRESS", pCustomerMaster.Address)
                db.AddParameter("p_CITY", pCustomerMaster.City)
                db.AddParameter("p_PIN", pCustomerMaster.Pin)
                db.AddParameter("p_COUNTRY_ID", pCustomerMaster.CountryId)
                db.AddParameter("p_STATUS", pCustomerMaster.Status)
                db.AddParameter("p_EXPORT", pCustomerMaster.Export)
                db.AddParameter("p_IMPORT", pCustomerMaster.Import)
                db.AddParameter("p_DOMESTIC", pCustomerMaster.Domestic)
                db.AddParameter("p_BANK_ID", pCustomerMaster.BankId)
                db.AddParameter("p_CREATED_BY", pCustomerMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCustomerMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCustomerMaster.UpdatedOn)
                db.AddParameter("p_STATE_CODE", pCustomerMaster.StateCode)
                db.AddParameter("p_GSTN", pCustomerMaster.GSTN)
                db.AddParameter("p_CREDIT_TYPE", pCustomerMaster.CreditType)
                db.AddParameter("p_DISCOUNT_DAYS", pCustomerMaster.discountDays)
                db.AddParameter("p_MAP_USD_CUSTOMER_NAME", pCustomerMaster.TallyUSDCustomerName)
                db.AddParameter("p_CUST_SUB_ID", pCustomerMaster.CustSubId)
                db.AddParameter("p_BANK_ID_USD", pCustomerMaster.BankIdUSD)
                db.AddParameter("p_ErrorMsg", pCustomerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pCustomerMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pCustomerMaster.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_CODE").ToString <> "" Then
                                pCustomerMaster.CustomerCode = dbr("CUSTOMER_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_NAME").ToString <> "" Then
                                pCustomerMaster.CustomerName = dbr("CUSTOMER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                pCustomerMaster.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_PERSON").ToString <> "" Then
                                pCustomerMaster.ContactPerson = dbr("CONTACT_PERSON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                pCustomerMaster.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MOBILE_NO").ToString <> "" Then
                                pCustomerMaster.MobileNo = dbr("MOBILE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_COMMERCIAL").ToString <> "" Then
                                pCustomerMaster.EmailCommercial = dbr("EMAIL_COMMERCIAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_OPERATIONAL").ToString <> "" Then
                                pCustomerMaster.EmailOperational = dbr("EMAIL_OPERATIONAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_TERMS").ToString <> "" Then
                                pCustomerMaster.PaymentTerms = dbr("PAYMENT_TERMS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPENING_AMOUNT").ToString <> "" Then
                                pCustomerMaster.OpeningAmount = dbr("OPENING_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TDS_AMOUNT").ToString <> "" Then
                                pCustomerMaster.TdsAmount = dbr("TDS_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREDIT_PERIOD").ToString <> "" Then
                                pCustomerMaster.CreditPeriod = dbr("CREDIT_PERIOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREDIT_LIMIT").ToString <> "" Then
                                pCustomerMaster.CreditLimit = dbr("CREDIT_LIMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_NO").ToString <> "" Then
                                pCustomerMaster.AccountNo = dbr("ACCOUNT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_MAP_CODE").ToString <> "" Then
                                pCustomerMaster.AccountMapCode = dbr("ACCOUNT_MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX_NO").ToString <> "" Then
                                pCustomerMaster.ServiceTaxNo = dbr("SERVICE_TAX_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAN_NO").ToString <> "" Then
                                pCustomerMaster.TanNo = dbr("TAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAN_NO").ToString <> "" Then
                                pCustomerMaster.PanNo = dbr("PAN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BIN_NO").ToString <> "" Then
                                pCustomerMaster.BinNo = dbr("BIN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXEMPTION").ToString <> "" Then
                                pCustomerMaster.Exemption = dbr("EXEMPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                pCustomerMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CITY").ToString <> "" Then
                                pCustomerMaster.City = dbr("CITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PIN").ToString <> "" Then
                                pCustomerMaster.Pin = dbr("PIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_ID").ToString <> "" Then
                                pCustomerMaster.CountryId = dbr("COUNTRY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                pCustomerMaster.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXPORT").ToString <> "" Then
                                pCustomerMaster.Export = dbr("EXPORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMPORT").ToString <> "" Then
                                pCustomerMaster.Import = dbr("IMPORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOMESTIC").ToString <> "" Then
                                pCustomerMaster.Domestic = dbr("DOMESTIC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID").ToString <> "" Then
                                pCustomerMaster.BankId = dbr("BANK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pCustomerMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pCustomerMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                pCustomerMaster.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                pCustomerMaster.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPERATER_ID").ToString <> "" Then
                                pCustomerMaster.OperaterId = dbr("OPERATER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                pCustomerMaster.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("GSTN").ToString <> "" Then
                                pCustomerMaster.GSTN = dbr("GSTN")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CREDIT_TYPE").ToString <> "" Then
                                pCustomerMaster.CreditType = dbr("CREDIT_TYPE")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT_DAYS").ToString <> "" Then
                                pCustomerMaster.discountDays = dbr("DISCOUNT_DAYS")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_GROUP_ID").ToString <> "" Then
                                pCustomerMaster.CustomerGroupId = dbr("CUSTOMER_GROUP_ID")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_TPT_CUSTOMER_NAME").ToString <> "" Then
                                pCustomerMaster.strTallyTptCustomerName = dbr("MAP_TPT_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_FRT_CUSTOMER_NAME").ToString <> "" Then
                                pCustomerMaster.strTallyFrtCustomerName = dbr("MAP_FRT_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("TDS").ToString <> "" Then
                                pCustomerMaster.TDS = dbr("TDS")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_PURCHASE_CUSTOMER_NAME").ToString <> "" Then
                                pCustomerMaster.TallyPurchaseCustomerName = dbr("MAP_PURCHASE_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            If dbr("CREDIT_DISCOUNT_TYPE").ToString <> "" Then
                                pCustomerMaster.CreditDiscountType = dbr("CREDIT_DISCOUNT_TYPE")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_USD_CUSTOMER_NAME").ToString <> "" Then
                                pCustomerMaster.TallyUSDCustomerName = dbr("MAP_USD_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CUST_SUB_ID").ToString <> "" Then
                                pCustomerMaster.CustSubId = dbr("CUST_SUB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID_USD").ToString <> "" Then
                                pCustomerMaster.BankIdUSD = dbr("BANK_ID_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                temp.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_CODE").ToString <> "" Then
                                temp.CustomerCode = dbr("CUSTOMER_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_NAME").ToString <> "" Then
                                temp.CustomerName = dbr("CUSTOMER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                temp.CustomerType = dbr("CUSTOMER_TYPE")
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
                            If dbr("MOBILE_NO").ToString <> "" Then
                                temp.MobileNo = dbr("MOBILE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_COMMERCIAL").ToString <> "" Then
                                temp.EmailCommercial = dbr("EMAIL_COMMERCIAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_OPERATIONAL").ToString <> "" Then
                                temp.EmailOperational = dbr("EMAIL_OPERATIONAL")
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
                            If dbr("TDS_AMOUNT").ToString <> "" Then
                                temp.TdsAmount = dbr("TDS_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREDIT_PERIOD").ToString <> "" Then
                                temp.CreditPeriod = dbr("CREDIT_PERIOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREDIT_LIMIT").ToString <> "" Then
                                temp.CreditLimit = dbr("CREDIT_LIMIT")
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
                            If dbr("ACCOUNT_MAP_CODE").ToString <> "" Then
                                temp.AccountMapCode = dbr("ACCOUNT_MAP_CODE")
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
                            If dbr("TAN_NO").ToString <> "" Then
                                temp.TanNo = dbr("TAN_NO")
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
                            If dbr("BIN_NO").ToString <> "" Then
                                temp.BinNo = dbr("BIN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXEMPTION").ToString <> "" Then
                                temp.Exemption = dbr("EXEMPTION")
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
                            If dbr("PIN").ToString <> "" Then
                                temp.Pin = dbr("PIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_ID").ToString <> "" Then
                                temp.CountryId = dbr("COUNTRY_ID")
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
                            If dbr("EXPORT").ToString <> "" Then
                                temp.Export = dbr("EXPORT")
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
                            If dbr("DOMESTIC").ToString <> "" Then
                                temp.Domestic = dbr("DOMESTIC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID").ToString <> "" Then
                                temp.BankId = dbr("BANK_ID")
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
                            If dbr("UPDATED_BY").ToString <> "" Then
                                temp.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                temp.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPERATER_ID").ToString <> "" Then
                                temp.OperaterId = dbr("OPERATOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                temp.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("GSTN").ToString <> "" Then
                                temp.GSTN = dbr("GSTN")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CREDIT_TYPE").ToString <> "" Then
                                temp.CreditType = dbr("CREDIT_TYPE")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT_DAYS").ToString <> "" Then
                                temp.discountDays = dbr("DISCOUNT_DAYS")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_GROUP_ID").ToString <> "" Then
                                temp.CustomerGroupId = dbr("CUSTOMER_GROUP_ID")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_TPT_CUSTOMER_NAME").ToString <> "" Then
                                temp.strTallyTptCustomerName = dbr("MAP_TPT_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_FRT_CUSTOMER_NAME").ToString <> "" Then
                                temp.strTallyFrtCustomerName = dbr("MAP_FRT_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("TDS").ToString <> "" Then
                                temp.TDS = dbr("TDS")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_PURCHASE_CUSTOMER_NAME").ToString <> "" Then
                                temp.TallyPurchaseCustomerName = dbr("MAP_PURCHASE_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CREDIT_DISCOUNT_TYPE").ToString <> "" Then
                                temp.CreditDiscountType = dbr("CREDIT_DISCOUNT_TYPE")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("MAP_USD_CUSTOMER_NAME").ToString <> "" Then
                                temp.TallyUSDCustomerName = dbr("MAP_USD_CUSTOMER_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("CUST_SUB_ID").ToString <> "" Then
                                temp.CustSubId = dbr("CUST_SUB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID_USD").ToString <> "" Then
                                temp.BankIdUSD = dbr("BANK_ID_USD")
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

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomerMaster(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_ID", pCustomerMaster.TerminalId & "," & pCustomerMaster.CustomerId)
                pCustomerMaster = ReturnObjectValues(dbr, pCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomerMasterForRate(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_ID", pCustomerMaster.TerminalId & "," & pCustomerMaster.CustomerId)
                pCustomerMaster = ReturnObjectValues(dbr, pCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomerCode(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_CODE", pCustomerMaster.TerminalId & "," & "'" & pCustomerMaster.CustomerCode & "'")
                pCustomerMaster = ReturnObjectValues(dbr, pCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerMasterList(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_ALL", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        '''
        Public Shared Function ReturnCustomerMasterGroupList(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_GALL", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListConsignee(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_CONSINEE", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterTypeDtls(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_DTLS", "' '")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListAllLine(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_ALL_LINE", "' '")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList of CHA by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerMasterListByCustomerNameSearch(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_ALL_SEARCH", pCustomerMaster.TerminalId & ",'" & pCustomerMaster.CustomerName & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomerCodeType(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_TYPE", pCustomerMaster.TerminalId & "," & "'" & pCustomerMaster.CustomerCode & "','" & pCustomerMaster.CustomerType & "'")
                pCustomerMaster = ReturnObjectValues(dbr, pCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList of CHA by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerMasterListByInventoryImpList(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_INVENTORY_REPORT_IMPORTER", pCustomerMaster.TerminalId & "," & pCustomerMaster.BankId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList of CHA by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerMasterListByInventoryExpList(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_INVENTORY_REPORT_EXPORTER", pCustomerMaster.TerminalId & "," & pCustomerMaster.BankId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListByRateDetails(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_RATE_ALL", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomerMailExport(ByVal pCustomerMaster As CustomerMaster) As CustomerMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_MAIL_ID", pCustomerMaster.TerminalId & "," & pCustomerMaster.CustomerId)
                pCustomerMaster = ReturnObjectValues(dbr, pCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                pCustomerMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterCostList(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_COST", "'" & pCustomerMaster.CustomerType & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
    End Class
End Namespace
