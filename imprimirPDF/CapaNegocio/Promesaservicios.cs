using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imprimirPDF.Models.ViewModels;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using imprimirPDF.Models;

namespace imprimirPDF.CapaNegocio
{

    public class PromesaServicio
    {
        public string Cadena = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.7)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=MMC))); User Id=ADMINISTRADOR;Password=1nfabc123;";
       // string consulta = "";

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
                using (OracleConnection db = new OracleConnection(Cadena))
                {
                    string consulta = @"SELECT CLICOD Codigo, CLIRAZSOC Razon, CLINOM Nombre, CLITEL1 Celular, CLITEL2 Casa, CLITEL3 Otro, CLINIT NIT, CLIEMA Email,
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

                                    //PADRE = Convert.ToString(dr["Genero"]),
                                    //MADRE = Convert.ToString(dr["Genero"]),
                                    //CONYUGE = Convert.ToString(dr["Genero"]),
                                    //PERTENECEIGLESIA = Convert.ToString(dr["Genero"]),
                                    //CODIGOMIEBRO = Convert.ToString(dr["Genero"]),
                                    //CODMUN = Convert.ToString(dr["Genero"]),
                                    //GENERO = Convert.ToString(dr["Genero"]),
                                    //GENERO = Convert.ToString(dr["Genero"]),
                                    //GENERO = Convert.ToString(dr["Genero"]),
                                    //GENERO = Convert.ToString(dr["Genero"]),

                                    //GENERO = Convert.ToString(dr["Genero"]),
                                    //FacFecAlt = dr.GetDateTime(0),
                                });
                            }
                        }
                    }
                    return oClientes;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
