
Partial Class Products
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label1.Text = "Category: " & Request.QueryString("Category")

    End Sub

    Function GetCategoryParam() As String

        If (Request.PathInfo.Length = 0) Then
            Return ""
        Else
            Return Request.PathInfo.Substring(1)
        End If

    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Button1.Text = "Check the URL to make sure it is still correct (it should be)"

    End Sub

End Class
