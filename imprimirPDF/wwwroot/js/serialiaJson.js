function Obten() {
    fetch("/PDF/test")
        .then(function (res) {
            return res.json();
        })
        .then(function (mijson) {
            let detaller = document.querySelector('#cabecera')
            console.log("Cabecera");
            console.log(mijson.facSer);
            console.log(mijson.facNum);
            console.log(mijson.fechAlt);
            console.log(mijson.facHoraAlt);
            console.log(mijson.facANit);
            console.log(mijson.facANomDe);
            console.log(mijson.facDirRent);
            console.log("nivel detalle");
            var prueba = mijson.facNum;
            detaller.innerHTML = `<p> ${prueba}</p>`;
            detaller.innerHTML = `<p> ${mijson.facANomDe}</p>`;
            console.log("un ciclo for");
            let Resultado = document.querySelector('#tabla');
            //Resultado = '';
            var resul;
            for (let i = 0; i < mijson.detalle.length; i++) {
                console.log(mijson.detalle[i].facCanFac + " " + mijson.detalle[i].artCod + " " + mijson.detalle[i].facDes + " " + mijson.detalle[i].facPreFac)
                Resultado.innerHTML += `
                    <tr>
                        <td>${mijson.detalle[i].facCanFac}</td>
                        <td>${mijson.detalle[i].artCod}</td>
                        <td>${mijson.detalle[i].facDes}</td>
                        <td>${mijson.detalle[i].facPreFac}</td>
                        <td> ${resul = (parseInt(mijson.detalle[i].facCanFac)) * (parseInt(mijson.detalle[i].facPreFac))}  </td>
                    </tr>
                    `;
            }
        })
}