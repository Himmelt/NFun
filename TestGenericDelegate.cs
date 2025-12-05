using System;
using NFun;

class Program {
    static void Main() {
        // 测试1：使用传统的强类型委托
        var calculator1 = Funny.Calculator
            .WithFunction("add", (int a, int b) => a + b)
            .BuildForCalc<int, int>();
        var result1 = calculator1.Calc("add(x, 5)", 10);
        Console.WriteLine($"强类型委托测试: add(10, 5) = {result1}");
        
        // 测试2：使用新的通用委托方式
        Func<int, int, int> addFunc = (a, b) => a + b;
        var calculator2 = Funny.Calculator
            .WithFunction("add", (Delegate)addFunc)
            .BuildForCalc<int, int>();
        var result2 = calculator2.Calc("add(x, 5)", 10);
        Console.WriteLine($"通用委托测试: add(10, 5) = {result2}");
        
        // 测试3：使用不同参数类型的通用委托
        Func<double, double, double> multiplyFunc = (a, b) => a * b;
        var calculator3 = Funny.Calculator
            .WithFunction("multiply", (Delegate)multiplyFunc)
            .BuildForCalc<double, double>();
        var result3 = calculator3.Calc("multiply(x, 2.5)", 4.0);
        Console.WriteLine($"不同参数类型测试: multiply(4.0, 2.5) = {result3}");
        
        // 测试4：使用3个参数的通用委托
        Func<int, int, int, int> sumFunc = (a, b, c) => a + b + c;
        var calculator4 = Funny.Calculator
            .WithFunction("sum", (Delegate)sumFunc)
            .BuildForCalc<int[], int>();
        var result4 = calculator4.Calc("sum(x[0], x[1], x[2])", new[] { 1, 2, 3 });
        Console.WriteLine($"3个参数测试: sum(1, 2, 3) = {result4}");
        
        Console.WriteLine("所有测试完成!");
    }
}