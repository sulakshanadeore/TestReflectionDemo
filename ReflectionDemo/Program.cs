﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // dynamically load assembly from file Test.dll
            Assembly testAssembly = Assembly.LoadFile(@"D:\AllDemos\CAPG_Nov\Test\Test\bin\Debug\Test.dll");

            Type[] typename=testAssembly.GetTypes();

            foreach (Type t in typename) {

                Console.WriteLine(t.Name);
                Console.WriteLine(t.FullName);
                Console.WriteLine(t.IsClass);
                Console.WriteLine(t.IsEnum);
            }
      


            // get type of class Calculator from just loaded assembly
            Type calcType = testAssembly.GetType("Test.Calculator");

            PropertyInfo[] propinfo=calcType.GetProperties();
            Console.WriteLine("Property Info");
            foreach (var item in propinfo)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.PropertyType);
            }

            

            //// create instance of class Calculator
            object calcInstance = Activator.CreateInstance(calcType);


            //// get info about property: public double Number
            PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");

            //// get value of property: public double Number
            double value = (double)numberPropertyInfo.GetValue(calcInstance, null);

            //// set value of property: public double Number
            numberPropertyInfo.SetValue(calcInstance, 10.0,null);

            //// get info about static property: public static double Pi
            PropertyInfo piPropertyInfo = calcType.GetProperty("Pi");

            //// get value of static property: public static double Pi
            double piValue = (double)piPropertyInfo.GetValue(null, null);

            MethodInfo[] methodinfo=calcType.GetMethods();

            //// invoke public instance method: public void Clear()
            calcType.InvokeMember("Clear",
                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                null, calcInstance, null);


            //// invoke private instance method: private void DoClear()
            //calcType.InvokeMember("DoClear",
            //    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
            //    null, calcInstance, null);


            //// invoke public instance method: public double Add(double number)
            double value1 = (double)calcType.InvokeMember("Add",
                BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                null, calcInstance, new object[] { 20.0 });
            Console.WriteLine("The answer of add is =" + value1);


            //// invoke public static method: public static double GetPi()
             piValue = (double)calcType.InvokeMember("Pi",
                BindingFlags.GetProperty| BindingFlags.Static | BindingFlags.Public,
                null, null, null);
            Console.WriteLine("Value of pi= "  + piValue);


            //// get value of private field: private double _number
            //double value = (double)calcType.InvokeMember("_number",
            //    BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
            //    null, calcInstance, null);
            Console.ReadLine();

        }
    }
}
