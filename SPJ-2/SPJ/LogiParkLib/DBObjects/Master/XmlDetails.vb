Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: JobMenuItems
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class XmlDetails

        Private lngJobId As Long ' Define Private Variable JobId With DataType As Long 
        Private lngMenuId As Double ' Define Private Variable MenuId With DataType As Long 
        Private strAddPermit As String ' Define Private Variable AddPermit With DataType As String 
        Private strEditPermit As String ' Define Private Variable EditPermit With DataType As String 
        Private strDeletePermit As String ' Define Private Variable DeletePermit With DataType As String 
        Private strSearchPermit As String ' Define Private Variable SearchPermit With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

        Private strJobName As String ' Define Private Variable JobName With DataType As String 
        Private strDescription As String ' Define Private Variable Description With DataType As String 

        ''' <summary>
        ''' Get or Set the Value of JobId
        ''' </summary>
        ''' <value>lngJobId</value>
        ''' <returns> Return lngJobId</returns>
        ''' <remarks> Get or Set the Value of JobId  </remarks>
        '''
        Public Property JobId() As Long
            Get
                Return lngJobId
            End Get
            Set(ByVal value As Long)
                lngJobId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MenuId
        ''' </summary>
        ''' <value>lngMenuId</value>
        ''' <returns> Return lngMenuId</returns>
        ''' <remarks> Get or Set the Value of MenuId  </remarks>
        '''
        Public Property MenuId() As Double
            Get
                Return lngMenuId
            End Get
            Set(ByVal value As Double)
                lngMenuId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of AddPermit
        ''' </summary>
        ''' <value>strAddPermit</value>
        ''' <returns> Return strAddPermit</returns>
        ''' <remarks> Get or Set the Value of AddPermit  </remarks>
        '''
        Public Property AddPermit() As String
            Get
                Return strAddPermit
            End Get
            Set(ByVal value As String)
                strAddPermit = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EditPermit
        ''' </summary>
        ''' <value>strEditPermit</value>
        ''' <returns> Return strEditPermit</returns>
        ''' <remarks> Get or Set the Value of EditPermit  </remarks>
        '''
        Public Property EditPermit() As String
            Get
                Return strEditPermit
            End Get
            Set(ByVal value As String)
                strEditPermit = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DeletePermit
        ''' </summary>
        ''' <value>strDeletePermit</value>
        ''' <returns> Return strDeletePermit</returns>
        ''' <remarks> Get or Set the Value of DeletePermit  </remarks>
        '''
        Public Property DeletePermit() As String
            Get
                Return strDeletePermit
            End Get
            Set(ByVal value As String)
                strDeletePermit = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SearchPermit
        ''' </summary>
        ''' <value>strSearchPermit</value>
        ''' <returns> Return strSearchPermit</returns>
        ''' <remarks> Get or Set the Value of SearchPermit  </remarks>
        '''
        Public Property SearchPermit() As String
            Get
                Return strSearchPermit
            End Get
            Set(ByVal value As String)
                strSearchPermit = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of JobName
        ''' </summary>
        ''' <value>strJobName</value>
        ''' <returns> Return strJobName</returns>
        ''' <remarks> Get or Set the Value of JobName  </remarks>
        '''
        Public Property JobName() As String
            Get
                Return strJobName
            End Get
            Set(ByVal value As String)
                strJobName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Description
        ''' </summary>
        ''' <value>strDescription</value>
        ''' <returns> Return strDescription</returns>
        ''' <remarks> Get or Set the Value of Description  </remarks>
        '''
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngJobId = 0
            lngMenuId = 0
            strAddPermit = ""
            strEditPermit = ""
            strDeletePermit = ""
            strSearchPermit = ""
            strErrormsg = ""
            strJobName = ""
            strDescription = ""
        End Sub


        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pXmlDetails As XmlDetails) As XmlDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                pXmlDetails.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                pXmlDetails.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADD_PERMIT").ToString <> "" Then
                                pXmlDetails.AddPermit = dbr("ADD_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EDIT_PERMIT").ToString <> "" Then
                                pXmlDetails.EditPermit = dbr("EDIT_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DELETE_PERMIT").ToString <> "" Then
                                pXmlDetails.DeletePermit = dbr("DELETE_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SEARCH_PERMIT").ToString <> "" Then
                                pXmlDetails.SearchPermit = dbr("SEARCH_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TITLE").ToString <> "" Then
                                pXmlDetails.JobName = dbr("TITLE")
                            End If
                        Catch ex1 As Exception

                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                pXmlDetails.Description = dbr("DESCRIPTION")
                            End If
                        Catch ex1 As Exception

                        End Try
                    End While
                End If
            Catch ex As Exception
                pXmlDetails.Errormsg = ex.Message
            End Try
            Return pXmlDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrXmlDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New XmlDetails
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                temp.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                temp.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADD_PERMIT").ToString <> "" Then
                                temp.AddPermit = dbr("ADD_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EDIT_PERMIT").ToString <> "" Then
                                temp.EditPermit = dbr("EDIT_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DELETE_PERMIT").ToString <> "" Then
                                temp.DeletePermit = dbr("DELETE_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SEARCH_PERMIT").ToString <> "" Then
                                temp.SearchPermit = dbr("SEARCH_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TITLE").ToString <> "" Then
                                temp.JobName = dbr("TITLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                temp.Description = dbr("DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnXmlDetailsList(ByVal pXmlDetails As XmlDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrXmlDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_XML_DETAILS", " ")
                arrXmlDetails = ReturnObjectValuesList(dbr, arrXmlDetails)
                dbr.Close()
            Catch ex As Exception
                arrXmlDetails = Nothing
            End Try
            db.CloseDB()
            Return arrXmlDetails
        End Function

    End Class
End Namespace
