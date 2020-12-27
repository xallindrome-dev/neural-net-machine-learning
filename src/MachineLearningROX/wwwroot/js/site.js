// Write your Javascript code.
(function () {
    $(document).ready(function () {
        $.support.cors = true;

        $(".data").on("click", function () {
            $.get("http://localhost:56033/api/values", function (data) {
                var i = data;
            });
        });
    });
})();
