Option Strict On
Imports System.Console
Imports System.Threading.Thread
Module Program
    Sub Main()
        Dim Choice As Integer
        Dim hard As Boolean = False
        Dim CColour As ConsoleColor = ConsoleColor.Red
        Dim CIcon As String = "☻"
        Dim highscore As Integer = 0
        CursorVisible = False
        BackgroundColor = ConsoleColor.Black
        ForegroundColor = CColour
        Do
            SetWindowSize(52, 26)
            Clear()
            WriteLine("________________________________________________
___  __ \_  __ \__  __ \_  ____/__  ____/__  __ \
__  / / /  / / /_  / / /  / __ __  __/  __  /_/ /
_  /_/ // /_/ /_  /_/ // /_/ / _  /___  _  _, _/
/_____/ \____/ /_____/ \____/  /_____/  /_/ |_|
")
            Choice = Menu(highscore)
            If Choice = 0 Then
                hard = False
                Play(highscore, CColour, CIcon, hard)
            ElseIf Choice = 1 Then
                hard = True
                Play(highscore, CColour, CIcon, hard)
            ElseIf Choice = 2 Then
                Customise(CColour, CIcon)
            ElseIf Choice = 3 Then
                End
            End If
        Loop
        SetCursorPosition(3, 8)
        WriteLine("Exiting...")
        Sleep(500)
    End Sub
    Sub Customise(ByRef CColour As ConsoleColor, ByRef CIcon As String)
        Dim Pos As Integer
        Dim Key As ConsoleKey
        Dim Choice As Integer
        Do
            SetWindowSize(64, 26)
            Clear()
            WriteLine("_________             _____                 _____            
__  ____/___  __________  /_____________ ______(_)___________
_  /    _  / / /_  ___/  __/  __ \_  __ `__ \_  /__  ___/  _ \
/ /___  / /_/ /_(__  )/ /_ / /_/ /  / / / / /  / _(__  )/  __/
\____/  \__,_/ /____/ \__/ \____//_/ /_/ /_//_/  /____/ \___/
                                                              ")
            WriteLine("   Character colour")
            WriteLine("   Character icon")
            WriteLine("   Back to menu")
            Do
                SetCursorPosition(0, Pos + 6)
                Write("->")
                Key = ReadKey().Key
                SetCursorPosition(0, Pos + 6)
                Write("   ")
                Select Case Key
                    Case ConsoleKey.UpArrow
                        If Pos > 0 Then Pos -= 1
                    Case ConsoleKey.DownArrow
                        If Pos < 2 Then Pos += 1
                End Select
            Loop Until Key = ConsoleKey.Enter
            Choice = Pos
            If Choice = 0 Then
                CharacterColour(CColour)
            ElseIf Choice = 1 Then
                CharacterIcon(CIcon)
            End If
        Loop Until Choice = 2
        SetCursorPosition(3, 8)
        WriteLine("Returning to menu...")
        Sleep(500)
    End Sub
    Sub CharacterColour(ByRef CColour As ConsoleColor)
        Dim pos As Integer
        Dim Key As ConsoleKey
        Clear()
        WriteLine("_________             _____                 _____            
__  ____/___  __________  /_____________ ______(_)___________
_  /    _  / / /_  ___/  __/  __ \_  __ `__ \_  /__  ___/  _ \
/ /___  / /_/ /_(__  )/ /_ / /_/ /  / / / / /  / _(__  )/  __/
\____/  \__,_/ /____/ \__/ \____//_/ /_/ /_//_/  /____/ \___/
                                                              ")
        WriteLine("   CHOOSE COLOUR")
        WriteLine("   Red(defult)")
        WriteLine("   Blue")
        WriteLine("   Green")
        WriteLine("   Yellow")
        WriteLine("   White")
        WriteLine("   Magenta")
        WriteLine("   Cyan")
        Do
            SetCursorPosition(0, pos + 7)
            Write("->")
            Key = ReadKey().Key
            SetCursorPosition(0, pos + 7)
            Write("   ")
            Select Case Key
                Case ConsoleKey.UpArrow
                    If pos > 0 Then pos -= 1
                Case ConsoleKey.DownArrow
                    If pos < 6 Then pos += 1
            End Select
        Loop Until Key = ConsoleKey.Enter
        Select Case pos
            Case 0 : CColour = ConsoleColor.Red
            Case 1 : CColour = ConsoleColor.Blue
            Case 2 : CColour = ConsoleColor.Green
            Case 3 : CColour = ConsoleColor.Yellow
            Case 4 : CColour = ConsoleColor.White
            Case 5 : CColour = ConsoleColor.Magenta
            Case 6 : CColour = ConsoleColor.Cyan
        End Select
    End Sub
    Sub CharacterIcon(ByRef CIcon As String)
        Dim Pos As Integer
        Dim Key As ConsoleKey
        Dim Choice As Integer
        SetWindowSize(64, 26)
        Clear()
        WriteLine("_________             _____                 _____            
__  ____/___  __________  /_____________ ______(_)___________
_  /    _  / / /_  ___/  __/  __ \_  __ `__ \_  /__  ___/  _ \
/ /___  / /_/ /_(__  )/ /_ / /_/ /  / / / / /  / _(__  )/  __/
\____/  \__,_/ /____/ \__/ \____//_/ /_/ /_//_/  /____/ \___/
                                                              ")
        WriteLine("   CHOOSE ICON")
        WriteLine("   ☻ (defult)")
        WriteLine("   ¤")
        WriteLine("   ¶")
        WriteLine("   ©")
        WriteLine("   Ô")
        WriteLine("   Â")
        WriteLine("   ¥")
        Do
            SetCursorPosition(0, Pos + 7)
            Write("->")
            Key = ReadKey().Key
            SetCursorPosition(0, Pos + 7)
            Write("   ")
            Select Case Key
                Case ConsoleKey.UpArrow
                    If Pos > 0 Then Pos -= 1
                Case ConsoleKey.DownArrow
                    If Pos < 6 Then Pos += 1
            End Select
        Loop Until Key = ConsoleKey.Enter
        Choice = Pos
        Select Case Pos
            Case 0 : CIcon = "☻"
            Case 1 : CIcon = "¤"
            Case 2 : CIcon = "¶"
            Case 3 : CIcon = "©"
            Case 4 : CIcon = "Ô"
            Case 5 : CIcon = "Â"
            Case 6 : CIcon = "¥"
        End Select
    End Sub
    Function Menu(ByVal highscore As Integer) As Integer
        Dim Pos As Integer
        Dim Key As ConsoleKey
        WriteLine("   Play")
        WriteLine("   Hard Play")
        WriteLine("   Customise character")
        WriteLine("   Exit")
        WriteLine()
        WriteLine()
        WriteLine("   Highscore = " & highscore)
        Do
            SetCursorPosition(0, Pos + 6)
            Write("->")
            Key = ReadKey().Key
            SetCursorPosition(0, Pos + 6)
            Write("   ")
            Select Case Key
                Case ConsoleKey.UpArrow
                    If Pos > 0 Then Pos -= 1
                Case ConsoleKey.DownArrow
                    If Pos < 3 Then Pos += 1
            End Select
        Loop Until Key = ConsoleKey.Enter
        Return Pos
    End Function

    Sub Play(ByRef highscore As Integer, ByVal CColour As ConsoleColor, ByVal CIcon As String, ByVal hard As Boolean)
        Clear()
        CursorVisible = False
        Dim keypressed As ConsoleKeyInfo
        Dim sPos As Integer = 25
        Dim aPos As Integer
        Dim Direction As Integer
        Dim i As Integer = 1
        Dim endGame As Boolean = False
        Dim score As Integer = 0
        Dim delay As Integer = 50
        Dim maxDelay As Integer = 40
        SetCursorPosition(sPos, 25)
        ForegroundColor = CColour : Write(CIcon) : ForegroundColor = ConsoleColor.Red
        Do

            Randomize()
            If hard Then
                aPos = sPos
                maxDelay = 30
            Else
                aPos = CInt(Rnd() * 49)
            End If
            delay = CInt((Rnd() * maxDelay) + 10)
            SetCursorPosition(aPos, 0) : Write("►█◄")
            Do
                Sleep(delay)
                Randomize()
                Direction = CInt(Rnd() * 2)
                Select Case Direction
                    Case 0
                        If aPos > 2 Then
                            aPos -= 3
                            SetCursorPosition(aPos, i) : Write("►█◄")
                            SetCursorPosition(aPos + 3, i - 1) : Write("   ")
                        Else
                            i -= 1
                        End If
                    Case 1
                        SetCursorPosition(aPos, i) : Write("►█◄")
                        SetCursorPosition(aPos, i - 1) : Write("   ")
                    Case 2
                        If aPos < 47 Then
                            aPos += 3
                            SetCursorPosition(aPos, i) : Write("►█◄")
                            SetCursorPosition(aPos - 3, i - 1) : Write("   ")
                        Else
                            i -= 1
                        End If
                End Select
                If (aPos - 3 = sPos Or aPos - 2 = sPos Or aPos - 1 = sPos Or aPos = sPos Or aPos + 1 = sPos Or aPos + 2 = sPos Or aPos + 3 = sPos Or aPos + 4 = sPos Or aPos + 5 = sPos) And i = 25 Then
                    endGame = True
                End If
                SpaceshipMovement(keypressed, sPos, CIcon, CColour)
                i += 1
            Loop Until i = 26
            If endGame = False Then
                SetCursorPosition(aPos, i - 1) : Write("   ")
                score += 1
            End If
            If maxDelay > 10 Then maxDelay -= 3
            i = 1
        Loop Until endGame = True
        If score > highscore Then highscore = score
        Death(score, aPos)
    End Sub
    Sub SpaceshipMovement(ByRef keypressed As ConsoleKeyInfo, ByRef sPos As Integer, ByVal CIcon As String, ByVal CColour As ConsoleColor)
        ForegroundColor = ConsoleColor.Black
        If KeyAvailable() = True Then
            keypressed = ReadKey()
            If keypressed.Key = ConsoleKey.LeftArrow And sPos > 0 Then
                SetCursorPosition(sPos, 25)
                Write(" ")
                sPos -= 5
            ElseIf keypressed.Key = ConsoleKey.RightArrow And sPos < 50 Then
                SetCursorPosition(sPos, 25)
                Write(" ")
                sPos += 5
            Else
                SetCursorPosition(sPos + 1, 25)
                Write(" ")
            End If
            SetCursorPosition(sPos, 25)
            ForegroundColor = CColour : Write(CIcon) : ForegroundColor = ConsoleColor.Red
        End If
        ForegroundColor = ConsoleColor.Red
    End Sub
    Sub Death(score As Integer, aPos As Integer)
        BackgroundColor = ConsoleColor.White
        For x = 0 To 10
            If (aPos - x) > 0 Then SetCursorPosition(aPos - x, 25) : Write(" ")
            If (aPos + x) < 51 Then SetCursorPosition(aPos + x, 25) : Write(" ")
            If (aPos - (x / 2)) > 0 Then SetCursorPosition(CInt(aPos - (x / 2)), 24) : Write(" ")
            If (aPos + (x / 2)) < 51 Then SetCursorPosition(CInt(aPos + (x / 2)), 24) : Write(" ")
            If (aPos - (x / 4)) > 0 Then SetCursorPosition(CInt(aPos - (x / 4)), 23) : Write(" ")
            If (aPos + (x / 4)) < 51 Then SetCursorPosition(CInt(aPos + (x / 4)), 23) : Write(" ")
            If (aPos - (x / 8)) > 0 Then SetCursorPosition(CInt(aPos - (x / 8)), 22) : Write(" ")
            If (aPos + (x / 8)) < 51 Then SetCursorPosition(CInt(aPos + (x / 8)), 22) : Write(" ")
            Sleep(100)
        Next
        BackgroundColor = ConsoleColor.Black
        SetCursorPosition(0, 0) : WriteLine("__  __                 _____________     _________
_ \/ /_________  __    ______  /__(_)__________  /
__  /_  __ \  / / /    _  __  /__  /_  _ \  __  /
_  / / /_/ / /_/ /     / /_/ / _  / /  __/ /_/ /  
/_/  \____/\__,_/      \__,_/  /_/  \___/\__,_/ ")
        Sleep(2000)
        Clear()
        WriteLine("________________________________________
__  ___/_  ____/_  __ \__  __ \__  ____/
_____ \_  /    _  / / /_  /_/ /_  __/  
____/ // /___  / /_/ /_  _, _/_  /___  
/____/ \____/  \____/ /_/ |_| /_____/  
                                       
= " & score)
        Sleep(2000)
        Clear()
    End Sub
End Module