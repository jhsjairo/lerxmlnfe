

using System;

public static class App
{

    public static decimal DecimalFormat(string valor, bool edecimal)
    {

        decimal numero = 0;

        if (decimal.TryParse(valor, out numero))
        {
            return numero;
        }

        return numero;


    }


    public static double DecimalFormat(string valor)
    {

        double numero = 0;

        if (double.TryParse(valor, out numero))
        {
            return numero;
        }

        return numero;


    }


    public static double DoubleFormat(string valor)
    {

        double numero = 0;

        if (double.TryParse(valor, out numero))
        {
            return numero;
        }

        return numero;


    }




    public static int IntFormat(string valor)
    {


        int numero = 0;

        if (int.TryParse(valor, out numero))
        {
            return numero;
        }

        return numero;

    }



    public static string DecimalConvert(string valor, int casas_decimais = 2)
    {


        string n_zeros = "0";
        //"{ 0:0,0.00}"
        string format = "{0:0,0." + n_zeros.PadLeft(casas_decimais, '0') + "}";

        double numero = 0;

        if (!String.IsNullOrEmpty(valor))
        {

            if (valor.Contains(","))
            {
                valor = valor.Replace(".", "");
            }
            else
            {
                valor = valor.Replace(".", ",");
            }



        }

        if (double.TryParse(valor, out numero))
        {

            return String.Format("{0:N" + casas_decimais.ToString() + "}", Math.Round(numero, casas_decimais, MidpointRounding.ToEven));

        }

        return "0";

    }

    public static string DecimalConvert(string valor, bool nao_arredonda)
    {

        double numero = 0;

        if (!String.IsNullOrEmpty(valor))
        {

            valor = valor.Replace(".", ",");

        }

        if (double.TryParse(valor, out numero))
        {

            return numero.ToString();

        }

        return "0";

    }

    public static string DecimalConvertComNegativo(string valor, int casas_decimais = 2)
    {


        string n_zeros = "0";
        //"{ 0:0,0.00}"
        string format = "{0:0,0." + n_zeros.PadLeft(casas_decimais, '0') + "}";

        double numero = 0;

        if (!String.IsNullOrEmpty(valor))
        {

            if (valor.Contains(","))
            {
                valor = valor.Replace(".", "");
            }
            else
            {
                valor = valor.Replace(".", ",");
            }

        }

        if (double.TryParse(valor, out numero))
        {
            string sinal = "";
            if (App.DecimalFormat(valor) > 0)
            {
                sinal = "+";
            }

            return sinal + String.Format("{0:N" + casas_decimais.ToString() + "}", Math.Round(numero, casas_decimais, MidpointRounding.ToEven));

        }

        return "0";

    }

    public static string DecimalConvertComNegativo(string valor, bool nao_arredonda)
    {

        double numero = 0;

        if (!String.IsNullOrEmpty(valor))
        {

            valor = valor.Replace(".", ",");

        }

        if (double.TryParse(valor, out numero))
        {
            string sinal = "";
            if (App.DecimalFormat(valor) > 0)
            {
                sinal = "+";
            }
            return sinal + numero.ToString();

        }

        return "0";

    }


}