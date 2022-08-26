using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using System.Threading;
using SoftMaisPDV.Models;

namespace SoftMaisPDV.Forms
{
    public partial class FRM_CompraXML : Form
    {
        public int pk = 0;
        public int pk_itens = 0;
        public int pk_pagto = 0;
        //private CompraXML p;//= new CompraXML();
        List<string> letras = new List<string>();
        List<string> caracterePula = new List<string>();
        XmlDocument xmlCompra = new XmlDocument();


        //private FRM_Compra _f;
        private bool _exibir = false;
        private bool verificar_NCM = false;

        private bool nf_entrada_lote_gerar_serial = false;

        CompraXML p;

        public FRM_CompraXML( bool exbir = false)
        {
            InitializeComponent();
           
            configuraLista();
            configuraListaPagto();

            limparDados();

           
            _exibir = exbir;

           
        }


        private void limparDados()
        {

            numero_nfe.Text = "";
            serie_nfe.Text = "";


            tot_base_icms.Text = "0,00";
            tot_base_st.Text = "0,00";
            tot_cofins.Text = "0,00";
            tot_desconto.Text = "0,00";
            tot_frete.Text = "0,00";
            tot_icms.Text = "0,00";
            tot_icms_st.Text = "0,00";
            tot_ipi.Text = "0,00";
            tot_nota.Text = "0,00";
            tot_outros.Text = "0,00";
            tot_pis.Text = "0,00";
            tot_seguro.Text = "0,00";


            chnfe.Text = "";
           

           

            //emitente
            razao_social.Text = "";
            fantasia.Text = "";
            cnpj_cpf.Text = "";
            ie.Text = "";
            endereco.Text = "";
            endereco_num.Text = "";
            bairro.Text = "";
           // cidade.SelectedValue = 0;
           // uf.SelectedValue = "";
            ceps.Text = "";
            fones.Text = "";

            listaItens.Items.Clear();
            listaPagamentos.Items.Clear();


        }

