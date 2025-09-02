namespace AppMultiUsos.Servicios.CalculadoraDivisas
{
    public class CalculadoraDivisas : iCalculadoraDivisas
    {

        //Dictionary<TKey,TValue>
        private readonly Dictionary<string, decimal> Tasas = new()
        {
             // Desde DOP (Peso dominicano)
                { "DOP_USD", 0.0167m },
                { "DOP_EUR", 0.0143m },
                { "DOP_ARS", 19.933m },
                { "DOP_AUD", 0.0256m },
                { "DOP_CAD", 0.0229m },
                { "DOP_GBP", 0.0122m },
                { "DOP_JPY", 2.4204m },
                { "DOP_INR", 1.4352m },
                { "DOP_ZAR", 0.2988m },
                { "DOP_SGD", 0.0213m },

                // Desde USD (Dólar estadounidense)
                { "USD_DOP", 60.00m },
                { "USD_EUR", 0.90m },
                { "USD_ARS", 120.5m },
                { "USD_AUD", 1.50m },
                { "USD_CAD", 1.35m },
                { "USD_GBP", 0.78m },
                { "USD_JPY", 145.0m },
                { "USD_INR", 83.5m },
                { "USD_ZAR", 18.0m },
                { "USD_SGD", 1.35m },

                // Desde EUR (Euro)
                { "EUR_DOP", 66.7m },
                { "EUR_USD", 1.11m },
                { "EUR_ARS", 133.9m },
                { "EUR_AUD", 1.66m },
                { "EUR_CAD", 1.49m },
                { "EUR_GBP", 0.87m },
                { "EUR_JPY", 161.7m },
                { "EUR_INR", 92.9m },
                { "EUR_ZAR", 20.2m },
                { "EUR_SGD", 1.50m },

                // Desde ARS (Peso argentino)
                { "ARS_USD", 0.0083m },
                { "ARS_EUR", 0.0075m },
                { "ARS_DOP", 0.0501m },


                // Desde AUD (Dólar australiano)
                { "AUD_USD", 0.67m },
                { "AUD_EUR", 0.60m },
                { "AUD_DOP", 39.2m },

                // Desde GBP (Libra esterlina)
                { "GBP_USD", 1.28m },
                { "GBP_EUR", 1.15m },
                { "GBP_DOP", 76.9m },

                // Desde JPY (Yen japonés)
                { "JPY_USD", 0.0069m },
                { "JPY_EUR", 0.0062m },
                { "JPY_DOP", 0.413m },

                // Desde INR (Rupia india)
                { "INR_USD", 0.012m },
                { "INR_EUR", 0.011m },
                { "INR_DOP", 0.695m },

                // Desde ZAR (Rand sudafricano)
                { "ZAR_USD", 0.056m },
                { "ZAR_EUR", 0.050m },
                { "ZAR_DOP", 3.35m },

                // Desde SGD (Dólar de Singapur)
                { "SGD_USD", 0.74m },
                { "SGD_EUR", 0.67m },
                { "SGD_DOP", 44.5m },
                    };




        public decimal Operar(decimal monto, string desde, string hacia)
        {


            var clave = $"{desde}_{hacia}";

            if(desde == hacia)
                throw new InvalidOperationException($"No Puedes convertir de {desde} hacia {hacia}");
            



            var tasa = Tasas[clave];

            return monto * tasa;
        }
    }
}
