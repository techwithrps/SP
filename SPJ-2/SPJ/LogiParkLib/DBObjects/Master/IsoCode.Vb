Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: IsoCode
    ''' @author	: Amit K. Singh- 17/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class IsoCode 
    
        Private lngIsoCodeId As Long ' Define Private Variable IsoCodeId With DataType As Long 
        Private strIsoCode As String ' Define Private Variable IsoCode With DataType As String 
        Private strIsoCodeDetails As String ' Define Private Variable IsoCodeDetails With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private dblTareWt As Double ' Define Private Variable TareWt With DataType As Double 
        Private dblWidth As Double ' Define Private Variable Width With DataType As Double 
        Private dblLength As Double ' Define Private Variable Length With DataType As Double 
        Private dblHeight As Double ' Define Private Variable Height With DataType As Double 
        Private strHighCubeStatus As String ' Define Private Variable HighCubeStatus With DataType As String 
        Private strReeferStatus As String ' Define Private Variable ReeferStatus With DataType As String 
        Private strOpenTopStatus As String ' Define Private Variable OpenTopStatus With DataType As String 
        Private strHazStatus As String ' Define Private Variable HazStatus With DataType As String 
        Private dblHazClass As Double ' Define Private Variable HazClass With DataType As Double 
        Private strImdgCode As String ' Define Private Variable ImdgCode With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of IsoCodeId
        ''' </summary>
        ''' <value>lngIsoCodeId</value>
        ''' <returns> Return lngIsoCodeId</returns>
        ''' <remarks> Get or Set the Value of IsoCodeId  </remarks>
        '''
        Public Property IsoCodeId() as Long
            Get
                Return lngIsoCodeId
            End Get
            Set(ByVal value As Long)
                lngIsoCodeId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IsoCode
        ''' </summary>
        ''' <value>strIsoCode</value>
        ''' <returns> Return strIsoCode</returns>
        ''' <remarks> Get or Set the Value of IsoCode  </remarks>
        '''
        Public Property IsoCode() as String
            Get
                Return strIsoCode
            End Get
            Set(ByVal value As String)
                strIsoCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IsoCodeDetails
        ''' </summary>
        ''' <value>strIsoCodeDetails</value>
        ''' <returns> Return strIsoCodeDetails</returns>
        ''' <remarks> Get or Set the Value of IsoCodeDetails  </remarks>
        '''
        Public Property IsoCodeDetails() as String
            Get
                Return strIsoCodeDetails
            End Get
            Set(ByVal value As String)
                strIsoCodeDetails = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContSize
        ''' </summary>
        ''' <value>strContSize</value>
        ''' <returns> Return strContSize</returns>
        ''' <remarks> Get or Set the Value of ContSize  </remarks>
        '''
        Public Property ContSize() as String
            Get
                Return strContSize
            End Get
            Set(ByVal value As String)
                strContSize = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType  </remarks>
        '''
        Public Property ContType() as String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TareWt
        ''' </summary>
        ''' <value>dblTareWt</value>
        ''' <returns> Return dblTareWt</returns>
        ''' <remarks> Get or Set the Value of TareWt  </remarks>
        '''
        Public Property TareWt() as Double
            Get
                Return dblTareWt
            End Get
            Set(ByVal value As Double)
                dblTareWt = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Width
        ''' </summary>
        ''' <value>dblWidth</value>
        ''' <returns> Return dblWidth</returns>
        ''' <remarks> Get or Set the Value of Width  </remarks>
        '''
        Public Property Width() as Double
            Get
                Return dblWidth
            End Get
            Set(ByVal value As Double)
                dblWidth = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Length
        ''' </summary>
        ''' <value>dblLength</value>
        ''' <returns> Return dblLength</returns>
        ''' <remarks> Get or Set the Value of Length  </remarks>
        '''
        Public Property Length() as Double
            Get
                Return dblLength
            End Get
            Set(ByVal value As Double)
                dblLength = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Height
        ''' </summary>
        ''' <value>dblHeight</value>
        ''' <returns> Return dblHeight</returns>
        ''' <remarks> Get or Set the Value of Height  </remarks>
        '''
        Public Property Height() as Double
            Get
                Return dblHeight
            End Get
            Set(ByVal value As Double)
                dblHeight = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HighCubeStatus
        ''' </summary>
        ''' <value>strHighCubeStatus</value>
        ''' <returns> Return strHighCubeStatus</returns>
        ''' <remarks> Get or Set the Value of HighCubeStatus  </remarks>
        '''
        Public Property HighCubeStatus() as String
            Get
                Return strHighCubeStatus
            End Get
            Set(ByVal value As String)
                strHighCubeStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReeferStatus
        ''' </summary>
        ''' <value>strReeferStatus</value>
        ''' <returns> Return strReeferStatus</returns>
        ''' <remarks> Get or Set the Value of ReeferStatus  </remarks>
        '''
        Public Property ReeferStatus() as String
            Get
                Return strReeferStatus
            End Get
            Set(ByVal value As String)
                strReeferStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OpenTopStatus
        ''' </summary>
        ''' <value>strOpenTopStatus</value>
        ''' <returns> Return strOpenTopStatus</returns>
        ''' <remarks> Get or Set the Value of OpenTopStatus  </remarks>
        '''
        Public Property OpenTopStatus() as String
            Get
                Return strOpenTopStatus
            End Get
            Set(ByVal value As String)
                strOpenTopStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HazStatus
        ''' </summary>
        ''' <value>strHazStatus</value>
        ''' <returns> Return strHazStatus</returns>
        ''' <remarks> Get or Set the Value of HazStatus  </remarks>
        '''
        Public Property HazStatus() as String
            Get
                Return strHazStatus
            End Get
            Set(ByVal value As String)
                strHazStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HazClass
        ''' </summary>
        ''' <value>dblHazClass</value>
        ''' <returns> Return dblHazClass</returns>
        ''' <remarks> Get or Set the Value of HazClass  </remarks>
        '''
        Public Property HazClass() as Double
            Get
                Return dblHazClass
            End Get
            Set(ByVal value As Double)
                dblHazClass = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ImdgCode
        ''' </summary>
        ''' <value>strImdgCode</value>
        ''' <returns> Return strImdgCode</returns>
        ''' <remarks> Get or Set the Value of ImdgCode  </remarks>
        '''
        Public Property ImdgCode() as String
            Get
                Return strImdgCode
            End Get
            Set(ByVal value As String)
                strImdgCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() as String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property CreatedOn() as String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
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
            lngIsoCodeId = 0 
            strIsoCode = ""
            strIsoCodeDetails = ""
            strContSize = ""
            strContType = ""
            dblTareWt = 0.0 
            dblWidth = 0.0 
            dblLength = 0.0 
            dblHeight = 0.0 
            strHighCubeStatus = ""
            strReeferStatus = ""
            strOpenTopStatus = ""
            strHazStatus = ""
            dblHazClass = 0.0 
            strImdgCode = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pIsoCode"></param>
        ''' <returns>Return pIsoCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pIsoCode As IsoCode) As IsoCode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ISO_CODE_ID", pIsoCode.IsoCodeId, ParameterDirection.Output)
                db.AddParameter("p_ISO_CODE", pIsoCode.IsoCode)
                db.AddParameter("p_ISO_CODE_DETAILS", pIsoCode.IsoCodeDetails)
                db.AddParameter("p_CONT_SIZE", pIsoCode.ContSize)
                db.AddParameter("p_CONT_TYPE", pIsoCode.ContType)
                db.AddParameter("p_TARE_WT", pIsoCode.TareWt)
                db.AddParameter("p_WIDTH", pIsoCode.Width)
                db.AddParameter("p_LENGTH", pIsoCode.Length)
                db.AddParameter("p_HEIGHT", pIsoCode.Height)
                db.AddParameter("p_HIGH_CUBE_STATUS", pIsoCode.HighCubeStatus)
                db.AddParameter("p_REEFER_STATUS", pIsoCode.ReeferStatus)
                db.AddParameter("p_OPEN_TOP_STATUS", pIsoCode.OpenTopStatus)
                db.AddParameter("p_HAZ_STATUS", pIsoCode.HazStatus)
                db.AddParameter("p_HAZ_CLASS", pIsoCode.HazClass)
                db.AddParameter("p_IMDG_CODE", pIsoCode.ImdgCode)
                db.AddParameter("p_CREATED_BY", pIsoCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pIsoCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pIsoCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ISO_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pIsoCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pIsoCode.IsoCodeId  = db.Parameters.Item("p_ISO_CODE_ID").value
                
                If pIsoCode.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pIsoCode.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pIsoCode
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pIsoCode"></param>
        ''' <returns>Return pIsoCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pIsoCode As IsoCode) As IsoCode
            Try
                db.ClearParameters()
                db.AddParameter("p_ISO_CODE_ID", pIsoCode.IsoCodeId, ParameterDirection.Output)
                db.AddParameter("p_ISO_CODE", pIsoCode.IsoCode)
                db.AddParameter("p_ISO_CODE_DETAILS", pIsoCode.IsoCodeDetails)
                db.AddParameter("p_CONT_SIZE", pIsoCode.ContSize)
                db.AddParameter("p_CONT_TYPE", pIsoCode.ContType)
                db.AddParameter("p_TARE_WT", pIsoCode.TareWt)
                db.AddParameter("p_WIDTH", pIsoCode.Width)
                db.AddParameter("p_LENGTH", pIsoCode.Length)
                db.AddParameter("p_HEIGHT", pIsoCode.Height)
                db.AddParameter("p_HIGH_CUBE_STATUS", pIsoCode.HighCubeStatus)
                db.AddParameter("p_REEFER_STATUS", pIsoCode.ReeferStatus)
                db.AddParameter("p_OPEN_TOP_STATUS", pIsoCode.OpenTopStatus)
                db.AddParameter("p_HAZ_STATUS", pIsoCode.HazStatus)
                db.AddParameter("p_HAZ_CLASS", pIsoCode.HazClass)
                db.AddParameter("p_IMDG_CODE", pIsoCode.ImdgCode)
                db.AddParameter("p_CREATED_BY", pIsoCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pIsoCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pIsoCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ISO_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pIsoCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pIsoCode.IsoCodeId  = db.Parameters.Item("p_ISO_CODE_ID").value
                
            Catch ex As Exception
                pIsoCode.ErrorMsg = ex.Message
            End Try
            Return pIsoCode
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pIsoCode"></param>
        ''' <returns>Return pIsoCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pIsoCode As IsoCode) As IsoCode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ISO_CODE_ID", pIsoCode.IsoCodeId)
                db.AddParameter("p_ISO_CODE", pIsoCode.IsoCode)
                db.AddParameter("p_ISO_CODE_DETAILS", pIsoCode.IsoCodeDetails)
                db.AddParameter("p_CONT_SIZE", pIsoCode.ContSize)
                db.AddParameter("p_CONT_TYPE", pIsoCode.ContType)
                db.AddParameter("p_TARE_WT", pIsoCode.TareWt)
                db.AddParameter("p_WIDTH", pIsoCode.Width)
                db.AddParameter("p_LENGTH", pIsoCode.Length)
                db.AddParameter("p_HEIGHT", pIsoCode.Height)
                db.AddParameter("p_HIGH_CUBE_STATUS", pIsoCode.HighCubeStatus)
                db.AddParameter("p_REEFER_STATUS", pIsoCode.ReeferStatus)
                db.AddParameter("p_OPEN_TOP_STATUS", pIsoCode.OpenTopStatus)
                db.AddParameter("p_HAZ_STATUS", pIsoCode.HazStatus)
                db.AddParameter("p_HAZ_CLASS", pIsoCode.HazClass)
                db.AddParameter("p_IMDG_CODE", pIsoCode.ImdgCode)
                db.AddParameter("p_CREATED_BY", pIsoCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pIsoCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pIsoCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ISO_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pIsoCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pIsoCode.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pIsoCode.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pIsoCode
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pIsoCode"></param>
        ''' <returns>Return pIsoCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pIsoCode As IsoCode) As IsoCode
            Try
                db.ClearParameters()
                db.AddParameter("p_ISO_CODE_ID", pIsoCode.IsoCodeId)
                db.AddParameter("p_ISO_CODE", pIsoCode.IsoCode)
                db.AddParameter("p_ISO_CODE_DETAILS", pIsoCode.IsoCodeDetails)
                db.AddParameter("p_CONT_SIZE", pIsoCode.ContSize)
                db.AddParameter("p_CONT_TYPE", pIsoCode.ContType)
                db.AddParameter("p_TARE_WT", pIsoCode.TareWt)
                db.AddParameter("p_WIDTH", pIsoCode.Width)
                db.AddParameter("p_LENGTH", pIsoCode.Length)
                db.AddParameter("p_HEIGHT", pIsoCode.Height)
                db.AddParameter("p_HIGH_CUBE_STATUS", pIsoCode.HighCubeStatus)
                db.AddParameter("p_REEFER_STATUS", pIsoCode.ReeferStatus)
                db.AddParameter("p_OPEN_TOP_STATUS", pIsoCode.OpenTopStatus)
                db.AddParameter("p_HAZ_STATUS", pIsoCode.HazStatus)
                db.AddParameter("p_HAZ_CLASS", pIsoCode.HazClass)
                db.AddParameter("p_IMDG_CODE", pIsoCode.ImdgCode)
                db.AddParameter("p_CREATED_BY", pIsoCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pIsoCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pIsoCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ISO_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pIsoCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pIsoCode.ErrorMsg = ex.Message
                End Try
            Return pIsoCode
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pIsoCode As IsoCode) As IsoCode
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("ISO_CODE_ID").ToString <> "" Then
                                PIsoCode.IsoCodeId = dbr("ISO_CODE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE").ToString <> "" Then
                                PIsoCode.IsoCode = dbr("ISO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE_DETAILS").ToString <> "" Then
                                PIsoCode.IsoCodeDetails = dbr("ISO_CODE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PIsoCode.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PIsoCode.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                PIsoCode.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WIDTH").ToString <> "" Then
                                PIsoCode.Width = dbr("WIDTH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LENGTH").ToString <> "" Then
                                PIsoCode.Length = dbr("LENGTH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HEIGHT").ToString <> "" Then
                                PIsoCode.Height = dbr("HEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HIGH_CUBE_STATUS").ToString <> "" Then
                                PIsoCode.HighCubeStatus = dbr("HIGH_CUBE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REEFER_STATUS").ToString <> "" Then
                                PIsoCode.ReeferStatus = dbr("REEFER_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPEN_TOP_STATUS").ToString <> "" Then
                                PIsoCode.OpenTopStatus = dbr("OPEN_TOP_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HAZ_STATUS").ToString <> "" Then
                                PIsoCode.HazStatus = dbr("HAZ_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HAZ_CLASS").ToString <> "" Then
                                PIsoCode.HazClass = dbr("HAZ_CLASS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMDG_CODE").ToString <> "" Then
                                PIsoCode.ImdgCode = dbr("IMDG_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PIsoCode.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PIsoCode.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pIsoCode.ErrorMsg = ex.Message
            End Try
            Return pIsoCode
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrIsoCode As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New IsoCode
                        Try
                            If dbr("ISO_CODE_ID").ToString <> "" Then
                                temp.IsoCodeId = dbr("ISO_CODE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE").ToString <> "" Then
                                temp.IsoCode = dbr("ISO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE_DETAILS").ToString <> "" Then
                                temp.IsoCodeDetails = dbr("ISO_CODE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                temp.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                temp.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                temp.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WIDTH").ToString <> "" Then
                                temp.Width = dbr("WIDTH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LENGTH").ToString <> "" Then
                                temp.Length = dbr("LENGTH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HEIGHT").ToString <> "" Then
                                temp.Height = dbr("HEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HIGH_CUBE_STATUS").ToString <> "" Then
                                temp.HighCubeStatus = dbr("HIGH_CUBE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REEFER_STATUS").ToString <> "" Then
                                temp.ReeferStatus = dbr("REEFER_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPEN_TOP_STATUS").ToString <> "" Then
                                temp.OpenTopStatus = dbr("OPEN_TOP_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HAZ_STATUS").ToString <> "" Then
                                temp.HazStatus = dbr("HAZ_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HAZ_CLASS").ToString <> "" Then
                                temp.HazClass = dbr("HAZ_CLASS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMDG_CODE").ToString <> "" Then
                                temp.ImdgCode = dbr("IMDG_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                end If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnIsoCode(ByVal pIsoCode As IsoCode) As IsoCode
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ISO_CODE_BY_ID", pIsoCode.IsoCodeId)
                pIsoCode = ReturnObjectValues(dbr, pIsoCode)
                dbr.Close()
            Catch ex As Exception
                pIsoCode.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pIsoCode
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList of distinct ContType
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnIsoCodeListOfContType(ByVal pIsoCode As IsoCode) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrIsoCode As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_TYPE_BY_ISO_CODE", " ")
                arrIsoCode = ReturnObjectValuesList(dbr, arrIsoCode)
                dbr.Close()
            Catch ex As Exception
                arrIsoCode = Nothing
            End Try
            db.CloseDB()
            Return arrIsoCode
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList of distinct ContType
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnIsoCodeSearchByIsoCode(ByVal pIsoCode As IsoCode) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrIsoCode As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ISO_CODE_SEARCH", "'" & pIsoCode.IsoCode & "'")
                arrIsoCode = ReturnObjectValuesList(dbr, arrIsoCode)
                dbr.Close()
            Catch ex As Exception
                arrIsoCode = Nothing
            End Try
            db.CloseDB()
            Return arrIsoCode
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnIsoCodeList(ByVal pIsoCode As IsoCode) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrIsoCode As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ISO_CODE_ALL", " ")
                arrIsoCode = ReturnObjectValuesList(dbr, arrIsoCode)
                dbr.Close()
            Catch ex As Exception
                arrIsoCode = Nothing
            End Try
            db.CloseDB()
            Return arrIsoCode
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnIsoCodeType(ByVal pIsoCode As IsoCode) As IsoCode
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ISO_CODE_SEARCH", "'" & pIsoCode.IsoCode & "'")
                pIsoCode = ReturnObjectValues(dbr, pIsoCode)
                dbr.Close()
            Catch ex As Exception
                pIsoCode.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pIsoCode
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnIsoCodeByTypeSize(ByVal pIsoCode As IsoCode) As IsoCode
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ISO_CODE_BY_SIZE_TYPE", "'" & pIsoCode.ContSize & "'" & pIsoCode.ContType & "'")
                pIsoCode = ReturnObjectValues(dbr, pIsoCode)
                dbr.Close()
            Catch ex As Exception
                pIsoCode.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pIsoCode
        End Function
    End Class
End Namespace
