namespace CalculadoraDePrestamos.Servicios.CalculadoraMatematica
{
    public class Calculadora : iCalculadora
    {
        private static decimal total = 0;

        public decimal Operar(decimal numero, string operacion)
        {





            switch (operacion)
            {
                //Suma
                case "+":
                    total += numero;
                    break;
                    //Resta
                case "-":
                    total -= numero;
                    break;
                    //Multiplicacion
                case "*":
                    total *= numero;
                    break;
                    //Divicion
                case "/":
                    total = numero != 0 ? total / numero : throw new DivideByZeroException("No se puede dividir por cero.");
                    break;
                    //Potencia de 2
                case "^2":
                    total = (decimal)Math.Pow((double)total, 2);
                    break;
                   //Potencia de 3
                case "^3":
                    total = (decimal)Math.Pow((double)total, 3);
                    break;
                    //Raiz cuadrada
                case "sqrt":
                    if (total < 0)
                        throw new InvalidOperationException("No se puede calcular la raíz cuadrada de un número negativo.");
                    total = Math.Round((decimal)Math.Sqrt((double)total),4);
                    break;
                    //Numero absoluto
                case "abs":
                    total = Math.Abs(total);
                    break;
                    //Porcentaje
                case "%":
                    total = total * (numero / 100);
                    break;
                    //Negativo
                case "neg":
                    total = -total;
                    break;
                case "reset":
                    
                    total = 0;
                    return total;
                    
                case "=":
                    var resultadoFinal = total;
                    return resultadoFinal;
                default:
                    throw new InvalidOperationException("Operación inválida. Usa +, -, *, /, ^2, ^3, sqrt, abs, %, neg o =");
            }

            return total;
        }
    }
}
