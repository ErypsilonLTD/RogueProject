Public Class SoundPlayerData
    Public Shared Sub Play(ByVal Type As SByte)
        Dim Sound As New Threading.Thread(Sub() PlaySound(Type))
        Call Sound.Start()
    End Sub

    Private Shared Sub PlaySound(ByVal Type As SByte)

        Select Case Type
            Case 1 'Positive
                Console.Beep(435, 120)
                Console.Beep(650, 115)
            Case 2 'Damage Taken
                Console.Beep(360, 112)
                Console.Beep(200, 110)
                Console.Beep(150, 200)
            Case 3 'Win
                Console.Beep(470, 200)
                Threading.Thread.Sleep(100)
                Console.Beep(520, 100)
                Console.Beep(520, 100)
                Console.Beep(520, 100)
                Console.Beep(600, 500)
            Case 4 'Lose
                Console.Beep(200, 112)
                Console.Beep(170, 110)
                Console.Beep(140, 100)
                Threading.Thread.Sleep(10)
                Console.Beep(110, 500)
            Case 5 'Shoot
                Console.Beep(70, 15)
            Case 6 'Reload
                Console.Beep(60, 15)
                Threading.Thread.Sleep(110)
                Console.Beep(170, 15)
            Case 7 'Force Cycle
                Console.Beep(400, 10)
                Console.Beep(405, 10)
            Case 8 'Basic Interaction
                Console.Beep(400, 10)
        End Select

    End Sub
End Class
