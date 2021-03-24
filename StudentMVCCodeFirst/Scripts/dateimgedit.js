$(document).ready(function () {
    $("#DateOfBirth").datepicker({
        changeMonth: true,
        changeYear: true
    });
})
$(function () {
    $('.changeImage').change(function () {
        var input = this;
        if (input.files) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $(".change_edit").attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0])
        }
        else {
            $(".change_edit").attr('src', '/Images/@Model.ImageUrl');
        }
    })
})
