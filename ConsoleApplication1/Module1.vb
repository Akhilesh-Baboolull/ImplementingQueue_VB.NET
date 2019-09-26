Module Module1

    Structure QUEUE

        Dim item As Integer
        Dim pointer As Integer

    End Structure

    Structure QUEUEPOINTERS

        Dim size As Integer
        Dim front As Integer
        Dim rear As Integer
        Dim freecell As Integer

    End Structure
    '==================================================================================
    Function EMPTYQ(ByVal pointers As QUEUEPOINTERS) As Boolean

        If pointers.size = 0 Then
            EMPTYQ = True
        Else
            EMPTYQ = False
        End If

    End Function
    '==================================================================================
    Function FULLQ(ByVal pointers As QUEUEPOINTERS) As Boolean

        If pointers.size = 10 Then
            FULLQ = True
        Else
            FULLQ = False
        End If

    End Function
    '==================================================================================
    Sub ENQUEUE(ByRef pointers As QUEUEPOINTERS, ByRef rec() As QUEUE)

        If FULLQ(pointers) = True Then
            Console.WriteLine("The Queue is Full!")
        Else
            Console.Write("Enter Number: ")
            rec(pointers.freecell).item = Console.ReadLine()
            rec(pointers.freecell).pointer = pointers.freecell
            Console.WriteLine("Number Stored Successfully!")
            pointers.size = pointers.size + 1
            pointers.rear = (pointers.rear Mod 10) + 1
            pointers.freecell = (pointers.freecell Mod 10) + 1

        End If

    End Sub
    '==================================================================================
    Sub DELQUEUE(ByRef pointers As QUEUEPOINTERS, ByRef rec() As QUEUE)

        If EMPTYQ(pointers) = True Then
            Console.WriteLine("The Queue is already Empty!")
        Else
            Console.WriteLine("First Item in Queue Successfully Deleted!")
            pointers.size = pointers.size - 1
            pointers.front = (pointers.front Mod 10) + 1

        End If


    End Sub
    '==================================================================================
    Sub Main()

        Dim record(10) As QUEUE
        Dim pointers As QUEUEPOINTERS
        Dim choice As Integer

        pointers.size = 0
        pointers.front = 1
        pointers.rear = 0
        pointers.freecell = 1

        Do
            Console.WriteLine("The Menu is as follows: ")
            Console.WriteLine("PRESS 1 TO ENTER AN ITEM INTO THE QUEUE")
            Console.WriteLine("PRESS 2 TO DELETE THE FIRST ITEM ENTERED INTO THE QUEUE")
            Console.WriteLine("PRESS 3 TO DISPLAY STATUS OF QUEUE")
            Console.WriteLine("PRESS 4 TO EXIT")

            Console.WriteLine()
            Console.Write("Enter Choice: ")
            choice = Console.ReadLine()

            If choice = 1 Then
                Call ENQUEUE(pointers, record)
                Console.WriteLine()
            Else
                If choice = 2 Then
                    Call DELQUEUE(pointers, record)
                    Console.WriteLine()
                Else
                    If choice = 3 Then
                        Console.WriteLine("Is Queue Empty? : " & EMPTYQ(pointers))
                        Console.WriteLine("Is Queue Full? : " & FULLQ(pointers))
                        Console.WriteLine("The Size is : " & pointers.size)
                        Console.WriteLine("The Front is : " & pointers.front)
                        Console.WriteLine("The Rear is : " & pointers.rear)
                        Console.WriteLine("The Free Cell is : " & pointers.freecell)
                        Console.WriteLine()
                    Else

                        If choice = 4 Then
                            Console.WriteLine("Press Any key to Exit!!")
                        Else
                            Console.WriteLine("Wrong Choice! Choose from the above menu...")
                        End If
                        End If
                    End If
                End If
        Loop Until (choice = 4)








    End Sub

End Module
