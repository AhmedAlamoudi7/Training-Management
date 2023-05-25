$(document).ready(function () {
    //Initially load pagenumber=1
    GetPageData(1);
});
function GetPageData(pageNum, pageSize) {
    //After every trigger remove previous data and paging
    $("#advisorList").empty();
    $("#paged").empty();
    var selectBox = document.getElementById("selectBox");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    var kt_filter_search = document.getElementById("kt_filter_search");
    if (kt_filter_search.length >0) {
        $.getJSON("/ProfileAccount/AccountProfileUsers/AdvisorList?GeneralSearch=" + $('#kt_filter_search').val(), function (response) {
            var rowData = "";
            for (var i = 0; i < response.data.length; i++) {
                rowData = rowData + '<div class="col-md-6 col-xl-12 col-xxl-6">\
															<div class="card">\
																<div class="card-body d-flex flex-center flex-column pt-12 p-9">\
																	<div class="symbol symbol-65px symbol-circle mb-5">\
																		<img alt="avatar user" src="data:image/png;base64,'+ response.data[i].image + '">\
																		<div class="bg-success position-absolute border border-4 border-body h-15px w-15px rounded-circle translate-middle start-100 top-100 ms-n3 mt-n3"></div>\
																	</div>\
																	<a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="fs-4 text-gray-800 text-hover-primary fw-bold mb-0">' + response.data[i].firstName +' '+ response.data[i].lastName + '</a>\
																	<div class="fw-semibold text-gray-400 mb-6">'+ response.data[i].specializationName + '</div>\
																	<div class="d-flex flex-center flex-wrap">\
																		<div class="border border-gray-300 border-dashed rounded min-w-80px py-3 px-4 mx-2 mb-3">\
																			<div class="fs-6 fw-bold text-gray-700">$'+ response.data[i].perHoure + ' الساعة</div>\
																		</div>\
																		<div class="">\
                                                                            <a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="btn btn-primary">حجز استشارة</a>\
																		</div>\
                                                                      </div>\
																</div>\
															</div>\
														</div>';
            }
            $("#advisorList").append(rowData);
            PaggingTemplate(response.totalPages, response.currentPage);
        });
    } else {
        $.getJSON('/ProfileAccount/AccountProfileUsers/AdvisorList?advisorType=' + selectedValue, { pageNumber: pageNum, pageSize: pageSize }, function (response) {
            var rowData = "";
            for (var i = 0; i < response.data.length; i++) {
                rowData = rowData + '<div class="col-md-6 col-xl-12 col-xxl-6">\
															<div class="card">\
																<div class="card-body d-flex flex-center flex-column pt-12 p-9">\
																	<div class="symbol symbol-65px symbol-circle mb-5">\
																		<img alt="avatar user" src="data:image/png;base64,'+ response.data[i].image + '">\
																		<div class="bg-success position-absolute border border-4 border-body h-15px w-15px rounded-circle translate-middle start-100 top-100 ms-n3 mt-n3"></div>\
																	</div>\
																	<a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="fs-4 text-gray-800 text-hover-primary fw-bold mb-0">' + response.data[i].firstName +' ' + response.data[i].lastName + '</a>\
																	<div class="fw-semibold text-gray-400 mb-6">'+ response.data[i].specializationName + '</div>\
																	<div class="d-flex flex-center flex-wrap">\
																		<div class="border border-gray-300 border-dashed rounded min-w-80px py-3 px-4 mx-2 mb-3">\
																			<div class="fs-6 fw-bold text-gray-700">$'+ response.data[i].perHoure + ' الساعة</div>\
																		</div>\
																		<div class="">\
                                                                            <a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="btn btn-primary">حجز استشارة</a>\
																		</div>\
                                                                      </div>\
																</div>\
															</div>\
														</div>';

            }
            $("#advisorList").append(rowData);
            PaggingTemplate(response.totalPages, response.currentPage);
        });
    }





}

