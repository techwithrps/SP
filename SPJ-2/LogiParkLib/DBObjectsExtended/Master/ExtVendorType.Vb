Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorType
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtVendorType
        Inherits VendorType

        Private arrVendorType As ArrayList

        Public Property VendeorTypeList() As ArrayList
            Get
                Return arrVendorType
            End Get
            Set(ByVal value As ArrayList)
                arrVendorType = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing Return ArrayList of VendorType By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorTypeListAll(ByVal pVendorType As ExtVendorType) As ExtVendorType

            pVendorType.VendeorTypeList = VendorType.ReturnVendorTypeList(pVendorType)
            Return pVendorType
        End Function
    End Class
End Namespace