// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var detail = [];
    $('.select-filter').select2();

    $('#tbDetail').on('click', '.remove', function () {
        var product = $(this).closest('tr').children(':eq(1)').text();
        detail = $.grep(detail, function (item) {
            return item.descripcion !== product;
        });
        $(this).closest('tr').remove();
    });

    $('#btnAdd').on('click', function () {
        var idProducto = $('#ddlProduct').select2('data')[0].id;
        if (detail.some((x) => x.codigoProducto == idProducto)) return;

        detail.push({
            productId: parseInt($('#ddlProduct').select2('data')[0].id),
            quantity: parseFloat($('#txtQuantity').val()),
            description: $('#ddlProduct').select2('data')[0].text,
            unitPrice: parseFloat($('#txtUnitPrice').val())
        });
        var row = `<tr>
                            <td>${$('#txtQuantity').val()}</td>
                            <td>${$('#ddlProduct').select2('data')[0].text}</td>
                            <td>${$('#txtUnitPrice').val()}</td>
                            <td>${parseFloat($('#txtQuantity').val()) * parseFloat($('#txtUnitPrice').val())}</td>
                            <td><button type="button" class="btn btn-danger btn-xs remove">x</button></td>
                        <tr>`;
        $('#tbDetail tbody').append(row);
        clearItem();
    });

    $('#btnSave').on('click', function () {
        if (!detail.length) {
            alert("Debe ingresar los productos");
            return;
        }

        var data = {
            clientId: parseInt($('#ddlClient').select2('data')[0].id),
            orderDetail: detail
        };

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            async: true,
            url: "/Order/SaveOrder",
            data: JSON.stringify(data),
            success: function (result) {
                alert(result);
                clearItem();
                $('#tbDetail tbody').html("");
                detail = [];
            },
            error: function (err) {
                alert("Error interno. Comuniquese con tus administrador");
            }
        });
    });

    function clearItem() {
        $('#txtQuantity').val('');
        $('#txtUnitPrice').val('');
    }
});