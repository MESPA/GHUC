



var man = new $;
    $('#btngh').click(function (e) {
        if ($('#Descripcion').val() === "") {
            sweetAlert("¡El expediente no debe estar vacío!");
            // alert ("¡El archivo no debe estar vacío!");
            return false;
        }
        else if ($('#nombrearea').val() === "") {
            sweetAlert("¡El Campo Cantidad Donar no debe estar vacío!");
            // alert ("¡El archivo no debe estar vacío!");
            return false;
        }

       man ('#btngh').click(
            function (e) {
                var res = validate();
                if (res == false) {
                    return false;
                }

                var url = "/UnidadCapacitacion/UnidadCapacitacion";
                var empObj = {

                    Descripcion: $('#Descripcion').val(),
                    Departamento: $('#Departamento').val(),
                    Fecha: $('#Fecha').val(),
                    Administrador: $('#Administrador').val(),
                    nombrearea: $('#nombrearea').val(),
                    cursorequerido: $('#cursorequerido').val(),
                    cantidadempleado: $('#cantidadempleado').val(),
                    importancia: $('#importancia').val(),
                    puestoempleado: $('#puestoempleado').val(),
                    IdDepartamentoss: $('#IdDepartamentoss').val(),

                }

                $.ajax({
                    url: url,
                    data: JSON.stringify(empObj),
                    type: "POST",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: true,
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                    }
                });

            });

    });