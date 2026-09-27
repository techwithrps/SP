Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: EquipmentType
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtEquipmentType
        Inherits EquipmentType

        Private arrEquipmentType As ArrayList

        Public Property EquipmentTypeList() As ArrayList
            Get
                Return arrEquipmentType
            End Get
            Set(ByVal value As ArrayList)
                arrEquipmentType = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing Return ArrayList of EquipmentType By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnEquipmentTypeListAll(ByVal pEquipmentType As ExtEquipmentType) As ExtEquipmentType

            pEquipmentType.EquipmentTypeList = EquipmentType.ReturnEquipmentTypeList(pEquipmentType)
            Return pEquipmentType
        End Function
    End Class
End Namespace
