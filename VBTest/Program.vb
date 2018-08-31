Imports System
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks

Module Program

    Public Sub Main()

        Dim input = "2018-08-30T19:38:42Z"

        Dim result1 = Method1(input).GetAwaiter().GetResult()
        Console.WriteLine($"result1 = {result1}")

        Dim result2 = Method2(input).GetAwaiter().GetResult()
        Console.WriteLine($"result2 = {result2}")

        Dim result3 = Method3(input)
        Console.WriteLine($"result1 = {result3}")

        Dim result4 = Method4(input).GetAwaiter().GetResult()
        Console.WriteLine($"result4 = {result4}")

        Console.WriteLine()
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()

    End Sub

    Public Async Function Method1(dateTimeString As String) As Task(Of Date?)
        Return dateTimeString.ParseDateTimeString()?.TruncateMilliseconds()
    End Function

    Public Async Function Method2(dateTimeString As String) As Task(Of Date?)
        Return dateTimeString?.ParseDateTimeString()
    End Function

    Public Function Method3(dateTimeString As String) As Date?
        Return dateTimeString?.ParseDateTimeString()?.TruncateMilliseconds()
    End Function

    Public Async Function Method4(dateTimeString As String) As Task(Of Date?)
        Return dateTimeString?.ParseDateTimeString()?.TruncateMilliseconds()
    End Function

    <Extension>
    Public Function ParseDateTimeString(dateTimeString As String) As Date?
        Select Case (dateTimeString)
            Case Nothing, String.Empty
                Return Nothing
            Case NameOf(Date.MinValue)
                Return Date.MinValue
            Case NameOf(Date.Today)
                Return Date.Today
            Case NameOf(Date.Now)
                Return Date.Now
            Case NameOf(Date.UtcNow)
                Return Date.UtcNow
            Case NameOf(Date.MaxValue)
                Return Date.MaxValue
            Case Else
                Return Date.Parse(dateTimeString)
        End Select
    End Function

    <Extension>
    Public Function TruncateMilliseconds(value As Date) As Date
        Return value.AddTicks(-(value.Ticks Mod TimeSpan.TicksPerSecond))
    End Function

End Module
