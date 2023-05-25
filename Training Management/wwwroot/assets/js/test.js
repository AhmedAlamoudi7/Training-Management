    //$(function () {
    //    $('.form-check-input').click(function () {
    //        var klasID = "";
    //        $('.form-check-input').each(function () {
    //            if ($(this).is(':checked')) {
    //                klasID += $(this).val() + ",";
    //            }
    //        });
    //        $.ajax({
    //            url: '/ProfileAccount/AccountProfileUsers/AdvisorListss?klasID=' + klasID,
    //            method: 'POST',
    //            dataType: "json",
    //            contentType: 'application/json',
    //            data: klasID,
    //            success: function (response) {
    //                var customers = JSON.parse(response.d);
    //                var table = $("#tblCustomers");
    //                table.find("tr:not(:first)").remove();
    //                $.each(customers, function (i, customer) {
    //                    var row = table[0].insertRow(-1);
    //                    $(row).append("<td />");
    //                    $(row).find("td").eq(0).html(customer.CustomerId);
    //                    $(row).append("<td />");
    //                    $(row).find("td").eq(1).html(customer.Name);
    //                    $(row).append("<td />");
    //                    $(row).find("td").eq(2).html(customer.Country);
    //                });
    //            },
    //            error: function (err, response) {
    //                console.log(err, response);
    //                alert(err, response.responseText);
    //            }
    //        })
    //    });
    //    });
