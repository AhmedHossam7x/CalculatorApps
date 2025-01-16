using System.Data;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a DataTable to hold the operation history
            DataTable history = new DataTable();
            history.Columns.Add("Operation", typeof(string));
            history.Columns.Add("Operands", typeof(string));
            history.Columns.Add("Result", typeof(double));

            Console.WriteLine("Welcome to the Unlimited Advanced Calculator!");
            Console.WriteLine("Available operations:");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Square Root (sqrt)");
            Console.WriteLine("6. Power (^)");
            Console.WriteLine("7. Sine (sin)");
            Console.WriteLine("8. Cosine (cos)");
            Console.WriteLine("9. Tangent (tan)");
            Console.WriteLine("Type 'history' to view calculation history.");
            Console.WriteLine("Type 'clear' to clear the history.");
            Console.WriteLine("Type 'exit' to quit.");

            while (true)
            {
                Console.WriteLine("\nEnter your operation (or type 'exit', 'history', 'clear'): ");
                string operation = Console.ReadLine().ToLower();
                if (operation == "exit")
                {
                    break;
                }

                if (operation == "history")
                {
                    // Display the history of calculations
                    DisplayHistory(history);
                    continue;
                }

                if (operation == "clear")
                {
                    // Clear the history
                    history.Rows.Clear();
                    Console.WriteLine("History cleared.");
                    continue;
                }

                string[] operands;
                double result = 0;

                switch (operation)
                {
                    case "+":
                    case "addition":
                        Console.WriteLine("Enter numbers separated by spaces:");
                        operands = Console.ReadLine().Split(' ');
                        result = operands.Select(double.Parse).Sum();
                        history.Rows.Add("Addition", string.Join(", ", operands), result);
                        Console.WriteLine($"Result: {result}");
                        break;

                    case "-":
                    case "subtraction":
                        Console.WriteLine("Enter numbers separated by spaces:");
                        operands = Console.ReadLine().Split(' ');
                        result = operands.Select(double.Parse).Aggregate((a, b) => a - b);
                        history.Rows.Add("Subtraction", string.Join(", ", operands), result);
                        Console.WriteLine($"Result: {result}");
                        break;

                    case "*":
                    case "multiplication":
                        Console.WriteLine("Enter numbers separated by spaces:");
                        operands = Console.ReadLine().Split(' ');
                        result = operands.Select(double.Parse).Aggregate((a, b) => a * b);
                        history.Rows.Add("Multiplication", string.Join(", ", operands), result);
                        Console.WriteLine($"Result: {result}");
                        break;

                    case "/":
                    case "division":
                        Console.WriteLine("Enter numbers separated by spaces:");
                        operands = Console.ReadLine().Split(' ');
                        double[] numArray = operands.Select(double.Parse).ToArray();
                        if (numArray.Contains(0))
                        {
                            Console.WriteLine("Error: Division by zero is not allowed!");
                        }
                        else
                        {
                            result = numArray.Aggregate((a, b) => a / b);
                            history.Rows.Add("Division", string.Join(", ", operands), result);
                            Console.WriteLine($"Result: {result}");
                        }
                        break;

                    case "sqrt":
                        Console.Write("Enter a number: ");
                        double num = Convert.ToDouble(Console.ReadLine());
                        if (num < 0)
                        {
                            Console.WriteLine("Error: Cannot calculate square root of a negative number!");
                        }
                        else
                        {
                            result = Math.Sqrt(num);
                            history.Rows.Add("Square Root", num.ToString(), result);
                            Console.WriteLine($"Square root: {result}");
                        }
                        break;

                    case "^":
                    case "power":
                        Console.WriteLine("Enter base number and exponent separated by space:");
                        operands = Console.ReadLine().Split(' ');
                        double baseNum = Convert.ToDouble(operands[0]);
                        double exponent = Convert.ToDouble(operands[1]);
                        result = Math.Pow(baseNum, exponent);
                        history.Rows.Add("Power", string.Join(", ", operands), result);
                        Console.WriteLine($"Result: {result}");
                        break;

                    case "sin":
                        Console.Write("Enter angle in degrees: ");
                        double angle = Convert.ToDouble(Console.ReadLine());
                        angle = Math.PI * angle / 180; // Convert degrees to radians
                        result = Math.Sin(angle);
                        history.Rows.Add("Sine", angle * 180 / Math.PI, result); // Store angle in degrees
                        Console.WriteLine($"Sine: {result}");
                        break;

                    case "cos":
                        Console.Write("Enter angle in degrees: ");
                        angle = Convert.ToDouble(Console.ReadLine());
                        angle = Math.PI * angle / 180; // Convert degrees to radians
                        result = Math.Cos(angle);
                        history.Rows.Add("Cosine", angle * 180 / Math.PI, result); // Store angle in degrees
                        Console.WriteLine($"Cosine: {result}");
                        break;

                    case "tan":
                        Console.Write("Enter angle in degrees: ");
                        angle = Convert.ToDouble(Console.ReadLine());
                        angle = Math.PI * angle / 180; // Convert degrees to radians
                        result = Math.Tan(angle);
                        history.Rows.Add("Tangent", angle * 180 / Math.PI, result); // Store angle in degrees
                        Console.WriteLine($"Tangent: {result}");
                        break;

                    default:
                        Console.WriteLine("Invalid operation. Please try again.");
                        break;
                }
            }
            Console.WriteLine("Thank you for using the Advanced Calculator!");
        }
        static void DisplayHistory(DataTable history)
        {
            if (history.Rows.Count == 0)
            {
                Console.WriteLine("No history available.");
                return;
            }

            Console.WriteLine("Operation    Operands    Result");
            foreach (DataRow row in history.Rows)
            {
                Console.WriteLine($"{row["Operation"],-12} {row["Operands"],-12} \'{row["Result"]}\'");
            }
        }
    }
}
