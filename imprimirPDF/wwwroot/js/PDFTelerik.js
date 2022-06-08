$(".export-pdf").click(function () {

    $(".export-pdf").click(function () {
        // Convierta el elemento DOM en un dibujo usando kendo.drawing.drawDOM
        kendo.drawing.drawDOM($("#ReciboImprimir"))
            .then(function (group) {
                // Renderizar el resultado como un archivo PDF
                return kendo.drawing.exportPDF(group, {
                    paperSize: "auto",
                    margin: { left: "1cm", top: "1cm", right: "1cm", bottom: "1cm" }
                });
            })
            .done(function (data) {
                // Guarda el archivo PDF
                kendo.saveAs({
                    dataURI: data,
                    fileName: "Mitest.pdf",
                    proxyURL: "https://demos.telerik.com/kendo-ui/service/export"
                });
            });
    });
});