"use strict";
(function () {

    var controls;

    $(document).ready(function () {
        var publicLobbyTable = $('#PublicLobbyTable').dataTable({
            "processing": true,
            "filter": true,
            "columnDefs": [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": [6],
                    "sortable": false,
                    "searchable": false
                }
            ]
        });
    });

    function _bindEvents() {
    }

    function _init() {
        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
    }

    _init();
})();