"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.cancel.addEventListener("click", function (event) {
            event.preventDefault();
            window.location.href = "/lobby";
        });
    }

    function _init() {
        _setUpControls();
        _bindEvents();
        if (controls.action.value == "COMPLETE") {
            window.location.href = "/lobby/invite/" + controls.voteSessionUID.value;
        }
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            voteSessionUID: document.getElementById("VoteSessionUID"),
            cancel: document.getElementById("Cancel")
        };
    }

    _init();
})();