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
        controls.notifications.addEventListener("click", function () {
            window.location.href = "/notifications/"
        });
        controls.friends.addEventListener("click", function () {
            window.location.href = "/friends/"
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
            locations: document.getElementById("Locations"),
            notifications: document.getElementById("Notifications"),
            friends: document.getElementById("Friends")
        };
    }

    _init();
})();