        private void configuraLista()
        {
            //Labels


            // CONFIGURAR LISTA
            listaItens.View = View.Details;
            // permite ao usuário editar o texto
            listaItens.LabelEdit = false;
            // permite ao usuário rearranjar as colunas
            listaItens.AllowColumnReorder = false;
            // Selecione o item e subitem quando um seleção for feita
            listaItens.FullRowSelect = true;
            // Exibe as linhas no ListView
            listaItens.GridLines = true;




            //botao
            //listaItens.FullRowSelect = true;
            //ListViewExtender extender = new ListViewExtender(listaItens);
            //ListViewButtonColumn buttonAction = new ListViewButtonColumn(12);
            //buttonAction.Click += OnButtonActionClick;
            //buttonAction.FixedWidth = true;
            //extender.AddColumn(buttonAction);

            // Anexa Subitems no ListView
            listaItens.Columns.Add("ID", 0);

            listaItens.Columns.Add("Código Sistema", 100, HorizontalAlignment.Left);
            listaItens.Columns.Add("cProd", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("xProd", 200, HorizontalAlignment.Left);
            listaItens.Columns.Add("CFOP", 50, HorizontalAlignment.Left);
            listaItens.Columns.Add("NCM", 80, HorizontalAlignment.Left);

            listaItens.Columns.Add("CEST", 70, HorizontalAlignment.Left);
            listaItens.Columns.Add("EAN", 80, HorizontalAlignment.Left);

            listaItens.Columns.Add("uCom", 50, HorizontalAlignment.Left);
            listaItens.Columns.Add("qCom", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("vUnCom", 90, HorizontalAlignment.Left);


            listaItens.Columns.Add("vProd", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("vDesc", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("vFrete", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("vSeguro", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("vOutros", 90, HorizontalAlignment.Left);

            listaItens.Columns.Add("IPI_CST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("IPI_vBC", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("IPI_pIPI", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("IPI_vIPI", 90, HorizontalAlignment.Left);

            listaItens.Columns.Add("ICMS_orig", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_CST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_pICMS", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_vBC", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_pICMSST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_vICMSST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_vBCST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("ICMS_pRedBC", 90, HorizontalAlignment.Left);

            listaItens.Columns.Add("PIS_CST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("PIS_vBC", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("PIS_pPIS", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("PIS_vPIS", 90, HorizontalAlignment.Left);

            listaItens.Columns.Add("COFINS_CST", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("COFINS_vBC", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("COFINS_pPIS", 90, HorizontalAlignment.Left);
            listaItens.Columns.Add("COFINS_vPIS", 90, HorizontalAlignment.Left);



        }

        private void configuraListaPagto()
        {
            //Labels


            // CONFIGURAR LISTA
            listaPagamentos.View = View.Details;
            // permite ao usuário editar o texto
            listaPagamentos.LabelEdit = false;
            // permite ao usuário rearranjar as colunas
            listaPagamentos.AllowColumnReorder = false;
            // Selecione o item e subitem quando um seleção for feita
            listaPagamentos.FullRowSelect = true;
            // Exibe as linhas no ListView
            listaPagamentos.GridLines = true;

            // Anexa Subitems no ListView
            listaPagamentos.Columns.Add("Nº Duplicata", 100);

            listaPagamentos.Columns.Add("Vencimento", 100, HorizontalAlignment.Left);
            listaPagamentos.Columns.Add("Valor", 150, HorizontalAlignment.Right);


        }



        private void dropDisable_KeyDown(object sender, KeyEventArgs e)
        {

            ComboBox cb = (ComboBox)sender;
            cb.DroppedDown = false;

        }

        private void ValidaCombo_Leave(object sender, EventArgs e)
        {

           
        }

        private void btnLocalXML_Click(object sender, EventArgs e)
        {

            this.openFileDialog_arqxml.FileName = "";
            this.openFileDialog_arqxml.RestoreDirectory = true;
            this.openFileDialog_arqxml.Filter = "Arquivos XML|*.xml";
            if (this.openFileDialog_arqxml.ShowDialog(this) == DialogResult.OK)
            {
                this.local_xml.Text = this.openFileDialog_arqxml.FileName.ToString();

                this.Cursor = Cursors.WaitCursor;
                LerXML(this.local_xml.Text);

            }

            this.Cursor = Cursors.Default;

        }


        public void LerXML(string xml, bool loadXml = false)
        {


            try
            {


                p = new CompraXML();
                XmlDocument xmls = new XmlDocument();

                if (loadXml == true)
                {

                    xmls.LoadXml(xml);
                    xmlCompra.LoadXml(xml);
                }
                else
                {
                    xmls.Load(xml);
                    xmlCompra.Load(xml);
                }

                XmlNodeList retEnviNFeList = null;

                retEnviNFeList = xmls.GetElementsByTagName("nfeProc");
                
                foreach (XmlNode retEnviNFeNode in retEnviNFeList)
                {
                    XmlElement retEnviNFeElemento = (XmlElement)retEnviNFeNode;


                   // int tpAmb = App.IntFormat(retEnviNFeElemento.GetElementsByTagName("tpAmb")[0].InnerText);

                    //if (tpAmb == 2)
                    //{

                    //    MessageBox.Show("Não é permitido a importação de NF-e emitida em Homologação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    goto eFim;
                    //}


                    #region CABECALHO

                    p.chNFe = retEnviNFeElemento.GetElementsByTagName("protNFe")[0]["infProt"]["chNFe"].InnerText;
                    p.nNF = retEnviNFeElemento.GetElementsByTagName("nNF")[0].InnerText;
                    p.mod = retEnviNFeElemento.GetElementsByTagName("mod")[0].InnerText;
                    p.serie = retEnviNFeElemento.GetElementsByTagName("serie")[0].InnerText;
                    p.dhEmi = retEnviNFeElemento.GetElementsByTagName("dhEmi")[0].InnerText;
                    p.cUF = retEnviNFeElemento.GetElementsByTagName("cUF")[0].InnerText;

                    p.CNPJ = retEnviNFeElemento.GetElementsByTagName("CNPJ")[0].InnerText;
                    p.xNome = retEnviNFeElemento.GetElementsByTagName("xNome")[0].InnerText;
                    p.IE = retEnviNFeElemento.GetElementsByTagName("IE")[0].InnerText;
                    p.CRT = retEnviNFeElemento.GetElementsByTagName("CRT")[0].InnerText;


                    try
                    {
                        p.xLgr = retEnviNFeElemento.GetElementsByTagName("xLgr")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.nro = retEnviNFeElemento.GetElementsByTagName("nro")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.xBairro = retEnviNFeElemento.GetElementsByTagName("xBairro")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.cMun = retEnviNFeElemento.GetElementsByTagName("cMun")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.xMun = retEnviNFeElemento.GetElementsByTagName("xMun")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.UF = retEnviNFeElemento.GetElementsByTagName("UF")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.CEP = retEnviNFeElemento.GetElementsByTagName("CEP")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.cPais = retEnviNFeElemento.GetElementsByTagName("cPais")[0].InnerText;
                    }
                    catch { };
                    try
                    {
                        p.xPais = retEnviNFeElemento.GetElementsByTagName("xPais")[0].InnerText;
                    }
                    catch { };
                    try
                    { p.fone = retEnviNFeElemento.GetElementsByTagName("fone")[0].InnerText; }
                    catch { };

                    p.vProdutos_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vProd"].InnerText;
                    p.vNF_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vNF"].InnerText;
                    p.vBC_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vBC"].InnerText;
                    p.vICMS_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vICMS"].InnerText;
                    p.vBCST_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vBCST"].InnerText;
                    p.vST_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vST"].InnerText;
                    p.vIPI_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vIPI"].InnerText;
                    p.vFrete_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vFrete"].InnerText;
                    p.vSeg_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vSeg"].InnerText;
                    p.vDesc_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vDesc"].InnerText;
                    p.vOutro_Tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vOutro"].InnerText;
                    p.vPIS_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vPIS"].InnerText;
                    p.vCOFINS_tot = retEnviNFeElemento.GetElementsByTagName("ICMSTot")[0]["vCOFINS"].InnerText;

                    #endregion

                    XmlNodeList itensList = xmls.GetElementsByTagName("det");

                    #region ITENS
                    int i = 0;
                    foreach (XmlNode itensNode in itensList)
                    {
                        XmlElement itensElemento = (XmlElement)itensNode;


                        CompraXMLItens pi = new CompraXMLItens();
                        pi.ITEM = i;
                        pi.cProd = itensElemento.GetElementsByTagName("prod")[0]["cProd"].InnerText;
                        pi.xProd = itensElemento.GetElementsByTagName("prod")[0]["xProd"].InnerText;
                        pi.CFOP = itensElemento.GetElementsByTagName("prod")[0]["CFOP"].InnerText;
                        pi.uCom = itensElemento.GetElementsByTagName("prod")[0]["uCom"].InnerText;
                        pi.qCom = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["qCom"].InnerText, true));
                        pi.vUnCom = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vUnCom"].InnerText, true));
                        pi.NCM = itensElemento.GetElementsByTagName("prod")[0]["NCM"].InnerText;

                        //LOTES

                        XmlNodeList loteList = itensElemento.GetElementsByTagName("rastro");
                       
                        foreach (XmlNode itensNodeLote in loteList)
                        {

                            XmlElement itensElementoLote = (XmlElement)itensNodeLote;
                            CompraXMLLotes piLote = new CompraXMLLotes();

                            try { piLote.nLote = itensElementoLote.GetElementsByTagName("nLote")[0].InnerText; }
                            catch { piLote.nLote = ""; };

                            try { piLote.qLote = App.DecimalFormat(App.DecimalConvert(itensElementoLote.GetElementsByTagName("qLote")[0].InnerText, true), true); }
                            catch { piLote.qLote = 0; };

                            try { piLote.dFab = itensElementoLote.GetElementsByTagName("dFab")[0].InnerText; }
                            catch { piLote.dFab = String.Format("{0:yyyy-MM-dd}", DateTime.Now); };

                            try { piLote.dVal = itensElementoLote.GetElementsByTagName("dVal")[0].InnerText; }
                            catch { piLote.dVal = String.Format("{0:yyyy-MM-dd}", DateTime.Now); };

                            pi.lotes.Add(piLote);

                        }


                        //**********************

                        try { pi.CEST = itensElemento.GetElementsByTagName("prod")[0]["CEST"].InnerText; }
                        catch { };

                        pi.vProd = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vProd"].InnerText));
                        try { pi.vDesc = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vDesc"].InnerText)); } catch { };
                        try { pi.cEANTrib = itensElemento.GetElementsByTagName("prod")[0]["cEAN"].InnerText; }
                        catch { };
                        try { pi.vFrete = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vFrete"].InnerText)); } catch { };
                        try { pi.vSeguro = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vSeg"].InnerText)); } catch { };
                        try { pi.vOutros = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vOutro"].InnerText)); } catch { };

                        try{ pi.ICMS_orig = itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["orig"].InnerText; } catch { pi.ICMS_orig = "0";};
                        

                        if (p.CRT == "3")
                        {
                            try { pi.ICMS_CST = itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["CST"].InnerText; }
                            catch { pi.ICMS_CST = ""; }
                        }
                        else
                        {

                            try { pi.ICMS_CST = itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["CSOSN"].InnerText; }
                            catch { pi.ICMS_CST = ""; }

                        }


                        try { pi.ICMS_pICMS = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["pICMS"].InnerText)); } catch { };
                        if (pi.ICMS_CST == "101")
                        {
                            try { pi.ICMS_pICMS = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["pCredSN"].InnerText)); } catch { };
                        }

                        try { pi.ICMS_pICMSST = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["pICMSST"].InnerText)); }
                        catch { };
                        try { pi.ICMS_vICMSST = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["vICMSST"].InnerText)); }
                        catch { };
                        try { pi.ICMS_vBCST = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["vBCST"].InnerText)); }
                        catch { };

                        try { pi.ICMS_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["vBC"].InnerText)); }
                        catch { };
                        if (pi.ICMS_CST == "101")
                        {
                            try { pi.ICMS_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("prod")[0]["vProd"].InnerText)); }
                            catch { };
                        }


                        try { pi.ICMS_pRedBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["pRedBC"].InnerText)); }
                        catch { };

                        try { pi.ICMS_vFCPST = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["vFCPST"].InnerText)); } catch { };



