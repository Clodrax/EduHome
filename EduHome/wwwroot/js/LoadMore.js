
let skip = 3;
let coursesCount = $("#loadMore").next().val()
$(document).on("click","#loadMore", function () {
    $.ajax({
        url: "/Courses/LoadMore/",
        type: "GET",
        data: {
            "skip" : skip
        },
        success: function (response) {
            $("#myCourses").append(response)
            skip += 3;
            if (coursesCount <= skip) {
                $("#loadMore").remove()
            }
        }
    });
});