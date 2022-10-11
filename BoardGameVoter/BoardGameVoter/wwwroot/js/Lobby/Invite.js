"use strict";
(function () {

    var controls;

    $(document).ready(function () {
        var table = $('#InviteTable').dataTable({
            filter: true,
            dom: 'Bfrtip',
            select: {
                style: 'single'
            },
            columnDefs: [
                {
                    targets: [0],
                    visible: false,
                    searchable: false
                },
            ],
            buttons: [
                {
                    text: 'Add Users',
                    action: function () {
                        controls.action.value = "ADD";
                        controls.form.submit();
                    }
                }
            ],
            language: {
                emptyTable: 'No Friends found by that name'
            }
        });

        $('#InviteTable tbody').on('click', 'tr', function () {
            var aPos = table.fnGetPosition(this);
            var aData = table.fnGetData(aPos[0]);
            if (controls.user.value != aData[aPos][0]) {
                controls.user.value = aData[aPos][0];
            }
            else {
                controls.user.value = '';
            }
            
        });
    });

    function _init() {
        _setUpControls();
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            form: document.getElementById("InviteForm"),
            user: document.getElementById("User_UID")
        };
    }

    _init();
})();