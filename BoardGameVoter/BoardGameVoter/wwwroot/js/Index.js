"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.library.addEventListener("click", function () {
            window.location.href = "/library/"
        });
        controls.locations.addEventListener("click", function () {
            window.location.href = "/locations/"
        });
        controls.organise.addEventListener("click", function () {
            window.location.href = "/lobby/"
        });
    }

    function _init() {

        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
            organise: document.getElementById("Organise"),
            library: document.getElementById("Library"),
            profile: document.getElementById("Profile"),
            settings: document.getElementById("Settings"),
            locations: document.getElementById("Locations")
        };
    }

    _init();
})();