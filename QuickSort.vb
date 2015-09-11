'快速排序的时间复杂度是O(N*logN)
'快速排序的基本思想是二分

Public Module quicksort
    Dim n As Integer
    Dim num(100) As Integer

    Sub Main()

        Dim n As Integer
        Console.Write("请输入要排序的数目 n= ")
        n = Integer.Parse(Console.ReadLine())

        Console.WriteLine("请输入数值：")

        For i As Integer = 1 To n
            num(i) = Integer.Parse(Console.ReadLine())
        Next

        quicksort(1, n)

        Console.WriteLine("经排序后：")

        For i As Integer = 1 To n
            Console.Write(num(i).ToString & " ")
        Next

        Console.WriteLine()
        Console.Read()


    End Sub

    Sub quicksort(ByVal left As Integer, ByVal right As Integer)   'left是最左端的数字，right是最右端的数字
        Dim i, j, t, base As Integer  'base即为基准数

        If left > right Then  '停止递归的条件
            Exit Sub
        End If

        base = num(left)  '本例以最左端的数为基准数，可以自定
        i = left  '创建left的全新副本i
        j = right  '创建right的全新副本j

        Do While i <> j
            Do While num(j) >= base And i < j
                j -= 1

            Loop
            Do While num(i) <= base And i < j
                i += 1

            Loop
            If i < j Then  '当i和j还没有相遇时交换两个数在数组中的位置
                t = num(i)
                num(i) = num(j)
                num(j) = t

            End If
        Loop
        '将基准数归位
        num(left) = num(i)
        num(i) = base

        quicksort(left, i - 1)  '继续处理左边的部分，这是一个递归的过程
        quicksort(i + 1, right)  '继续处理右边的部分，这是一个递归的过程

    End Sub

End Module
