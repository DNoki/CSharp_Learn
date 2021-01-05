# 这是一行注释
'''该文档介绍的是 Python3
Python 是一种解释型、面向对象、动态数据类型的高级程序设计语言。
Python 是一门解释型语言，因为不需要编译和链接的时间，它可以帮你省下一些开发时间。解释器可以交互式使用，这样就可以很方便的测试语言中的各种功能，以便于编写发布用的程序，或者进行自下而上的开发。还可以当他是一个随手可用的计算器。
Python 可以写出很紧凑合和可读性很强的程序。用 Python 写的程序通常比同样的 C 或 C++ 程序要短的多。
这是因为：
①高级数据结构是你可以在一个单独的语句中表达出很复杂的操作
②语句的组织依赖于缩进，而不是 begin/end 块
③不予要变量或参数声明
'''
'''
这是一段注释
'''
"""
这也是一段注释
"""


if False:
    """导入模块"""
    # 模块是包括 Python 定义和声明的文件。
    # 除了包含函数定义外，模块也可以包含可执行语句。这些语句一般用来初始化模块。他们仅在 第一次 被导入的地方执行一次。
    # 每个模块都有自己私有的符号表，被模块内所有的函数定义作为全局符号表使用。
    import MyPython
    from Python_Simple_Function import YourClass# import 语句的一个变体,直接从被导入的模块中导入命名到本模块的语义表中。
    from Python_Simple_Function import *# 导入模块中的所有定义 # 这样可以导入所有除了以下划线( _ )开头的命名。


if __name__ == "__main__" : # 如果程序从当前文件启动，则调用该语句。用来快速测试文件很有帮助
    print(__name__) # 当前文件名，如果是程序入口文件则为 “__main__”
    print(__file__) # 当前文件路径
    print(__doc__) # 当前文件说明
else:
    MyPython.Move(3,"A","B","C")

# 输出
print("Holle,World!",end=" ")# 修改默认end标识禁止换行
print("你好，世界！\n")
# 输入
_input = input()

# 获取字符的整数表示
ord("九")
# 把编码转换为对应字符
chr(35328)
# 输出 九言
print("\u4E5D\u8A00")




# 生成一个整数序列
# 所生成的链表中不包括范围中的结束值。
# 步进值可以为负数
range(101) # 生成从0开始到小于101的整数
range(50,101) # 生成从50开始到小于101的整数
range(0,101,10) # 生成从0开始到小于101的整数，步进长度为 10 （0,10,20…）

list(range(0,101,10)) # list 函数是另外一个（ 迭代器 ），它从可迭代（对象）中创建列表
zip(range(0,101,10)) # zip 函数从可迭代（对象）中创建一个元组列表，注意是元组列表,它是一个可迭代对象

# 数据类型检查
x = 3
isinstance(x,(int,float))# 检查对象 x 是否是 int 或 float 类型
print("\n\nPress the enter key to exit.")

# -----------------------------------------------------------------------------

# Python_SimpleDataTypeAndVariable.py
import copy

