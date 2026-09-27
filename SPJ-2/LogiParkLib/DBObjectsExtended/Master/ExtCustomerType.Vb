Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CustomerType
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtCustomerType
        Inherits CustomerType

        Private arrCustomerType As ArrayList

        Public Property CustpmerTypeList() As ArrayList
            Get
                Return arrCustomerType
            End Get
            Set(ByVal value As ArrayList)
                arrCustomerType = value
            End Set
        End Property
        
        ''' <summary>
        ''' Preparing Return ArrayList of CustpmerType By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerTypeListAll(ByVal pCustomerType As ExtCustomerType) As ExtCustomerType

            pCustomerType.CustpmerTypeList = CustomerType.ReturnCustomerTypeList(pCustomerType)
            Return pCustomerType
        End Function
    End Class
End Namespace
