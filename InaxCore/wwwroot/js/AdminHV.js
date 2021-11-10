/*Esta funcion es para cargar el datatable*/
function cargarTablaHerramientas() {
  url = $('#urlGetHerramientas').data('request-url');
  //$('#table_herramientasventa').DataTable().destroy();
  var table = $('#table_herramientasventa').DataTable({
    destroy: true,
    search: true,
    paging: true,
    info: false,
    responsive: true,
    ajax: {
      processing: true,
      serverSide: true,
      url: url,
      type: 'POST',
      data: {}
    },
    columns: [
      { title: 'CLAVE DEL EQUIPO', width: '25%' },
      { title: 'DESCRIPCIÓN', width: '40%' },
      { title: 'ACCESO A HERRAMIENTAS', width: '30%' },
      { title: 'ACCIONES', width: '5%' },
    ]
  });
};

/**
 * Esta función es para editar la datatable:
 * @param {any} Id
 * @param {any} SKU
 * @param {any} Descripcion
 * @param {any} Enlace
 */
function editar(Id, SKU, Descripcion, Enlace) {
  const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer)
      toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
  })

  var url = $('#urlUpdateHerramientas').data('request-url');
  html = '';
  html += '<div class="row">';
  html += ' <div class="col-md-4">';
  html += '   <label for="SKU">Clave del Equipo</label>';
  html += '   <input type="text" class="form-control" id="sku" value="' + SKU + '"/>';
  html += ' </div>';
  html += ' <div class="col-md-4">';
  html += '   <label for="Descripcion">Descripción</label>';
  html += '   <input type="text" class="form-control" id="Descripcion" value="' + Descripcion + '"/>';
  html += ' </div>';
  html += ' <div class="col-md-4">';
  html += '   <label for="Enlace">Enlace</label>';
  html += '   <input type="text" class="form-control" id="Enlace" value="' + Enlace + '"/>';
  html += ' </div>';
  html += '</div>';
  Swal.fire({
    title: 'Actualizar Datos',
    html: html,
    width: 1000,
    allowOutsideClick: false,
    showCancelButton: true,
    cancelButtonText: 'Cancelar',
    confirmButtonText: 'Actualizar',
    confirmButtonColor: '#334f8c'
  }).then(function (res) {
    console.log(res);
    if (res.isConfirmed) {
      SKU2 = $('#sku').val();
      Descripcion2 = $('#Descripcion').val();
      Enlace2 = $('#Enlace').val();
      if (SKU2 == '' || Descripcion2 == '' || Enlace2 == '') {
        Toast.fire({
          icon: 'error',
          title: 'Llene todos los campos'
        })
      } else {
        $.ajax({
          url: url,
          type: 'POST',
          dataType: "JSON",
          data: { Id, SKU: SKU2, Descripcion: Descripcion2, Enlace: Enlace2 },
          success: function (data) {
            if (data.status > 0) {
              Swal.fire('Exito!.', 'Proceso efectuado satisfactoriamente', 'success').then(function (res) {
                if (res) { location.reload(); }
              });
            } else {
              Swal.fire('Atencion!.', 'Se registró un problema al actualizar datos', 'error').then(function (res) {
                if (res) { location.reload(); }
              });
            }
          }
        });
      }
    }
  },
    function (dismiss) {
      if (dismiss == 'cancel') {
        console.log('cancel agregar/editar datos');
      }
    }
  )
}

/**
 * Esta función es para agregar a la datatable:
 * @param {any} SKU
 * @param {any} Descripcion
 * @param {any} Enlace
 */
function Agregar() {
  const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer)
      toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
  })

  var url = $('#urlSaveHerramientas').data('request-url');
  html = '';
  html += '<div class="row">';
  html += ' <div class="col-md-4">';
  html += '   <label for="SKU">Clave del Equipo</label>';
  html += '   <input type="text" class="form-control" id="sku" value=""/>';
  html += ' </div>';
  html += ' <div class="col-md-4">';
  html += '   <label for="Descripcion">Descripción</label>';
  html += '   <input type="text" class="form-control" id="Descripcion" value=""/>';
  html += ' </div>';
  html += ' <div class="col-md-4">';
  html += '   <label for="Enlace">Enlace</label>';
  html += '   <input type="text" class="form-control" id="Enlace" value=""/>';
  html += ' </div>';
  html += '</div>';

  Swal.fire({
    title: '<h1>Agregar Herramienta de Venta</h1>',
    html: html,
    width: 1000,
    allowOutsideClick: false,
    showCancelButton: true,
    cancelButtonText: 'Cancelar',
    confirmButtonText: 'Agregar',
    confirmButtonColor: '#334f8c'
  }).then(function (res) {
    if (res.isConfirmed) {
      SKU2 = $('#sku').val();
      Descripcion2 = $('#Descripcion').val();
      Enlace2 = $('#Enlace').val();
      if (SKU2 == '' || Descripcion2 == '' || Enlace2 == '') {
        Toast.fire({
          icon: 'error',
          title: 'Llene todos los campos'
        })
      } else {
        $.ajax({
          url: url,
          type: 'POST',
          dataType: "JSON",
          data: { SKU: SKU2, Descripcion: Descripcion2, Enlace: Enlace2 },
          success: function (data) {
            if (data.status > 0) {
              Swal.fire('Exito!.', 'Proceso efectuado satisfactoriamente', 'success').then(function (res) {
                if (res) { location.reload(); }
              });
            } else {
              Swal.fire('Atencion!.', 'Se registró un problema al actualizar datos', 'error').then(function (res) {
                if (res) { location.reload(); }
              });
            }
          }
        });
      }
    }
  },
    function (dismiss) {
      if (dismiss == 'cancel') {
        console.log('cancel agregar/editar datos');
      }
    })
}

//Evento para habiltar o deshabiltar los minimos de venta
function deshabilitar(sku, obj) {
  var url = $('#urlDisableHerramientas').data('request-url');
    var sku = $(obj).data('sku');
    var status = 0;
    if ($(obj).is(':checked')) {
      status = '1';
    }
    $.ajax({
      url: url,
      type: "POST",
      dataType: "json",
      data: { status, sku },
      success: function (res) {
        console.log(res.status);
        if (res.status > 0) {
          Swal.fire('Exito!', 'Estado actualizado correctamente', 'success').then(function (res) {
            if (res) {
              console.log(res);
            }
          });
        } else {
          Swal.fire('Error', 'Ocurrio un error al actualizar los datos', 'error');
        }
          console.log(res);
      }
    });
}