class DataTypeAndVariable(object):
    """ 数据类型。 """
    # Number（数字）
    # String（字符串）
    # List（列表）
    # Tuple（元组）
    # Sets（集合）
    # Dictionary（字典）

    def NumberAndString():
        ' Number（数字） String（字符串） '
        _int = 0                    # 整型
        _float = 3.14               # 浮点型
        _bool = False               # 布尔型
        _complex = "这是一行文字"   # 字串符
        _none = None                # 空值

        (-3)**3# a**b 表示a的b次方
        17 / 3# / 除法会返回一个浮点数
        17 // 3# // 除法会返回一个整数
        17 % 3# % 取余
        3+5j# j表示复数

        # Python 可以动态转换类型
        _int = _float
        _int = _bool
        _int = _complex
        _int = None
        # 字符串索引、切片
        _complex[-1]
        _complex[:3]# 省略的第一个索引默认为零，省略的第二个索引默认为切片的字符串的大小。
        len(_complex)# 返回字符串的长度
        '''Python字符串不可以被更改 — 它们是 不可变的 。'''
        '''切片、索引同样适用于列表、元组'''
        ''' 格式化字符串 '''
        # 格式化字符串不仅仅是格式化。它也是强制类型转换。
        _str="%s + %d"%("一段文字",666)

        return
    def List():
        ' List（列表） '
        # list是一种有序的集合，可以随时添加和删除其中的元素。
        _list = [1,2,3,4]
        '''list、tuple是有序的，而sets、dict是无序的
        列表可以用索引、切割或者 append() 和 extend() 等方法改变。
        '''
        # 用 len() 函数获取list的元素个数
        len(_list)
        # 用索引访问 list 中每个位置的元素，-1 表示最后一个位置的元素
        _list[0]                # 第一个元素
        _list[-1]               # 倒数第一个元素
        _list[len(_list) - 1]   # 倒数第一个元素
        _list[-2]               # 倒数第二个元素
        # 追加元素到 list 末尾
        _list.append(5)
        # 追加列表到 list 末尾
        _list.extend(_list)
        # 插入元素到指定位置
        _list.insert(0,0)
        # 删除list末尾的元素
        _list.pop()# 可以与 append 一起使用，吧list当成一个堆栈
        # 删除指定位置的元素
        _list.pop(len(_list) - 1)
        # 排列元素
        _list.sort()
        # List 中的元素可以是不同类型的
        _list = [1,"九言",True,[233,666]]
        ''' 映射 List '''
        # 可以通过对 list 中的每个元素应用一个函数, 从而将一个 list 映射为另一个 list。
        _list=[1,233,666,3448]
        [elem*2 for elem in li] # 遍历列表然后计算表达式的值后映射，并将其输出为列表
        [(x, y) for x in [1,2,3] for y in [3,1,4] if x != y]# 结合两个列表的元素，如果元素之间不相等的话
        # 根据索引切片删除元素
        del _list[1:3]
        return
    def Tuple():
        ' Tuple（元组） '
        # Tuple 元组就是不可改变值得 List，Tuple 一旦初始化就不能修改
        _tuple = (1,2,3,4)
        # 当 Tuple 只有一个元素时，需要在这个元素后加一个逗号，否则不会被识别成元组
        _tuple = (1,)
        return
    def Sets():
        ' Sets（集合） '
        # set和dict类似，也是一组key的集合，但不存储value。由于key不能重复，所以，在set中，没有重复的key。
        # 集合是一个无序不重复元素的集。基本功能包括关系测试和消除重复元素。
        # 集合对象还支持 union（联合），intersection（交），difference（差）和 sysmmetric difference（对称差集）等数学运算。
        _set = set([1, 2, 3])
        # 重复元素在set中自动被过滤
        _set = set([1, 1, 2, 2, 3, 3])
        _mySet = set([1,6,9,8])
        return
    def Dict():
        ' Dictionary（字典） '
        '''
        字典是无序的 键：值对 （key:value 对）集合，键必须是互不相同的
        键可以是任意不可变类型，通常用字符串或数值。

        和list比较，dict有以下几个特点：

        查找和插入的速度极快，不会随着key的增加而变慢；
        需要占用大量的内存，内存浪费多。
        而list相反：

        查找和插入的时间随着元素的增加而增加；
        占用空间小，浪费内存很少。
        所以，dict是用空间来换取时间的一种方法。

        dict可以用在需要高速查找的很多地方，在Python代码中几乎无处不在，正确使用dict非常重要，需要牢记的第一条就是dict的key必须是不可变对象。
        这是因为dict根据key来计算value的存储位置，如果每次计算相同的key得出的结果不同，那dict内部就完全混乱了。这个通过key计算位置的算法称为哈希算法（Hash）。
        要保证hash的正确性，作为key的对象就不能变。在Python中，字符串、整数等都是不可变的，因此，可以放心地作为key。而list是可变的，就不能作为key：

        '''
        # Dictionary，在其他语言中也称为map，使用键-值（key-value）存储，具有极快的查找速度。
        _dict = {1:"666",555:"什么鬼","Key":"Value"}
        # 重复键会被后写入的值覆盖
        _dict = {1:"666",1:"Value"}
        # 根据key取出value
        _dict["Key"] # 若键值不存在会报错
        _dict.get("Key")# 若键值不存在会返回 None
        # 添加一个键-值，如果键已存在则会更新数据
        _dict.setdefault(2,"2222")
        # 删除指定的键值
        _dict.pop(1)
        return

    def ValueChange():
        # Python 中的变量都是对象的引用
        '''
        Python中每次赋值会改变变量的address，分配新的内存空间，所以Python中对于类型不像C那样严格要求。
        如果变量赋值的是一个可变对象（比如字典或者列表）的引用，就能修改对象的原始值——相当于传址。如果函数收到的是一个不可变对象（比如数字、字符或者元组）的引用（其实也是对象地址！！！），就不能直接修改原始对象——相当于传值。
        '''
        a = [1,2,3] # 创建数据并创建一个变量a指向它
        b = a # 将a的地址赋给了b（b指向了a的数据）
        a[0] = 666 # b[0]此时也会改变为666
        a = ["呵呵"] # 创建数据并让变量a指向它，此时b的值不会改变
        '''
        如果想新建一个与a的值相等的b变量，同时b的值与a的值没有关联时，需要使用copy与deepcopy
        copy使用场景：列表或字典，且内部元素为数字，字符串或元组
        deepcopy使用场景：列表或字典，且内部元素包含列表或字典
        '''
        a = [1,2,3]# 创建数据并创建一个变量a指向它
        b = copy.copy(a)# 无论a如何修改都不会影响b
        a = [1,2,[3,4]]
        b = copy.deepcopy(a)# 当a中有元素是列表或字典时，使用deepcopy

        ''' del 关键字 '''
        # 可以删除变量
        del a[0]
        del a
        return

