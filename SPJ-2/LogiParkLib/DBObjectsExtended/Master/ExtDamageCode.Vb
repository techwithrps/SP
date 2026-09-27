Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: DamageCode
    ''' @author	: Amit K. Singh- 16/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtDamageCode
        Inherits DamageCode

        Dim arrDamageTypeList As New ArrayList
        Public Property DamageTypeList() As ArrayList
            Get
                Return arrDamageTypeList
            End Get
            Set(ByVal value As ArrayList)
                arrDamageTypeList = value
            End Set
        End Property
    End Class
End Namespace
