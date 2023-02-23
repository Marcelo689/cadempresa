using Org.BouncyCastle.Asn1.TeleTrust;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using WF_Gestao_Estoque_Gastos.Servicos.Excecoes;

namespace WF_Gestao_Estoque_Gastos.Servicos.Validacoes
{
    public static class ValidarCampos
    {

        public static int RetornaZeroCasoVazio(string entrada)
        {
            int.TryParse(entrada, out int result);
            return result;
        }
        public static string RemoverPontosHifensEBarra(string entrada)
        {
            return entrada.Replace(".", "").Replace("-", "").Replace("/", "");
        }
        public static string RemoveMaskaraCnpj(string cnpj)
        {
            cnpj = RemoverPontosHifensEBarra(cnpj);

            return cnpj;
        }

        public static string FormatCNPJ(string cnpj)
        {
            if (cnpj.Length > 14)
                cnpj = cnpj.Substring(0, 14);

            return Convert.ToInt64(RemoveMaskaraCnpj(cnpj)).ToString(@"00\.000\.000\.\/0000-00");
        }
        public static bool IsCPNJComMaskara(string cnpj)
        {
            var saida = "";

            if(cnpj.Length == 19)
            for(var i =0; i < cnpj.Length; i++)
            {
                saida += AdicionaCaracteresMaskara(i);
            }

            return saida.Length == 5;

        }

        public static string FormataIntParaStringCNPJ(int cnpj)
        {
            string cnpjAsString = cnpj.ToString();
            var qtdCarcteres = cnpjAsString.Length;

            if (qtdCarcteres < 13)
                return cnpjAsString.PadLeft(13 - qtdCarcteres, '0');
            return cnpjAsString.Substring(0, 13);
        }

        public static string AdicionaCaracteresMaskara(int i)
        {
            var ponto = ".";
            var barra = "/";
            var hifen = "-";
            switch (i)
            {
                case 2: return ponto;
                case 5: return ponto;
                case 8: return ponto + barra;
                case 12: return hifen;

                default: return "";
            }
        }
        public static string AdicionaMascaraCNPJ(string cnpj)
        {
            var saida = "";
            cnpj = RemoveMaskaraCnpj(cnpj);
            
            if(cnpj.Length != 14)
            {
                if (cnpj.Length >= 15)
                {
                    return cnpj.Substring(0, 14);
                }
                else
                {
                    ExibirMensagem.Aviso("Esperado 14 numeros, sem maskara");
                    return cnpj;
                }
            }
            for (var i = 0; i < 14; i++)
            {
                saida += AdicionaCaracteresMaskara(i) + cnpj[i];
            }
            return saida;
        }
        public static string FormatarCNPJ(string CNPJ)
        {
            var cnpjFormatado = AdicionaMascaraCNPJ(CNPJ);

            return cnpjFormatado;
        }

        public static string FormatarTelefone(string telefone)
        {
            if (telefone.Length > 11)
                telefone = telefone.Substring(0, 11);
            return
                Convert.ToUInt64(telefone).ToString(@"\(00\) 00000\-0000");
        }

        public static string RemoveMaskaraTelefone(string text)
        {
            return text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }
    }
}
