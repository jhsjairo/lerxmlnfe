using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftMaisPDV.Models
{
    public class CompraXML
    {
        public string chNFe { get; set; }
        public string nNF { get; set; }
        public string mod { get; set; }
        public string serie { get; set; }
        public string dhEmi { get; set; }
        public string cUF { get; set; }

        public string CNPJ { get; set; }
        public string xNome { get; set; }
        public string IE { get; set; }
        public string CRT { get; set; }

        public string xLgr { get; set; }
        public string nro { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string cPais { get; set; }
        public string xPais { get; set; }
        public string fone { get; set; }

        public string vPMC { get; set; }
        public string vDescItem { get; set; }
        public string pRedBC { get; set; }

        public string vProdutos_tot { get; set; }
        public string vNF_tot { get; set; }
        public string vBC_tot { get; set; }
        public string vICMS_tot { get; set; }
        public string vBCST_tot { get; set; }
        public string vST_tot { get; set; }
        public string vIPI_tot { get; set; }
        public string vFrete_tot { get; set; }
        public string vSeg_tot { get; set; }
        public string vDesc_tot { get; set; }
        public string vOutro_Tot { get; set; }
        public string vPIS_tot { get; set; }
        public string vCOFINS_tot { get; set; }
        public string idDest { get; set; }
        public string natOp { get; set; }
        public string nProt { get; set; }
        

        public List<CompraXMLItens> itens = new List<CompraXMLItens>();
        public List<CompraXMLDuplicatas> duplicatas = new List<CompraXMLDuplicatas>();

    }

    public class CompraXMLItens
    {
             public int ITEM { get; set; }
             public int FK_PRODUTO{ get; set; }
             public string cProd{ get; set; }
             public string xProd{ get; set; }
             public string CFOP{ get; set; }
             public string NCM{ get; set; }
             public string CEST { get; set; }
             public string cEANTrib { get; set; }
             public string uCom{ get; set; }
             public double qCom { get; set; }
             public double vUnCom { get; set; }

             public double vProd{ get; set; }
             public double vDesc { get; set; }
             public double vFrete { get; set; }
             public double vSeguro { get; set; }
             public double vOutros { get; set; }


        public string IPI_CST { get; set; }
        public double IPI_vBC { get; set; }
             public double IPI_pIPI { get; set; }
             public double IPI_vIPI { get; set; }

             public string ICMS_orig{ get; set; }
             public string ICMS_CST{ get; set; }
             public double ICMS_pICMS { get; set; }
             public double ICMS_vICMS { get; set; }
             public double ICMS_vBC { get; set; }
        public double ICMS_pICMSST { get; set; }
        public double ICMS_vICMSST { get; set; }
        public double ICMS_vBCST { get; set; }
             public double ICMS_pRedBC { get; set; }
        public double ICMS_vFCPST { get; set; }
        

             public string PIS_CST{ get; set; }
             public double PIS_vBC { get; set; }
             public double PIS_pPIS { get; set; }
             public double PIS_vPIS { get; set; }

             public string COFINS_CST{ get; set; }
             public double COFINS_vBC { get; set; }
             public double COFINS_pPIS { get; set; }
             public double COFINS_vPIS { get; set; }
             public int MOD_BC { get; set; }
             public int MOD_BCST { get; set; }
             public double PMVAST { get; set; }
             public double PREDBCST { get; set; }


        public List<CompraXMLLotes> lotes = new List<CompraXMLLotes>();

    }

    public class CompraXMLLotes
    {
        public string nLote { get; set; }
        public decimal qLote { get; set; }
        public string dFab { get; set; }
        public string dVal { get; set; }

    }

        public class CompraXMLDuplicatas
    {


        public string nDup { get; set; }
        public string dVenc { get; set; }
        public double vDup { get; set; }
       

       

    }



}
