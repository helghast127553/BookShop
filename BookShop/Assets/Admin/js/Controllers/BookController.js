$(document).ready(function () {
    let user = {
        init: function () {
            this.registerEvent();
        },
        registerEvent: function () {
            $('#deleteUser').click(function (e) {
                e.preventDefault();
                let ID = $(this).data('id');
                $.ajax({
                    type: 'GET',
                    url: '/Admin/Book/Delete',
                    data: { "ID": ID },
                    dataType: 'json',
                    success: function (response) {
                        if (response == true) {
                            $('#row_' + ID).remove();
                        }
                    },
                })
            });
        }
    };
    user.init();
});