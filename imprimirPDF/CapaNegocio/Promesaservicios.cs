using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imprimirPDF.Models.ViewModels;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using imprimirPDF.Models;
using imprimirPDF.common;

namespace imprimirPDF.CapaNegocio
{

    public class PromesaServicio
    {
        public static PromesaServicio _instancia = null;

        private PromesaServicio()
        {

        }

        public static PromesaServicio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PromesaServicio();
                }
                return _instancia;
            }
        }
        public List<CXC_Clientes> GetAll()
        {
            List<CXC_Clientes> oClientes = new List<CXC_Clientes>();

            try
            {
                using (OracleConnection db = new OracleConnection(Parametros.CadenaConnexion))
                {
                    string consulta = @"SELECT EMPCOD, CLICOD Codigo, CLIRAZSOC Razon, CLINOM Nombre, CLITEL1 Celular, CLITEL2 Casa, CLITEL3 Otro, CLINIT NIT, CLIEMA Email,
                CLIFECALT FechaAlta, CLIUSUALT UsuarioAlta, CLIEST Estatus, CLISHESTCIV EstadoCivil, CLINUMDOC DPI_POSIBLE, CLISHSEX Genero, CLISHNOMPAD Padre,
                CLISHNOMMAD Madre, CLISHNOMCON Conyuge, CLIPERFAMDIOS PerteneceIglesia, CLICODMIEMBRO CodigoMiebro, CLISHUGCMUNCOD CodMun, PROFCOD, 
				CLISHDIRACT Direccion, CLISHUGCDEPCOD codDepto, CLISHUGCMUNCOD codMun, CLISHUGCZONCOD zona, CLISOCHON
                                    FROM CXC_CLIENTES cc 
                                    WHERE EMPCOD = '00001'
                                    AND CliTel1 = '33335728'";
                    db.Open();
                    using (OracleCommand cmd = new OracleCommand(consulta, db))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                #region otra forma de cargar al cliente
                                //var buscaCliente = new CXC_Clientes();
                                //{
                                //    buscaCliente.EmpCod = Convert.ToString(dr["EMPCOD"]);
                                //    buscaCliente.CODIGO = Convert.ToString(dr["Codigo"]);
                                //    buscaCliente.RAZON = Convert.ToString(dr["Razon"]);
                                //    buscaCliente.NOMBRE = Convert.ToString(dr["Nombre"]);
                                //    buscaCliente.CELULAR = Convert.ToString(dr["Celular"]);
                                //    buscaCliente.CASA = Convert.ToString(dr["Casa"]);
                                //    buscaCliente.OTRO = Convert.ToString(dr["Otro"]);
                                //    buscaCliente.NIT = Convert.ToString(dr["NIT"]);
                                //    buscaCliente.EMAIL = Convert.ToString(dr["Email"]);
                                //    buscaCliente.FechAlt = Convert.ToDateTime(dr["FechaAlta"]);
                                //    buscaCliente.UsuAlt = Convert.ToString(dr["UsuarioAlta"]);
                                //    buscaCliente.ESTATUS = Convert.ToString(dr["Estatus"]);
                                //    buscaCliente.ESTADOCIVIL = Convert.ToString(dr["EstadoCivil"]);
                                //    buscaCliente.DPI_POSIBLE = Convert.ToString(dr["DPI_POSIBLE"]);
                                //    buscaCliente.GENERO = Convert.ToString(dr["Genero"]);
                                //    buscaCliente.PADRE = Convert.ToString(dr["Padre"]);
                                //    buscaCliente.MADRE = Convert.ToString(dr["Madre"]);
                                //    buscaCliente.CONYUGE = Convert.ToString(dr["Conyuge"]);
                                //    buscaCliente.PERTENECEIGLESIA = Convert.ToString(dr["PerteneceIglesia"]);
                                //    buscaCliente.CODIGOMIEBRO = Convert.ToString(dr["CodigoMiebro"]);
                                //    buscaCliente.CODMUN = Convert.ToString(dr["CodMun"]);
                                //    buscaCliente.PROFCOD = Convert.ToString(dr["PROFCOD"]);
                                //    buscaCliente.DIRECCION = Convert.ToString(dr["Direccion"]);
                                //    buscaCliente.CODDEPTO = Convert.ToString(dr["codDepto"]);
                                //    buscaCliente.ZONA = Convert.ToString(dr["zona"]);
                                //    buscaCliente.CLISOCHON = Convert.ToString(dr["CLISOCHON"]);
                                //}

                                //oClientes.Add(buscaCliente);
                                #endregion

                                oClientes.Add(new CXC_Clientes()
                                {
                                    EmpCod = Convert.ToString(dr["EMPCOD"]),
                                    CODIGO = Convert.ToString(dr["Codigo"]),
                                    RAZON = Convert.ToString(dr["Razon"]),
                                    NOMBRE = Convert.ToString(dr["Nombre"]),
                                    CELULAR = Convert.ToString(dr["Celular"]),
                                    CASA = Convert.ToString(dr["Casa"]),
                                    OTRO = Convert.ToString(dr["Otro"]),
                                    NIT = Convert.ToString(dr["NIT"]),
                                    EMAIL = Convert.ToString(dr["Email"]),
                                    FechAlt = Convert.ToDateTime(dr["FechaAlta"]),
                                    UsuAlt = Convert.ToString(dr["UsuarioAlta"]),
                                    ESTATUS = Convert.ToString(dr["Estatus"]),
                                    ESTADOCIVIL = Convert.ToString(dr["EstadoCivil"]),
                                    DPI_POSIBLE = Convert.ToString(dr["DPI_POSIBLE"]),
                                    GENERO = Convert.ToString(dr["Genero"]),
                                    PADRE = Convert.ToString(dr["Padre"]),
                                    MADRE = Convert.ToString(dr["Madre"]),
                                    CONYUGE = Convert.ToString(dr["Conyuge"]),
                                    PERTENECEIGLESIA = Convert.ToString(dr["PerteneceIglesia"]),
                                    CODIGOMIEBRO = Convert.ToString(dr["CodigoMiebro"]),
                                    CODMUN = Convert.ToString(dr["CodMun"]),
                                    PROFCOD = Convert.ToString(dr["PROFCOD"]),
                                    DIRECCION = Convert.ToString(dr["Direccion"]),
                                    CODDEPTO = Convert.ToString(dr["codDepto"]),
                                    ZONA = Convert.ToString(dr["zona"]),
                                    CLISOCHON = Convert.ToString(dr["CLISOCHON"]),
                                });
                            }
                        }
                    }
                    return oClientes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CXC_Clientes> ClinetesById(string clicod)
        {
            List<CXC_Clientes> oClientes = new List<CXC_Clientes>();
            string consulta = @"SELECT  EMPCOD, CLICOD Codigo, CLIRAZSOC Razon, CLINOM Nombre, CLITEL1 Celular, CLITEL2 Casa, CLITEL3 Otro, CLINIT NIT, CLIEMA Email,
                                        CLIFECALT FechaAlta, CLIUSUALT UsuarioAlta, CLIEST Estatus, CLISHESTCIV EstadoCivil, CLINUMDOC DPI_POSIBLE, CLISHSEX Genero, CLISHNOMPAD Padre,
                                        CLISHNOMMAD Madre, CLISHNOMCON Conyuge, CLIPERFAMDIOS PerteneceIglesia, CLICODMIEMBRO CodigoMiebro, CLISHUGCMUNCOD CodMun, PROFCOD, 
				                        CLISHDIRACT Direccion, CLISHUGCDEPCOD codDepto, CLISHUGCZONCOD zona, CLISOCHON
                                FROM CXC_CLIENTES cc 
                                   WHERE EMPCOD ='00001'
                                   AND CLICOD = '" + clicod + "'";

            try
            {
                using (OracleConnection context = new OracleConnection(Parametros.CadenaConnexion))
                {
                    context.Open();
                    OracleCommand cmd = new OracleCommand(consulta, context);
                        
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                        while (dr.Read())
                        {
                                var buscaCliente = new CXC_Clientes();
                                {
                                    buscaCliente.EmpCod = Convert.ToString(dr["EMPCOD"]);
                                    buscaCliente.CODIGO = Convert.ToString(dr["Codigo"]);
                                    buscaCliente.RAZON = Convert.ToString(dr["Razon"]);
                                    buscaCliente.NOMBRE = Convert.ToString(dr["Nombre"]);
                                    buscaCliente.CELULAR = Convert.ToString(dr["Celular"]);
                                    buscaCliente.CASA = Convert.ToString(dr["Casa"]);
                                    buscaCliente.OTRO = Convert.ToString(dr["Otro"]);
                                    buscaCliente.NIT = Convert.ToString(dr["NIT"]);
                                    buscaCliente.EMAIL = Convert.ToString(dr["Email"]);
                                    buscaCliente.FechAlt = Convert.ToDateTime(dr["FechaAlta"]);
                                    buscaCliente.UsuAlt = Convert.ToString(dr["UsuarioAlta"]);
                                    buscaCliente.ESTATUS = Convert.ToString(dr["Estatus"]);
                                    buscaCliente.ESTADOCIVIL = Convert.ToString(dr["EstadoCivil"]);
                                    buscaCliente.DPI_POSIBLE = Convert.ToString(dr["DPI_POSIBLE"]);
                                    buscaCliente.GENERO = Convert.ToString(dr["Genero"]);
                                    buscaCliente.PADRE = Convert.ToString(dr["Padre"]);
                                    buscaCliente.MADRE = Convert.ToString(dr["Madre"]);
                                    buscaCliente.CONYUGE = Convert.ToString(dr["Conyuge"]);
                                    buscaCliente.PERTENECEIGLESIA = Convert.ToString(dr["PerteneceIglesia"]);
                                    buscaCliente.CODIGOMIEBRO = Convert.ToString(dr["CodigoMiebro"]);
                                    buscaCliente.CODMUN = Convert.ToString(dr["CodMun"]);
                                    buscaCliente.PROFCOD = Convert.ToString(dr["PROFCOD"]);
                                    buscaCliente.DIRECCION = Convert.ToString(dr["Direccion"]);
                                    buscaCliente.CODDEPTO = Convert.ToString(dr["codDepto"]);
                                    buscaCliente.ZONA = Convert.ToString(dr["zona"]);
                                    buscaCliente.CLISOCHON = Convert.ToString(dr["CLISOCHON"]);
                                }

                                oClientes.Add(buscaCliente);
                            }
                            foreach (var cliente in oClientes)
                            {
                                obtienePromea(cliente, context);
                            }                         
                        }
                    return oClientes;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return oClientes;
            }
        }

        private void obtienePromea(CXC_Clientes Cliente, OracleConnection context)
        {
            var result = new List<CXC_Captaciones>();
            var cliclod = Cliente.CODIGO;
            var consulta = @"SELECT CAPNUM promesa, CAPFCH, TIPCAPCOD, CAPSTA, CAPUSUALT 
	                             FROM CXC_CAPTACIONES cc 
	                             WHERE PAICOD = '00001'
	                             AND EMPCOD = '00001'

	                             AND CLICOD ='" + cliclod + "'";
            var cmd = new OracleCommand(consulta, context);

            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var oPromesa = new CXC_Captaciones
                        {
                            PROMESA = dr.GetInt32(0),
                            FechAlt = dr.GetDateTime(1),
                            TIPCAPCOD = dr.GetString(2),
                            ESTATUS = dr.GetString(3),
                            UsuAlt = dr.GetString(4),
                        };

                        result.Add(oPromesa);
                        Cliente.Promesas = result;
                    }
                }
                //foreach (var detalle in factura.detalle)
                //{
                //    ObtenerArticulo(detalle, context);
                //}
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                throw;
            }
        }
    }
}
