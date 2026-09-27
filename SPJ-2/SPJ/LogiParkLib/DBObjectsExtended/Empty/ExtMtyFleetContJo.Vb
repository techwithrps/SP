Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects

	''' <summary>
	''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
	''' @Version	: Version 1.0.0.0
	''' @Module/Class Name	: ExportBooking
	''' @author	: Amit K. Singh- 10/3/2012
	''' </summary>
	''' <remarks> </remarks>
	'''
	Public Class ExtMtyFleetContJo
		Inherits MtyFleetContJo

		Private arrMtyContJoDtlsList As ArrayList

		Public Property ContJoDtlsList() As ArrayList
			Get
				Return arrMtyContJoDtlsList
			End Get
			Set(ByVal value As ArrayList)
				arrMtyContJoDtlsList = value
			End Set
		End Property

		Public Shared Function InsertUpdateMtyFleetContJo(ByVal pExtFJO As ExtMtyFleetContJo) As ExtMtyFleetContJo
			Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
			Try
				db.BeginTransaction()
				If pExtFJO.ContJoId > 0 Then
					ExtMtyFleetContJo.Update(pExtFJO)
				Else
					ExtMtyFleetContJo.Insert(pExtFJO)

				End If

				If pExtFJO.Errormsg = "" AndAlso pExtFJO.ContJoId > 0 Then
					For Each pFID As MtyFleetContJoDtls In pExtFJO.arrMtyContJoDtlsList
						pFID.ContJoId = pExtFJO.ContJoId
						If pFID.MtyContId > 0 Then
							MtyFleetContJoDtls.UpdateTrn(db, pFID)
						Else
							MtyFleetContJoDtls.InsertTrn(db, pFID)
						End If
						If pFID.Errormsg <> "" Then
							Throw New Exception(pFID.Errormsg)
						End If
					Next
				Else
					Throw New Exception(pExtFJO.Errormsg)
				End If
				db.CommitTransaction()
			Catch ex As Exception
				pExtFJO.Errormsg = ex.Message
				Try
					db.RollbackTransaction()
				Catch ex1 As Exception
				End Try
				' Rollback the transaction if any 
			End Try
			Return pExtFJO
		End Function
	End Class
End Namespace
