Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TransactionStatus
    ''' @author	: Amit K. Singh- 7/1/2022
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TransactionStatus 
    
        Private lngRunningStatus As Long ' Define Private Variable RunningStatus With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of RunningStatus
        ''' </summary>
        ''' <value>lngRunningStatus</value>
        ''' <returns> Return lngRunningStatus</returns>
        ''' <remarks> Get or Set the Value of RunningStatus  </remarks>
        '''
        Public Property RunningStatus() as Long
            Get
                Return lngRunningStatus
            End Get
            Set(ByVal value As Long)
                lngRunningStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() as String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngRunningStatus = 0 
            strErrormsg = ""
        End Sub


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTransactionStatus"></param>
        ''' <returns>Return pTransactionStatus Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTransactionStatus As TransactionStatus) As TransactionStatus
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RUNNING_STATUS", pTransactionStatus.RunningStatus)
                db.AddParameter("p_ErrorMsg", pTransactionStatus.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("LOCK_PKG.SP_TRANSACTION_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTransactionStatus.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTransactionStatus.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTransactionStatus.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTransactionStatus
        End Function


        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTransactionStatus As TransactionStatus) As TransactionStatus
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("RUNNING_STATUS").ToString <> "" Then
                                PTransactionStatus.RunningStatus = dbr("RUNNING_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTransactionStatus.ErrorMsg = ex.Message
            End Try
            Return pTransactionStatus
        End Function



        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTransactionStatus(ByVal pTransactionStatus As TransactionStatus) As TransactionStatus
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("LOCK_PKG.SP_TRANSACTION_STATUS_BY_ALL", "' '")
                pTransactionStatus = ReturnObjectValues(dbr, pTransactionStatus)
                dbr.Close()
            Catch ex As Exception
                pTransactionStatus.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTransactionStatus
        End Function
    End Class
End Namespace
