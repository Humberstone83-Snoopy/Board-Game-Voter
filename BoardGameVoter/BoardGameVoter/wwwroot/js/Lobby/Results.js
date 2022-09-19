"use strict";
(function () {

    var controls;

    $(document).ready(function () {
        var resultTable = $('#ResultTable').dataTable({
            "processing": true,
            "filter": false,
            "paging": false
        });
    });

    function _bindEvents() {
    }

    function _init() {
        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
        }
    }
    _init();
})();