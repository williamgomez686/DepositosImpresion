using imprimirPDF.common;
using imprimirPDF.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imprimirPDF.CapaNegocio
{
    public class FacturaServicios
    {
        public IEnumerable<Fac_Factura> GetAll()
        {
            var cadena = Parametros.CadenaConnexion;
            var result = new List<Fac_Factura>();
            var consulta = @"SELECT PAICOD , EMPCOD , TIECOD , CAJCOD , FACNOTX ,TTRCOD , VENCOD , CLICOD , FACANOMDE , FACANIT , FACDIRFAC , FACDIRENT , FACEST 
                                , FACOBS , FACIVA , FACTASCAM , FACSER , FACNUM , FACTOTFAC , FACTOTDES , FACFECALT , FACUSUALT ,FACHORALT 
                                FROM FAC_FACTURA ff 
                                WHERE empcod = '00002'
                                AND TIECOD = '00001'
                                AND FACNOTX IN (145675)";

            try
            {
                using (var context = new OracleConnection(cadena))
                {
                    context.Open();

                    var cmd = new OracleCommand(consulta, context);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var oFactura = new Fac_Factura
                            {
                                PaiCod = reader.GetString(0),
                                EmpCod = reader.GetString(1),
                                TieCod = reader.GetString(2),
                                CajCod = reader.GetString(3),
                                FacNotx = reader.GetInt32(4),
                                TtrCod = reader.GetString(5),
                                VenCod = reader.GetString(6),
                                CliCod = reader.GetString(7),
                                FacANomDe = reader.GetString(8),
                                FacANit = reader.GetString(9),
                                FacDirFac = reader.GetString(10),
                                FacDirRent = reader.GetString(11),
                                FacEst = reader.GetString(12),
                                FacObs = reader.GetString(13),
                                FacIva = reader.GetInt32(14),
                                FacTasCam = reader.GetInt32(15),
                                FacSer = reader.GetString(16),
                                FacNum = reader.GetInt32(17),
                                FacToFac = reader.GetInt32(18),
                                FacToDes = reader.GetInt32(19),
                                FechAlt = reader.GetDateTime(20),
                                UsuAlt = reader.GetString(21),
                                FacHoraAlt = reader.GetString(22)
                            };
                            result.Add(oFactura);
                        }
                        //obtenemos al cliente
                        foreach (var factura in result)
                        {
                            //Cliente
                            obtieneCliente(factura, context); 
                            //Detalle de la factura
                            obtieneDetalle(factura, context);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return result;
            }
        }
        public List<Fac_Factura> ListaFacturas()
        {
            var consulta = @"SELECT PAICOD , EMPCOD , TIECOD , CAJCOD , FACNOTX ,TTRCOD , VENCOD , CLICOD , FACANOMDE , FACANIT , FACDIRFAC , FACDIRENT , FACEST 
                                , FACOBS , FACIVA , FACTASCAM , FACSER , FACNUM , FACTOTFAC , FACTOTDES , FACFECALT , FACUSUALT ,FACHORALT 
                                FROM FAC_FACTURA ff 
                                WHERE empcod = '00002'
                                AND TIECOD = '00001'
                                AND CAJCOD = '00001'
                                AND FACEST = 'C'
                                AND FACFECALT >= '03/01/2018'
                                AND FACFECALT <= '4/01/2018'";
            //var oFactura = new Fac_Factura();
            List<Fac_Factura> result = new List<Fac_Factura>();
            using (var context = new OracleConnection(Parametros.CadenaConnexion))
            {
                context.Open();

                var cmd = new OracleCommand(consulta, context);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var oFactura = new Fac_Factura
                        {
                            PaiCod = reader.GetString(0),
                            EmpCod = reader.GetString(1),
                            TieCod = reader.GetString(2),
                            CajCod = reader.GetString(3),
                            FacNotx = reader.GetInt32(4),
                            TtrCod = reader.GetString(5),
                            VenCod = reader.GetString(6),
                            CliCod = reader.GetString(7),
                            FacANomDe = reader.GetString(8),
                            FacANit = reader.GetString(9),
                            FacDirFac = reader.GetString(10),
                            FacDirRent = reader.GetString(11),
                            FacEst = reader.GetString(12),
                            FacObs = reader.GetString(13),
                            FacIva = reader.GetInt32(14),
                            FacTasCam = reader.GetInt32(15),
                            FacSer = reader.GetString(16),
                            FacNum = reader.GetInt32(17),
                            FacToFac = reader.GetDecimal(18),
                            FacToDes = reader.GetInt32(19),
                            FechAlt = reader.GetDateTime(20),
                            UsuAlt = reader.GetString(21),
                            FacHoraAlt = reader.GetString(22)
                        };
                        result.Add(oFactura);
                    }          
                }              
                //obtieneDetalle(oFactura, context);
            }
            return result;
        }

        public Fac_Factura verFactura(int id)
        {
            var consulta = @"SELECT PAICOD , EMPCOD , TIECOD , CAJCOD , FACNOTX ,TTRCOD , VENCOD , CLICOD , FACANOMDE , FACANIT , FACDIRFAC , FACDIRENT , FACEST 
                                , FACOBS , FACIVA , FACTASCAM , FACSER , FACNUM , FACTOTFAC , FACTOTDES , FACFECALT , FACUSUALT ,FACHORALT 
                                FROM FAC_FACTURA ff 
                                WHERE empcod = '00002'
                                AND TIECOD = '00001'
                                AND FACNOTX =" + id;
            var result = new Fac_Factura();
            using (var context = new OracleConnection(Parametros.CadenaConnexion))
            {
                context.Open();

                var cmd = new OracleCommand(consulta, context);

                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    result.PaiCod = Convert.ToString(reader["PAICOD"]);
                    //result.PaiCod = reader.GetString(0);
                    result.EmpCod = reader.GetString(1);
                    result.TieCod = reader.GetString(2);
                    result.CajCod = reader.GetString(3);
                    result.FacNotx = reader.GetInt32(4);
                    result.TtrCod = reader.GetString(5);
                    result.VenCod = reader.GetString(6);
                    result.CliCod = reader.GetString(7);
                    result.FacANomDe = reader.GetString(8);
                    result.FacANit = reader.GetString(9);
                    result.FacDirFac = reader.GetString(10);
                    result.FacDirRent = reader.GetString(11);
                    result.FacEst = reader.GetString(12);
                    result.FacObs = reader.GetString(13);
                    result.FacIva = reader.GetInt32(14);
                    result.FacTasCam = reader.GetInt32(15);
                    result.FacSer = reader.GetString(16);
                    result.FacNum = reader.GetInt32(17);
                    result.FacToFac = reader.GetInt32(18);
                    result.FacToDes = reader.GetInt32(19);
                    result.FechAlt = reader.GetDateTime(20);
                    result.UsuAlt = reader.GetString(21);
                    result.FacHoraAlt = reader.GetString(22);
                }

                obtieneDetalle(result, context);
            }
            return result;
        }

       
        #region "Cliente"
        private void obtieneCliente(Fac_Factura factura, OracleConnection context)
        {
            
            var consulta = @"SELECT PAICOD, EMPCOD, CLICOD, CLIRAZSOC, CLINIT, CLIDIRFAC, CLIFECALT, CLIUSUALT, CLIEST, CLINOM
                                FROM CXC_CLIENTES cc 
                                WHERE EMPCOD = '00002'
                                AND CLICOD ='" + factura.CliCod + "'";
            var cmd = new OracleCommand(consulta, context);

            cmd.CommandType = System.Data.CommandType.Text;
            //using (OracleDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))        
            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    //var Cliente = new CXC_Cliente
                    //{
                    //    PaiCod = reader.GetString(0),
                    //    EmpCod = reader.GetString(1),
                    //    CliCod = reader.GetString(2),
                    //    CliRazSoc = reader.GetString(3),
                    //    //CliTel1 = reader.GetString(4),
                    //    CliNit = reader.GetString(4),
                    //    CliDirFac = reader.GetString(5),
                    //    CliFecAlt = reader.GetDateTime(6),
                    //    CliUsuAlt = reader.GetString(7),
                    //    CliEst = reader.GetString(8),
                    //    CliNom = reader.GetString(9)
                    //    //CliShFchNac = reader.GetDateTime(11),
                    //    //CliShSex = reader.GetString(12)
                    //};
                }
            }
            catch (System.Exception ex)
            {
                var error = ex.Message;
                throw;
            }
        }
        #endregion

        #region "Metodos Privados"
        private void obtieneDetalle(Fac_Factura factura, OracleConnection context)
        {
            var result = new List<Fac_Factura_Detalle>();
            var notx = factura.FacNotx;
            var consulta = @"SELECT PAICOD, EMPCOD , TIECOD ,CAJCOD ,FACNOTX , FACNOLIN , ARTCOD , FACCANFAC , FACPREFAC , FACCOSFAC , FACARTDES , FACCANDES , FACMONIVA , FACMONSINIVA , FACLFECALT 
                                FROM FAC_FACTURA_DETALLE WHERE EMPCOD = '00002' AND FACNOTX =" + notx;
            var cmd = new OracleCommand(consulta, context);
            //cmd.Parameters.Add(new OracleParameter("@notx", OracleDbType.Int32)).Value = notx;
            //cmd.Parameters.Add(new OracleParameter("@notx", notx).Value);

            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var oFactura_Detalle = new Fac_Factura_Detalle
                        {
                            PaiCod = dr.GetString(0),
                            EmpCod = dr.GetString(1),
                            TieCod = dr.GetString(2),
                            CajCod = dr.GetString(3),
                            FacNotx = dr.GetInt32(4),
                            FacNoLin = dr.GetInt32(5),
                            ArtCod = dr.GetString(6),
                            FacCanFac = dr.GetInt32(7),
                            FacPreFac = dr.GetDecimal(8),
                            FacCosFac = dr.GetDecimal(9),
                            FacArtDes = dr.GetString(10),
                            FacCantDes = dr.GetInt32(11),
                            FacMonIVA = dr.GetDecimal(12),
                            FacMonSinIVA = dr.GetDecimal(13),
                            FacFecAlt = dr.GetDateTime(14)
                        };

                        result.Add(oFactura_Detalle);
                        factura.detalle = result;
                    }
                }
                foreach (var detalle in factura.detalle)
                {
                    ObtenerArticulo(detalle, context);
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                throw;
            }
            //throw new NotImplementedException();
        }

        private void ObtenerArticulo(Fac_Factura_Detalle factura_Detalle, OracleConnection context)
        {
            var articulo = factura_Detalle.ArtCod;
            var consulta = @"SELECT PAICOD , EMPCOD  , ARTCOD , ARTDES , ARTDESCOR , ARTFECALT , ARTFECMOD 
                                FROM INV_ARTICULO ia 
                                WHERE EMPCOD  = '00002'                                
                                AND ARTCOD ='" + articulo + "'";

            var cmd = new OracleCommand(consulta, context);

            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    factura_Detalle.Articulo = new Inv_Articulo
                    {
                        PaiCod = Convert.ToString(reader["PAICOD"]),
                        EmpCod = Convert.ToString(reader["EMPCOD"]),
                        ArtCod = Convert.ToString(reader["ARTCOD"]),
                        ArtDes = Convert.ToString(reader["ARTDES"]),
                        ArtDesCor = Convert.ToString(reader["ARTDESCOR"]),
                        FechAlt = Convert.ToDateTime(reader["ARTFECALT"]),
                        FechMod = Convert.ToDateTime(reader["ARTFECMOD"])
                    };
                }
            }
            catch (System.Exception ex)
            {
                var error = ex.Message;
                throw;
            }
        }
        #endregion
    }

}
