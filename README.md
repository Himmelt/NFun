# NFun .NET 表达式求值器

## 关于
本项目Fork自[tmteam/NFun](https://github.com/tmteam/NFun)，并对其进行了一些修改。
主要添加功能为，扩展`WithFunction`方法，支持`Delegate`委托类型的函数。

## 安装
要安装 NFun，请在包管理器控制台中运行以下命令：

```js
PM> Install-Package Himmelt.NFun
```

## 什么是 NFun？

这是一个表达式求值器或 .NET 的迷你脚本语言。它支持处理数学表达式以及集合、字符串、高阶函数和结构。NFun 与 NCalc 非常相似，但具有丰富的类型系统和 LINQ 支持。
详细信息请参阅 ['使用指南/规范'](https://github.com/tmteam/NFun#how-to) 部分

NFun 可以执行简单的求值
```cs
  double d = Funny.Calc<double>(" 2 * 10 + 1 ") // 21  
  bool b   = Funny.Calc<bool>("false and (2 > 1)") // false

  // 'age' 和 'name' 来自输入 'User' 模型的属性 
  string userAlias = Funny.Calc<User,string> (
                       "if(age < 18) name else 'Mr. {name}' ", 
                        inputUser)  
```
也可以执行复杂的、多复合输入和输出的操作
```cs   
  // 求值多个值并将它们设置到 'Person' 对象的属性中 
  // 输入和输出 'age', 'cars' 和 'birthYear' 都是 'Person' 对象的属性 
  var personModel = new Person(birthYear: 2000);
  
  Funny.CalcContext(@"   
     age = 2022 - birthYear 
     cars = [
   	    { name = 'lada',   cost = 1200, power = 102 },
   	    { name = 'camaro', cost = 5000, power = 275 }
     ]
     ", personModel);
  
  Assert.Equal(22,   personModel.Age);
  Assert.Equal(2,    personModel.Cars.Count());
  Assert.Equal(1200, personModel.Cars[0].Cost);
  
```
也支持底层硬核 API
```cs
  var runtime = Funny.Hardcore.Build("y = 2x+1");

  runtime["x"].Value = 42; //写入输入数据
  runtime.Run(); //运行脚本
  var result = runtime["y"].Value //收集结果
  
  Console.WriteLine("脚本包含这些变量:"
  foreach(var variable in runtime.Variables)
     Console.WriteLine(
        "{variable.Name}:{variable.Type} {variable.IsOutput?"[OUTPUT]":"[INPUT]"}");
```

## 主要功能

- 算术、按位、逻辑和比较运算符
```py	
  # 算术运算符: + - * / % // ** 
  y1 = 2*(x//2 + 1) / (x % 3 -1)**0.5 + 3x
  
  # 按位:     ~ | & ^ << >> 
  y2 = (x | y & 0xF0FF << 2) ^ 0x1234
	
  # 逻辑和比较:    and or not > >= < <= == !=
  y3 = x and false or not (y>0)
```

- If 表达式
```py
  simple  = if (x>0) x else if (x==0) 0 else -1
  complex = if (age>18)
                if (weight>100) 1
                if (weight>50)  2
                else 3
            if (age>16) 0
            else       -1     
```
- 用户函数和泛型算术
```py
  sum3(a,b,c) = a+b+c
  
  r:real = sum3(1,2,3)
  i:int  = sum3(1,2,3)
```
- 数组、字符串、数字、结构和高阶函数支持
```py
  out = {
    name = 'etaK'.reverse()
    values = [0xFF0F, 2_000_000, 0b100101]
    items = [1,2,3].map(rule 'item {it}')
  }
```
- 严格类型系统和类型推导算法
```py
  y = 2x
  z:int = y*x
  m:real[] = [1,2,3].map(rule it/2)
```
- 双精度或十进制算术
- 语法和语义定制
- 内置函数
- 注释

## 如何使用

[API - 指南和示例](https://github.com/tmteam/NFun/blob/master/Examples/ApiUsageExamplesAndExplanation.cs)

[语法 - 指南和示例](https://github.com/tmteam/NFun/blob/master/Examples/SyntaxExamplesAndExplanation.cs)

[内置函数](https://github.com/tmteam/NFun/blob/master/Specs/Functions.md)

----
详细的规范比没有规范好

[详细规范: 基础](https://github.com/tmteam/NFun/blob/master/Specs/Basics.md)

[详细规范: 运算符](https://github.com/tmteam/NFun/blob/master/Specs/Operators.md)

[详细规范: 数组](https://github.com/tmteam/NFun/blob/master/Specs/Arrays.md)

[详细规范: 文本(字符串)](https://github.com/tmteam/NFun/blob/master/Specs/Texts.md)

[详细规范: 结构](https://github.com/tmteam/NFun/blob/master/Specs/Structs.md)

[详细规范: 规则(匿名函数)](https://github.com/tmteam/NFun/blob/master/Specs/Rules.md)

[详细规范: 类型](https://github.com/tmteam/NFun/blob/master/Specs/Types.md)
