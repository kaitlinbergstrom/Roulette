Module Roulette
    Dim numberBet, ball, cash As Integer
    Sub Main()
        Dim winner As Boolean
        Dim winCash, choice, numberBet, moneyBet, odds As Integer
        winner = False
        cash = 100
        While cash > 0
            menu()
            choice = readChoice()
            If choice = 1 Then
                odds = 1
            ElseIf choice = 2 Then
                odds = 1
            ElseIf choice = 3 Then
                odds = 2
            ElseIf choice = 4 Then
                odds = 2
            ElseIf choice = 5 Then
                odds = 2
            ElseIf choice = 6 Then
                odds = 36
                Console.Write("Enter number bet: ")
                numberBet = Console.ReadLine()
                While numberBet < 0 Or numberBet > 36
                    Console.Write("Invalid number. Try again: ")
                    numberBet = Console.ReadLine()
                End While
            Else
                Console.WriteLine("You are leaving with " & cash.ToString("C2"))
                Environment.Exit(0)

            End If
            moneyBet = enterMoneyBet(cash)
            ball = wheelSpin()
            winner = winOrLose(choice, ball)
            If winner = True Then
                winCash = moneyBet * odds
                Console.WriteLine("You win " & winCash.ToString("C2"))
                cash += winCash
            Else
                Console.WriteLine("You lose " & moneyBet.ToString("C2"))
                cash -= moneyBet
            End If
            Console.WriteLine("Press any key to continue")
            Console.ReadKey(True)

        End While
    End Sub
    Function winOrLose(choice As Integer, ball As Integer)
        Dim win As Boolean
        If ball = 0 Then
            win = False
        ElseIf choice = 1 And ball Mod 2 = 1 Then
            win = True
        ElseIf choice = 2 And ball Mod 2 = 0 Then
            win = True
        ElseIf choice = 3 And ball <= 12 Then
            win = True
        ElseIf choice = 4 And ball > 12 And ball <= 24 Then
            win = True
        ElseIf choice = 5 And ball > 24 Then
            win = True
        ElseIf choice = 6 And ball = numberBet Then
            win = True
        Else
            win = False
        End If
        Return win
    End Function
    Function wheelSpin()
        Randomize()
        Dim color As String
        Console.WriteLine("Press any key to spin the wheel.")
        Console.ReadKey(True)
        ball = Int(37 * Rnd())
        If ball = 0 Then
            color = "green"
        ElseIf ball Mod 2 = 1 Then
            color = "red"
        ElseIf ball Mod 2 = 0 Then
            color = "black"
        End If
        Console.WriteLine("The ball landed on " & ball & " " & color)
        Return ball

    End Function
    Sub menu()
        Console.Clear()
        Console.WriteLine("Play Roullette!")
        Console.WriteLine("You currently have " & cash.ToString("C0"))
        Console.WriteLine("1. Bet on red (pays 1 to 1)")
        Console.WriteLine("2. Bet on black (pays 1 to 1)")
        Console.WriteLine("3. First 12 (pays 2 to 1)")
        Console.WriteLine("4. Middle 12 (pays 2 to 1)")
        Console.WriteLine("5. Last 12 (pays 2 to 1)")
        Console.WriteLine("6. Choose any 1 number (pays 35 to 1)")
        Console.WriteLine("7. Cash out")
        Console.WriteLine("=====================================")
    End Sub

    Function readChoice()
        Dim choice1 As Integer
        Console.Write("Please enter your choice: ")
        choice1 = Console.ReadLine()
        While choice1 <= 0 Or choice1 > 7
            Console.WriteLine("Error. Invalid option.")
            Console.Write("Try again: ")
            choice1 = Console.ReadLine()
        End While
        Return choice1
    End Function
    Function enterMoneyBet(cash As Integer)
        Dim mbet As Integer
        Console.Write("Enter bet: ")
        mbet = Console.ReadLine()
        While mbet > cash Or mbet <= 0
            Console.WriteLine("Error. Enter valid amount of money.")
            Console.Write("Enter bet: ")
            mbet = Console.ReadLine()
        End While
        Return mbet
    End Function
End Module
