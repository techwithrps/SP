Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  eLOGiSol :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ServiceMaster
    ''' @author	: Amit K. Singh- 16/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtServiceMaster
        Inherits ServiceMaster

        Dim arrServiceList As New ArrayList
        Public Property ServiceList() As ArrayList
            Get
                Return arrServiceList
            End Get
            Set(ByVal value As ArrayList)
                arrServiceList = value
            End Set
        End Property
    End Class
End Namespace
