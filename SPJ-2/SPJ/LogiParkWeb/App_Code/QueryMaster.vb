Imports System.Data
Imports System.Data.OleDb

Public Class QueryMaster
    Public Shared Function GetDataTable(cmdStr As string, 
                                        params as Dictionary(Of String, Object), 
                                        Optional strCmdType As Boolean = True) As DataTable
        Dim table As DataTable = New DataTable()

        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))

            Using cmd = New OleDbCommand(cmdStr, con)

                Using da = New OleDbDataAdapter(cmd)
                    cmd.CommandType = If(strCmdType, CommandType.StoredProcedure, CommandType.Text) 
                    For Each keyValuePair As KeyValuePair(Of String,Object) In params
                        cmd.Parameters.AddWithValue(keyValuePair.Key,
                                                    keyValuePair.Value)
                    Next
                    da.Fill(table)
                End Using
            End Using
        End Using
        Return table
    End Function

    Public shared sub GetDataTables(cmdStrList As List(Of String), 
                                        params as List(Of Dictionary(Of String, Object)),
                                        listTable As List(Of DataTable), 
                                        Optional strCmdType As Boolean = True)  
        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
            Dim index=0
            For Each cmdStr As String In cmdStrList
                Using cmd = New OleDbCommand(cmdStr, con)
                    Using da = New OleDbDataAdapter(cmd)
                        cmd.CommandType = If(strCmdType, CommandType.StoredProcedure, CommandType.Text) 
                        For Each keyValuePair As KeyValuePair(Of String,Object) In params(index)
                            cmd.Parameters.AddWithValue(keyValuePair.Key,
                                                        keyValuePair.Value)
                        Next
                        da.Fill(listTable(index))
                    End Using
                End Using
                index +=1
            Next
        End Using
    End Sub

    Public Shared Sub FillDropDowns(commands As List(Of String),
                             bindingTextValue As List(Of Tuple(Of String, String)),
                             parameters As List(Of Dictionary(Of String, Object)),
                             dropDownLists As List(Of DropDownList),
                             Optional strCmdType As Boolean = True)
        Dim table As DataTable
        Dim index = 0
        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
            For Each cmdStr As String In commands
                Using cmd = New OleDbCommand(cmdStr, con)
                    Using da = New OleDbDataAdapter(cmd)
                        cmd.CommandType = If(strCmdType, CommandType.StoredProcedure, CommandType.Text)
                        Dim params = parameters(index)
                        For Each keyValuePair As KeyValuePair(Of String, Object) In params
                            cmd.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value)
                        Next
                        table = New DataTable()
                        da.Fill(table)
                        Dim ddl = dropDownLists(index)
                        ddl.DataSource = table
                        Dim tuple = bindingTextValue(index)
                        ddl.DataTextField = tuple.Item1
                        ddl.DataValueField = tuple.Item2
                        ddl.DataBind()
                        index += 1
                    End Using
                End Using
            Next
        End Using

    End Sub



End Class
