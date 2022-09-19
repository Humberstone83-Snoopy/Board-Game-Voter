"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.clear.addEventListener("click", function () {
            _clear();
        });
        controls.cancel.addEventListener("click", function (event) {
            _redirect(event);
        });
    }

    function _clear() {
        controls.name.value = "";
        controls.address1.value = "";
        controls.address2.value = "";
        controls.address3.value = "";
        controls.postcode.value = "";
        controls.cost.value = 0;
    }

    function _init() {

        _setUpControls();
        _bindEvents();

        if (controls.action.value == "REDIRECT") {
            _redirect();
        }
    }

    function _redirect(event) {
        if (event) {
            event.preventDefault();
        }
        window.location.href = "/locations";
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            clear: document.getElementById("Clear"),
            name: document.getElementById("NameInput"),
            address1: document.getElementById("Address1Input"),
            address2: document.getElementById("Address2Input"),
            address3: document.getElementById("Address3Input"),
            postcode: document.getElementById("PostcodeInput"),
            cost: document.getElementById("CostInput"),
            cancel: document.getElementById("Cancel")
        };
    }

    _init();
})();