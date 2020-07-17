Public Class StudentRecords
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\EmploymentFiles\dbStudentsGradeCrud.accdb")
    'PLEASE CHANGE THE PROVIDER depending on LOCATION of DATABASE ACCESS'
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            If con.State = ConnectionState.Open Then
                MsgBox("Connected to DataBase")
            Else
                MsgBox("Not Connected to DataBase")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            con.Close()

        End Try


    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim dataAdap As New OleDb.OleDbDataAdapter



        Try
            con.Open()

            sql = "select * from tblStudents"
            cmd.Connection = con
            cmd.CommandText = sql
            dataAdap.SelectCommand = cmd

            dataAdap.Fill(dt)
            dataGridView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer



        Try
            con.Open()

            sql = "INSERT INTO tblStudents (StudentsID, LastName, FirstName, MiddleName, YearLevel, Course, Eng, Fil, Math, Sci)
                VALUES('" & txtstudentid.Text & "','" & txtlname.Text & "','" & txtfname.Text & "','" & txtmname.Text & "','" & txtyear.Text & "','" & txtcourse.Text & "','" & txteng.Text & "','" & txtfil.Text & "','" & txtmath.Text & "','" & txtsci.Text & "')"
            cmd.Connection = con
            cmd.CommandText = sql

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("New record insert successfully!")
            Else
                MsgBox("No record inserted")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


        'Reload automatically all records!'
        Dim dt As New DataTable
        Dim dataAdap As New OleDb.OleDbDataAdapter



        Try
            con.Open()

            sql = "select * from tblStudents"
            cmd.Connection = con
            cmd.CommandText = sql
            dataAdap.SelectCommand = cmd

            dataAdap.Fill(dt)
            dataGridView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub dataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView.CellClick
        Try
            Me.Text = dataGridView.CurrentRow.Cells(0).Value
            txtlname.Text = dataGridView.CurrentRow.Cells(1).Value
            txtfname.Text = dataGridView.CurrentRow.Cells(2).Value
            txtmname.Text = dataGridView.CurrentRow.Cells(3).Value
            txtyear.Text = dataGridView.CurrentRow.Cells(4).Value
            txtcourse.Text = dataGridView.CurrentRow.Cells(5).Value
            txteng.Text = dataGridView.CurrentRow.Cells(6).Value
            txtfil.Text = dataGridView.CurrentRow.Cells(7).Value
            txtmath.Text = dataGridView.CurrentRow.Cells(8).Value
            txtsci.Text = dataGridView.CurrentRow.Cells(9).Value

        Catch ex As Exception
            MsgBox("No remaining records")
        End Try


    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim dataAdap As New OleDb.OleDbDataAdapter



        Try
            con.Open()

            sql = "select * from tblStudents WHERE StudentsID='" & txtsearch.Text & "'"
            cmd.Connection = con
            cmd.CommandText = Sql
            dataAdap.SelectCommand = cmd

            dataAdap.Fill(dt)
            dataGridView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer



        Try
            con.Open()

            sql = "UPDATE tblStudents SET 
                   
                    LastName = '" & txtlname.Text & "', 
                    FirstName = '" & txtfname.Text & "', 
                    MiddleName = '" & txtmname.Text & "', 
                    YearLevel = '" & txtyear.Text & "', 
                    Course = '" & txtcourse.Text & "', 
                    Eng  = '" & txteng.Text & "', 
                    Fil  = '" & txtfil.Text & "', 
                    Math  = '" & txtmath.Text & "', 
                    Sci  = '" & txtsci.Text & "' where StudentsID = '" & Me.Text & "'
                    "
            cmd.Connection = con
            cmd.CommandText = sql

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record Updated Successfully!")
            Else
                MsgBox("No record has been updated")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


        'Reload automatically all records!'
        Dim dt As New DataTable
        Dim dataAdap As New OleDb.OleDbDataAdapter



        Try
            con.Open()

            sql = "select * from tblStudents"
            cmd.Connection = con
            cmd.CommandText = sql
            dataAdap.SelectCommand = cmd

            dataAdap.Fill(dt)
            dataGridView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer



        Try
            con.Open()

            sql = "DELETE * from tblStudents where StudentsID = '" & Me.Text & "'
                    "
            cmd.Connection = con
            cmd.CommandText = sql

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record DELETED Successfully!")
            Else
                MsgBox("No record has been DELETED")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


        'Reload automatically all records!'
        Dim dt As New DataTable
        Dim dataAdap As New OleDb.OleDbDataAdapter



        Try
            con.Open()

            sql = "select * from tblStudents"
            cmd.Connection = con
            cmd.CommandText = sql
            dataAdap.SelectCommand = cmd

            dataAdap.Fill(dt)
            dataGridView.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class
