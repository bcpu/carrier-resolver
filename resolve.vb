Private Sub Resolve()

        dim strphone as string
	strphone = "1112223333"
        exchange = strphone.Substring(0, 3)
        exchange2 = strphone.Substring(3, 3)
        exchange3 = strphone.Substring(6, 4)

        Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://www.fonefinder.net/findome.php?npa=" & exchange & "&nxx=" & exchange2 & "&thoublock=" & exchange3 & "&usaquerytype=Search+by+Number&cityname="), HttpWebRequest)
        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        request.CookieContainer = tempCookies
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome"
        On Error Resume Next
        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        On Error Resume Next
        Dim reader As New StreamReader(response.GetResponseStream())
        Dim theusercp As String = reader.ReadToEnd
        Dim postresponse As HttpWebResponse
        postresponse = DirectCast(request.GetResponse(), HttpWebResponse)
        RichTextBox1.Text = theusercp

        ' grab carrier result
        If RichTextBox1.Text.Contains("CINGULAR") Then
            Console.WriteLine(strphone & " uses att/cingular")
        End If

        If RichTextBox1.Text.Contains("VERIZON") Then
            Console.WriteLine(strphone & " uses verizon")
        End If

        If RichTextBox1.Text.Contains("NEXTEL") Then
            Console.WriteLine(strphone & " uses nextel")
        End If

        If RichTextBox1.Text.Contains("T-MOBILE") Then
            Console.WriteLine(strphone & " uses t-mobile")
        End If

        If RichTextBox1.Text.Contains("METRO PCS") Then
            Console.WriteLine(strphone & " uses metro pcs")
        End If

        If RichTextBox1.Text.Contains("METROPCS") Then
            Console.WriteLine(strphone & " uses metro pcs")
        End If

        If RichTextBox1.Text.Contains("SPRINT") Then
            Console.WriteLine(strphone & " uses sprint")
        End If
    End Sub
