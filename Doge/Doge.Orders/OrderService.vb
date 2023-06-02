Imports System.Net
Imports System.ServiceProcess
Imports System.Text
Imports Doge.Model
Imports Newtonsoft.Json

Public Class OrderService
    Inherits ServiceBase

    Private listener As HttpListener

    Protected Overrides Sub OnStart(ByVal args() As String)
        listener = New HttpListener()
        listener.Prefixes.Add("http://localhost:5001/orders/")
        listener.Start()

        ProcessRequests()
    End Sub

    Protected Overrides Sub OnStop()
        ' Stop listening for incoming HTTP requests
        listener.[Stop]()
    End Sub

    Private Sub ProcessRequests()
        While listener.IsListening
            Dim context As HttpListenerContext = listener.GetContext()
            Dim request As HttpListenerRequest = context.Request

            ' Process the incoming request based on the URL route
            If request.HttpMethod = "GET" Then

                Dim orders As New List(Of Order)()

                ' Add orders to the list
                Dim order1 As New Order()
                order1.OrderId = "1"
                order1.RequiredShippedTimestamp = 1234567890
                orders.Add(order1)

                Dim order2 As New Order()
                order2.OrderId = "2"
                order2.RequiredShippedTimestamp = 2345678901
                orders.Add(order2)

                ' Serialize the list of orders to JSON
                Dim jsonOrders As String = JsonConvert.SerializeObject(Orders)


                ' Write the JSON data to the response
                Dim responseBytes As Byte() = Encoding.UTF8.GetBytes(jsonOrders)
                context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length)

                ' Close the response
                context.Response.Close()
            Else
                ' Return a 404 Not Found response for unknown routes
                context.Response.StatusCode = 404
                context.Response.Close()
            End If
        End While
    End Sub

End Class
