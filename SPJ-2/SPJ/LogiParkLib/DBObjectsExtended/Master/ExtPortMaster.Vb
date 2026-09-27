Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PortMaster
    ''' @author	: Amit K. Singh- 16/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtPortMaster
        Inherits PortMaster

        Dim arrPortList As New ArrayList
        Public Property PortList() As ArrayList
            Get
                Return arrPortList
            End Get
            Set(ByVal value As ArrayList)
                arrPortList = value
            End Set
        End Property
    End Class
End Namespace