# End Python_SimpleDataTypeAndVariable.py

# -----------------------------------------------------------------------------

# Python_Simple_Function.py
# 类
class YourClass:
    '类的帮助信息'

    def Function():
        '函数的帮助信息'
        # 一个函数定义会在当前符号表内引入函数名。函数名指代的值可以赋予其他的名字（即变量名），然后它也可以被当做函数使用。
        newNameForFunction = Function
        # Lambda 形式
        LambdaMethod=lambda params:print(params)

        ''' 条件判断 '''
        if _bool:
            (' 判断句为真时执行 ')
        elif _bool:
            (' 判断句为真时执行 ')
        else:
            (' 以上判断句都不为真时执行 ')

        ''' 循环 '''
        # for...in 循环，依次把list或tuple中的每个元素迭代出来
        for value in range(5):
            print(value)
            continue # continue 表示循环继续执行下一次迭代
            break # break 表示跳出最近的一级 for 或 while 循环。且不执行 else 语句块
        else:# 循环可以有一个 else 子句。在循环迭代完整个列表（对于 for ）或执行条件为 false （对于 while ）时执行，但循环被 break 中止的情况下不会执行。
        	print("循环结束")

        # while 循环，只要条件满足，就不断循环，条件不满足时退出循环。
        while _bool:
            pass # pass 占位符
        else:# 当条件为 false 时执行。循环被 break 中止的情况下不会执行。
            pass

        ''' 循环技巧 '''
        _list1=[1,2,3,4,5]
        _list2=[11,12,13,14,15]
        for i in range(len(_list1)):# 迭代列表
            print(_list1[i])
        for i,v in enumerate(_list1):# 在序列中循环时，索引位置和对应值可以使用 enumerate() 函数同时得到
            print("%s = %s"%(i,v))
        for l1,l2 in zip(_list1,_list2):# 同时循环两个或更多的序列，可以使用 zip() 整体打包
            print("%s = %s"%(l1,l2))
        for i in reversed(range(0,10,1)): #需要逆向循环序列的话，先正向定位序列，然后调用 reversed() 函数
            print(i)
        for value in sorted(reversed(_list1)):#要按排序后的顺序循环序列的话，使用 sorted() 函数，它不改动原序列，而是生成一个新的已排序的序列
            print(value)
        _dict={"Key1":"Value1","Key2":"Value2","Key3":"Value3"}
        for k,v in _dict.items():# 在字典中循环时，关键字和对应的值可以使用 items() 方法同时解读出来
            print("%s = %s"%(k,v))


        ''' 关键字 '''
        # 比较操作符 in 和 not in 审核值是否在一个区间之内。
        6 in [3,2,6,8]
        6 not in [3,2,6,8]
        # 操作符 is 和 is not 比较两个对象是否相同
        _list1 is _list2
        return

    def Function(param):
        ' 位置参数 '
        '''
        Python参数传递方式：传递对象引用（传值和传址的混合方式），如果是数字，字符串，元组则传值；如果是列表，字典则传址（可改变元素的值）；解释：在函数内对形参的修改（非元素数据）不会对实参造成任何实质的影响，因为对形参的重新赋值，只是改变了形参所指向的内存单元，却没有改变实参的指向。
        Python是不允许程序员选择采用传值还是传址的。Python参数传递采用的肯定是“传对象引用”的方式。实际上，这种方式相当于传值和传址的一种综合。
        如果函数收到的是一个可变对象（比如字典或者列表）的引用，就能修改对象的原始值——相当于传址。如果函数收到的是一个不可变对象（比如数字、字符或者元组）的引用（其实也是对象地址！！！），就不能直接修改原始对象——相当于传值。
        传值的参数类型：数字，字符串，元组（immutable）
        传址的参数类型：列表，字典（mutable）
        不止是函数里面，函数外面的变量赋值也同样遵循这个规则
        '''
        param[0] = 666 # 如果实参是列表，那么这句代码可以改变实参的值
        param = 666 # 不论实参是什么类型，这句代码都不会影响实参
        return
    def Function(defaultParam=0):
        ' 默认参数 '
        # 重要警告: 默认值只被赋值一次。这使得当默认值是可变对象时会有所不同，比如列表、字典或者大多数类的实例。
        # 定义默认参数时要注意，默认参数必须指向不变对象！
        return
    def Function(*changeableParam):
        ' 可变参数 '
        # 可变参数允许你传入0个或任意个参数，这些可变参数在函数调用时自动组装为一个tuple。
        # 将列表或元组当成可变参数传入函数 # 在list或tuple前面加一个*号，把list或tuple的元素变成可变参数传进去
        Function(*[1,2,3])# 列表的分拆，使之可以当成参数传入
        return
    def Function(**keyParam):
        ' 关键字参数 '
        # 关键字参数允许你传入0个或任意个含参数名的参数，这些关键字参数在函数内部自动组装为一个dict
        # 将字典当成关键字参数传入函数
        Function(**{'Key':'Value',1:666})
        return
    def Function(*,Key="Value",Key2):
        ' 命名关键字参数 '
        # 如果要限制关键字参数的名字，就可以用命名关键字参数。
        # 命名关键字参数需要一个特殊分隔符*，*后面的参数被视为命名关键字参数。
        return
    def Function(param,defaultParam=0,*changeableParam,Key="Value",**keyParam):
        """参数组合
        参数含义：
        param -- 位置参数
        defaultParam -- 默认参数（默认值 0）
        *changeableParam -- 可变参数
        Key -- 命名关键字参数（默认值 "Value"）
        **keyParam -- 关键字参数
        """
        # 在Python中定义函数，可以用必选参数、默认参数、可变参数、关键字参数和命名关键字参数，这5种参数都可以组合使用。
        # 但是请注意，参数定义的顺序必须是：必选参数、默认参数、可变参数、命名关键字参数和关键字参数。
        # 如果函数定义中已经有了一个可变参数，后面跟着的命名关键字参数就不再需要一个特殊分隔符*了
        print('param =',param,'defaultParam =',defaultParam,"*changeableParam =",changeableParam,"key =",Key,"**keyParam =",keyParam)
        return

    def RecursiveFunction():
        ''' 递归函数。 '''
        # 解决递归调用栈溢出的方法是通过尾递归优化，事实上尾递归和循环的效果是一样的，所以，把循环看成是一种特殊的尾递归函数也是可以的。
        # 尾递归是指，在函数返回的时候，调用自身本身，并且，return语句不能包含表达式。
        return RecursiveFunction()

    class 常见递归的实现(object):
        """docstring for 常见递归的实现."""


        def Fibonacci(self,n,a=0,b=1,_list=[]):
            '''斐波那契数列
            n -- 从 1 到 n 的黄金数列
            '''
            if n>0:
                _list.append(b)
                self.Fibonacci(n-1,b,a+b,_list)
            return _list

        def Factorial(self,n,f=1):
            """阶乘"""
            if n==1:
                return f
            else:
                return self.Factorial(n-1,n*f)

        def Hanoi(self,n,a,b,c):
            '''汉诺塔 递归实现'''
            if n==1:
                print(a," --> ",c)
            else:
                self.Hanoi(n-1,a,c,b)
                print(a," --> ",c)
                self.Hanoi(n-1,b,a,c)

        def __init__(self):
            print(self.Fibonacci(10),"\n")
            print(self.Factorial(5),"\n")
            self.Hanoi(3,"A","B","C")

class BaseCalss(object):
    """docstring for BaseCalss."""
    # 类的私有字段
    # 私有字段自动加上 _类名 所以 __filed 被编译器转换成了 _BaseCalss__filed
    # 实际上 Python 的字段封装并不是真正的封装。仍然可以通过 _BaseCalss__filed 在外部访问私有字段
    __filed="已读取基类__filed"

    # 私有方法
    def __Method(self):
        print("已执行基类__Method")


    # 类的公有字段
    filed="已读取基类filed"

    def Method(self):
        print("已执行基类Method")

    # 构造函数
    def __init__(self):
        super(BaseCalss, self).__init__()
        print(self.__filed)
        print("基类构造函数已执行")

class ChildClass(BaseCalss):
    """docstring for ChildClass."""
    def __init__(self):
        super(ChildClass, self).__init__()
        self.Method()
        print(self.filed)

        self._BaseCalss__Method()
        print(self._BaseCalss__filed)


if __name__=="__main__":
    print(__name__)
    obj=ChildClass()
    #obj=YourClass.常见递归的实现()

# End Python_Simple_Function.py