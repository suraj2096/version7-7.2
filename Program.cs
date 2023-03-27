// See https://aka.ms/new-console-template for more information


using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Versions;

class Version
{

   


    // old way to define tuple in method
    /* private static Tuple<int, double> Calulate(IEnumerable<double> values)
     {
         int count = 0;
         double sum = 0.0;
         foreach (var value in values)
         {
             count++;
             sum += value;
         }
         //Creating an object of Tuple class by calling the static Create method
         Tuple<int, double> t = Tuple.Create(count, sum);
         //Returning the tuple instance
         return t;
     }*/

    // new way to define tuple in method.

    private static (string name, double address) Calulate(IEnumerable<double> values)
    {

        int count = 0;
        double sum = 0.0;
        foreach (var value in values)
        {
            count++;
            sum += value;
        }

        return ("suraj", sum);
    }

    public static async ValueTask<string> task1() // ValueTask is a readonly strucutre
    {
        Console.WriteLine("waiting");
        await Task.Delay(2000);
        var data = await task2();
        return data;

    }
    public static async ValueTask<string> task2()
    {
        Console.WriteLine("request come in task2");
        await Task.Delay(5000);
        return "this is the task";
    }

    public static void notChangeAValue(in int x, in int y, out int result)
    {
        result = x + y;
    }

    // this below function readonly keyword not work instead we use in 
    /*public static void Add(ref readonly int x, ref readonly int y, out int result)
    {
        result = x + y;
    }*/

    public static void takeInput(int a, int b, int c, int d, string e)
    {
        Console.WriteLine("get the value");
    }



