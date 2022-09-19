"use strict";
(function () {

    $(document).ready(function () {
        var locations = $('#locationsDatatable').dataTable({
            "processing": true,
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
            "searching": false,
            "ordering": false,
            "paging": true
        });
    });

    var controls;

    function _bindEvents() {
        controls.add.addEventListener("click", function () {
            window.location.href = "/locations/add"
        });

    }

    function _init() {

        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
            add: document.getElementById("Add")
        };
    }

    _init();
})();