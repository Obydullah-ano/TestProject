function DetailsRecord(StudentId) {
    $.ajax({
        url: "/Student/Details?StudentId=" + StudentId,
        type: 'GET',
        data: "",
        contentType: 'application/json: charset=utf-8',
        success: function (data) {
            $('#partialDiv').show();
            $('#partialDiv').html(data);

        },
        error: function (error) {
            alert(error)
        }
    })
}