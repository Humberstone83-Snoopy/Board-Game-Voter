"use strict";
(function () {

    $(document).ready(function () {
        var userLibrary = $('#userLibraryDatatable').dataTable({
            "processing": true,
            "serverSide": true,
            "filter": true,
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }]
        });
    });

    var controls;

    function _bindEvents() {
        controls.add.addEventListener("click", function () {
            window.location.href = "/library/add"
        });

    }

    function _init() {

        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
            mygames: document.getElementById("MyGames"),
            add: document.getElementById("Add")
        };
    }

    _init();
})();