                        try { pi.PIS_CST = itensElemento.GetElementsByTagName("imposto")[0]["PIS"].ChildNodes[0]["CST"].InnerText; } catch { pi.PIS_CST = ""; };
                        try { pi.PIS_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["PIS"].ChildNodes[0]["vBC"].InnerText)); } catch { };
                        try { pi.PIS_pPIS = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["PIS"].ChildNodes[0]["pPIS"].InnerText)); } catch { };
                        try { pi.PIS_vPIS = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["PIS"].ChildNodes[0]["vPIS"].InnerText)); } catch { };


                        try { pi.COFINS_CST = itensElemento.GetElementsByTagName("imposto")[0]["COFINS"].ChildNodes[0]["CST"].InnerText; } catch { pi.COFINS_CST = ""; };
                        try { pi.COFINS_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["COFINS"].ChildNodes[0]["vBC"].InnerText)); } catch { };
                        try { pi.COFINS_pPIS = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["COFINS"].ChildNodes[0]["pCOFINS"].InnerText)); } catch { };
                        try { pi.COFINS_vPIS = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["COFINS"].ChildNodes[0]["vCOFINS"].InnerText)); } catch { };

                        try { pi.IPI_CST = itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[3]["CST"].InnerText; } catch { };
                        try { pi.IPI_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[3]["vBC"].InnerText)); } catch { };
                        try { pi.IPI_pIPI = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[3]["pIPI"].InnerText)); } catch { };
                        try { pi.IPI_vIPI = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[3]["vIPI"].InnerText)); } catch { };

                        try { pi.IPI_CST = itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[1]["CST"].InnerText; } catch { };
                        try { pi.IPI_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[1]["vBC"].InnerText)); } catch { };
                        try { pi.IPI_pIPI = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[1]["pIPI"].InnerText)); } catch { };
                        try { pi.IPI_vIPI = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[1]["vIPI"].InnerText)); } catch { };

                        try { pi.IPI_CST = itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[2]["CST"].InnerText; } catch { };
                        try { pi.IPI_vBC = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[2]["vBC"].InnerText)); } catch { };
                        try { pi.IPI_pIPI = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[2]["pIPI"].InnerText)); } catch { };
                        try { pi.IPI_vIPI = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["IPI"].ChildNodes[2]["vIPI"].InnerText)); } catch { };

                        try { pi.MOD_BC = App.IntFormat(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["modBC"].InnerText); } catch { };
                        try { pi.MOD_BCST = App.IntFormat(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["modBCST"].InnerText); } catch { };
                        try { pi.PMVAST = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["pMVAST"].InnerText)); } catch { };
                        try { pi.PREDBCST = App.DecimalFormat(App.DecimalConvert(itensElemento.GetElementsByTagName("imposto")[0]["ICMS"].ChildNodes[0]["pRedBCST"].InnerText)); } catch { };


                        p.itens.Add(pi);
                        i++;

                    }


                    #endregion


                    XmlNodeList dupList = xmls.GetElementsByTagName("dup");

                    #region DUPLICATAS
                    foreach (XmlNode dupNode in dupList)
                    {
                        XmlElement dupElemento = (XmlElement)dupNode;


                        CompraXMLDuplicatas pi = new CompraXMLDuplicatas();


                        pi.nDup = dupElemento.GetElementsByTagName("nDup")[0].InnerText;
                        try
                        {
                            pi.dVenc =
                        dupElemento.GetElementsByTagName("dVenc")[0].InnerText;
                        }
                        catch { };
                        try { pi.vDup = App.DecimalFormat(App.DecimalConvert(dupElemento.GetElementsByTagName("vDup")[0].InnerText)); } catch { };
                        p.duplicatas.Add(pi);
                    }


                    #endregion


                }


                carregarCabecalho();
                carregarItens();
                carregarDuplicatas();
               
                

            eFim:;

            }
            catch
            {

                MessageBox.Show("Arquivo Inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void carregarCabecalho()
        {

            string emissao = p.dhEmi.Substring(0, 10);
            data_emissao.Value = Convert.ToDateTime(emissao);

            numero_nfe.Text = p.nNF;
            serie_nfe.Text = p.serie;


            tot_base_icms.Text = App.DecimalConvert(p.vBC_tot);
            tot_base_st.Text = App.DecimalConvert(p.vBCST_tot);
            tot_cofins.Text = App.DecimalConvert(p.vCOFINS_tot);
            tot_desconto.Text = App.DecimalConvert(p.vDesc_tot);
            tot_frete.Text = App.DecimalConvert(p.vFrete_tot);
            tot_icms.Text = App.DecimalConvert(p.vICMS_tot);
            tot_icms_st.Text = App.DecimalConvert(p.vST_tot);
            tot_ipi.Text = App.DecimalConvert(p.vIPI_tot);
            tot_nota.Text = App.DecimalConvert(p.vNF_tot);
            tot_outros.Text = App.DecimalConvert(p.vOutro_Tot);
            tot_pis.Text = App.DecimalConvert(p.vPIS_tot);
            tot_seguro.Text = App.DecimalConvert(p.vSeg_tot);


            chnfe.Text = p.chNFe;
            modelo.Text = p.mod;

            //emitente
            razao_social.Text = p.xNome;
            fantasia.Text = p.xNome;
            cnpj_cpf.Text = p.CNPJ;
            ie.Text = p.IE;
            endereco.Text = p.xLgr;
            endereco_num.Text = p.nro;
            bairro.Text = p.xBairro;
            cidade.Text = p.cMun;
            uf.Text = p.cUF;
            ceps.Text = p.CEP;
            fones.Text = p.fone;



        }


        private void carregarItens()
        {


            bool cor = false;
            double n_itens = 0;
            double v_total = 0;
            double v_volume = 0;
            int i = 0;

            listaItens.Items.Clear();

            foreach (CompraXMLItens pi in p.itens)
            {

                ListViewItem lvi = new ListViewItem((i).ToString());

                lvi.UseItemStyleForSubItems = false;

                if (pi.FK_PRODUTO == 0)
                {
                    lvi.SubItems.Add("").BackColor = Color.Red;
                }
                else
                {
                    lvi.SubItems.Add(pi.FK_PRODUTO.ToString());
                }

                //  string test =  App.DecimalConvert(pi.qCom);

                lvi.SubItems.Add(pi.cProd);
                lvi.SubItems.Add(pi.xProd);
                lvi.SubItems.Add(pi.CFOP);
                lvi.SubItems.Add(pi.NCM);
                lvi.SubItems.Add(pi.CEST);
                lvi.SubItems.Add(pi.cEANTrib);
                lvi.SubItems.Add(pi.uCom);
                lvi.SubItems.Add(App.DecimalConvert(pi.qCom.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.vUnCom.ToString()));


                lvi.SubItems.Add(App.DecimalConvert(pi.vProd.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.vDesc.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.vFrete.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.vSeguro.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.vOutros.ToString()));

                lvi.SubItems.Add(pi.IPI_CST);
                lvi.SubItems.Add(App.DecimalConvert(pi.IPI_vBC.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.IPI_pIPI.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.IPI_vIPI.ToString()));

                lvi.SubItems.Add(pi.ICMS_orig);
                lvi.SubItems.Add(pi.ICMS_CST);
                lvi.SubItems.Add(App.DecimalConvert(pi.ICMS_pICMS.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.ICMS_vBC.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.ICMS_pICMSST.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.ICMS_vICMSST.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.ICMS_vBCST.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.ICMS_pRedBC.ToString()));

                lvi.SubItems.Add(pi.PIS_CST);
                lvi.SubItems.Add(App.DecimalConvert(pi.PIS_vBC.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.PIS_pPIS.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.PIS_vPIS.ToString()));

                lvi.SubItems.Add(pi.COFINS_CST);
                lvi.SubItems.Add(App.DecimalConvert(pi.COFINS_vBC.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.COFINS_pPIS.ToString()));
                lvi.SubItems.Add(App.DecimalConvert(pi.COFINS_vPIS.ToString()));


                listaItens.Items.Add(lvi);

                if (cor == true)
                {

                    //Listagem.Items[i].BackColor = Color.LightBlue;
                    listaItens.Items[i].BackColor = Color.White;
                    cor = false;
                }
                else
                {
                    listaItens.Items[i].BackColor = Color.Azure;
                    //Listagem.Items[i].ForeColor = Color.White;
                    cor = true;
                }



                i++;
                n_itens = i;
                v_total += pi.vProd;
                v_volume += pi.qCom;

            }


            txtItens.Text = (n_itens).ToString();
            txtTotal.Text = String.Format("{0:N}", v_total);
            txtVolumes.Text = String.Format("{0:N}", v_volume);

           

        }

     
     
        private void carregarDuplicatas()
        {


            bool cor = false;
            double n_itens = 0;
            double v_total = 0;

            int i = 0;

            listaPagamentos.Items.Clear();

            foreach (CompraXMLDuplicatas pi in p.duplicatas)
            {

                ListViewItem lvi = new ListViewItem((pi.nDup).ToString());


                lvi.SubItems.Add(pi.dVenc);
                lvi.SubItems.Add(App.DecimalConvert(pi.vDup.ToString()));



                listaPagamentos.Items.Add(lvi);

                if (cor == true)
                {

                    //Listagem.Items[i].BackColor = Color.LightBlue;
                    listaPagamentos.Items[i].BackColor = Color.White;
                    cor = false;
                }
                else
                {
                    listaPagamentos.Items[i].BackColor = Color.Azure;
                    //Listagem.Items[i].ForeColor = Color.White;
                    cor = true;
                }



                i++;
                n_itens = i;
                v_total += pi.vDup;


            }


            txtItensPagto.Text = (n_itens).ToString();
            txtTotalPagto.Text = String.Format("{0:N}", v_total);


        }




        private string replaceExpressao(string expressao, DataTable _dadosImp)
        {
            string str = "";

            try
            {


                DataTable dadosImp = _dadosImp;

                #region Tratativa List

                letras.Clear();
                letras.Add("x");
                letras.Add("[preco_venda]");
                letras.Add("[preco_a]");
                letras.Add("[preco_b]");
                letras.Add("[preco_c]");

                caracterePula.Clear();
                caracterePula.Add("(");
                caracterePula.Add(")");
                caracterePula.Add("/");
                caracterePula.Add("+");
                caracterePula.Add("-");
                caracterePula.Add("*");
                caracterePula.Add("0");
                caracterePula.Add("1");
                caracterePula.Add("2");
                caracterePula.Add("3");
                caracterePula.Add("4");
                caracterePula.Add("5");
                caracterePula.Add("6");
                caracterePula.Add("7");
                caracterePula.Add("8");
                caracterePula.Add("9");

                #endregion


                for (int i = 0; i < expressao.Length; i++)
                {
                    string _letra = expressao.Substring(i, 1);

                    if (_letra == "[")
                    {
                        i++;
                        string _letra2 = expressao.Substring(i, 1);
                        while (_letra2 != "]")
                        {
                            _letra2 = expressao.Substring(i, 1);
                            _letra = _letra + _letra2;
                            i++;

                            if (i >= 500)
                            {

                                MessageBox.Show("O sistema interrompeu um loop infinito na Expressão:" + expressao);
                                goto eFim;
                            }
                        }
                        i--;

                        if (letras.Contains(_letra.ToLower()))
                        {
                            str = str + _dadosImp.Rows[0][_letra.Replace("[","").Replace("]","")].ToString() == "" ? "0" : str + _dadosImp.Rows[0][_letra.Replace("[", "").Replace("]", "")].ToString();
                        }
                        else
                        {
                            DataRow[] rows = dadosImp.Select("CAMPO='" + _letra.Replace("[", "").Replace("]", "" + "'"));

                            str = str + rows[0]["DADOS"].ToString() == "" ? "0" : str + rows[0]["DADOS"].ToString();
                        }



                    }
                    else
                    {

                        if (letras.Contains(_letra))
                        {
                            str = str + dadosImp.Rows[0]["PRECO_COMPRA"].ToString() == "" ? "0" : str + dadosImp.Rows[0]["PRECO_COMPRA"].ToString();
                        }
                        else
                        {
                            if (caracterePula.Contains(_letra))
                            {
                                str = str + _letra;
                            }
                            else
                            {
                                DataRow[] rows = dadosImp.Select("CAMPO='" + _letra + "'");

                                str = str + rows[0]["DADOS"].ToString() == "" ? "0" : str + rows[0]["DADOS"].ToString();
                            }

                        }
                    }
                }


            }
            catch 
            {

                //MessageBox.Show("Erro na Regra de Cálculo! Importação Incompleta!\n" + expressao, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           

        eFim:;
            return str.Replace(".", "").Replace(',', '.');
        }




    

        private void FRM_CompraXML_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCadFornecedor_Click(object sender, EventArgs e)
        {
            
        }

        private void mc_itens_ncm_Click(object sender, EventArgs e)
        {
            
        }

        private void mc_itens_produto_Click(object sender, EventArgs e)
        {

           
        }

        private void mc_itens_selecionar_Click(object sender, EventArgs e)
        {
            
        }

        private void listaItens_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Enter:

                   

                    break;

            }

        }

        private void listaItens_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           
        }



        private void btnRastreador_Click(object sender, EventArgs e)
        {
            
        }

        private void mc_itens_conversor_Click(object sender, EventArgs e)
        {
            
        }

        private void FRM_CompraXML_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void BtnProduto_Click(object sender, EventArgs e)
        {
           
        }

        private void btnConfiguracao_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void configuracao_natureza_Click(object sender, EventArgs e)
        {
           
        }

        private void mc_itens_alterar_ncm_Click(object sender, EventArgs e)
        {
           
        }



    }
}
