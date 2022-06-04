using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imprimirPDF.Models.ViewModels;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace imprimirPDF.CapaNegocio
{

    public class Factura
    {
        public string Cadena = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.12)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=MMC))); User Id=ADMINISTRADOR;Password=1nfabc123;";
       // string consulta = "";

        public static Factura _instancia = null;

        private Factura()
        {

        }

        public static Factura Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Factura();
                }
                return _instancia;
            }
        }
        public List<FacturaViewModel> Listar()
        {
            List<FacturaViewModel> oFactura = new List<FacturaViewModel>();
            using (OracleConnection db = new OracleConnection(Cadena))
            {
                string consulta = @"SELECT ff.FACFECALT, ff.FACANOMDE, ff.CLICOD, ff.FACDIRFAC, ffd.FACCANFAC, ffd.ARTCOD, ffd.FACPREFAC
                                        FROM FAC_FACTURA ff 
	                                        INNER JOIN FAC_FACTURA_DETALLE ffd 
		                                        ON ff.FACNOTX = ffd.FACNOTX 
                                        WHERE ff.EMPCOD = '00002'
                                        AND ff.TIECOD = '00001'
                                        AND ff.FACSER = 'E'
                                        AND ff.FACNUM = 59476";
                db.Open();
                using (OracleCommand cmd = new OracleCommand(consulta, db))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {                                
                            oFactura.Add(new FacturaViewModel()
                            { 
                                FacFecAlt = dr.GetDateTime(0),
                                FacANomD = dr.GetString(1),
                                CliCod = dr.GetString(2),
                                facDirFac = dr.GetString(3),
                                FacCanFac = dr.GetInt32(4),
                                ArtCod = dr.GetString(5),
                                FacPreFac = dr.GetInt32(6)

                                //FacFecAlt = (DateTime)dr["FACFECALT"],
                                //FacANomD = dr["FACANOMDE"].ToString(),
                                //CliCod = dr["CLICOD"].ToString(),
                                //facDirFac = dr["FACDIRFAC"].ToString(),
                                //FacCanFac = (int)dr[""],
                                //ArtCod = dr["ARTCOD"].ToString(),
                                //FacPreFac = (float)dr["FACPREFAC"]
                            });
                        }
                    }
                }
                return oFactura;
            }
        }
    }
}
