Imports System.Security
Imports TharstenAPI

Module Module1

    Sub Main()
        Test.Wait()
    End Sub

    Private Async Function Test() As Task
        Dim user = "CONFIDENTIAL"
        Dim appId = "CONFIDENTIAL"
        Dim password As New SecureString()
        password.AppendChar("p")
        password.AppendChar("a")
        password.AppendChar("s")
        password.AppendChar("s")
        Dim host = "CONFIDENTIAL"

        Dim api = New Tharsten(host, user, password, appId)

        Dim customerCode = "CONFIDENTIAL"
        Dim time = DateTime.Now.ToShortDateString()
        Dim title = "VV Test"
        ' Dim jobs = Await api.GetJobs(customerCode:=customerCode)
        Dim projectID = Await api.GetCustomerProject(customerCode:=customerCode, defaultName:="Vertical Vet - TEST " & time, projectDate:=time)
        Dim jobID = Await api.CreateCustomerJob(estimateTemplateRef:="VerticalVet", projectId:=projectID, customerCode:=customerCode, jobTitle:=title & " - " & projectID, defaultpapercode:="100#GVGlossCover")
    End Function

End Module