function changeFunc(pageNum, pageSize) {
    //After every trigger remove previous data and paging
    $("#advisorList").empty();
    $("#paged").empty();
    var selectBox = document.getElementById("selectBox");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    $.getJSON('/ProfileAccount/AccountProfileUsers/AdvisorList?advisorType=' + selectedValue, { pageNumber: pageNum, pageSize: pageSize }, function (response) {
        var rowData = "";
        for (var i = 0; i < response.data.length; i++) {
            rowData = rowData + '<div class="col-md-6 col-xl-12 col-xxl-6">\
															<div class="card">\
																<div class="card-body d-flex flex-center flex-column pt-12 p-9">\
																	<div class="symbol symbol-65px symbol-circle mb-5">\
																		<img alt="avatar user" src="data:image/png;base64,'+ response.data[i].image + '">\
																		<div class="bg-success position-absolute border border-4 border-body h-15px w-15px rounded-circle translate-middle start-100 top-100 ms-n3 mt-n3"></div>\
																	</div>\
																	<a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="fs-4 text-gray-800 text-hover-primary fw-bold mb-0">' + response.data[i].firstName  +' ' + response.data[i].lastName + '</a>\
																	<div class="fw-semibold text-gray-400 mb-6">'+ response.data[i].specializationName + '</div>\
																	<div class="d-flex flex-center flex-wrap">\
																		<div class="border border-gray-300 border-dashed rounded min-w-80px py-3 px-4 mx-2 mb-3">\
																			<div class="fs-6 fw-bold text-gray-700">$'+ response.data[i].perHoure + ' الساعة</div>\
																		</div>\
																		<div class="">\
                                                                            <a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="btn btn-primary">حجز استشارة</a>\
																		</div>\
                                                                      </div>\
																</div>\
															</div>\
														</div>';
        }
        $("#advisorList").append(rowData);
        PaggingTemplate(response.totalPages, response.currentPage);
    });

}
$('.specialIds').click(function (pageNum, pageSize) {
    //$("input:checkbox").change(function (pageNum, pageSize) {
        //After every trigger remove previous data and paging form-check-input

    var SpecialIds = "";
    $('.specialIds').each(function () {
            if ($(this).is(':checked')) {
                SpecialIds += $(this).val() + ",";
            }
    });
    var degreeIds = "";
    $('.degreeIds').each(function () {
        if ($(this).is(':checked')) {
            degreeIds += $(this).val() + ",";
        }
    });
    $.ajax({
        url: '/ProfileAccount/AccountProfileUsers/AdvisorList?SpecialIds=' + SpecialIds + '&degreeIds=' + degreeIds, pageNumber: pageNum, pageSize: pageSize,
            method: 'POST',
            dataType: "json",
            contentType: 'application/json',
            success: function (response) {
                $("#advisorList").empty();
                $("#paged").empty();
                var rowData = "";
                for (var i = 0; i < response.data.length; i++) {
                    rowData = rowData + '<div class="col-md-6 col-xl-12 col-xxl-6">\
															<div class="card">\
																<div class="card-body d-flex flex-center flex-column pt-12 p-9">\
																	<div class="symbol symbol-65px symbol-circle mb-5">\
																		<img alt="avatar user" src="data:image/png;base64,'+ response.data[i].image + '">\
																		<div class="bg-success position-absolute border border-4 border-body h-15px w-15px rounded-circle translate-middle start-100 top-100 ms-n3 mt-n3"></div>\
																	</div>\
																	<a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="fs-4 text-gray-800 text-hover-primary fw-bold mb-0">' + response.data[i].firstName + ' ' + response.data[i].lastName + '</a>\
																	<div class="fw-semibold text-gray-400 mb-6">'+ response.data[i].specializationName + '</div>\
																	<div class="d-flex flex-center flex-wrap">\
																		<div class="border border-gray-300 border-dashed rounded min-w-80px py-3 px-4 mx-2 mb-3">\
																			<div class="fs-6 fw-bold text-gray-700">$'+ response.data[i].perHoure + ' الساعة</div>\
																		</div>\
																		<div class="">\
                                                                            <a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="btn btn-primary">حجز استشارة</a>\
																		</div>\
                                                                      </div>\
																</div>\
															</div>\
														</div>';
                }
                $("#advisorList").append(rowData);
                PaggingTemplate(response.totalPages, response.currentPage);

            },
        error: function (err, response) {
            location.reload();
            }
        })
});
//});
$('.degreeIds').click(function (pageNum, pageSize) {
    //$("input:checkbox").change(function (pageNum, pageSize) {
    //After every trigger remove previous data and paging form-check-input
    $("#advisorList").empty();
    $("#paged").empty();
    var degreeIds = "";
    $('.degreeIds').each(function () {
        if ($(this).is(':checked')) {
            degreeIds += $(this).val() + ",";
        }
    });
    var SpecialIds = "";
    $('.specialIds').each(function () {
        if ($(this).is(':checked')) {
            SpecialIds += $(this).val() + ",";
        }
    });
    $.ajax({
        url: '/ProfileAccount/AccountProfileUsers/AdvisorList?degreeIds=' + degreeIds + '&SpecialIds=' + SpecialIds, pageNumber: pageNum, pageSize: pageSize,
        method: 'POST',
        dataType: "json",
        contentType: 'application/json',
        success: function (response) {
            $("#advisorList").empty();
            $("#paged").empty();
            var rowData = "";
            for (var i = 0; i < response.data.length; i++) {
                rowData = rowData + '<div class="col-md-6 col-xl-12 col-xxl-6">\
															<div class="card">\
																<div class="card-body d-flex flex-center flex-column pt-12 p-9">\
																	<div class="symbol symbol-65px symbol-circle mb-5">\
																		<img alt="avatar user" src="data:image/png;base64,'+ response.data[i].image + '">\
																		<div class="bg-success position-absolute border border-4 border-body h-15px w-15px rounded-circle translate-middle start-100 top-100 ms-n3 mt-n3"></div>\
																	</div>\
																	<a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="fs-4 text-gray-800 text-hover-primary fw-bold mb-0">' + response.data[i].firstName + response.data[i].lastName + '</a>\
																	<div class="fw-semibold text-gray-400 mb-6">'+ response.data[i].specializationName + '</div>\
																	<div class="d-flex flex-center flex-wrap">\
																		<div class="border border-gray-300 border-dashed rounded min-w-80px py-3 px-4 mx-2 mb-3">\
																			<div class="fs-6 fw-bold text-gray-700">$'+ response.data[i].perHoure + ' الساعة</div>\
																		</div>\
																		<div class="">\
                                                                            <a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="btn btn-primary">حجز استشارة</a>\
																		</div>\
                                                                      </div>\
																</div>\
															</div>\
														</div>';
            }
            $("#advisorList").append(rowData);
            PaggingTemplate(response.totalPages, response.currentPage);
        },
        error: function (err, response) {
            location.reload();
        }
    })
});
//});


        $("#kt_filter_search").keyup(function () {
            $("#advisorList").empty();
            $("#paged").empty();
            $.getJSON("/ProfileAccount/AccountProfileUsers/AdvisorList?GeneralSearch=" + $('#kt_filter_search').val(), function (response) {
                var rowData = "";
                for (var i = 0; i < response.data.length; i++) {
                    rowData = rowData + '<div class="col-md-6 col-xl-12 col-xxl-6">\
															<div class="card">\
																<div class="card-body d-flex flex-center flex-column pt-12 p-9">\
																	<div class="symbol symbol-65px symbol-circle mb-5">\
																		<img alt="avatar user" src="data:image/png;base64,'+ response.data[i].image + '">\
																		<div class="bg-success position-absolute border border-4 border-body h-15px w-15px rounded-circle translate-middle start-100 top-100 ms-n3 mt-n3"></div>\
																	</div>\
																	<a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="fs-4 text-gray-800 text-hover-primary fw-bold mb-0">' + response.data[i].firstName + response.data[i].lastName + '</a>\
																	<div class="fw-semibold text-gray-400 mb-6">'+ response.data[i].specializationName + '</div>\
																	<div class="d-flex flex-center flex-wrap">\
																		<div class="border border-gray-300 border-dashed rounded min-w-80px py-3 px-4 mx-2 mb-3">\
																			<div class="fs-6 fw-bold text-gray-700">$'+ response.data[i].perHoure + '</div>\
																		</div>\
																		<div class="">\
                                                                            <a href="/ProfileAccount/AccountProfileUsers/AdvisorDetailes/'+ response.data[i].id + '" class="btn btn-primary">حجز استشارة</a>\
																		</div>\
                                                                      </div>\
																</div>\
															</div>\
														</div>';
                }
                $("#advisorList").append(rowData);
                PaggingTemplate(response.totalPages, response.currentPage);
            });
        });
        //This is paging temlpate ,you should just copy paste
        function PaggingTemplate(totalPage, currentPage) {
            var template = "";
            var TotalPages = totalPage;
            var CurrentPage = currentPage;
            var PageNumberArray = Array();


            var countIncr = 1;
            for (var i = currentPage; i <= totalPage; i++) {
                PageNumberArray[0] = currentPage;
                if (totalPage != currentPage && PageNumberArray[countIncr - 1] != totalPage) {
                    PageNumberArray[countIncr] = i + 1;
                }
                countIncr++;
            };
            PageNumberArray = PageNumberArray.slice(0, 5);
            var FirstPage = 1;
            var LastPage = totalPage;
            if (totalPage != currentPage) {
                var ForwardOne = currentPage + 1;
            }
            var BackwardOne = 1;
            if (currentPage > 1) {
                BackwardOne = currentPage - 1;
            }
            $("#paged").empty();
            template = template + '<ul class="pagination">' +
                '<li class="page-item prev"><a href="/ProfileAccount/AccountProfileHome/Advisors#" class="page-link" href="/ProfileAccount/AccountProfileHome/Advisors#" rel="prev" aria-label="Prev &raquo;" onclick="GetPageData(' + BackwardOne + ')">السابق</a></li>';

            var numberingLoop = "";
            if (PageNumberArray.length == 0) {
                numberingLoop = numberingLoop + '<div class="alert alert-warning" role="alert">لا يوجد نتائج !</div> ';
            }
            for (var i = 0; i < PageNumberArray.length; i++) {


                if (PageNumberArray[i] == CurrentPage) {
                    numberingLoop = numberingLoop + ' <li class="page-item active" aria-current="page"><a style="padding-top:24px;padding-right:12px;"class="page-link" onclick="GetPageData(' + PageNumberArray[i] + ')" href="/ProfileAccount/AccountProfileHome/Advisors#">' + PageNumberArray[i] + ' &nbsp;&nbsp;</a></li>'
                } else {
                    numberingLoop = numberingLoop + ' <li class="page-item" aria-current="page"><a style="padding-top:24px;padding-right:12px;"class="page-link" onclick="GetPageData(' + PageNumberArray[i] + ')" href="/ProfileAccount/AccountProfileHome/Advisors#">' + PageNumberArray[i] + ' &nbsp;&nbsp;</a></li>'
                }
                numberingLoop;
            }
            template = template + numberingLoop + '<li class="page-item next"><a class="page-link" href="/ProfileAccount/AccountProfileHome/Advisors#" rel="next" aria-label="Next &raquo;" onclick="GetPageData(' + ForwardOne + ')">التالي</a></li>';
            $("#paged").append(template);

        }

