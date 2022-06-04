using imprimirPDF.common;
using imprimirPDF.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.CapaNegocio
{
    public class DepositosServicios
    {
        LetrasaNumeros convertir = new LetrasaNumeros();
        public IEnumerable<Depositos> Todos()

        {
            var cadena = Parametros.CadenaConnexion;
            var ListDeposito = new List<Depositos>();
        
            var consulta = @"SELECT a.EMPCOD, b.clicod cliente,  b.LIQCAJRECSER serie, b.liqcajrecnum numero, a.liqcajfch fecha, cc.CLIRAZSOC Nombre, (LiqCajRutaMonAbo * LiqCajDetTasCam)monto, a.LIQCAJNUM Liquidacion, LIQCAJUSUALT 
                                from REC_LIQUIDACIONES a
	                                join REC_LIQUIDACIONESRECIBOS b
	                                    on a.PAICOD = b.PAICOD
	                                    and a.EMPCOD = b.EMPCOD
	                                    and a.LIQCAJCOD = b.LIQCAJCOD
	                                    and a.LIQCAJNUM = b.LIQCAJNUM
    	                                JOIN  CXC_CLIENTES cc 
    		                                ON a.PAICOD = cc.PAICOD 
    		                                AND a.EMPCOD = cc.EMPCOD 
    		                                AND b.CLICOD = cc.CLICOD 
                                where a.PAICOD = '00001'
                                and a.EMPCOD = '00001'
                                and a.LiqCajSta <> 'AN' 
                                and b.LiqCajRecNum <> 0
                                and b.LiqCajRutaMonAbo > 0 
                                and b.LiqCajMotCod = 9
                                and a.LiqCajTipRutCod in ( ' ','DDI')
                                and a.LIQCAJFCH between '01/01/2022' and '29/01/2022'";

            try
            {
                using (var context = new OracleConnection(cadena))
                {
                    context.Open();

                    var cmd = new OracleCommand(consulta, context);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var oDeposito = new Depositos();
                            {
                                oDeposito.EmpCod = Convert.ToString(reader["EMPCOD"]);
                                oDeposito.clicod = Convert.ToString(reader["CLIENTE"]);
                                oDeposito.Serie = Convert.ToString(reader["SERIE"]);
                                oDeposito.Numero = Convert.ToInt32(reader["NUMERO"]);
                                oDeposito.FechaAlta = Convert.ToDateTime(reader["FECHA"]);
                                oDeposito.ClienteRazon = Convert.ToString(reader["Nombre"]);
                                oDeposito.Monto = Convert.ToDouble(reader["MONTO"]);
                                oDeposito.NumeroLiquidacion = Convert.ToInt64(reader["Liquidacion"]);
                                oDeposito.UsuAlt = Convert.ToString(reader["LIQCAJUSUALT"]);
                            };
                            oDeposito.MontoLetras = convertir.enletras(oDeposito.Monto.ToString());
                            ListDeposito.Add(oDeposito);
                        }
                    }
                }
                return ListDeposito;
            }
            catch (Exception error)
            {
                var error1 = error.Message;
                throw;
            }
        }

        public Depositos DepositosPorId(int id)
        {
            var consulta = @"SELECT a.EMPCOD, b.clicod cliente,  b.LIQCAJRECSER serie, b.liqcajrecnum numero, a.liqcajfch fecha, cc.CLIRAZSOC Nombre, (LiqCajRutaMonAbo * LiqCajDetTasCam)monto, a.LIQCAJNUM Liquidacion, LIQCAJUSUALT 
                                from REC_LIQUIDACIONES a
	                                join REC_LIQUIDACIONESRECIBOS b
	                                    on a.PAICOD = b.PAICOD
	                                    and a.EMPCOD = b.EMPCOD
	                                    and a.LIQCAJCOD = b.LIQCAJCOD
	                                    and a.LIQCAJNUM = b.LIQCAJNUM
    	                                JOIN  CXC_CLIENTES cc 
    		                                ON a.PAICOD = cc.PAICOD 
    		                                AND a.EMPCOD = cc.EMPCOD 
    		                                AND b.CLICOD = cc.CLICOD 
                                where a.PAICOD = '00001'
                                and a.EMPCOD = '00001'
                                and a.LiqCajSta <> 'AN' 
                                and b.LiqCajRecNum <> 0
                                and b.LiqCajRutaMonAbo > 0 
                                and b.LiqCajMotCod = 9
                                and a.LiqCajTipRutCod in ( ' ','DDI')
                                and a.LIQCAJFCH between '01/01/2022' and '29/01/2022'
                                and b.liqcajrecnum = " + id;
            var oDeposito = new Depositos();

            using (var context = new OracleConnection(Parametros.CadenaConnexion))
            {
                context.Open();
                var cmd = new OracleCommand(consulta, context);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    oDeposito.EmpCod = Convert.ToString(reader["EMPCOD"]);
                    oDeposito.clicod = Convert.ToString(reader["CLIENTE"]);
                    oDeposito.Serie = Convert.ToString(reader["SERIE"]);
                    oDeposito.Numero = Convert.ToInt32(reader["NUMERO"]);
                    oDeposito.FechaAlta = Convert.ToDateTime(reader["FECHA"]);
                    oDeposito.ClienteRazon = Convert.ToString(reader["Nombre"]);
                    oDeposito.Monto = Convert.ToDouble(reader["MONTO"]);
                    oDeposito.NumeroLiquidacion = Convert.ToInt64(reader["Liquidacion"]);
                    oDeposito.UsuAlt = Convert.ToString(reader["LIQCAJUSUALT"]);
                    oDeposito.MontoLetras = convertir.enletras(oDeposito.Monto.ToString());
                }
            }
            return oDeposito;
        }

        public IEnumerable<Depositos> ObtenerLiquidacion (long id)
        {
            var oLiquidacion = new List<Depositos>();

            var consulta = @"SELECT a.EMPCOD, b.clicod cliente,  b.LIQCAJRECSER serie, b.liqcajrecnum numero, a.liqcajfch fecha, 
                                    cc.CLIRAZSOC Nombre, (LiqCajRutaMonAbo * LiqCajDetTasCam)monto, a.LIQCAJNUM NoLiquidacion, LIQCAJUSUALT Usuario, 
                                        b.LIQCAJRUTANUMDOC NoPromesa 
                                from REC_LIQUIDACIONES a
	                                join REC_LIQUIDACIONESRECIBOS b
	                                    on a.PAICOD = b.PAICOD
	                                    and a.EMPCOD = b.EMPCOD
	                                    and a.LIQCAJCOD = b.LIQCAJCOD
	                                    and a.LIQCAJNUM = b.LIQCAJNUM
    	                                JOIN  CXC_CLIENTES cc 
    		                                ON a.PAICOD = cc.PAICOD 
    		                                AND a.EMPCOD = cc.EMPCOD 
    		                                AND b.CLICOD = cc.CLICOD 
                                where a.PAICOD = '00001'
                                and a.EMPCOD = '00001'
                                and a.LiqCajSta <> 'AN' 
                                and b.LiqCajRecNum <> 0
                                and b.LiqCajRutaMonAbo > 0 
                                and b.LiqCajMotCod = 9 --motivo
                                and a.LiqCajTipRutCod in ( ' ','DDI')
                                AND a.LIQCAJNUM =" + id;
            try
            {
                using (var context = new OracleConnection(Parametros.CadenaConnexion))
                {
                    context.Open();

                    var cmd = new OracleCommand(consulta, context);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var oDeposito = new Depositos();
                            {
                                oDeposito.EmpCod = Convert.ToString(reader["EMPCOD"]);
                                oDeposito.clicod = Convert.ToString(reader["CLIENTE"]);
                                oDeposito.Serie = Convert.ToString(reader["SERIE"]);
                                oDeposito.Numero = Convert.ToInt32(reader["NUMERO"]);
                                oDeposito.FechaAlta = Convert.ToDateTime(reader["FECHA"]);
                                oDeposito.ClienteRazon = Convert.ToString(reader["Nombre"]);
                                oDeposito.Monto = Convert.ToDouble(reader["MONTO"]);
                                oDeposito.NumeroLiquidacion = Convert.ToInt64(reader["NoLiquidacion"]);
                                oDeposito.UsuAlt = Convert.ToString(reader["Usuario"]);
                                oDeposito.NumeroPromesa = Convert.ToInt64(reader["NoPromesa"]);
                            };
                            oDeposito.MontoLetras = convertir.enletras(oDeposito.Monto.ToString());
                            oLiquidacion.Add(oDeposito);
                        }
                    }
                }
                return oLiquidacion;
            }
            catch (Exception error)
            {
                
                throw;
            }
        }
    }
}
