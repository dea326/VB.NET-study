Module Module1

    '深度优先搜索（Depth First Search, DFS）应用
    '给定一个大于1的正整数n，求1到n的全排列，如n等于3，则123就是一种排列，求这样的排列共有多少种
    '解的个数是n的阶乘，即n！
    '想象手里有1到n一共n张牌，一次放一张牌到桌上，直到手中没牌可放，即得出一种排列的解
    '当n值比较小时，如n=3或者n=4时，可以采用嵌套循环求解
    '8(n)皇后问题即是对DFS应用的经典问题

    Private n As Integer
    Private box(10) As Integer   '桌面上的牌堆
    Private hand(10) As Integer  '手里的牌

    Sub Main()

        Console.Write("请输入最大值正整数n(n<=10): ")
        n = Integer.Parse(Console.ReadLine())

        For i As Integer = 0 To hand.Length - 1
            hand(i) = 1
        Next

        dfs(1)

        Console.Read()

    End Sub

    Private Sub print(ByVal n As Integer)
        For i As Integer = 1 To n
            Console.Write("{0:d}", box(i))
        Next
        Console.WriteLine()
    End Sub

    Private Sub dfs(ByVal pos As Integer)

        If pos > n Then  '递归停止的条件，即表示前n张牌已经排列好
            print(n)
        Else
            For i As Integer = 1 To n
                If hand(i) = 1 Then  '判断牌i是否还在手上，1表示在手上，反之为0
                    box(pos) = i
                    hand(i) = 0

                    dfs(pos + 1)
                    hand(i) = 1  '非常重要的一步，一定要将刚才尝试的扑克牌收回，才能进行下一步尝试
                End If
            Next
        End If
    End Sub

End Module
