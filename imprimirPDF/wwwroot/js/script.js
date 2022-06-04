const $estado = document.querySelector("#estado"),
    $listaDeImpresoras = document.querySelector("#listaDeImpresoras"),
    $btnLimpiarLog = document.querySelector("#btnLimpiarLog"),
    $btnImprimir = document.querySelector("#btnImprimir");

const obtenerListaDeImpresoras = () => {
    loguear("Cargando lista...");
    ConectorPlugin.obtenerImpresoras()
        .then(listaDeImpresoras => {
            loguear("Lista cargada");
            listaDeImpresoras.forEach(nombreImpresora => {
                const option = document.createElement('option');
                option.value = option.text = nombreImpresora;
                $listaDeImpresoras.appendChild(option);
            })
        })
        .catch(() => {
            loguear("Error obteniendo impresoras. Asegúrese de que el plugin se está ejecutando");
        });
}

const loguear = texto => $estado.textContent += (new Date()).toLocaleString() + " " + texto + "\n";
const limpiarLog = () => $estado.textContent = "";

$btnLimpiarLog.addEventListener("click", limpiarLog);


$btnImprimir.addEventListener("click", async () => {
    let nombreImpresora = $listaDeImpresoras.value;
    if (!nombreImpresora) return loguear("Selecciona una impresora");
    Obten()

    //en esta variable se puede recibir la informacion desde el controlador para imprimir
    var serie = "K";
    var numero = 2020;
    var nombre = 'William Eduardo Gomez Morales'

    const conector = new ConectorPlugin()
        .cortar()
        .feed(1)
        .establecerEnfatizado(1)
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Recursos y Libreria Cristiana\n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .establecerEnfatizado(1)
        .texto("Qunram S.A.\n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .establecerEnfatizado(0)
        .texto("Calzada Roosevelt 2-61 Z. 3\n")
        .establecerFuente(ConectorPlugin.Constantes.FuenteA)
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Colonia Cotio Mixco Guatemala\n")
        .establecerFuente(ConectorPlugin.Constantes.FuenteB)
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("2424-3500 / 2421-3500\n")
        .establecerFuente(ConectorPlugin.Constantes.FuenteC)
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("NIT: 796711-K C\n")
        .feed(1)

        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Numero de Autorizacion: \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("55d4d4fs5az1z4a54d \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Fecha de certificacion: \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("24/12/2021 \n")
        .feed(1)

        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Serie: ")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto(serie + "\n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Numero: ")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto(numero + "\n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("Fecha \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .texto("29/12/2021 \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionIzquierda)
        .texto("Nit: 2548556 \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionIzquierda)
        .texto("Nombre: \n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionIzquierda)
        .texto(nombre + "\n")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionIzquierda)
        .texto("Direccioin: ")
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionIzquierda)
        .texto("Ciudad  \n")
        .establecerTamanioFuente(1, 1)
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionIzquierda); // <- Aquí dejamos de encadenar los métodos, puedes encadenarlos o llamar a la misma operación en cada paso
    // Nota: El tamaño máximo es 8,8 pero no lo pongo porque consume demasiado papel. Para la demostración solo pongo hasta el 3
    for (let i = 1; i <= 3; i++) {
        conector.establecerTamanioFuente(i, i)
            .texto(`Texto con size ${i},${i}\n`);
    }
    conector
        .feed(1)
        .establecerJustificacion(ConectorPlugin.Constantes.AlineacionCentro)
        .establecerTamanioFuente(1, 1)
        .cortar() // Cortar
        conector.feed(2)

    const respuestaAlImprimir = await conector.imprimirEn(nombreImpresora);
    if (respuestaAlImprimir === true) {
        loguear("Impreso correctamente");
    } else {
        loguear("Error. La respuesta es: " + respuestaAlImprimir);
    }
});

obtenerListaDeImpresoras();

function Obten() {
    fetch("~/PDF/test")
        .then(function (res) {
            return res.json();
        })
        .then(function (mijson) {
            let detaller = document.querySelector('#cabecera')
            console.log(mijson);
            console.log("Cabecera");
            console.log(mijson.facSer);
            console.log(mijson.facNum);
            console.log(mijson.fechAlt);
            console.log(mijson.facHoraAlt);
            console.log(mijson.facANit);
            console.log(mijson.facANomDe);
            console.log(mijson.facDirRent);
            console.log("nivel detalle");
            var prueba = mijson.facSer;
            detaller.innerHTML = `<p> ${prueba}</p>`;
            detaller.innerHTML = `<p> ${mijson.facNum}</p>`;
            detaller.innerHTML = `<p> ${mijson.fechAlt}</p>`;
            detaller.innerHTML = `<p> ${mijson.facHoraAlt}</p>`;
            detaller.innerHTML = `<p> ${mijson.facANit}</p>`;
            detaller.innerHTML = `<p> ${mijson.facAnomDe}</p>`;
            detaller.innerHTML = `<p> ${mijson.facDirRent}</p>`;
            console.log("un ciclo for");
            let Resultado = document.querySelector('#tabla');
            var total;
            var resul;
            for (let i = 0; i < mijson.detalle.length; i++) {
                console.log(mijson.detalle[i].facCanFac + " " + mijson.detalle[i].artCod + " " + mijson.detalle[i].facDes + " " + mijson.detalle[i].facPreFac)

                Resultado.innerHTML += `
                    <tr> 
                        <td>${mijson.detalle[i].facCanFac}</td>
                        <td>${mijson.detalle[i].artCod + ` ` + mijson.detalle[i].articulo.artDesCor}</td>
                        <td>${mijson.detalle[i].facDes}</td>
                        <td>${mijson.detalle[i].facPreFac}</td>
                        <td> ${resul = (parseInt(mijson.detalle[i].facCanFac)) * (parseInt(mijson.detalle[i].facPreFac))} </td>
                    </tr>
                    `;
            }
            console.log(mijson.detalle[1].articulo.artDesCor)
        })
}