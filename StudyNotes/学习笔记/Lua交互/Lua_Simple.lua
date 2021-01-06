-- 单行注释
--[[
跨行注释
--]]
-- 尽管在编写时可以不加分号，但尽量不要这么做。
print("Holle World!");
print("你好，世界！");


    -- 数据类型
if(false)then
    _nil    = nil -- null -- 所有没有被赋值过的变量默认值为nil，给变量赋nil可以收回变量的空间。
    _boolen = false -- 布尔值
    _number = 666 -- 双精度浮点数
    _string = "Text" -- 字串符
    _string = "ab".."cd" -- .. 两个点用来连接字串符
    _string = #_string -- #用来计算字符串的长度，放在字符串的前面 -- 也可以用来计算 Table 的长度
    string.format("格式化文本：%d",666) -- 格式化字串符
--[[
    %d
    十进制整数
    %o
    八进制整数
    %x
    十六进制整数，大写的话为 %X
    %f
    浮点型 格式 [-]nnnn.nnnn
    %e
    科学表示法 格式 [-]n.nnnn e [+|-]nnn, 大写的话为 %E
    %g
    floating-point as %e if exp. < -4 or >= precision, else as %f ; uppercase if %G .
    %c
    character having the (system-dependent) code passed as integer
    %s
    没有\0的字符串
    %q
    双引号间的string, with all special characters escaped
    %%
    ' % ' 字符
    %a 字母
    %c控制字符
    %d多个数字
    %l 小写字母
    %p标点符号
    %s空白字符
    %x十六进制
    %z内部表示为0的字符
--]]

    _table = {1,2,3,4}-- 关联数组
    -- Table是 Lua 唯一的数据结构，
    -- 不带键值的 Table 是有序排列，默认索引从 1 开始，也可以指定索引值
    _table[-2] = -2
    -- 带键值得 Table 是无序排列，迭代时会放在有序列的后面
    _table["NewKey"] = "NewValue"-- 添加新的键值

    -- 返回值、函数调用和赋值都可以使用长度不匹配的list。
    -- 不匹配的接收方会被赋为nil；
    -- 不匹配的发送方会被忽略。
    x, y, z = 1, 2, 3, 4 -- 现在x = 1, y = 2, z = 3, 而 4 会被丢弃。
    x, y, z = 1 -- 现在x = 1 而 y, z = nil
end


-- 函数
-- 在 Lua 中，函数是被看作是"第一类值（First-Class Value）"，函数可以存在变量里，定义函数的函数名就相当于一个变量
-- 函数可以有多返回值
function Function (...)-- 三个点 ... 表示可变参数
    _boolen = false
    -- 判断语句
    if _boolen then
        -- 在该表达式为真时执行
    elseif _boolen then
        -- 在该表达式为真时执行
    else
        -- 在以上都不为真时执行
    end

    -- 循环语句
    -- for 循环
    for i = 1, 10, 2 do
        -- i 从 1 变化到 10，每次变化以 2 为步长递增 i，并执行一次循环体
        break -- 跳出循环
        -- lua 中没有 continue 关键字，用以下方法可以变相实现 continue 功能
        --[[
        while (true) do -- 套嵌一个只会循环一次的循环体
            if _boolen then
                break
            end -- 如果判断式为真将会执行类似 continue 的功能
            -- body...
            break
        end
        --]]
    end
    _list={111,222,333,444}
    -- 泛型 for 循环、迭代器
    for i,v in pairs(_list) do
        -- 遍历数组的值，其中 i 是数组索引，v 是索引对应的元素值
        -- pairs()将遍历Table中所有的key，并且除了迭代器本身以及遍历表本身还可以返回nil;
        -- ipairs()遍历从 1 开始，如果索引对应的值为 nil 则退出遍历。它只能遍历到表中出现的第一个不是整数的key
    end
    -- while 循环
    while _boolen do
        -- 在该表达式为真时执行循环体
    end
    -- repeat..until 循环
    repeat
        -- 先执行一次循环，然后判断表达式
    until _boolen


    return "Function已执行"
end
Method = Function -- 函数重命名
Method = function () return "匿名函数已执行"; end


-- 全局与局部
local function LocationFunction ()
    -- 局部函数，其它模块中不可访问，同文件下只有当运行到该局部函数时才会被访问
end
function GlobalFunction ()
    -- 局部变量的作用域为从声明位置开始到所在语句块结束。
    local _localV = 1
    -- 在lua中声明的变量全部是全局变量，无论是在语句块还是函数中。除非加 local 将其声明为局部变量
    globalV=1
end
GlobalFunction()-- 运行一次函数，声明变量
--print("_localV = ".._localV)
print("_globalV = "..globalV)
print(_localV, globalV)-- 局部变量不能读取，而全局变量能被读取


-- 闭包详解
-- 词法定界：当一个函数内嵌套另一个函数的时候，内函数可以访问外部函数的局部变量，这种特征叫做词法定界
-- 任何声明在另一个函数内部的函数都可以称为闭包。
-- 可以把闭包的“闭包外局部变量”看成是一个对象中的私有变量
function Closure (x) -- 函数的参数相当于局部变量
    y = 222 -- y 是一个全局变量
    local z = 333 -- 尽管 z 在这里相对于 Closure 是局部变量，但它仍可以被函数 InsideFun访问，也就是说 z 的值会被闭包函数记住，它不会随着外部函数的作用域结束而消失。
    local function InsideFun (i) -- InsideFun 是函数 Closure 的局部函数，它可以访问 Closure 的所有成员。它是一个闭包函数，也就是说它会保存x、y的值直到生命周期结束。
        print(x, y, z)
        return x + y + z + i
    end
    return InsideFun
end

if false then
Closure(111)
    insinde1 = Closure(111)
    insinde2 = Closure(111)
    print(insinde1(1)) -- 闭包函数的“闭包外局部变量”作用域只在该闭包内有效。insinde1 和 insinde2 两个闭包的“闭包外局部变量”互不干扰
    print(insinde2(10000))
end
-- 闭包及匿名函数的综合使用
function Function1 (x)
    -- 调用 Function1 时，会创建用于返回的函数，并且能记住变量x的值
    return function (y) return x + y end -- 内部匿名函数可以访问外部函数的变量 x
end


-- 异常处理
function Error ()
    function SomeFun (_bool)
        if _bool then
            return "value";
        else
            error("抛出一个错误");
        end
    end

    -- 以保护模式执行　SomeFun
    local status,value = pcall(SomeFun, true);
    -- 如果 status 为真则无异常，为假则捕捉到异常
    -- 如果有异常则 value 为错误对象，否则为调用函数的返回值
    if status then
        -- 无异常，返回调用函数的返回值
        return value;
    else
        -- 有异常，显示异常信息
        print(value);
        return;
    end
end


-- Lua_Module.lua
-- 模块类似于一个封装库
-- Lua 的模块是由变量、函数等已知元素组成的 table，因此创建一个模块很简单，就是创建一个 table，然后把需要导出的常量、函数放入其中，最后返回这个 table 就行。

-- 文件名为 Lua_Module.lua
-- 定义一个名为 Lua_Module 的模块

Lua_Module = {};

-- 定义一个常量
Lua_Module.CONSTANT = 3.1415926; -- 虽然它的值可以被更改，但你不应该这么做

-- 定义一个函数
function Lua_Module.GlobalFunction ()
	print("这是一个公有函数");
end


return "lua 返回值";