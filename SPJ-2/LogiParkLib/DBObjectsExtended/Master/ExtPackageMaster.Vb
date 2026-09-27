Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PackageMaster
    ''' @author	: Amit K. Singh- 16/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtPackageMaster
        Inherits PackageMaster

        Dim arrPackageTypeList As New ArrayList
        Public Property PackageTypeList() As ArrayList
            Get
                Return arrPackageTypeList
            End Get
            Set(ByVal value As ArrayList)
                arrPackageTypeList = value
            End Set
        End Property
    End Class
End Namespace
