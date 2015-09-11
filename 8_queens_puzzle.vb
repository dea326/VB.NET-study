Module nQueenspuzzle
    Dim queen(20) As Integer
    Dim count As Integer = 0



    Sub Main()

        Dim n As Integer

        Console.Write("请输入皇后的个数 n（n<=20）:")
        n = Val(Console.ReadLine())

        If n > 20 Then
            Console.WriteLine("n值太大，不能求解!")
        Else
            Console.WriteLine("{0:d}皇后问题求解如下(每行的皇后所在的列数)：", n)
            place(1, n)

        End If

        Console.Read()

    End Sub

    '输出一个解
    Sub print(ByVal n As Integer)

        count += 1

        Console.Write(String.Format("第{0:d}个解：", count))

        For i = 1 To n

            Console.Write(String.Format("({0:d},{1:d})", i, queen(i)))

        Next

        Console.WriteLine()


        For i = 1 To n
            For j = 1 To n
                If queen(i) <> j Then
                    Console.Write("x")
                Else
                    Console.Write("Q")
                End If
            Next
            Console.WriteLine()
        Next

    End Sub

    Function find(ByVal row As Integer, ByVal col As Integer) As Boolean '检验第row行的col列上是否可以摆放皇后

        Dim j As Integer = 1

        Do While j < row  '1 to row-1是已经放置了皇后的行

            '第j行的皇后是否在col列或(j,q[j])与(row,col)是否在斜线上

            If queen(j) = col Or Math.Abs(row - j) = Math.Abs(col - queen(j)) Then
                Return False
            End If

            j += 1

        Loop

        Return True

    End Function

    '放置皇后到棋盘上
    Sub place(ByVal row As Integer, ByVal n As Integer)
        If row > n Then
            print(n)
        Else
            For col = 1 To n  '试探第row行的每一个列
                If find(row, col) Then
                    queen(row) = col
                    place(row + 1, n)
                End If
            Next
        End If
    End Sub

End Module