    // ref readonly function
    








public static void Main(String[] args)
    {



        /*----------------------- first we will perform the c# 7 version feature------------------------------------------ */


        // 1.----- out parameter enhancement
  /*      OutParameterEnhance.takeOutParameter(out string userName, out string password);
        Console.WriteLine(userName + " " + password);*/
        



        // 2.----- pattern matching in c# 7 
        // we implement pattern matching with two expression: first one with the help of is operator and second one, switch case

        PattenMatching7.Figure  f = new PattenMatching7.Rectangle { Length=10,Breadth=10 };


        //***********   Older way of pattern mtching before c# 7  ***********************
        // first we will look at the previous version before c# 7 how pattern matching done


        /* switch (f)
         {
             case PattenMatching7.Square:
                 PattenMatching7.Square? sq = f as PattenMatching7.Square; // line 1
                 Console.WriteLine("this is square");
                 break;
             case PattenMatching7.Rectangle:
                 PattenMatching7.Rectangle? rec = f as PattenMatching7.Rectangle;
                 Console.WriteLine("this is rectangle");
                 break;
             case PattenMatching7.Circle:
                 PattenMatching7.Circle? cr = f as PattenMatching7.Circle;
                 Console.WriteLine("this is circle");
                 break;
             default:
                 Console.WriteLine("this is not a shape");
                 break;
         }*/

        /* here in the above code:
            * we will first check the expression and then we will explicity type casting as shown in
              the line one. 
            * this problem will be solved in c# version 7 the below code will demonstrate the same code above 
              but with the new feature of pattern matching in c# 7 
        */


        // *****************  New Way of pattern matching in c# 7  **********************************

        /*switch (f)
        {
            case PattenMatching7.Rectangle rec when rec.Length == rec.Breadth: // line 1

                Console.WriteLine("this is square " + rec.Length + " " + rec.Breadth);
                break;
            case PattenMatching7.Rectangle rec:
                Console.WriteLine(rec.Length + " " + rec.Breadth);
                break;
            case PattenMatching7.Circle cr:
                Console.WriteLine(cr.Radius);
                break;
        }*/

        /*
           * Here one line do two things first one is type checking and second one is casting.
           * here in above code  line 1 it will first check  f is of  Rectangle type or not if it is  of rectangle type then it will cast
             f to Rectangle type and then f will assigned to variable rec automatically.

         */


        // one more example with the help of is operator  
        /*        if(f is PattenMatching7.Square s)
                {
                    Console.WriteLine(s.length);
                }*/


        // 3. Digit separator :it say you can separate very large number with underscore(_) or multiple underscore(_)
        //    it can also be used with float,double .
        //  ex:
        /*
        var abc = 332323232323232323;
        var abcDigitSeperator = 332_323_232_323_232_323;
        Console.WriteLine("without digit seperator " + abc);
        Console.WriteLine("with digit seperator " + abcDigitSeperator);
        */



        //4: tuple emprovement

        // in old version we do the work like this
        /*var values = new List<double>() { 10, 20, 30, 40, 50 };
        Tuple<int, double> t = Calulate(values);
        Console.WriteLine($"There are {t.Item1} values and their sum is {t.Item2}");*/

        /*
         * in the above code there are problems that solve in c# 7 :
         * first problem is tuple is a reference type means memory is allocated on heap . it is major issues for 
            application that performance is most important for him.
         * the element in tuple donot have any name it will be refer by name item1,item2 and so on. 
         */


        // but in c# 7 it will change 
        // tuple becomes the itegral part of the code.
        /* var values = new List<double>() { 10, 20, 30, 40, 50 };
         var result = Calulate(values);
         Console.WriteLine(result.GetType());
         result.name = "hello";
         Console.WriteLine($"There are {result.name} values and their sum is {result.address}");*/


        /* 
            * here in the above code the tuple is a value type means memory is allocated on stack. 
            * the element in tuple have nay name it will refer by name as you see in the above code like result.name
            * this tuple is mutable because it a value tuple type not a tuple type and value tuple is a structure.
            * major difference between ValueTuple and Tuple is:
                                        * the ValueTuple is a mutable while Tuple is immutable.
         */


        //4. local Function: this are that function that are defined in an already defined fucntion. in simpler words
        // this local fuction are private function of an existing function.
        /*void mainPrivateFunction()
        {
            Console.WriteLine("this function is only called inside the  main function");
        }
        mainPrivateFunction();*/




        /*5. Ref local in c# 7
         * the ref local is a new variable type that is used to store the refrence
         * that means local variable can also be declared with the ref modifier.
         *example:
         */
        /* var num1 = 2;
         ref var num2 = ref num1;
         num2 = 20;
         Console.WriteLine($"the num1 value will be changed {num1}");*/

        /* ref return in cz# 7:
        * Before C# 7.0, the ref was only used to be passed as a parameter in a method, however, 
          there was no provision to return it and use it later. With C# 7.0, this constraint 
          has been waived off and now you can return references from a method as well. 
          This change is really adding flexibility to handle the scenarios when we want 
          references to return in order to make an in-lined replacement.
       * for example:
         */
        /* ref int returnSum(int[] num)
         {
             return ref num[0];
         }
         int[] x = new int[] { 1, 4, 5 };

         ref var getValue = ref returnSum(x);
         getValue = 2;
         Console.WriteLine(getValue);
         Console.WriteLine("it will change the x arry element at 0 " + x[0]);*/



        //6. expression bodied members: it allows us to provide the better implementation of the member in a readable format

        // 1. we define expression bodied methods.

        /* ExpressionBodedMembers ex = new ExpressionBodedMembers("suraj");
         Console.WriteLine(ex.readData);
         ex.readData = "sahil";
         Console.WriteLine(ex.readData);*/



        // 7. generalized async return type in c# :
        /*
         * before c# 7 we use Task that is a refrence type.
         * after c# 7 we use Value Task that is a ValueTask<T> means it is lightweight then the Task
         example:
         */
        /*var data = Version.task1().Result;
        Console.WriteLine(data);*/



        /* 8. Deconstruction:
         * it allows us to extract properties of a class, elements of a tuple that you need , and stored it in a distinct 
           variable. means extract that properties that you need not others.
        * it is used to access the class variables outside the class by assigning them into new variables.
         */

        /* we use deconstructor in a class*/
        /* DeconstructClass deconstructVar = new DeconstructClass(1, "suraj", "chandigarh");
         var (name, address) = deconstructVar;
         Console.WriteLine($"the name is {name} and address is {address}");*/

        /* we use deconstruct in a tuple*/
        /*var values = new List<double>() { 10, 20, 30, 40, 50 };
        var (name,_) = Calulate(values); // _ is a discard.
        Console.WriteLine(name);*/




        // 9. throw:this keyword is used to signal the occurence of an exception during program execution
        /* int? a = null;
         _=a ?? throw new NullReferenceException(message:"the a is null plesse enter the value");*/






        /*  ------------------------------------- c# 7.1 Feature ------------------------------------------*/

        // 1. Async Main : Main method return Task.
        /* example: above code will be call as */
        /* var data = await Version.task1();
         Console.WriteLine(data);*/

        //2. default literal expression:A default literal expression produces the default value of a type. it is 
        //   achieved using default keyword.


        // old way:
        /*int data = default(int);*/

        //new way:
        /* int data = default;
         Console.WriteLine(data);*/


        //3. Inferred Tuple elements Name:

        // before c# 7.0 we had to specify the name of tuple members or elements
        //ex:
        /* var name = "suraj";
         var age = 20;
         var tuple = (Name: name, Age: age);*/



        // In C# 7.1 we don’t have to specify member names anymore if we are using variables to define tuple:
        //ex:
        /*      var count = 20;
                var size = 6;
                var countSize = (count, size);
                Console.WriteLine(countSize.count);
                Console.WriteLine(countSize.size);*/






        /*-----------------------------c# 7.2 features.--------------------------------*/

        //1. ref readonly: ref readonly modifier on method returns to indicate that the returned value should
        //   be treated as read-only, and that it should be passed by reference rather than by value. 

        /*int[] number = { 1, 2, 3, 4 };

        ref readonly int getFirstNumber(int[] arr)
        {
            return ref number[0];
        }
        ref readonly var firstNumber = ref getFirstNumber(number);
        Console.WriteLine(firstNumber);*/






        //2. private protected access modifier: this means we can accesss method or properties whose 
        // access specifier is private protected in the child class that inherit from the parent class . 
        // Note that we cannot access members directly in the main method whose access modifier is private protected.

        // now we will check private protected modifier will be executed here
        /* Child1 c = new Child1();
         c.callParent();*/

        // we will not direct access the member inside this method
        /* Parent p = new Parent();
         p.message();*/




        /* 3. Non trailing Named Argument
         * With C# 7.2 it is now allowed to have named arguments also after positional ones.
         * or
         * Named argument can be followed by positonal argument ones.
         * This feature is called non-trailing named arguments.
         */

        // old version this is not allowed 
        /*Version.takeInput(1, b: 2, 3, e: "hello", d: 4);*/


        // now c# 7.2 it is now allowed.
        /*Version.takeInput(1, b: 2, 3, e: "hello", d: 4);*/




        /* 4.  ref conditional expression
         * here it will alllowed to bind variable conditionally by reference to a different expression
        example:
         */



        // old version this will not be allowed:
        /*
        ref var max = ref b; // requires initialization
        if (a > b)
        {
            max = ref a;       // not allowed in C# 7.2
        }
        */



        // in c# 7.2 it is now allowed to conditonally store reference in a variale to a another variable.
        /*var a = 20;
        var b = 30;
        ref var c = ref(a > b ? ref a : ref b);
        Console.WriteLine(c);*/





        //5. in modifier on parameters:
        //to specify that an argument is passed by reference but not modified by the called method.

        // example:
        /*var x = 20;
        var y = 30;
        notChangeAValue(x, y, out var result);
        Console.WriteLine(result);*/



        




        /*----------------c# 7.3 features -------------------------*/


        /*  1. ref Local reassignment: here we can reassign to ref local variables */
        /*  int a = 5;
          int b = 3;
          ref int c = ref b;
          if (a > b)
          {
              c = ref a;
          }
          Console.WriteLine(c);*/

        /* 2. Comparison between tuples:*/
        var tuple1 = (1, 2);
        var tuple2 = (2, 3);    
       /* var match = tuple1 != tuple2;*/
        var match = tuple1 == tuple2;
        Console.WriteLine(match);


        /*-------------------------------- c# 8 features --------------------------------------------*/

        /* 1. Readonly Members:
         * In C# 8, you can use the readonly keyword to declare fields that can only be set in the constructor and 
            cannot be modified later on. 
         * The readonly keyword can only be used for fields, not for properties.
         * However, properties are not fields - 
           they are methods that provide access to a private field. Therefore, 
           you cannot use the readonly keyword with a property.
         */
        // example:
        /* ReadonlyProperty readProperty = new ReadonlyProperty("suraj",21);
          console.writeLine(readProperty.Name);
          console.writeLine(readProperty.Age);
         readProperty.Name = "rahul" // this will gave error in compile time a readonly field cannot be initialized.*/


        /* 2. Default Interface Method
         *  This feature allows you to provide default implementations for methods in interfaces, 
             which can then be overridden by implementing classes if needed.
         * here the advantage for the classes if they implement interface  then they have option that they need to
          modify this default interface method or they use the default functionality that are defined by the 
          default interface method.
         */
        // example:
        /* DefInterface classImplement = new ClassImplementInter();
          Console.WriteLine(classImplement.call());
          classImplement.DefaultMessage();*/


        /*3. pattern matching enhancement:  */
        /* 
        1. property pattern:
            * the property pattern can be used for checking and comparing values of properties. It tests 
               whether an expression properties or fields match the values of specified properties/field.
               Each corresponding property or field must be match & the expression must not be null.
           example:
        */
        /* PattenMatching7.Circle circle1 = new PattenMatching7.Circle { Radius = 10 };
         if(circle1 is PattenMatching7.Circle{Radius:10 } circle2) {
             Console.WriteLine("it is circle and the radius is " + circle2.Radius);
         }*/


        /*
         2. var pattern:
           * var pattern can be used to match any expression and then assigned it to a new declared variable.
           * The var pattern is useful if you want to store property values in a variable if other patterns are matching.
        example:
         */
        /*PattenMatching7.Rectangle rectangle = new PattenMatching7.Rectangle { Length=10,Breadth=20};
        if(rectangle is PattenMatching7.Rectangle { Length:var length })
        {
            Console.WriteLine("the length of a rectangle that stored in a variable length " +length);
        }*/


        /*
         3. positional pattern:
             * Positional pattern is usedful when testing a type that can be deconstructed.
             * The positional pattern can deconstruct an input expression and then test if the resulting variables 
               match against a pattern specified in parentheses.
        example:
         */
        /*PattenMatching7.Rectangle rec= new PattenMatching7.Rectangle { Length= 10,Breadth=20 }; 
        if(rec is (10,20) rect)
        {
            Console.WriteLine(rect.Length + " " + rect.Breadth);
        }*/

        // here the pattern reflect position of each variable has within the deconstruct.


        /*
         4. tuple pattern :
           * tuple pattern can be used to pattern match multiple input values . 
        example:
         */
        /*  string returnDescriptionofShape(string shape,int length,int height)
       {
           return (shape, length, height) switch
           {
               ("Rectangle", 2, 1) => "this is a recatangle",
               ("square", 10, 10) => "this is a square",
               (_, _, _) => "this is not a valid pattern"
           };
       }
      ;
       Console.WriteLine(returnDescriptionofShape("Rectangle", 2, 1));*/

       


        // 4. using declaration:
         // using var outPattern = new OutParameterEnhance();


        // now in the above code the outPattern will destroy when program control react end of the block of main method 
       // which is not possible in using statement.




        //5. 
      






    }
}
