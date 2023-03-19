// See https://aka.ms/new-console-template for more information


using System.Data;
using System.Reflection.Metadata;
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

    private static (string name,double address) Calulate(IEnumerable<double> values)
    {
        
        int count = 0;
        double sum = 0.0;
        foreach (var value in values)
        {
            count++;
            sum += value;
        }
       
        return ("suraj",sum);
    }

    public static async ValueTask<string> task1() // ValueTask is a readonly strucutre
    {
        Console.WriteLine("waiting");
        await Task.Delay(2000);
      var data =  await task2();
        return data;
        
    }
    public static async ValueTask<string> task2()
    {
        Console.WriteLine("request come in task2");
        await Task.Delay(5000);
        return "this is the task";
    }

    public static void notChangeAValue(in int x,in int y,ref int result)
    {
        result = x + y;
    }

    // this below function readonly keyword not work instead we use in 
    /*public static void Add(ref readonly int x, ref readonly int y, out int result)
    {
        result = x + y;
    }*/

    public static void takeInput(int a,int b ,int c ,int d ,string e)
    {
        Console.WriteLine("get the value");
    }

    // generic pattern matching
    /*public static void checkPattern<T>(T shape) where T:class
    {
        switch (shape)
        {
            case PattenMatching7.Rectangle:
                Console.WriteLine("this is rectangle");
                break;
            case PattenMatching7.Square:
                Console.WriteLine("this is square");
                break;
            default:
                Console.WriteLine("donot now about this type");
                break;
        }
    }*/






    public static void Main(String[] args)
    {
        /*----------------------- first we will perform the c# 7 version feature------------------------------------------ */


        // 1.----- out parameter enhancement
  /*      OutParameterEnhance.takeOutParameter(out string userName, out string password);
        Console.WriteLine(userName + " " + password);*/
        



        // 2.----- pattern matching in c# 7 
        // we implement pattern matching with two expression first one, is operator and second one, switch case

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


        // *****************New Way of pattern matching in c# 7  **********************************

        /*  switch (f)
          {
              case PattenMatching7.Rectangle rec when rec.Length==rec.Breadth: // line 1

                  Console.WriteLine("this is square "+rec.Length +" "+rec.Breadth);
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
         * here in above code  line 1 it will first check  f is of  Square type or not if it is  of Square type then it will cast
           f to Square type and then f will assigned to variable sq automatically.
        
         */


        // one more example with the help of is operator  
        /*        if(f is PattenMatching7.Square s)
                {
                    Console.WriteLine(s.length);
                }*/


        // 3. Digit separator :it say you can separate very large number with underscore(_) or multiple underscore(_)
        //    it can also be used with float,double .
        //  ex:
        /*var abc = 332323232323232323;
        var abcDigitSeperator = 332_323_232_323_232_323;
        Console.WriteLine("without digit seperator " + abc);
        Console.WriteLine("with digit seperator " + abcDigitSeperator);*/



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
        /*var values = new List<double>() { 10, 20, 30, 40, 50 };
        var result = Calulate(values);
        result.name = "hello";
        Console.WriteLine($"There are {result.name} values and their sum is {result.address}");*/


        //4. local Function: this are that function that are defined in an already defined fucntion. in simpler words
        // this local fuction are private function of an existing function.
       /* void mainPrivateFunction()
        {
            Console.WriteLine("this function is only called inside the  main function");
        }*/
        // how to call this function
      /*  mainPrivateFunction()*/;



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
        /*  ref int returnSum(int[] num)
          {
              return ref num[0];
          }
          int[] x = new int[] { 1, 4, 5 };

          ref var getValue =ref returnSum(x);
          getValue = 2;
          Console.WriteLine(getValue);
          Console.WriteLine("it will change the x arry element at 0 "+ x[0]);*/



        //6. expression bodied members: it allows us to provide the better implementation of the member in a readable format

        // 1. we define expression bodied methods.

        /* ExpressionBodedMembers ex = new ExpressionBodedMembers("suraj");
         Console.WriteLine(ex.readData);
         ex.readData = "sahil";
         Console.WriteLine(ex.readData);*/


        // 7. generalized async return type in c# :
        /*
         * before c# 7 we use Task that is a refrence type.
         * after c# 7 we use value task that is a ValueTask<T> means it is lightweight then the Task
         example:
         */
        /*var data = Version.task1().Result;
        Console.WriteLine(data);*/





        /*  ------------------------------------- c# 7.1 Feature ------------------------------------------*/

        // 1. Async Main
        /* example: above code will be call as */
        /* var data = await Version.task1();
         Console.WriteLine(data);*/

        //2. default literal expression:A default literal expression produces the default value of a type
        // old way:
        /*int data = default(int);*/

        //new way:
        /* long data = default;
         Console.WriteLine(data);*/


        //3. Inferred Tuple Name:we can name tuple members using variable name
        /*        var count = 20;
                var size = 6;
                var countSize = (count, size);
                Console.WriteLine(countSize.count);
                Console.WriteLine(countSize.size);*/

        // 4 pattern matching generic type
        /*  PattenMatching7.Square sq = new PattenMatching7.Square();
          Version.checkPattern<PattenMatching7.Figure>(sq);*/



        /*-----------------------------c# 7.2 features.--------------------------------*/

        // 1. ref readonly
        /* int a = 20;
         int b = 30;
          int c = 0;
         notChangeAValue(a, b,ref c);
         Console.WriteLine(c);*/

        //2. private protected access modifier.
        // now we will check private protected modifier will be executed here
        /* Child1 c = new Child1();
         c.callParent();*/

        // we will not direct access the member inside this method
        /* Parent p = new Parent();
         p.message();*/


        /* 3. Non trailing Named Argument
         * With C# 7.2 it is now allowed to have named arguments also after positional ones. 
         * This feature is called non-trailing named arguments.
         */
        /*Version.takeInput(1, b: 2, 3, e: "hello", d: 4);*/


        /*----------------c# 7.3 features -------------------------*/
        /*  1. ref Local reassignment*/
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

    }
}
