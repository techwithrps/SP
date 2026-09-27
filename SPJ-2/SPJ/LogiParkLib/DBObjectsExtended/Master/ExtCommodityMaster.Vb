Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CommodityMaster
    ''' @author	: Amit K. Singh- 16/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtCommodityMaster
        Inherits CommodityMaster

        Dim arrCommodityList As New ArrayList
        Public Property CommodityList() As ArrayList
            Get
                Return arrCommodityList
            End Get
            Set(ByVal value As ArrayList)
                arrCommodityList = value
            End Set
        End Property
    End Class
End Namespace
