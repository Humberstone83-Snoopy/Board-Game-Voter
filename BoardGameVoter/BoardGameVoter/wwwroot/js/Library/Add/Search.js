"use strict";
(function () {

    $(document).ready(function () {
        var boardGameSearch = $('#BoardGameSearchTable').dataTable({
            "processing": true,
            "filter": true,
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }]
        });
    });

    function _init() {
    }

    _init();
})();