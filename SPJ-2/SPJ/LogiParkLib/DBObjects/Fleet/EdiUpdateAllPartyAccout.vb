Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    Public Class EdiJO
        Private _ctsId As Integer
        Public Property CfsId() As Integer
            Get
                Return _ctsId
            End Get
            Set(ByVal value As Integer)
                _ctsId = value
            End Set
        End Property

        Private _joNo As String
        Public Property JoNo() As String
            Get
                Return _joNo
            End Get
            Set(ByVal value As String)
                _joNo = value
            End Set
        End Property
    End Class
    Public Class EdiUpdateAllPartyAccout

        Public AllPartyList As New List(Of EdiUpdateAllPartyAccout)()

        Public Shared Function UpdateJOForTransaction(ByVal obj As EdiUpdateAllPartyAccout) As EdiUpdateAllPartyAccout
            Dim db As New DBConnect
            Try
                db.BeginTransaction()

                Try

                    Dim err As String = ""
                    Dim generatedJonNo As String = ""


                    For Each p In obj.AllPartyList
                        If String.IsNullOrEmpty(p.JobNumber) AndAlso String.IsNullOrEmpty(generatedJonNo) Then
                            generatedJonNo = EdiUpdateAllPartyAccout.GenearetJOB(err, p.CfsId, db)
                            If Not String.IsNullOrEmpty(err) Then
                                Throw New Exception(err)
                            End If
                        End If

                        If String.IsNullOrEmpty(p.JobNumber) Then
                            p.JobNumber = generatedJonNo
                            EdiUpdateAllPartyAccout.InsertEdiDeatils(p, db)
                        Else
                            EdiUpdateAllPartyAccout.UpdateEdiDeatils(p, db)
                        End If
                        If p.ErrorMsg <> "" Then
                            Throw New Exception(p.ErrorMsg)
                        End If
                    Next

                Catch ex As Exception
                    Throw New Exception(obj.ErrorMsg)
                End Try


                db.CommitTransaction()
            Catch ex As Exception
                obj.ErrorMsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return obj
        End Function


        Private strConsignerName As String = ""
        Public Property ConsignerName() As String
            Get
                Return strConsignerName
            End Get
            Set(ByVal value As String)
                strConsignerName = value
            End Set
        End Property

        Private intConsigerId As Integer
        Public Property ConsigerId() As Integer
            Get
                Return intConsigerId
            End Get
            Set(ByVal value As Integer)
                intConsigerId = value
            End Set
        End Property

        Private strConsignmentType As String = ""
        Public Property ConsignmentType() As String
            Get
                Return strConsignmentType
            End Get
            Set(ByVal value As String)
                strConsignmentType = value
            End Set
        End Property

        Private intConsignmentTypeId As Integer
        Public Property ConsignmentTypeId() As Integer
            Get
                Return intConsignmentTypeId
            End Get
            Set(ByVal value As Integer)
                intConsignmentTypeId = value
            End Set
        End Property

        Private strCommodityName As String = ""
        Public Property CommodityName() As String
            Get
                Return strCommodityName
            End Get
            Set(ByVal value As String)
                strCommodityName = value
            End Set
        End Property
        Private intCommodityId As Integer
        Public Property CommodityId() As Integer
            Get
                Return intCommodityId
            End Get
            Set(ByVal value As Integer)
                intCommodityId = value
            End Set
        End Property
        Private strNotifyParty As String = ""
        Public Property NotifyParty() As String
            Get
                Return strNotifyParty
            End Get
            Set(ByVal value As String)
                strNotifyParty = value
            End Set
        End Property
        Private strShipperName As String = ""
        Public Property ShipperName() As String
            Get
                Return strShipperName
            End Get
            Set(ByVal value As String)
                strShipperName = value
            End Set
        End Property
        Private strConsigneeName As String = ""
        Public Property ConsigneeName() As String
            Get
                Return strConsigneeName
            End Get
            Set(ByVal value As String)
                strConsigneeName = value
            End Set
        End Property
        Private strPort As String = ""
        Public Property Port() As String
            Get
                Return strPort
            End Get
            Set(ByVal value As String)
                strPort = value
            End Set
        End Property
        Private intPodId As Integer
        Public Property PodId() As Integer
            Get
                Return intPodId
            End Get
            Set(ByVal value As Integer)
                intPodId = value
            End Set
        End Property
        Private strPartyInvoiceNo As String = ""
        Public Property PartyInvoiceNo() As String
            Get
                Return strPartyInvoiceNo
            End Get
            Set(ByVal value As String)
                strPartyInvoiceNo = value
            End Set
        End Property
        Private IngFobValue As Integer
        Public Property FobValue() As Integer
            Get
                Return IngFobValue
            End Get
            Set(ByVal value As Integer)
                IngFobValue = value
            End Set
        End Property
        Private strHeathNo As String = ""
        Public Property HeathNo() As String
            Get
                Return strHeathNo
            End Get
            Set(ByVal value As String)
                strHeathNo = value
            End Set
        End Property
        Private IngCARTONS As Integer
        Public Property CARTONS() As Integer
            Get
                Return IngCARTONS
            End Get
            Set(ByVal value As Integer)
                IngCARTONS = value
            End Set
        End Property
        Private strPackageType As String = ""
        Public Property PackageType() As String
            Get
                Return strPackageType
            End Get
            Set(ByVal value As String)
                strPackageType = value
            End Set
        End Property
        Private IngNetWt As Double
        Public Property NetWt() As Double
            Get
                Return IngNetWt
            End Get
            Set(ByVal value As Double)
                IngNetWt = value
            End Set
        End Property
        Private IngGrossWeight As Double
        Public Property GrossWeight() As Double
            Get
                Return IngGrossWeight
            End Get
            Set(ByVal value As Double)
                IngGrossWeight = value
            End Set
        End Property
        Private IngPackageTypeId As Integer
        Public Property PackageTypeId() As Integer
            Get
                Return IngPackageTypeId
            End Get
            Set(ByVal value As Integer)
                IngPackageTypeId = value
            End Set
        End Property
        Private IngCfsId As Integer
        Public Property CfsId() As Integer
            Get
                Return IngCfsId
            End Get
            Set(ByVal value As Integer)
                IngCfsId = value
            End Set
        End Property
        Private strCfs As String = ""
        Public Property Cfs() As String
            Get
                Return strCfs
            End Get
            Set(ByVal value As String)
                strCfs = value
            End Set
        End Property
        Private strJobNumber As String = ""
        Public Property JobNumber() As String
            Get
                Return strJobNumber
            End Get
            Set(ByVal value As String)
                strJobNumber = value
            End Set
        End Property
        Private strJobDate As String = ""
        Public Property JobDate() As String
            Get
                Return strJobDate
            End Get
            Set(ByVal value As String)
                strJobDate = value
            End Set
        End Property
        Private strPartyInvoicedate As String = ""
        Public Property PartyInvoicedate() As String
            Get
                Return strPartyInvoicedate
            End Get
            Set(ByVal value As String)
                strPartyInvoicedate = value
            End Set
        End Property
        Private strCHA As String = ""
        Public Property CHA() As String
            Get
                Return strCHA
            End Get
            Set(ByVal value As String)
                strCHA = value
            End Set
        End Property
        Private IngChaId As Integer
        Public Property ChaId() As Integer
            Get
                Return IngChaId
            End Get
            Set(ByVal value As Integer)
                IngChaId = value
            End Set
        End Property
        Private strSbNo As String = ""
        Public Property SbNo() As String
            Get
                Return strSbNo
            End Get
            Set(ByVal value As String)
                strSbNo = value
            End Set
        End Property
        Private strSbDate As String = ""
        Public Property SbDate() As String
            Get
                Return strSbDate
            End Get
            Set(ByVal value As String)
                strSbDate = value
            End Set
        End Property
        Private strCreatedBy As String = ""
        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property
        Private strCreatedOn As String = ""
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property
        Private IngMtyContId As Integer
        Public Property MtyContId() As Integer
            Get
                Return IngMtyContId
            End Get
            Set(ByVal value As Integer)
                IngMtyContId = value
            End Set
        End Property
        Private IngContJoId As Integer
        Public Property ContJoId() As Integer
            Get
                Return IngContJoId
            End Get
            Set(ByVal value As Integer)
                IngContJoId = value
            End Set
        End Property
        Private strRefId As String = ""
        Public Property RefId() As String
            Get
                Return strRefId
            End Get
            Set(ByVal value As String)
                strRefId = value
            End Set
        End Property

        Private strErrorMsg As String = ""
        Public Property ErrorMsg() As String
            Get
                Return strErrorMsg
            End Get
            Set(ByVal value As String)
                strErrorMsg = value
            End Set
        End Property

        Public ContLIst As New List(Of EdiUpdateAllPartyAccout)

        'Public Shared Function UpdateEDI(ByVal pEdiUpdateAllPartyAccout As EdiUpdateAllPartyAccout) As EdiUpdateAllPartyAccout
        '    Dim db As New DBConnect
        '    db.BeginTransaction()
        '    EdiUpdateAllPartyAccout.GenearetJOB(pEdiUpdateAllPartyAccout, db)
        '    For Each p In pEdiUpdateAllPartyAccout.ContLIst
        '        p.JobNumber = pEdiUpdateAllPartyAccout.JobNumber
        '        p.JobDate = pEdiUpdateAllPartyAccout.JobDate
        '        EdiUpdateAllPartyAccout.UpdateEdiDeatilsTrn(p, db)
        '    Next
        '    db.CommitTransaction()
        'End Function

        Public Shared Function GenearetJOB(ByRef cErrorMsg As String, ByVal cfsId As Long, db As DBConnect) As String
            Dim geratedJONo As String = ""
            Try
                db.ClearParameters()
                db.AddParameter("p_CFS_ID", cfsId)
                db.AddParameter("p_JOB_NO", geratedJONo, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", cErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_GENERATE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    cErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                geratedJONo = db.Parameters.Item("p_JOB_NO").value.ToString
            Catch ex As Exception
                cErrorMsg = ex.Message
            End Try
            Return geratedJONo
        End Function


        Public Shared Function InsertEdiDeatils(ByVal pEdiUpdateAllPartyAccout As EdiUpdateAllPartyAccout, ByVal db As DBConnect) As EdiUpdateAllPartyAccout
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_NO", pEdiUpdateAllPartyAccout.JobNumber)
                db.AddParameter("p_JOB_DATE", pEdiUpdateAllPartyAccout.JobDate)
                db.AddParameter("p_CONSIGNOR_NAME", pEdiUpdateAllPartyAccout.ConsignerName)
                db.AddParameter("p_CONSIGNOR_ID", pEdiUpdateAllPartyAccout.ConsigerId)
                db.AddParameter("p_CONSIGNMENT_TYPE", pEdiUpdateAllPartyAccout.ConsignmentType)
                db.AddParameter("p_CONSIGNMENT_TYPE_ID", pEdiUpdateAllPartyAccout.ConsignmentTypeId)
                db.AddParameter("p_COMMODITY_NAME", pEdiUpdateAllPartyAccout.CommodityName)
                db.AddParameter("p_COMMODITY_ID", pEdiUpdateAllPartyAccout.CommodityId)
                db.AddParameter("p_NOTIFY_PARTY", pEdiUpdateAllPartyAccout.NotifyParty)
                db.AddParameter("p_SHIPPER_NAME", pEdiUpdateAllPartyAccout.ConsigneeName)
                db.AddParameter("p_CONSINGEE_NAME", pEdiUpdateAllPartyAccout.ConsigneeName)
                db.AddParameter("p_PORT", pEdiUpdateAllPartyAccout.Port)
                db.AddParameter("p_POD_ID", pEdiUpdateAllPartyAccout.PodId)
                db.AddParameter("p_PARTY_INV_NO", pEdiUpdateAllPartyAccout.PartyInvoiceNo)
                db.AddParameter("p_FOB_VALUE_INR", pEdiUpdateAllPartyAccout.FobValue)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pEdiUpdateAllPartyAccout.HeathNo)
                db.AddParameter("p_CARTONS", pEdiUpdateAllPartyAccout.CARTONS)
                db.AddParameter("p_NET_WT", pEdiUpdateAllPartyAccout.NetWt)
                db.AddParameter("p_GROSS_WT", pEdiUpdateAllPartyAccout.GrossWeight)
                db.AddParameter("p_PACKAGE_TYPE", pEdiUpdateAllPartyAccout.PackageType)
                db.AddParameter("p_PACKAGE_TYPE_ID", pEdiUpdateAllPartyAccout.PackageTypeId)
                db.AddParameter("p_CFS_ID", pEdiUpdateAllPartyAccout.CfsId)
                db.AddParameter("p_CFS", pEdiUpdateAllPartyAccout.Cfs)
                db.AddParameter("p_PARTY_INV_DATE", pEdiUpdateAllPartyAccout.PartyInvoicedate)
                db.AddParameter("p_CHA", pEdiUpdateAllPartyAccout.CHA)
                db.AddParameter("p_CHA_ID", pEdiUpdateAllPartyAccout.ChaId)
                db.AddParameter("p_SB_NO", pEdiUpdateAllPartyAccout.SbNo)
                db.AddParameter("p_SB_DATE", pEdiUpdateAllPartyAccout.SbDate)
                db.AddParameter("p_CREATED_BY", pEdiUpdateAllPartyAccout.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEdiUpdateAllPartyAccout.CreatedOn)
                db.AddParameter("p_MTY_CONT_ID", pEdiUpdateAllPartyAccout.MtyContId)
                db.AddParameter("p_CONT_JO_ID", pEdiUpdateAllPartyAccout.ContJoId)
                db.AddParameter("p_REF_ID", pEdiUpdateAllPartyAccout.RefId)
                db.AddParameter("p_ErrorMsg", pEdiUpdateAllPartyAccout.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EDI_DATA_UPDATE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEdiUpdateAllPartyAccout.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pEdiUpdateAllPartyAccout.ErrorMsg = ex.Message
            End Try
            Return pEdiUpdateAllPartyAccout
        End Function
        Public Shared Function UpdateEdiDeatils(ByVal pEdiUpdateAllPartyAccout As EdiUpdateAllPartyAccout, ByVal db As DBConnect) As EdiUpdateAllPartyAccout
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_NO", pEdiUpdateAllPartyAccout.JobNumber)
                db.AddParameter("p_JOB_DATE", pEdiUpdateAllPartyAccout.JobDate)
                db.AddParameter("p_CONSIGNOR_NAME", pEdiUpdateAllPartyAccout.ConsignerName)
                db.AddParameter("p_CONSIGNOR_ID", pEdiUpdateAllPartyAccout.ConsigerId)
                db.AddParameter("p_CONSIGNMENT_TYPE", pEdiUpdateAllPartyAccout.ConsignmentType)
                db.AddParameter("p_CONSIGNMENT_TYPE_ID", pEdiUpdateAllPartyAccout.ConsignmentTypeId)
                db.AddParameter("p_COMMODITY_NAME", pEdiUpdateAllPartyAccout.CommodityName)
                db.AddParameter("p_COMMODITY_ID", pEdiUpdateAllPartyAccout.CommodityId)
                db.AddParameter("p_NOTIFY_PARTY", pEdiUpdateAllPartyAccout.NotifyParty)
                db.AddParameter("p_SHIPPER_NAME", pEdiUpdateAllPartyAccout.ConsigneeName)
                db.AddParameter("p_CONSINGEE_NAME", pEdiUpdateAllPartyAccout.ConsigneeName)
                db.AddParameter("p_PORT", pEdiUpdateAllPartyAccout.Port)
                db.AddParameter("p_POD_ID", pEdiUpdateAllPartyAccout.PodId)
                db.AddParameter("p_PARTY_INV_NO", pEdiUpdateAllPartyAccout.PartyInvoiceNo)
                db.AddParameter("p_FOB_VALUE_INR", pEdiUpdateAllPartyAccout.FobValue)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pEdiUpdateAllPartyAccout.HeathNo)
                db.AddParameter("p_CARTONS", pEdiUpdateAllPartyAccout.CARTONS)
                db.AddParameter("p_NET_WT", pEdiUpdateAllPartyAccout.NetWt)
                db.AddParameter("p_GROSS_WT", pEdiUpdateAllPartyAccout.GrossWeight)
                db.AddParameter("p_PACKAGE_TYPE", pEdiUpdateAllPartyAccout.PackageType)
                db.AddParameter("p_PACKAGE_TYPE_ID", pEdiUpdateAllPartyAccout.PackageTypeId)
                db.AddParameter("p_CFS_ID", pEdiUpdateAllPartyAccout.CfsId)
                db.AddParameter("p_CFS", pEdiUpdateAllPartyAccout.Cfs)
                db.AddParameter("p_PARTY_INV_DATE", pEdiUpdateAllPartyAccout.PartyInvoicedate)
                db.AddParameter("p_CHA", pEdiUpdateAllPartyAccout.CHA)
                db.AddParameter("p_CHA_ID", pEdiUpdateAllPartyAccout.ChaId)
                db.AddParameter("p_SB_NO", pEdiUpdateAllPartyAccout.SbNo)
                db.AddParameter("p_SB_DATE", pEdiUpdateAllPartyAccout.SbDate)
                db.AddParameter("p_CREATED_BY", pEdiUpdateAllPartyAccout.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEdiUpdateAllPartyAccout.CreatedOn)
                db.AddParameter("p_MTY_CONT_ID", pEdiUpdateAllPartyAccout.MtyContId)
                db.AddParameter("p_CONT_JO_ID", pEdiUpdateAllPartyAccout.ContJoId)
                db.AddParameter("p_REF_ID", pEdiUpdateAllPartyAccout.RefId)
                db.AddParameter("p_ErrorMsg", pEdiUpdateAllPartyAccout.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EDI_DATA_UPDATE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEdiUpdateAllPartyAccout.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pEdiUpdateAllPartyAccout.ErrorMsg = ex.Message
            End Try
            Return pEdiUpdateAllPartyAccout
        End Function
    End Class
End Namespace
