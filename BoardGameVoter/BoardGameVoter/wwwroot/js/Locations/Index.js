"use strict";
(function () {

    $(document).ready(function () {
        var locations = $('#locationsDatatable').dataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": "/api/locations",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
            "columns": [
                { "data": "id", "name": "Id", "autoWidth": true },
                { "data": "name", "name": "Name", "autoWidth": true },
                { "data": "address", "name": "Address", "autoWidth": true },
                { "data": "postcode", "name": "Postcode", "autoWidth": true },
                { "data": "cost", "name": "Cost", "autoWidth": true }
            ],
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