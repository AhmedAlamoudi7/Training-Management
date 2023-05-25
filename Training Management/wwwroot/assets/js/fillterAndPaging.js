$(document).ready(function () {
    //Initially load pagenumber=1
    GetPageData(1);
});
function GetPageData(pageNum, pageSize) {
    //After every trigger remove previous data and paging
    $("#blogList").empty();
    $("#paged").empty();
    $.getJSON("/Home/BlogList", { pageNumber: pageNum, pageSize: pageSize }, function (response) {
        var rowData = "";
        for (var i = 0; i < response.data.length; i++) {
            rowData = rowData + '<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 mb-60">\
                        <div class="blog-item">\
                        <div class="blog-thumb">\
                        <img src="data:image/png;base64,'+ response.data[i].imageCover + '" alt = "blog" >\
                        </div>\
                            <div class="blog-content">\
                        <h3 class="title">\
                            <a href="/Home/BlogDetailes/'+ response.data[i].id + '">' + response.data[i].title + ' </a>\
                            </h3>\
                            <div class="blog-post-meta">\
                        <span class="user"> '+ response.data[i].writtenBy + ' </span>\
                            <span class="date"> '+ response.data[i].date + ' </span>\
                                </div>\
                                </div>\
                                </div>\
                                </div>';
        }
        $("#blogList").append(rowData);
        PaggingTemplate(response.totalPages, response.currentPage);
    });
   

        
    
}
//specieal Fillter
function theFunction(specialId,pageNum, pageSize) {
    $("#blogList").empty();
    $("#paged").empty();
    $.getJSON("/Home/BlogList?specialId=" + specialId, { pageNumber: pageNum, pageSize: pageSize }, function (response) {
        var rowData = "";
        for (var i = 0; i < response.data.length; i++) {
            rowData = rowData + '<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 mb-60">\
                        <div class="blog-item">\
                        <div class="blog-thumb">\
                        <img src="data:image/png;base64,'+ response.data[i].imageCover + '" alt = "blog" >\
                        </div>\
                            <div class="blog-content">\
                        <h3 class="title">\
                            <a href="/Home/BlogDetailes/'+ response.data[i].id + '">' + response.data[i].title + ' </a>\
                            </h3>\
                            <div class="blog-post-meta">\
                        <span class="user"> '+ response.data[i].writtenBy + ' </span>\
                            <span class="date"> '+ response.data[i].date + ' </span>\
                                </div>\
                                </div>\
                                </div>\
                                </div>';
        }
        $("#blogList").append(rowData);
        PaggingTemplate(response.totalPages, response.currentPage);
    });




}
//    $.get('/Home/BlogList?GeneralSearch=' + $('#kt_filter_search').val(),

$("#kt_filter_search").keyup(function () {
    $("#blogList").empty();
    $("#paged").empty();
    $.getJSON("/Home/BlogList?GeneralSearch=" +$('#kt_filter_search').val(), function (response) {
        var rowData = "";
        for (var i = 0; i < response.data.length; i++) {
            rowData = rowData + '<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 mb-60">\
                        <div class="blog-item">\
                        <div class="blog-thumb">\
                        <img src="data:image/png;base64,'+ response.data[i].imageCover + '" alt = "blog" >\
                        </div>\
                            <div class="blog-content">\
                        <h3 class="title">\
                            <a href="/Home/BlogDetailes/'+ response.data[i].id + '">' + response.data[i].title + ' </a>\
                            </h3>\
                            <div class="blog-post-meta">\
                        <span class="user"> '+ response.data[i].writtenBy + ' </span>\
                            <span class="date"> '+ response.data[i].date + ' </span>\
                                </div>\
                                </div>\
                                </div>\
                                </div>';
        }
        $("#blogList").append(rowData);
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
        '<li class="page-item prev"><a href="#" class="page-link" href="#" rel="prev" aria-label="Prev &raquo;" onclick="GetPageData(' + BackwardOne + ')">السابق</a></li>';

    var numberingLoop = "";
    if (PageNumberArray.length == 0) {
        numberingLoop = numberingLoop + '<div class="alert alert-warning" role="alert">لا يوجد نتائج !</div> ';
    }
    for (var i = 0; i < PageNumberArray.length; i++) {
       
  
            if (PageNumberArray[i] == CurrentPage) {
                numberingLoop = numberingLoop + ' <li class="page-item active" aria-current="page"><a class="page-link" onclick="GetPageData(' + PageNumberArray[i] + ')" href="#">' + PageNumberArray[i] + ' &nbsp;&nbsp;</a></li>'
            } else {
                numberingLoop = numberingLoop + ' <li class="page-item" aria-current="page"><a class="page-link" onclick="GetPageData(' + PageNumberArray[i] + ')" href="#">' + PageNumberArray[i] + ' &nbsp;&nbsp;</a></li>'      
        }
        numberingLoop;
        }
    template = template + numberingLoop + '<li class="page-item next"><a class="page-link" href="#" rel="next" aria-label="Next &raquo;" onclick="GetPageData(' + ForwardOne + ')">التالي</a></li>';
    $("#paged").append(template);

}

